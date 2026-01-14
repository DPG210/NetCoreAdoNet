namespace NetCoreAdoNet
{
    partial class Form04EliminarPlantilla
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
            btnEliminar = new Button();
            label1 = new Label();
            txtIdEmpleado = new TextBox();
            label2 = new Label();
            lstPlantilla = new ListBox();
            SuspendLayout();
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(77, 170);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(75, 51);
            btnEliminar.TabIndex = 0;
            btnEliminar.Text = "Eliminar empleado";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(77, 41);
            label1.Name = "label1";
            label1.Size = new Size(73, 15);
            label1.TabIndex = 1;
            label1.Text = "Id Empleado";
            // 
            // txtIdEmpleado
            // 
            txtIdEmpleado.Location = new Point(77, 94);
            txtIdEmpleado.Name = "txtIdEmpleado";
            txtIdEmpleado.Size = new Size(100, 23);
            txtIdEmpleado.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(246, 41);
            label2.Name = "label2";
            label2.Size = new Size(49, 15);
            label2.TabIndex = 3;
            label2.Text = "Plantilla";
            // 
            // lstPlantilla
            // 
            lstPlantilla.FormattingEnabled = true;
            lstPlantilla.Location = new Point(246, 94);
            lstPlantilla.Name = "lstPlantilla";
            lstPlantilla.Size = new Size(120, 169);
            lstPlantilla.TabIndex = 4;
            // 
            // Form04EliminarPlantilla
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lstPlantilla);
            Controls.Add(label2);
            Controls.Add(txtIdEmpleado);
            Controls.Add(label1);
            Controls.Add(btnEliminar);
            Name = "Form04EliminarPlantilla";
            Text = "Form04EliminarPlantilla";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnEliminar;
        private Label label1;
        private TextBox txtIdEmpleado;
        private Label label2;
        private ListBox lstPlantilla;
    }
}