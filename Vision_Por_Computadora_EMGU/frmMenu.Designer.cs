namespace Vision_Por_Computadora_EMGU
{
    partial class FrmMenu
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnImagenes = new Button();
            btnVideo = new Button();
            btnExamen1 = new Button();
            btnVideoImagen = new Button();
            BtnReconoce2 = new Button();
            SuspendLayout();
            // 
            // btnImagenes
            // 
            btnImagenes.Location = new Point(165, 72);
            btnImagenes.Margin = new Padding(4, 11, 4, 11);
            btnImagenes.Name = "btnImagenes";
            btnImagenes.Size = new Size(231, 69);
            btnImagenes.TabIndex = 0;
            btnImagenes.Text = "Imagenes";
            btnImagenes.UseVisualStyleBackColor = true;
            btnImagenes.Click += BtnImagenes_Click;
            // 
            // btnVideo
            // 
            btnVideo.Location = new Point(165, 272);
            btnVideo.Margin = new Padding(4, 11, 4, 11);
            btnVideo.Name = "btnVideo";
            btnVideo.Size = new Size(231, 69);
            btnVideo.TabIndex = 1;
            btnVideo.Text = "Video";
            btnVideo.UseVisualStyleBackColor = true;
            btnVideo.Click += BtnVideo_Click;
            // 
            // btnExamen1
            // 
            btnExamen1.Location = new Point(13, 349);
            btnExamen1.Margin = new Padding(4, 11, 4, 11);
            btnExamen1.Name = "btnExamen1";
            btnExamen1.RightToLeft = RightToLeft.Yes;
            btnExamen1.Size = new Size(125, 60);
            btnExamen1.TabIndex = 2;
            btnExamen1.Text = "1er Examen";
            btnExamen1.UseVisualStyleBackColor = true;
            btnExamen1.Click += btnExamen1_Click;
            // 
            // btnVideoImagen
            // 
            btnVideoImagen.Location = new Point(165, 180);
            btnVideoImagen.Margin = new Padding(4, 11, 4, 11);
            btnVideoImagen.Name = "btnVideoImagen";
            btnVideoImagen.RightToLeft = RightToLeft.Yes;
            btnVideoImagen.Size = new Size(231, 60);
            btnVideoImagen.TabIndex = 3;
            btnVideoImagen.Text = "Video/Imagen";
            btnVideoImagen.UseVisualStyleBackColor = true;
            btnVideoImagen.Click += btnVideoImagen_Click;
            // 
            // BtnReconoce2
            // 
            BtnReconoce2.Location = new Point(13, 267);
            BtnReconoce2.Margin = new Padding(4, 11, 4, 11);
            BtnReconoce2.Name = "BtnReconoce2";
            BtnReconoce2.Size = new Size(125, 60);
            BtnReconoce2.TabIndex = 4;
            BtnReconoce2.Text = "Reconoce2";
            BtnReconoce2.UseVisualStyleBackColor = true;
            BtnReconoce2.Click += BtnReconoce2_Click;
            // 
            // FrmMenu
            // 
            AutoScaleDimensions = new SizeF(9F, 54F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(608, 429);
            Controls.Add(BtnReconoce2);
            Controls.Add(btnVideoImagen);
            Controls.Add(btnExamen1);
            Controls.Add(btnVideo);
            Controls.Add(btnImagenes);
            Font = new Font("Sans Serif Collection", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 11, 4, 11);
            Name = "FrmMenu";
            Text = "Menu";
            Load += FrmMenu_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button btnImagenes;
        private Button btnVideo;
        private Button btnExamen1;
        private Button btnVideoImagen;
        private Button BtnReconoce2;
    }
}
