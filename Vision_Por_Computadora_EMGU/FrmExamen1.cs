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
    public partial class frmExamen1 : Form
    {
        private string _rutaImagenActual = "";

        public frmExamen1()
        {
            InitializeComponent();
        }
        private void btnCargar_Click(object sender, EventArgs e)
        {
            using OpenFileDialog ofd = new();
            ofd.Title = "Selecciona una imagen";
            ofd.Filter = "Image Files | *.jpg;*.jpeg;*.png;*.bmp";
            ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                _rutaImagenActual = ofd.FileName;
                pbImagen.Image = Image.FromFile(ofd.FileName);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CBMostrar_CheckedChanged(object sender, EventArgs e)
        {
            if (CBMostrar.Checked)
            {
                if (string.IsNullOrEmpty(_rutaImagenActual))
                {
                    MessageBox.Show("Por favor, carga una imagen primero.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    CBMostrar.Checked = false;
                    return;
                }

                Mat imagen = CvInvoke.Imread(_rutaImagenActual, ImreadModes.ColorBgr);
                IBImagen.Image = imagen;
            }
            else
            {
                if (IBImagen.Image != null)
                {
                    IBImagen.Image.Dispose();
                    IBImagen.Image = null;
                }
            }
        }

        private void btnConvertir_Click(object sender, EventArgs e)
        {
            if (IBImagen.Image == null) return;

            Mat currentImage = IBImagen.Image as Mat;
            if (currentImage == null || currentImage.IsEmpty) return;
            if (currentImage.NumberOfChannels == 1)
            {
                MessageBox.Show("La imagen ya está en escala de grises.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Mat gray = new();
            try
            {
                CvInvoke.CvtColor(currentImage, gray, ColorConversion.Bgr2Gray);
                var oldImage = IBImagen.Image;
                IBImagen.Image = gray;
                if (oldImage != null && oldImage != currentImage)
                {
                    oldImage.Dispose();
                }
            }
            catch (Exception ex)
            {
                gray?.Dispose();
                MessageBox.Show($"Error al convertir la imagen: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
