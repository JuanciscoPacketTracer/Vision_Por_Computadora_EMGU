namespace Vision_Por_Computadora_EMGU
{
    partial class FrmVideo
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
            IBVideo = new Emgu.CV.UI.ImageBox();
            BtnFlipH = new Button();
            BtnFlipV = new Button();
            BtnCerrar = new Button();
            BtnCargar = new Button();
            GBVista = new GroupBox();
            RBGris = new RadioButton();
            RBColor = new RadioButton();
            SBBrillo = new HScrollBar();
            label1 = new Label();
            LblValueBrillo = new Label();
            LblValueContraste = new Label();
            label3 = new Label();
            SBContraste = new HScrollBar();
            LblValueNitidez = new Label();
            label4 = new Label();
            SBNitidez = new HScrollBar();
            ((System.ComponentModel.ISupportInitialize)IBVideo).BeginInit();
            GBVista.SuspendLayout();
            SuspendLayout();
            // 
            // IBVideo
            // 
            IBVideo.BorderStyle = BorderStyle.Fixed3D;
            IBVideo.Location = new Point(6, 2);
            IBVideo.Name = "IBVideo";
            IBVideo.Size = new Size(1048, 669);
            IBVideo.SizeMode = PictureBoxSizeMode.StretchImage;
            IBVideo.TabIndex = 2;
            IBVideo.TabStop = false;
            // 
            // BtnFlipH
            // 
            BtnFlipH.Location = new Point(872, 426);
            BtnFlipH.Name = "BtnFlipH";
            BtnFlipH.Size = new Size(172, 48);
            BtnFlipH.TabIndex = 3;
            BtnFlipH.Text = "button1";
            BtnFlipH.UseVisualStyleBackColor = true;
            BtnFlipH.Click += BtnFlipH_Click;
            // 
            // BtnFlipV
            // 
            BtnFlipV.Location = new Point(872, 492);
            BtnFlipV.Name = "BtnFlipV";
            BtnFlipV.Size = new Size(172, 48);
            BtnFlipV.TabIndex = 4;
            BtnFlipV.Text = "button2";
            BtnFlipV.UseVisualStyleBackColor = true;
            BtnFlipV.Click += BtnFlipV_Click;
            // 
            // BtnCerrar
            // 
            BtnCerrar.Location = new Point(872, 591);
            BtnCerrar.Name = "BtnCerrar";
            BtnCerrar.Size = new Size(172, 66);
            BtnCerrar.TabIndex = 5;
            BtnCerrar.Text = "button3";
            BtnCerrar.UseVisualStyleBackColor = true;
            BtnCerrar.Click += BtnCerrar_Click;
            // 
            // BtnCargar
            // 
            BtnCargar.Location = new Point(17, 591);
            BtnCargar.Name = "BtnCargar";
            BtnCargar.Size = new Size(179, 66);
            BtnCargar.TabIndex = 6;
            BtnCargar.Text = "button4";
            BtnCargar.UseVisualStyleBackColor = true;
            BtnCargar.Click += BtnCargar_Click;
            // 
            // GBVista
            // 
            GBVista.Controls.Add(RBGris);
            GBVista.Controls.Add(RBColor);
            GBVista.Location = new Point(12, 32);
            GBVista.Name = "GBVista";
            GBVista.Size = new Size(185, 143);
            GBVista.TabIndex = 7;
            GBVista.TabStop = false;
            GBVista.Text = "Vista";
            // 
            // RBGris
            // 
            RBGris.AutoSize = true;
            RBGris.Location = new Point(6, 88);
            RBGris.Name = "RBGris";
            RBGris.Size = new Size(89, 58);
            RBGris.TabIndex = 9;
            RBGris.TabStop = true;
            RBGris.Text = "Grises";
            RBGris.UseVisualStyleBackColor = true;
            // 
            // RBColor
            // 
            RBColor.AutoSize = true;
            RBColor.Location = new Point(6, 36);
            RBColor.Name = "RBColor";
            RBColor.Size = new Size(82, 58);
            RBColor.TabIndex = 8;
            RBColor.TabStop = true;
            RBColor.Text = "Color";
            RBColor.UseVisualStyleBackColor = true;
            // 
            // SBBrillo
            // 
            SBBrillo.Location = new Point(18, 280);
            SBBrillo.Name = "SBBrillo";
            SBBrillo.Size = new Size(185, 35);
            SBBrillo.TabIndex = 8;
            SBBrillo.Scroll += SBBrillo_Scroll;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(18, 217);
            label1.Name = "label1";
            label1.Size = new Size(62, 54);
            label1.TabIndex = 9;
            label1.Text = "Brillo";
            // 
            // LblValueBrillo
            // 
            LblValueBrillo.AutoSize = true;
            LblValueBrillo.Location = new Point(226, 280);
            LblValueBrillo.Name = "LblValueBrillo";
            LblValueBrillo.Size = new Size(32, 54);
            LblValueBrillo.TabIndex = 10;
            LblValueBrillo.Text = "0";
            // 
            // LblValueContraste
            // 
            LblValueContraste.AutoSize = true;
            LblValueContraste.Location = new Point(226, 391);
            LblValueContraste.Name = "LblValueContraste";
            LblValueContraste.Size = new Size(32, 54);
            LblValueContraste.TabIndex = 13;
            LblValueContraste.Text = "0";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(18, 328);
            label3.Name = "label3";
            label3.Size = new Size(98, 54);
            label3.TabIndex = 12;
            label3.Text = "Contraste";
            // 
            // SBContraste
            // 
            SBContraste.Location = new Point(18, 391);
            SBContraste.Name = "SBContraste";
            SBContraste.Size = new Size(185, 35);
            SBContraste.TabIndex = 11;
            SBContraste.Scroll += SBContraste_Scroll;
            // 
            // LblValueNitidez
            // 
            LblValueNitidez.AutoSize = true;
            LblValueNitidez.Location = new Point(226, 505);
            LblValueNitidez.Name = "LblValueNitidez";
            LblValueNitidez.Size = new Size(32, 54);
            LblValueNitidez.TabIndex = 16;
            LblValueNitidez.Text = "0";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(18, 442);
            label4.Name = "label4";
            label4.Size = new Size(76, 54);
            label4.TabIndex = 15;
            label4.Text = "Nitidez";
            // 
            // SBNitidez
            // 
            SBNitidez.Location = new Point(18, 505);
            SBNitidez.Name = "SBNitidez";
            SBNitidez.Size = new Size(185, 35);
            SBNitidez.TabIndex = 14;
            SBNitidez.Scroll += SBNitidez_Scroll;
            // 
            // FrmVideo
            // 
            AutoScaleDimensions = new SizeF(9F, 54F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1056, 676);
            Controls.Add(LblValueNitidez);
            Controls.Add(label4);
            Controls.Add(SBNitidez);
            Controls.Add(LblValueContraste);
            Controls.Add(label3);
            Controls.Add(SBContraste);
            Controls.Add(LblValueBrillo);
            Controls.Add(label1);
            Controls.Add(SBBrillo);
            Controls.Add(GBVista);
            Controls.Add(BtnCargar);
            Controls.Add(BtnCerrar);
            Controls.Add(BtnFlipV);
            Controls.Add(BtnFlipH);
            Controls.Add(IBVideo);
            Font = new Font("Sans Serif Collection", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 11, 4, 11);
            Name = "FrmVideo";
            Text = "Reconocimiento por video";
            FormClosing += FrmVideo_FormClosing;
            Load += FrmVideo_Load;
            ((System.ComponentModel.ISupportInitialize)IBVideo).EndInit();
            GBVista.ResumeLayout(false);
            GBVista.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Emgu.CV.UI.ImageBox IBVideo;
        private Button BtnFlipH;
        private Button BtnFlipV;
        private Button BtnCerrar;
        private Button BtnCargar;
        private GroupBox GBVista;
        private RadioButton RBGris;
        private RadioButton RBColor;
        private HScrollBar SBBrillo;
        private Label label1;
        private Label LblValueBrillo;
        private Label LblValueContraste;
        private Label label3;
        private HScrollBar SBContraste;
        private Label LblValueNitidez;
        private Label label4;
        private HScrollBar SBNitidez;
    }
}