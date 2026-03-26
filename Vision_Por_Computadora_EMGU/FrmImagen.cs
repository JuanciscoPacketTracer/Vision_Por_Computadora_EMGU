using Emgu.CV;
using Emgu.CV.CvEnum;
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
    public partial class FrmImagen : Form
    {
        Mat _imagenOriginal;
        Mat _imagenActual;
        List<Rectangle> faces = [];
        List<Rectangle> eyes = [];
        CascadeClassifier face;
        CascadeClassifier eye;
        CascadeClassifier eyeWithGlasses;
        readonly List<string> _imagenes = [];
        int _indiceImagenActual = -1;

        private void AplicarEstilo()
        {
            this.BackColor = Estilos.Fondo;
            this.StartPosition = FormStartPosition.CenterScreen;
            Estilos.EstilizarLabel(LblInfo, esTitulo: false);
            Estilos.EstilizarLabel(LblInfo2, esTitulo: false);
            Estilos.EstilizarBoton(BtnCargar, "🖼️ Cargar Desde Archivo");
            Estilos.EstilizarBoton(BtnGrises, "⬜ BGR a Grises");
            Estilos.EstilizarBoton(BtnHSV, "⬜ BGR a HSV");
            Estilos.EstilizarBoton(BtnYCrCb, "⬜ BGR a YCrCb");
            Estilos.EstilizarBoton(BtnBGR, "🔁 Revertir a BGR");
            Estilos.EstilizarBoton(BtnCerrar, "❌ Cerrar", esPeligro: true);
            Estilos.EstilizarBoton(BtnReconocer, "👤 Reconocer Rostro");
            Estilos.EstilizarImageBoxProcesado(IBImagen);
            Estilos.EstilizarImageBoxProcesado(IBRostro);
            Estilos.EstilizarTextBoxConPlaceholder(TbPath, "Ruta de la imagen...");
            Estilos.EstilizarBoton(BtnPrev, "◀️");
            Estilos.EstilizarBoton(BtnNext, "▶️");
            Estilos.EstilizarLabel(LblImg, false);
        }
        public FrmImagen()
        {
            InitializeComponent();
            AplicarEstilo();
        }
        private void MostrarInformacion()
        {
            if (_imagenActual == null) return;
            LblInfo.Text = string.Format(
                "Filas de pixeles: {0} Columnas de pixeles: {1} Canales de color: {2}",
                _imagenActual.Rows,
                _imagenActual.Cols,
                _imagenActual.NumberOfChannels);
        }
        private void ActualizarVista()
        {
            if (_imagenActual == null) return;

            IBImagen.Image = _imagenActual;
            MostrarInformacion();
        }
        private void CargarImagenDesdeRuta(string ruta)
        {
            _imagenOriginal = CvInvoke.Imread(ruta, ImreadModes.ColorBgr);
            _imagenActual = _imagenOriginal.Clone();
            IBImagen.Image = _imagenActual;
            IBRostro.Image = _imagenActual;
            IBRostro.Visible = false;
            TbPath.Text = ruta;
            LblImg.Text = $"{Path.GetFileName(ruta)} ({_indiceImagenActual + 1}/{_imagenes.Count})";
            MostrarInformacion();
            BtnReconocer.Visible = true;
        }

        private void CargarImagenPorIndice(int indice)
        {
            if (_imagenes.Count == 0) return;
            if (indice < 0 || indice >= _imagenes.Count) return;

            _indiceImagenActual = indice;
            CargarImagenDesdeRuta(_imagenes[_indiceImagenActual]);
        }

        private void BtnCargar_Click(object sender, EventArgs e)
        {
            using OpenFileDialog ofd = new();
            ofd.Title = "Selecciona una imagen";
            ofd.Filter = "Image Files | *.jpg;*.jpeg;*.png;*.bmp";
            ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                _indiceImagenActual = -1;
                CargarImagenDesdeRuta(ofd.FileName);
                LblImg.Text = Path.GetFileName(ofd.FileName);
            }
        }

        private void BtnGrises_Click(object sender, EventArgs e)
        {
            if (_imagenOriginal == null) return;
            Mat gray = new();
            CvInvoke.CvtColor(_imagenOriginal, gray, ColorConversion.Bgr2Gray);
            _imagenActual = gray;
            ActualizarVista();
        }

        private void BtnHSV_Click(object sender, EventArgs e)
        {
            if (_imagenActual == null) return;
            _imagenActual = _imagenOriginal.Clone();
            Mat hsv = new();
            CvInvoke.CvtColor(_imagenActual, hsv, ColorConversion.Bgr2Hsv);
            _imagenActual = hsv;
            ActualizarVista();
        }

        private void BtnYCrCb_Click(object sender, EventArgs e)
        {
            if (_imagenActual == null) return;
            _imagenActual = _imagenOriginal.Clone();
            Mat ycrcb = new();
            CvInvoke.CvtColor(_imagenActual, ycrcb, ColorConversion.Bgr2YCrCb);
            _imagenActual = ycrcb;
            ActualizarVista();
        }

        private void BtnBGR_Click(object sender, EventArgs e)
        {
            if (_imagenOriginal == null) return;
            _imagenActual = _imagenOriginal.Clone();
            ActualizarVista();
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            var img = IBImagen.Image;
            IBImagen.Image = null;
            img?.Dispose();
            this.Close();
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

        private void InitializeCascadeClassifiers()
        {
            try
            {
                string facePath = GetCascadePath("haarcascade_frontalface_alt.xml");
                string eyePath = GetCascadePath("haarcascade_eye.xml");
                string eyeGlassesPath = GetCascadePath("haarcascade_eye_tree_eyeglasses.xml");

                if (!File.Exists(facePath))
                {
                    MessageBox.Show($"Archivo no encontrado: {facePath}\n\nPor favor, descarga haarcascade_frontalface_alt.xml desde:\nhttps://github.com/opencv/opencv/tree/master/data/haarcascades\ny colócalo en la carpeta 'data' del proyecto.",
                        "Error de configuración", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!File.Exists(eyePath))
                {
                    MessageBox.Show($"Archivo no encontrado: {eyePath}\n\nPor favor, descarga haarcascade_eye.xml desde:\nhttps://github.com/opencv/opencv/tree/master/data/haarcascades\ny colócalo en la carpeta 'data' del proyecto.",
                        "Error de configuración", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!File.Exists(eyeGlassesPath))
                {
                    MessageBox.Show($"Archivo no encontrado: {eyeGlassesPath}\n\nPor favor, descarga haarcascade_eye_tree_eyeglasses.xml desde:\nhttps://github.com/opencv/opencv/tree/master/data/haarcascades\ny colócalo en la carpeta 'data' del proyecto.",
                        "Error de configuración", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                face = new CascadeClassifier(facePath);
                eye = new CascadeClassifier(eyePath);
                eyeWithGlasses = new CascadeClassifier(eyeGlassesPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al inicializar clasificadores: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmImagen_Load(object sender, EventArgs e)
        {
            InitializeCascadeClassifiers();
            IBRostro.Visible = false;
            BtnReconocer.Visible = false;

            const string rutaFotos = @"C:\FOTOS";
            _imagenes.Clear();

            if (Directory.Exists(rutaFotos))
            {
                _imagenes.AddRange(Directory.GetFiles(rutaFotos, "*.JPG"));
                _imagenes.Sort(StringComparer.OrdinalIgnoreCase);
            }

            if (_imagenes.Count > 0)
            {
                CargarImagenPorIndice(0);
                BtnPrev.Enabled = true;
                BtnNext.Enabled = true;
            }
            else
            {
                LblImg.Text = "Sin imágenes en C:\\FOTOS";
                BtnPrev.Enabled = false;
                BtnNext.Enabled = false;
            }
        }
        private void BtnReconocer_Click(object sender, EventArgs e)
        {
            if (_imagenOriginal == null)
            {
                MessageBox.Show("Por favor, carga una imagen primero.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (face == null || eye == null || eyeWithGlasses == null)
            {
                MessageBox.Show("No se pudieron inicializar los clasificadores. Verifica los archivos XML en la carpeta data.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int totalEyes = 0;
                int peopleWithGlasses = 0;

                Mat grayImage = new();
                if (_imagenOriginal.NumberOfChannels == 3)
                {
                    CvInvoke.CvtColor(_imagenOriginal, grayImage, ColorConversion.Bgr2Gray);
                }
                else
                {
                    grayImage = _imagenOriginal.Clone();
                }

                faces = [.. face.DetectMultiScale(grayImage, 1.2, 10)];
                Mat resultImage = _imagenOriginal.Clone();
                foreach (Rectangle faceRect in faces)
                {
                    CvInvoke.Rectangle(resultImage, faceRect, new Emgu.CV.Structure.MCvScalar(255, 0, 0), 2);
                    using Mat faceROI = new(grayImage, faceRect);

                    Rectangle[] eyesNormal = eye.DetectMultiScale(faceROI, 1.2, 10);
                    Rectangle[] eyesGlasses = eyeWithGlasses.DetectMultiScale(faceROI, 1.1, 8);

                    bool hasGlasses = eyesGlasses.Length > 0;
                    if (hasGlasses) peopleWithGlasses++;

                    Rectangle[] eyesToDraw = eyesNormal.Length >= eyesGlasses.Length ? eyesNormal : eyesGlasses;
                    eyes = [.. eyesToDraw];
                    totalEyes += eyesToDraw.Length;

                    foreach (Rectangle eyeRect in eyesToDraw)
                    {
                        Rectangle adjustedEyeRect = new(
                            faceRect.X + eyeRect.X,
                            faceRect.Y + eyeRect.Y,
                            eyeRect.Width,
                            eyeRect.Height);
                        CvInvoke.Rectangle(resultImage, adjustedEyeRect, new Emgu.CV.Structure.MCvScalar(0, 255, 0), 2);
                    }
                }
                IBRostro.Visible = true;
                IBRostro.Image = resultImage;
                LblInfo2.Text = $"Rostros detectados: {faces.Count} | Ojos detectados: {totalEyes}";
                grayImage.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error durante el reconocimiento de rostros: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnPrev_Click(object sender, EventArgs e)
        {
            if (_imagenes.Count == 0) return;
            int nuevoIndice = _indiceImagenActual <= 0 ? _imagenes.Count - 1 : _indiceImagenActual - 1;
            CargarImagenPorIndice(nuevoIndice);
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            if (_imagenes.Count == 0) return;
            int nuevoIndice = _indiceImagenActual >= _imagenes.Count - 1 ? 0 : _indiceImagenActual + 1;
            CargarImagenPorIndice(nuevoIndice);
        }
    }
}
