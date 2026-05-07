using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Vision_Por_Computadora_EMGU
{
    public partial class FrmReconoce2 : Form
    {
        public FrmReconoce2()
        {
            InitializeComponent();
        }

        // Image variables
        private Mat? _imagenOriginal;
        private Mat? _imagenActual;

        // Webcam variables
        private VideoCapture? captureVideo;
        private Thread? captureThread;
        private volatile bool _running = false;

        // Video playback variables
        private VideoCapture? _videoCapture;
        private Thread? _videoThread;
        private volatile bool _videoPlaybackRunning = false;

        // Synchronization
        private readonly object _paramsLock = new();
        private readonly object _imgLock = new();
        private readonly object _facesLock = new();

        // Image processing parameters
        private int _brightness = 0;
        private double _contrast = 1.0;
        private double _sharpness = 0.0;
        private bool _flipHorizontal = false;
        private bool _flipVertical = false;
        private bool _faceRecognitionEnabled = false;

        // Face recognition variables
        private CascadeClassifier? _faceCascade;
        private CascadeClassifier? _eyeCascade;
        private List<Mat> _detectedFaces = new();
        private int _currentFaceIndex = 0;
        private DateTime _lastFaceUpdate = DateTime.MinValue;
        private DateTime _lastNavigationTime = DateTime.MinValue;

        private void CargarImagenDesdeRuta(string ruta)
        {
            try
            {
                StopWebCam();
                StopVideoPlayback();
                ClearImageBoxes();
                ClearDetectedFaces();

                _imagenOriginal?.Dispose();
                _imagenActual?.Dispose();

                _imagenOriginal = CvInvoke.Imread(ruta, ImreadModes.ColorBgr);
                if (_imagenOriginal == null || _imagenOriginal.IsEmpty)
                {
                    MessageBox.Show("No se pudo cargar la imagen.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                _imagenActual = _imagenOriginal.Clone();
                IBMedia.Image = _imagenActual;

                DetectFacesInImage(_imagenOriginal);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar imagen: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnFoto_Click(object sender, EventArgs e)
        {
            using OpenFileDialog ofd = new();
            ofd.Title = "Selecciona una imagen";
            ofd.Filter = "Image Files | *.jpg;*.jpeg;*.png;*.bmp";
            ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                CargarImagenDesdeRuta(ofd.FileName);
            }
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmReconoce2_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopWebCam();
            StopVideoPlayback();
            ClearImageBoxes();
            ClearDetectedFaces();

            _imagenOriginal?.Dispose();
            _imagenActual?.Dispose();
        }

        private void ClearImageBoxes()
        {
            lock (_imgLock)
            {
                try
                {
                    if (IBMedia.Image is Mat matMedia)
                    {
                        matMedia.Dispose();
                    }
                    IBMedia.Image = null;

                    if (IBRostro != null && IBRostro.Image is Mat matFace)
                    {
                        matFace.Dispose();
                    }
                    if (IBRostro != null)
                    {
                        IBRostro.Image = null;
                    }
                }
                catch { }
            }
        }

        private void ClearDetectedFaces()
        {
            lock (_facesLock)
            {
                foreach (var face in _detectedFaces)
                {
                    face?.Dispose();
                }
                _detectedFaces.Clear();
                _currentFaceIndex = 0;
            }

            UpdateFaceNavigationUI();
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

        private void DetectFacesInImage(Mat image)
        {
            if (image == null || image.IsEmpty) return;

            try
            {
                if (!EnsureFaceCascadeLoaded()) return;

                using Mat gray = new();
                CvInvoke.CvtColor(image, gray, ColorConversion.Bgr2Gray);
                CvInvoke.EqualizeHist(gray, gray);

                Rectangle[] faces = _faceCascade!.DetectMultiScale(gray, 1.1, 6, new Size(60, 60));

                lock (_facesLock)
                {
                    _detectedFaces.Clear();
                    _currentFaceIndex = 0;

                    if (faces.Length == 0)
                    {
                        MessageBox.Show("No se detectaron rostros en la imagen.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        UpdateFaceNavigationUI();
                        return;
                    }

                    foreach (var faceRect in faces)
                    {
                        using Mat faceRoi = new(image, faceRect);
                        Mat faceCopy = faceRoi.Clone();
                        _detectedFaces.Add(faceCopy);
                    }
                }

                UpdateFaceNavigationUI();
                DisplayCurrentFace();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al detectar rostros: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayCurrentFace()
        {
            lock (_facesLock)
            {
                if (_detectedFaces.Count == 0) return;

                try
                {
                    Mat? clonedFace = _detectedFaces[_currentFaceIndex].Clone();

                    if (IBRostro != null && IBRostro.IsHandleCreated)
                    {
                        IBRostro.BeginInvoke((MethodInvoker)delegate
                        {
                            lock (_imgLock)
                            {
                                if (IBRostro.Image is Mat oldMat)
                                {
                                    oldMat.Dispose();
                                }
                                IBRostro.Image = clonedFace;
                            }
                        });
                    }
                    else
                    {
                        clonedFace?.Dispose();
                    }
                }
                catch { }
            }
        }

        private void UpdateFaceNavigationUI()
        {
            if (!IsHandleCreated) return;

            int faceCount = 0;
            int currentIndex = 0;

            lock (_facesLock)
            {
                faceCount = _detectedFaces.Count;
                currentIndex = _currentFaceIndex;
            }

            if (InvokeRequired)
            {
                BeginInvoke((MethodInvoker)delegate
                {
                    UpdateNavigationButtons(faceCount, currentIndex);
                });
            }
            else
            {
                UpdateNavigationButtons(faceCount, currentIndex);
            }
        }

        private void UpdateNavigationButtons(int faceCount, int currentIndex)
        {
            if (BtnLeft != null)
            {
                BtnLeft.Enabled = currentIndex > 0;
            }
            if (BtnRight != null)
            {
                BtnRight.Enabled = currentIndex < faceCount - 1;
            }
        }

        private void BtnLeft_Click(object sender, EventArgs e)
        {
            _lastNavigationTime = DateTime.Now;
            lock (_facesLock)
            {
                if (_currentFaceIndex > 0)
                {
                    _currentFaceIndex--;
                }
            }

            DisplayCurrentFace();
            UpdateFaceNavigationUI();
        }

        private void BtnRight_Click(object sender, EventArgs e)
        {
            _lastNavigationTime = DateTime.Now;
            lock (_facesLock)
            {
                if (_currentFaceIndex < _detectedFaces.Count - 1)
                {
                    _currentFaceIndex++;
                }
            }

            DisplayCurrentFace();
            UpdateFaceNavigationUI();
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
                        Mat flipTarget = adjusted;

                        int passes = (int)Math.Round(n * 3.0);
                        for (int i = 0; i < passes; i++)
                            CvInvoke.Filter2D(flipTarget, flipTarget, kernelSharpen, new Point(-1, -1));

                        CvInvoke.Resize(flipTarget, resized, IBMedia.Size);

                        if (detectFaces && _faceCascade != null && _eyeCascade != null)
                        {
                            DetectAndDrawFaces(resized);
                        }

                        Mat displayMat = resized.Clone();

                        if (IBMedia.IsHandleCreated)
                        {
                            IBMedia.BeginInvoke((MethodInvoker)delegate
                            {
                                lock (_imgLock)
                                {
                                    var old = IBMedia.Image;
                                    IBMedia.Image = displayMat;
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

        private void DetectAndDrawFaces(Mat image)
        {
            if (_faceCascade == null) return;

            try
            {
                using Mat gray = new();
                CvInvoke.CvtColor(image, gray, ColorConversion.Bgr2Gray);
                CvInvoke.EqualizeHist(gray, gray);

                Rectangle[] faces = _faceCascade.DetectMultiScale(gray, 1.1, 6, new Size(60, 60));

                bool userIsNavigating = (DateTime.Now - _lastNavigationTime).TotalSeconds < 5.0;
                bool shouldUpdateList = !userIsNavigating && (DateTime.Now - _lastFaceUpdate).TotalMilliseconds > 1000;

                List<Mat> newFaces = new();
                if (shouldUpdateList)
                {
                    _lastFaceUpdate = DateTime.Now;
                    foreach (var faceRect in faces)
                    {
                        using Mat faceRoi = new(image, faceRect);
                        newFaces.Add(faceRoi.Clone());
                    }
                }

                // Siempre dibujar los cuadros de las caras y ojos en el video
                foreach (var faceRect in faces)
                {
                    CvInvoke.Rectangle(image, faceRect, new MCvScalar(255, 0, 0), 2);

                    if (_eyeCascade != null)
                    {
                        using Mat faceRoi = new(gray, faceRect);
                        Rectangle[] eyes = _eyeCascade.DetectMultiScale(faceRoi, 1.1, 8, new Size(18, 18));
                        foreach (var eyeRect in eyes)
                        {
                            Rectangle adjustedEyeRect = new(
                                faceRect.X + eyeRect.X,
                                faceRect.Y + eyeRect.Y,
                                eyeRect.Width,
                                eyeRect.Height);
                            CvInvoke.Rectangle(image, adjustedEyeRect, new MCvScalar(0, 255, 0), 2);
                        }
                    }
                }

                // Solo actualizar la lista visible de caras extraídas si ha pasado el tiempo adecuado
                if (shouldUpdateList)
                {
                    lock (_facesLock)
                    {
                        foreach (var f in _detectedFaces)
                        {
                            f?.Dispose();
                        }
                        _detectedFaces.Clear();
                        _detectedFaces.AddRange(newFaces);

                        if (_currentFaceIndex >= _detectedFaces.Count)
                        {
                            _currentFaceIndex = Math.Max(0, _detectedFaces.Count - 1);
                        }
                    }

                    if (_detectedFaces.Count > 0)
                    {
                        DisplayCurrentFace();
                    }
                    else
                    {
                        if (IBRostro != null && IBRostro.IsHandleCreated)
                        {
                            IBRostro.BeginInvoke((MethodInvoker)delegate
                            {
                                lock (_imgLock)
                                {
                                    if (IBRostro.Image is Mat oldMat)
                                    {
                                        oldMat.Dispose();
                                    }
                                    IBRostro.Image = null;
                                }
                            });
                        }
                    }

                    UpdateFaceNavigationUI();
                }
            }
            catch { }
        }

        private void StopWebCam()
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
        }

        private void frmVideoImagen_Load(object sender, EventArgs e)
        {
        }

        private void StopVideoPlayback()
        {
            _videoPlaybackRunning = false;

            if (_videoThread != null)
            {
                try { _videoThread.Join(500); }
                catch { }
                _videoThread = null;
            }

            if (_videoCapture != null)
            {
                try { _videoCapture.Dispose(); }
                catch { }
                _videoCapture = null;
            }
        }

        private void DisplayWebCam2()
        {
            while (_videoPlaybackRunning && _videoCapture != null && _videoCapture.IsOpened)
            {
                try
                {
                    using (Mat frame = _videoCapture.QueryFrame())
                    {
                        if (frame == null || frame.IsEmpty)
                        {
                            break;
                        }

                        using (Mat resized = new())
                        {
                            CvInvoke.Resize(frame, resized, IBMedia.Size);

                            if (_faceCascade != null && _eyeCascade != null)
                            {
                                DetectAndDrawFaces(resized);
                            }

                            Mat displayMat = resized.Clone();

                            if (IBMedia.IsHandleCreated)
                            {
                                IBMedia.BeginInvoke((MethodInvoker)delegate
                                {
                                    lock (_imgLock)
                                    {
                                        var old = IBMedia.Image;
                                        IBMedia.Image = displayMat;
                                        if (old != null && old is Mat oldMat) oldMat.Dispose();
                                    }
                                });
                            }
                            else
                            {
                                displayMat?.Dispose();
                            }
                        }
                    }

                    Thread.Sleep(25);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error durante la reproducción: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
            }

            StopVideoPlayback();
        }

        private void BtnVideo_Click(object sender, EventArgs e)
        {
            if (_running) return;

            StopVideoPlayback();
            ClearImageBoxes();
            ClearDetectedFaces();

            if (!EnsureFaceCascadeLoaded()) return;

            captureVideo = new VideoCapture();
            if (!captureVideo.IsOpened)
            {
                MessageBox.Show("No se pudo abrir la cámara.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                captureVideo?.Dispose();
                captureVideo = null;
                return;
            }

            _running = true;
            _faceRecognitionEnabled = true;
            captureThread = new Thread(DisplayWebCam)
            {
                IsBackground = true
            };
            captureThread.Start();
        }
    }
}
