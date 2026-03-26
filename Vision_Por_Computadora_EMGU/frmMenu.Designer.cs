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
            SuspendLayout();
            // 
            // btnImagenes
            // 
            btnImagenes.Location = new Point(165, 89);
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
            btnVideo.Location = new Point(165, 247);
            btnVideo.Margin = new Padding(4, 11, 4, 11);
            btnVideo.Name = "btnVideo";
            btnVideo.Size = new Size(231, 69);
            btnVideo.TabIndex = 1;
            btnVideo.Text = "Video";
            btnVideo.UseVisualStyleBackColor = true;
            btnVideo.Click += BtnVideo_Click;
            // 
            // FrmMenu
            // 
            AutoScaleDimensions = new SizeF(9F, 54F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(608, 429);
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
    }
}
