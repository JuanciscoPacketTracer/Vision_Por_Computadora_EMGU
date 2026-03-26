namespace Vision_Por_Computadora_EMGU
{
    partial class FrmImagen
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
            BtnCargar = new Button();
            IBImagen = new Emgu.CV.UI.ImageBox();
            BtnGrises = new Button();
            TbPath = new TextBox();
            BtnHSV = new Button();
            BtnCerrar = new Button();
            BtnYCrCb = new Button();
            BtnBGR = new Button();
            LblInfo = new Label();
            ((System.ComponentModel.ISupportInitialize)IBImagen).BeginInit();
            SuspendLayout();
            // 
            // BtnCargar
            // 
            BtnCargar.Location = new Point(12, 12);
            BtnCargar.Name = "BtnCargar";
            BtnCargar.Size = new Size(168, 47);
            BtnCargar.TabIndex = 0;
            BtnCargar.Text = "Cargar";
            BtnCargar.UseVisualStyleBackColor = true;
            BtnCargar.Click += BtnCargar_Click;
            // 
            // IBImagen
            // 
            IBImagen.BorderStyle = BorderStyle.Fixed3D;
            IBImagen.Location = new Point(12, 76);
            IBImagen.Name = "IBImagen";
            IBImagen.Size = new Size(490, 373);
            IBImagen.SizeMode = PictureBoxSizeMode.StretchImage;
            IBImagen.TabIndex = 2;
            IBImagen.TabStop = false;
            // 
            // BtnGrises
            // 
            BtnGrises.Location = new Point(661, 76);
            BtnGrises.Name = "BtnGrises";
            BtnGrises.Size = new Size(206, 58);
            BtnGrises.TabIndex = 3;
            BtnGrises.Text = "BGR a Grises";
            BtnGrises.UseVisualStyleBackColor = true;
            BtnGrises.Click += BtnGrises_Click;
            // 
            // TbPath
            // 
            TbPath.Location = new Point(212, 12);
            TbPath.Name = "TbPath";
            TbPath.ReadOnly = true;
            TbPath.Size = new Size(655, 50);
            TbPath.TabIndex = 4;
            // 
            // BtnHSV
            // 
            BtnHSV.Location = new Point(661, 162);
            BtnHSV.Name = "BtnHSV";
            BtnHSV.Size = new Size(206, 58);
            BtnHSV.TabIndex = 5;
            BtnHSV.Text = "BGR a HSV";
            BtnHSV.UseVisualStyleBackColor = true;
            BtnHSV.Click += BtnHSV_Click;
            // 
            // BtnCerrar
            // 
            BtnCerrar.Location = new Point(661, 466);
            BtnCerrar.Name = "BtnCerrar";
            BtnCerrar.Size = new Size(206, 62);
            BtnCerrar.TabIndex = 6;
            BtnCerrar.Text = "Cerrar";
            BtnCerrar.UseVisualStyleBackColor = true;
            BtnCerrar.Click += BtnCerrar_Click;
            // 
            // BtnYCrCb
            // 
            BtnYCrCb.Location = new Point(661, 248);
            BtnYCrCb.Name = "BtnYCrCb";
            BtnYCrCb.Size = new Size(206, 58);
            BtnYCrCb.TabIndex = 7;
            BtnYCrCb.Text = "BGR a YCrCb";
            BtnYCrCb.UseVisualStyleBackColor = true;
            BtnYCrCb.Click += BtnYCrCb_Click;
            // 
            // BtnBGR
            // 
            BtnBGR.Location = new Point(661, 380);
            BtnBGR.Name = "BtnBGR";
            BtnBGR.Size = new Size(206, 58);
            BtnBGR.TabIndex = 8;
            BtnBGR.Text = "Revertir a BRG";
            BtnBGR.UseVisualStyleBackColor = true;
            BtnBGR.Click += BtnBGR_Click;
            // 
            // LblInfo
            // 
            LblInfo.AutoSize = true;
            LblInfo.Location = new Point(12, 470);
            LblInfo.Name = "LblInfo";
            LblInfo.Size = new Size(68, 54);
            LblInfo.TabIndex = 9;
            LblInfo.Text = "label1";
            // 
            // FrmImagen
            // 
            AutoScaleDimensions = new SizeF(9F, 54F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(879, 540);
            Controls.Add(LblInfo);
            Controls.Add(BtnBGR);
            Controls.Add(BtnYCrCb);
            Controls.Add(BtnCerrar);
            Controls.Add(BtnHSV);
            Controls.Add(TbPath);
            Controls.Add(BtnGrises);
            Controls.Add(IBImagen);
            Controls.Add(BtnCargar);
            Font = new Font("Sans Serif Collection", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 11, 4, 11);
            Name = "FrmImagen";
            Text = "Tranformacion de Imagenes";
            Load += FrmImagen_Load;
            ((System.ComponentModel.ISupportInitialize)IBImagen).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BtnCargar;
        private Emgu.CV.UI.ImageBox IBImagen;
        private Button BtnGrises;
        private TextBox TbPath;
        private Button BtnHSV;
        private Button BtnCerrar;
        private Button BtnYCrCb;
        private Button BtnBGR;
        private Label LblInfo;
    }
}