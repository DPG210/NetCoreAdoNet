namespace NetCoreAdoNet
{
    partial class Form01PrimerAdo
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
            btnConectar = new Button();
            btnDesconectar = new Button();
            btnRead = new Button();
            label1 = new Label();
            lstApellidos = new ListBox();
            Columnas = new Label();
            lstColumnas = new ListBox();
            label3 = new Label();
            lstTipos = new ListBox();
            lblConexion = new Label();
            SuspendLayout();
            // 
            // btnConectar
            // 
            btnConectar.Location = new Point(77, 56);
            btnConectar.Name = "btnConectar";
            btnConectar.Size = new Size(86, 23);
            btnConectar.TabIndex = 0;
            btnConectar.Text = "Conectar";
            btnConectar.UseVisualStyleBackColor = true;
            btnConectar.Click += btnConectar_Click;
            // 
            // btnDesconectar
            // 
            btnDesconectar.Location = new Point(77, 115);
            btnDesconectar.Name = "btnDesconectar";
            btnDesconectar.Size = new Size(86, 23);
            btnDesconectar.TabIndex = 1;
            btnDesconectar.Text = "Desconectar";
            btnDesconectar.UseVisualStyleBackColor = true;
            btnDesconectar.Click += btnDesconectar_Click;
            // 
            // btnRead
            // 
            btnRead.Location = new Point(77, 179);
            btnRead.Name = "btnRead";
            btnRead.Size = new Size(86, 23);
            btnRead.TabIndex = 2;
            btnRead.Text = "Read";
            btnRead.UseVisualStyleBackColor = true;
            btnRead.Click += btnRead_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(271, 64);
            label1.Name = "label1";
            label1.Size = new Size(56, 15);
            label1.TabIndex = 3;
            label1.Text = "Apellidos";
            // 
            // lstApellidos
            // 
            lstApellidos.FormattingEnabled = true;
            lstApellidos.Location = new Point(276, 116);
            lstApellidos.Name = "lstApellidos";
            lstApellidos.Size = new Size(120, 229);
            lstApellidos.TabIndex = 4;
            // 
            // Columnas
            // 
            Columnas.AutoSize = true;
            Columnas.Location = new Point(448, 64);
            Columnas.Name = "Columnas";
            Columnas.Size = new Size(61, 15);
            Columnas.TabIndex = 5;
            Columnas.Text = "Columnas";
            // 
            // lstColumnas
            // 
            lstColumnas.FormattingEnabled = true;
            lstColumnas.Location = new Point(448, 115);
            lstColumnas.Name = "lstColumnas";
            lstColumnas.Size = new Size(120, 229);
            lstColumnas.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(616, 64);
            label3.Name = "label3";
            label3.Size = new Size(68, 15);
            label3.TabIndex = 7;
            label3.Text = "Tipos Datos";
            // 
            // lstTipos
            // 
            lstTipos.FormattingEnabled = true;
            lstTipos.Location = new Point(616, 115);
            lstTipos.Name = "lstTipos";
            lstTipos.Size = new Size(120, 229);
            lstTipos.TabIndex = 8;
            // 
            // lblConexion
            // 
            lblConexion.AutoSize = true;
            lblConexion.Location = new Point(77, 376);
            lblConexion.Name = "lblConexion";
            lblConexion.Size = new Size(71, 15);
            lblConexion.TabIndex = 9;
            lblConexion.Text = "lblConexion";
            // 
            // Form01PrimerAdo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblConexion);
            Controls.Add(lstTipos);
            Controls.Add(label3);
            Controls.Add(lstColumnas);
            Controls.Add(Columnas);
            Controls.Add(lstApellidos);
            Controls.Add(label1);
            Controls.Add(btnRead);
            Controls.Add(btnDesconectar);
            Controls.Add(btnConectar);
            Name = "Form01PrimerAdo";
            Text = "Form01PrimerAdo";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnConectar;
        private Button btnDesconectar;
        private Button btnRead;
        private Label label1;
        private ListBox lstApellidos;
        private Label Columnas;
        private ListBox lstColumnas;
        private Label label3;
        private ListBox lstTipos;
        private Label lblConexion;
    }
}