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
            IBRostro = new Emgu.CV.UI.ImageBox();
            BtnReconocer = new Button();
            LblInfo2 = new Label();
            BtnPrev = new Button();
            BtnNext = new Button();
            LblImg = new Label();
            ((System.ComponentModel.ISupportInitialize)IBImagen).BeginInit();
            ((System.ComponentModel.ISupportInitialize)IBRostro).BeginInit();
            SuspendLayout();
            // 
            // BtnCargar
            // 
            BtnCargar.Location = new Point(12, 12);
            BtnCargar.Name = "BtnCargar";
            BtnCargar.Size = new Size(168, 69);
            BtnCargar.TabIndex = 0;
            BtnCargar.Text = "Cargar";
            BtnCargar.UseVisualStyleBackColor = true;
            BtnCargar.Click += BtnCargar_Click;
            // 
            // IBImagen
            // 
            IBImagen.BorderStyle = BorderStyle.Fixed3D;
            IBImagen.Location = new Point(12, 100);
            IBImagen.Name = "IBImagen";
            IBImagen.Size = new Size(300, 300);
            IBImagen.SizeMode = PictureBoxSizeMode.StretchImage;
            IBImagen.TabIndex = 2;
            IBImagen.TabStop = false;
            // 
            // BtnGrises
            // 
            BtnGrises.Location = new Point(661, 100);
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
            BtnHSV.Location = new Point(661, 174);
            BtnHSV.Name = "BtnHSV";
            BtnHSV.Size = new Size(206, 58);
            BtnHSV.TabIndex = 5;
            BtnHSV.Text = "BGR a HSV";
            BtnHSV.UseVisualStyleBackColor = true;
            BtnHSV.Click += BtnHSV_Click;
            // 
            // BtnCerrar
            // 
            BtnCerrar.Location = new Point(661, 534);
            BtnCerrar.Name = "BtnCerrar";
            BtnCerrar.Size = new Size(206, 62);
            BtnCerrar.TabIndex = 6;
            BtnCerrar.Text = "Cerrar";
            BtnCerrar.UseVisualStyleBackColor = true;
            BtnCerrar.Click += BtnCerrar_Click;
            // 
            // BtnYCrCb
            // 
            BtnYCrCb.Location = new Point(661, 249);
            BtnYCrCb.Name = "BtnYCrCb";
            BtnYCrCb.Size = new Size(206, 58);
            BtnYCrCb.TabIndex = 7;
            BtnYCrCb.Text = "BGR a YCrCb";
            BtnYCrCb.UseVisualStyleBackColor = true;
            BtnYCrCb.Click += BtnYCrCb_Click;
            // 
            // BtnBGR
            // 
            BtnBGR.Location = new Point(661, 342);
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
            LblInfo.Location = new Point(0, 507);
            LblInfo.Name = "LblInfo";
            LblInfo.Size = new Size(324, 54);
            LblInfo.TabIndex = 9;
            LblInfo.Text = "Carga Imagen para mostrar informacion";
            // 
            // IBRostro
            // 
            IBRostro.BorderStyle = BorderStyle.Fixed3D;
            IBRostro.Location = new Point(332, 100);
            IBRostro.Name = "IBRostro";
            IBRostro.Size = new Size(300, 300);
            IBRostro.SizeMode = PictureBoxSizeMode.StretchImage;
            IBRostro.TabIndex = 10;
            IBRostro.TabStop = false;
            // 
            // BtnReconocer
            // 
            BtnReconocer.Location = new Point(389, 415);
            BtnReconocer.Name = "BtnReconocer";
            BtnReconocer.Size = new Size(206, 47);
            BtnReconocer.TabIndex = 11;
            BtnReconocer.Text = "Reconocer";
            BtnReconocer.UseVisualStyleBackColor = true;
            BtnReconocer.Click += BtnReconocer_Click;
            // 
            // LblInfo2
            // 
            LblInfo2.AutoSize = true;
            LblInfo2.Location = new Point(12, 543);
            LblInfo2.Name = "LblInfo2";
            LblInfo2.Size = new Size(0, 54);
            LblInfo2.TabIndex = 12;
            // 
            // BtnPrev
            // 
            BtnPrev.Location = new Point(12, 460);
            BtnPrev.Name = "BtnPrev";
            BtnPrev.Size = new Size(71, 47);
            BtnPrev.TabIndex = 13;
            BtnPrev.Text = "<";
            BtnPrev.UseVisualStyleBackColor = true;
            BtnPrev.Click += BtnPrev_Click;
            // 
            // BtnNext
            // 
            BtnNext.Location = new Point(241, 460);
            BtnNext.Name = "BtnNext";
            BtnNext.Size = new Size(71, 47);
            BtnNext.TabIndex = 14;
            BtnNext.Text = ">";
            BtnNext.UseVisualStyleBackColor = true;
            BtnNext.Click += BtnNext_Click;
            // 
            // LblImg
            // 
            LblImg.AutoSize = true;
            LblImg.Location = new Point(12, 403);
            LblImg.Name = "LblImg";
            LblImg.Size = new Size(124, 54);
            LblImg.TabIndex = 15;
            LblImg.Text = "Imagen 0 de 0";
            // 
            // FrmImagen
            // 
            AutoScaleDimensions = new SizeF(9F, 54F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(879, 598);
            Controls.Add(LblImg);
            Controls.Add(BtnNext);
            Controls.Add(BtnPrev);
            Controls.Add(LblInfo2);
            Controls.Add(BtnReconocer);
            Controls.Add(IBRostro);
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
            ((System.ComponentModel.ISupportInitialize)IBRostro).EndInit();
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
        private Emgu.CV.UI.ImageBox IBRostro;
        private Button BtnReconocer;
        private Label LblInfo2;
        private Button BtnPrev;
        private Button BtnNext;
        private Label LblImg;
    }
}