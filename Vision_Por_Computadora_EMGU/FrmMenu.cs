using Microsoft.VisualBasic;

namespace Vision_Por_Computadora_EMGU
{
    public partial class FrmMenu : Form
    {
        private void AplicarEstilo()
        {
            this.BackColor = Estilos.Fondo;
            this.StartPosition = FormStartPosition.CenterScreen;
            Estilos.EstilizarBoton(btnImagenes, "🖼️ Procesar Imagenes");
            Estilos.EstilizarBoton(btnVideo, "🎥 Procesar Video");
        }
        public FrmMenu()
        {
            InitializeComponent();
            AplicarEstilo();
        }

        private void BtnImagenes_Click(object sender, EventArgs e)
        {
            FrmImagen img = new();
            img.Show();
        }

        private void BtnVideo_Click(object sender, EventArgs e)
        {
            FrmVideo vid = new();
            vid.Show();
        }

        private void FrmMenu_Load(object sender, EventArgs e)
        {

        }

        private void btnExamen1_Click(object sender, EventArgs e)
        {
            frmExamen1 frmExamen1 = new();
            frmExamen1.Show();
        }

        private void btnVideoImagen_Click(object sender, EventArgs e)
        {
            
        }

        private void BtnReconoce2_Click(object sender, EventArgs e)
        {
            FrmReconoce2 frmVI = new();
            frmVI.Show();
        }
    }
}
