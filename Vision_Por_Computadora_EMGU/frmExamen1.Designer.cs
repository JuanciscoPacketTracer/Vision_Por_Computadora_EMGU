namespace Vision_Por_Computadora_EMGU
{
    partial class frmExamen1
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
            pbImagen = new PictureBox();
            IBImagen = new Emgu.CV.UI.ImageBox();
            btnCargar = new Button();
            btnConvertir = new Button();
            btnCerrar = new Button();
            CBMostrar = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)pbImagen).BeginInit();
            ((System.ComponentModel.ISupportInitialize)IBImagen).BeginInit();
            SuspendLayout();
            // 
            // pbImagen
            // 
            pbImagen.BorderStyle = BorderStyle.Fixed3D;
            pbImagen.Location = new Point(12, 36);
            pbImagen.Name = "pbImagen";
            pbImagen.Size = new Size(257, 215);
            pbImagen.SizeMode = PictureBoxSizeMode.StretchImage;
            pbImagen.TabIndex = 0;
            pbImagen.TabStop = false;
            // 
            // IBImagen
            // 
            IBImagen.BorderStyle = BorderStyle.Fixed3D;
            IBImagen.Location = new Point(393, 36);
            IBImagen.Name = "IBImagen";
            IBImagen.Size = new Size(264, 215);
            IBImagen.SizeMode = PictureBoxSizeMode.StretchImage;
            IBImagen.TabIndex = 2;
            IBImagen.TabStop = false;
            // 
            // btnCargar
            // 
            btnCargar.Location = new Point(12, 316);
            btnCargar.Name = "btnCargar";
            btnCargar.Size = new Size(161, 81);
            btnCargar.TabIndex = 3;
            btnCargar.Text = "CARGAR IMAGEN";
            btnCargar.UseVisualStyleBackColor = true;
            btnCargar.Click += btnCargar_Click;
            // 
            // btnConvertir
            // 
            btnConvertir.Location = new Point(256, 318);
            btnConvertir.Name = "btnConvertir";
            btnConvertir.Size = new Size(161, 81);
            btnConvertir.TabIndex = 4;
            btnConvertir.Text = "CONVERTIR";
            btnConvertir.UseVisualStyleBackColor = true;
            btnConvertir.Click += btnConvertir_Click;
            // 
            // btnCerrar
            // 
            btnCerrar.Location = new Point(496, 318);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(161, 81);
            btnCerrar.TabIndex = 5;
            btnCerrar.Text = "CERRAR";
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // CBMostrar
            // 
            CBMostrar.AutoSize = true;
            CBMostrar.Location = new Point(393, 277);
            CBMostrar.Name = "CBMostrar";
            CBMostrar.Size = new Size(165, 25);
            CBMostrar.TabIndex = 6;
            CBMostrar.Text = "MOSTRAR IMAGEN";
            CBMostrar.UseVisualStyleBackColor = true;
            CBMostrar.CheckedChanged += CBMostrar_CheckedChanged;
            // 
            // frmExamen1
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(667, 409);
            Controls.Add(CBMostrar);
            Controls.Add(btnCerrar);
            Controls.Add(btnConvertir);
            Controls.Add(btnCargar);
            Controls.Add(IBImagen);
            Controls.Add(pbImagen);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "frmExamen1";
            Text = "Examen 1er parcial";
            ((System.ComponentModel.ISupportInitialize)pbImagen).EndInit();
            ((System.ComponentModel.ISupportInitialize)IBImagen).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pbImagen;
        private Emgu.CV.UI.ImageBox IBImagen;
        private Button btnCargar;
        private Button btnConvertir;
        private Button btnCerrar;
        private CheckBox CBMostrar;
    }
}