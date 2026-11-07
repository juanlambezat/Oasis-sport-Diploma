namespace Oasis_Sports
{
    partial class FrmHistorialCambios
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            dgvHistorial = new DataGridView();
            lblTitulo = new Label();
            button1 = new Button();
            button2 = new Button();
            lblTituloHistorial = new Label();
            lblUsuarioHistorial = new Label();
            cmbUsuarioHistorial = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvHistorial).BeginInit();
            SuspendLayout();
            // 
            // dgvHistorial
            // 
            dgvHistorial.AllowUserToAddRows = false;
            dgvHistorial.AllowUserToDeleteRows = false;
            dgvHistorial.BackgroundColor = Color.White;
            dgvHistorial.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHistorial.Location = new Point(12, 90);
            dgvHistorial.Name = "dgvHistorial";
            dgvHistorial.ReadOnly = true;
            dgvHistorial.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHistorial.Size = new Size(760, 350);
            dgvHistorial.TabIndex = 1;
            // 
            // lblTitulo
            // 
            lblTitulo.Location = new Point(0, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(100, 23);
            lblTitulo.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(12, 452);
            button1.Name = "button1";
            button1.Size = new Size(178, 35);
            button1.TabIndex = 2;
            button1.Text = "Restaurar valor anterior";
            button1.BackColor = Color.White;
            button1.ForeColor = Color.DarkGreen;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(665, 454);
            button2.Name = "button2";
            button2.Size = new Size(107, 35);
            button2.TabIndex = 3;
            button2.Text = "Cerrar";
            button2.BackColor = Color.White;
            button2.ForeColor = Color.DarkGreen;
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click_2;
            // 
            // lblTituloHistorial
            // 
            lblTituloHistorial.AutoSize = true;
            lblTituloHistorial.Font = new Font("Times New Roman", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTituloHistorial.Location = new Point(276, 9);
            lblTituloHistorial.ForeColor = Color.DarkGreen;
            lblTituloHistorial.Name = "lblTituloHistorial";
            lblTituloHistorial.Size = new Size(234, 32);
            lblTituloHistorial.TabIndex = 4;
            lblTituloHistorial.Text = "Historial de Cambios";
            lblTituloHistorial.TextAlign = ContentAlignment.TopCenter;
            //
            // lblUsuarioHistorial
            //
            lblUsuarioHistorial.AutoSize = true;
            lblUsuarioHistorial.Location = new Point(12, 58);
            lblUsuarioHistorial.ForeColor = Color.DarkGreen;
            lblUsuarioHistorial.Name = "lblUsuarioHistorial";
            lblUsuarioHistorial.Size = new Size(50, 15);
            lblUsuarioHistorial.TabIndex = 5;
            lblUsuarioHistorial.Text = "Usuario:";
            //
            // cmbUsuarioHistorial
            //
            cmbUsuarioHistorial.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbUsuarioHistorial.Location = new Point(80, 55);
            cmbUsuarioHistorial.Name = "cmbUsuarioHistorial";
            cmbUsuarioHistorial.Size = new Size(200, 23);
            cmbUsuarioHistorial.TabIndex = 6;
            cmbUsuarioHistorial.SelectionChangeCommitted += cmbUsuarioHistorial_SelectionChangeCommitted;
            //
            // FrmHistorialCambios
            //
            BackColor = Color.FromArgb(224, 224, 224);
            ClientSize = new Size(784, 501);
            Controls.Add(cmbUsuarioHistorial);
            Controls.Add(lblUsuarioHistorial);
            Controls.Add(lblTituloHistorial);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(dgvHistorial);
            Name = "FrmHistorialCambios";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Historial de Cambios";
            FormClosing += FrmHistorialCambios_FormClosing;
            Load += FrmHistorialCambios_Load;
            ((System.ComponentModel.ISupportInitialize)dgvHistorial).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        private DataGridView dgvHistorial;
        private Label lblTitulo;
        private Button button1;
        private Button button2;
        private Label lblTituloHistorial;
        private Label lblUsuarioHistorial;
        private ComboBox cmbUsuarioHistorial;
    }
}