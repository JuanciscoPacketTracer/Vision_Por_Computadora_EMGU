namespace Vision_Por_Computadora_EMGU
{
    partial class FrmReconoce2 : Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            IBMedia = new Emgu.CV.UI.ImageBox();
            IBRostro = new Emgu.CV.UI.ImageBox();
            BtnFoto = new Button();
            BtnVideo = new Button();
            BtnCerrar = new Button();
            BtnLeft = new Button();
            BtnRight = new Button();
            RBCarros = new RadioButton();
            RbAnimales = new RadioButton();
            RbPersonas = new RadioButton();
            ((System.ComponentModel.ISupportInitialize)IBMedia).BeginInit();
            ((System.ComponentModel.ISupportInitialize)IBRostro).BeginInit();
            SuspendLayout();
            // 
            // IBMedia
            // 
            IBMedia.BorderStyle = BorderStyle.Fixed3D;
            IBMedia.Location = new Point(12, 12);
            IBMedia.Name = "IBMedia";
            IBMedia.Size = new Size(400, 300);
            IBMedia.SizeMode = PictureBoxSizeMode.StretchImage;
            IBMedia.TabIndex = 0;
            IBMedia.TabStop = false;
            // 
            // IBRostro
            // 
            IBRostro.BorderStyle = BorderStyle.Fixed3D;
            IBRostro.Location = new Point(12, 320);
            IBRostro.Name = "IBRostro";
            IBRostro.Size = new Size(200, 150);
            IBRostro.SizeMode = PictureBoxSizeMode.StretchImage;
            IBRostro.TabIndex = 1;
            IBRostro.TabStop = false;
            // 
            // BtnFoto
            // 
            BtnFoto.Location = new Point(420, 12);
            BtnFoto.Name = "BtnFoto";
            BtnFoto.Size = new Size(150, 50);
            BtnFoto.TabIndex = 2;
            BtnFoto.Text = "Cargar Foto";
            BtnFoto.UseVisualStyleBackColor = true;
            BtnFoto.Click += BtnFoto_Click;
            // 
            // BtnVideo
            // 
            BtnVideo.Location = new Point(420, 70);
            BtnVideo.Name = "BtnVideo";
            BtnVideo.Size = new Size(150, 50);
            BtnVideo.TabIndex = 3;
            BtnVideo.Text = "Cargar Video";
            BtnVideo.UseVisualStyleBackColor = true;
            BtnVideo.Click += BtnVideo_Click;
            // 
            // BtnCerrar
            // 
            BtnCerrar.Location = new Point(420, 420);
            BtnCerrar.Name = "BtnCerrar";
            BtnCerrar.Size = new Size(150, 50);
            BtnCerrar.TabIndex = 4;
            BtnCerrar.Text = "Cerrar";
            BtnCerrar.UseVisualStyleBackColor = true;
            BtnCerrar.Click += BtnCerrar_Click;
            // 
            // BtnLeft
            // 
            BtnLeft.Location = new Point(12, 480);
            BtnLeft.Name = "BtnLeft";
            BtnLeft.Size = new Size(80, 40);
            BtnLeft.TabIndex = 5;
            BtnLeft.Text = "◄ Anterior";
            BtnLeft.UseVisualStyleBackColor = true;
            BtnLeft.Click += BtnLeft_Click;
            // 
            // BtnRight
            // 
            BtnRight.Location = new Point(132, 480);
            BtnRight.Name = "BtnRight";
            BtnRight.Size = new Size(80, 40);
            BtnRight.TabIndex = 6;
            BtnRight.Text = "Siguiente ►";
            BtnRight.UseVisualStyleBackColor = true;
            BtnRight.Click += BtnRight_Click;
            // 
            // RBCarros
            // 
            RBCarros.AutoSize = true;
            RBCarros.Location = new Point(443, 172);
            RBCarros.Name = "RBCarros";
            RBCarros.Size = new Size(59, 19);
            RBCarros.TabIndex = 7;
            RBCarros.TabStop = true;
            RBCarros.Text = "Carros";
            RBCarros.UseVisualStyleBackColor = true;
            // 
            // RbAnimales
            // 
            RbAnimales.AutoSize = true;
            RbAnimales.Location = new Point(443, 197);
            RbAnimales.Name = "RbAnimales";
            RbAnimales.Size = new Size(74, 19);
            RbAnimales.TabIndex = 8;
            RbAnimales.TabStop = true;
            RbAnimales.Text = "Animales";
            RbAnimales.UseVisualStyleBackColor = true;
            // 
            // RbPersonas
            // 
            RbPersonas.AutoSize = true;
            RbPersonas.Location = new Point(443, 222);
            RbPersonas.Name = "RbPersonas";
            RbPersonas.Size = new Size(72, 19);
            RbPersonas.TabIndex = 9;
            RbPersonas.TabStop = true;
            RbPersonas.Text = "Personas";
            RbPersonas.UseVisualStyleBackColor = true;
            // 
            // FrmReconoce2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(582, 532);
            Controls.Add(RbPersonas);
            Controls.Add(RbAnimales);
            Controls.Add(RBCarros);
            Controls.Add(BtnRight);
            Controls.Add(BtnLeft);
            Controls.Add(BtnCerrar);
            Controls.Add(BtnVideo);
            Controls.Add(BtnFoto);
            Controls.Add(IBRostro);
            Controls.Add(IBMedia);
            Name = "FrmReconoce2";
            Text = "Reconocimiento de Rostros";
            FormClosing += FrmReconoce2_FormClosing;
            ((System.ComponentModel.ISupportInitialize)IBMedia).EndInit();
            ((System.ComponentModel.ISupportInitialize)IBRostro).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Emgu.CV.UI.ImageBox IBMedia;
        private Emgu.CV.UI.ImageBox IBRostro;
        private Button BtnFoto;
        private Button BtnVideo;
        private Button BtnCerrar;
        private Button BtnLeft;
        private Button BtnRight;
        private RadioButton RBCarros;
        private RadioButton RbAnimales;
        private RadioButton RbPersonas;
    }
}
