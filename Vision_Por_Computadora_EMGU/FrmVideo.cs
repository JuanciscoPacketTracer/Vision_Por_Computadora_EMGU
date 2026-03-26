using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Vision_Por_Computadora_EMGU
{
    public partial class FrmVideo : Form
    {
        public FrmVideo()
        {
            InitializeComponent();
            AplicarEstilo();
        }
        private VideoCapture? captureVideo;
        private Thread? captureThread;
        private readonly object _paramsLock = new();
        private int _brightness = 0;
        private double _contrast = 1.0;
        private double _sharpness = 0.0;
        private volatile bool _running = false;
        private readonly object _imgLock = new();
        private bool _flipHorizontal = false;
        private bool _flipVertical = false;
        private bool _faceRecognitionEnabled = false;
        private CascadeClassifier? _faceCascade;
        private CascadeClassifier? _eyeCascade;
        readonly int brillo = 0;
        readonly double contraste = 1.0;
        readonly double nitidez = 0.0;

        private void AplicarEstilo()
        {
            this.BackColor = Estilos.Fondo;
            this.StartPosition = FormStartPosition.CenterScreen;
            Estilos.EstilizarLabel(LblValueBrillo, esTitulo: false);
            Estilos.EstilizarLabel(LblValueContraste, esTitulo: false);
            Estilos.EstilizarLabel(LblValueNitidez, esTitulo: false);
            Estilos.EstilizarLabel(label1, esTitulo: false);
            Estilos.EstilizarLabel(label4, esTitulo: false);
            Estilos.EstilizarLabel(label3, esTitulo: false);
            Estilos.EstilizarBoton(BtnCerrar, "❌ Cerrar", esPeligro: true);
            Estilos.EstilizarBoton(BtnCargar, "🎥 Cargar Video");
            Estilos.EstilizarBoton(BtnFlipH, "🔄 Flip Horizontal");
            Estilos.EstilizarBoton(BtnFlipV, "🔄 Flip Vertical");
            Estilos.EstilizarBoton(BtnReconocer, "👤 Reconocer Rostro");
            Estilos.EstilizarHScrollBar(SBContraste);
            Estilos.EstilizarHScrollBar(SBNitidez);
            Estilos.EstilizarHScrollBar(SBBrillo);
            Estilos.EstilizarRadioButtonComoBoton(RBGris);
            Estilos.EstilizarRadioButtonComoBoton(RBColor);
            Estilos.EstilizarImageBoxLive(IBVideo);
            Estilos.EstilizarGroupBox(GBVista);
        }
        private void DisplayWebCam()
        {
            ConvolutionKernelF kernelSharpen = new(new float[,]
    {
        { 0f, -1f,  0f },
        { -1f, 5f, -1f },
        { 0f, -1f,  0f }
    });

            while (_running && captureVideo != null)
            {
                try
                {
                    using (Mat frame = captureVideo.QueryFrame())
                    {
                        if (frame == null || frame.IsEmpty)
                        {
                            Thread.Sleep(10);
                            continue;
                        }

                        int b; double c; double n; bool flipH; bool flipV; bool detectFaces;
                        lock (_paramsLock)
                        {
                            b = _brightness;
                            c = _contrast;
                            n = _sharpness;
                            flipH = _flipHorizontal;
                            flipV = _flipVertical;
                            detectFaces = _faceRecognitionEnabled;
                        }

                        using Mat adjusted = new();
                        using Mat flipped = new();
                        using Mat resized = new();
                        frame.ConvertTo(adjusted, frame.Depth, c, b);

                        // Apply flip transformations
                        Mat flipTarget = adjusted;
                        if (flipH || flipV)
                        {
                            flipTarget = flipped;
                            if (flipH && flipV)
                            {
                                CvInvoke.Flip(adjusted, flipTarget, FlipType.Both);
                            }
                            else if (flipH)
                            {
                                CvInvoke.Flip(adjusted, flipTarget, FlipType.Horizontal);
                            }
                            else
                            {
                                CvInvoke.Flip(adjusted, flipTarget, FlipType.Vertical);
                            }
                        }

                        int passes = (int)Math.Round(n * 3.0); // 0..3
                        for (int i = 0; i < passes; i++)
                            CvInvoke.Filter2D(flipTarget, flipTarget, kernelSharpen, new Point(-1, -1));

                        if (detectFaces && _faceCascade != null && _eyeCascade != null)
                        {
                            using Mat gray = new();
                            CvInvoke.CvtColor(flipTarget, gray, ColorConversion.Bgr2Gray);
                            CvInvoke.EqualizeHist(gray, gray);

                            Rectangle[] faces = _faceCascade.DetectMultiScale(gray, 1.1, 6, new Size(60, 60));
                            foreach (var faceRect in faces)
                            {
                                CvInvoke.Rectangle(flipTarget, faceRect, new MCvScalar(255, 0, 0), 2);

                                using Mat faceRoi = new(gray, faceRect);
                                Rectangle[] eyes = _eyeCascade.DetectMultiScale(faceRoi, 1.1, 8, new Size(18, 18));
                                foreach (var eyeRect in eyes)
                                {
                                    Rectangle adjustedEyeRect = new(
                                        faceRect.X + eyeRect.X,
                                        faceRect.Y + eyeRect.Y,
                                        eyeRect.Width,
                                        eyeRect.Height);
                                    CvInvoke.Rectangle(flipTarget, adjustedEyeRect, new MCvScalar(0, 255, 0), 2);
                                }
                            }
                        }

                        CvInvoke.Resize(flipTarget, resized, IBVideo.Size);

                        Mat displayMat = null;
                        if (RBColor.Checked)
                        {
                            displayMat = resized.Clone();
                        }
                        else
                        {
                            displayMat = new Mat();
                            CvInvoke.CvtColor(resized, displayMat, ColorConversion.Bgr2Gray);
                        }

                        if (IBVideo.IsHandleCreated)
                        {
                            IBVideo.BeginInvoke((MethodInvoker)delegate
                            {
                                lock (_imgLock)
                                {
                                    var old = IBVideo.Image;
                                    IBVideo.Image = displayMat;
                                    if (old != null && old is Mat oldMat) oldMat.Dispose();
                                }
                            });
                        }
                        else
                        {
                            displayMat?.Dispose();
                        }
                    }

                    Thread.Sleep(30);
                }
                catch
                {
                    Thread.Sleep(50);
                }
            }
        }
        private void BtnCargar_Click(object sender, EventArgs e)
        {
            if (_running) return;
            captureVideo = new VideoCapture();

            if (!captureVideo.IsOpened)
            {
                MessageBox.Show("No se pudo abrir la cámara.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                captureVideo?.Dispose();
                captureVideo = null;
                return;
            }

            _running = true;
            captureThread = new Thread(DisplayWebCam)
            {
                IsBackground = true
            };
            captureThread.Start();
        }

        private void BtnFlipH_Click(object sender, EventArgs e)
        {
            if (captureVideo == null || !captureVideo.IsOpened)
            {
                MessageBox.Show("Por favor, carga un video primero.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            lock (_paramsLock)
            {
                _flipHorizontal = !_flipHorizontal;
            }
        }

        private void BtnFlipV_Click(object sender, EventArgs e)
        {
            if (captureVideo == null || !captureVideo.IsOpened)
            {
                MessageBox.Show("Por favor, carga un video primero.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            lock (_paramsLock)
            {
                _flipVertical = !_flipVertical;
            }
        }
        private void StopCapture()
        {
            _running = false;

            if (captureThread != null)
            {
                try { captureThread.Join(500); }
                catch { }
                captureThread = null;
            }

            if (captureVideo != null)
            {
                try { captureVideo.Dispose(); }
                catch { }
                captureVideo = null;
            }
            lock (_imgLock)
            {
                if (IBVideo.Image != null)
                {
                    try
                    {
                        if (IBVideo.Image is Mat mat)
                        {
                            mat.Dispose();
                        }
                        IBVideo.Image = null;
                    }
                    catch { }
                }
            }
        }
        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            StopCapture();
            this.Close();
        }

        private void SBBrillo_Scroll(object sender, ScrollEventArgs e)
        {
            int b = (SBBrillo.Value - 50) * 2;
            lock (_paramsLock) _brightness = b;

            LblValueBrillo.Text = SBBrillo.Value + "%";
        }

        private void SBContraste_Scroll(object sender, ScrollEventArgs e)
        {
            double c = SBContraste.Value / 50.0;
            lock (_paramsLock) _contrast = c;

            LblValueContraste.Text = SBContraste.Value + "%";
        }

        private void SBNitidez_Scroll(object sender, ScrollEventArgs e)
        {
            double n = SBNitidez.Value / 100.0;
            lock (_paramsLock) _sharpness = n;
            LblValueNitidez.Text = SBNitidez.Value + "%";
        }

        private void FrmVideo_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void FrmVideo_Load(object sender, EventArgs e)
        {
            RBColor.Checked = true;
        }

        private static string GetCascadePath(string fileName)
        {
            string[] possiblePaths =
            [
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName),
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data", fileName),
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "data", fileName),
            ];

            foreach (var path in possiblePaths)
            {
                string fullPath = Path.GetFullPath(path);
                if (File.Exists(fullPath))
                {
                    return fullPath;
                }
            }

            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data", fileName);
        }

        private bool EnsureFaceCascadeLoaded()
        {
            if (_faceCascade != null && _eyeCascade != null) return true;

            string facePath = GetCascadePath("haarcascade_frontalface_alt.xml");
            string eyePath = GetCascadePath("haarcascade_eye.xml");

            if (!File.Exists(facePath))
            {
                MessageBox.Show($"Archivo no encontrado: {facePath}\n\nPor favor, descarga haarcascade_frontalface_alt.xml desde:\nhttps://github.com/opencv/opencv/tree/master/data/haarcascades\ny colócalo en la carpeta 'data' del proyecto.",
                    "Error de configuración", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!File.Exists(eyePath))
            {
                MessageBox.Show($"Archivo no encontrado: {eyePath}\n\nPor favor, descarga haarcascade_eye.xml desde:\nhttps://github.com/opencv/opencv/tree/master/data/haarcascades\ny colócalo en la carpeta 'data' del proyecto.",
                    "Error de configuración", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            try
            {
                _faceCascade ??= new CascadeClassifier(facePath);
                _eyeCascade ??= new CascadeClassifier(eyePath);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al inicializar clasificadores: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void BtnReconocer_Click(object sender, EventArgs e)
        {
            if (captureVideo == null || !captureVideo.IsOpened || !_running)
            {
                MessageBox.Show("Por favor, carga un video primero.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            lock (_paramsLock)
            {
                if (!_faceRecognitionEnabled)
                {
                    if (!EnsureFaceCascadeLoaded()) return;
                    _faceRecognitionEnabled = true;
                    BtnReconocer.Text = "🛑 Detener Reconocimiento";
                }
                else
                {
                    _faceRecognitionEnabled = false;
                    BtnReconocer.Text = "👤 Reconocer Rostro";
                }
            }
        }
    }
}
