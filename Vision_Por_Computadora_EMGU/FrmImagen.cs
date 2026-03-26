using Emgu.CV;
using Emgu.CV.CvEnum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vision_Por_Computadora_EMGU
{
    public partial class FrmImagen : Form
    {
        Mat _imagenOriginal;
        Mat _imagenActual;
        private void AplicarEstilo()
        {
            this.BackColor = Estilos.Fondo;
            this.StartPosition = FormStartPosition.CenterScreen;
            Estilos.EstilizarLabel(LblInfo, esTitulo: false);
            Estilos.EstilizarBoton(BtnCargar, "🖼️ Cargar Imagen");
            Estilos.EstilizarBoton(BtnGrises, "⬜ BGR a Grises");
            Estilos.EstilizarBoton(BtnHSV, "⬜ BGR a HSV");
            Estilos.EstilizarBoton(BtnYCrCb, "⬜ BGR a YCrCb");
            Estilos.EstilizarBoton(BtnBGR, "🔁 Revertir a BGR");
            Estilos.EstilizarBoton(BtnCerrar, "❌ Cerrar", esPeligro: true);
            Estilos.EstilizarImageBoxProcesado(IBImagen);
            Estilos.EstilizarTextBoxConPlaceholder(TbPath, "Ruta de la imagen...");
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
        private void BtnCargar_Click(object sender, EventArgs e)
        {
            using OpenFileDialog ofd = new();
            ofd.Title = "Selecciona una imagen";
            ofd.Filter = "Image Files | *.jpg;*.jpeg;*.png;*.bmp";
            ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                _imagenOriginal = CvInvoke.Imread(ofd.FileName, ImreadModes.ColorBgr);
                _imagenActual = _imagenOriginal.Clone();
                IBImagen.Image = _imagenActual;
                MostrarInformacion();
                TbPath.Text = ofd.FileName;
                MostrarInformacion();
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

        private void FrmImagen_Load(object sender, EventArgs e)
        {

        }
    }
}
