namespace Oasis_Sports
{
    partial class jzat506_FrmBitacoraCambios
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblTituloCambios = new Label();
            dgvVersiones = new DataGridView();
            lblUsuarioCambios = new Label();
            cmbUsuarioCambios = new ComboBox();
            lblNombreCambios = new Label();
            cmbNombreCambios = new ComboBox();
            lblFechaInicioCambios = new Label();
            dtpFechaInicioCambios = new DateTimePicker();
            lblFechaFinCambios = new Label();
            dtpFechaFinCambios = new DateTimePicker();
            btnAplicarCambios = new Button();
            btnLimpiarCambios = new Button();
            btnSalirCambios = new Button();
            btnActivarCambios = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvVersiones).BeginInit();
            SuspendLayout();
            lblTituloCambios.AutoSize = true;
            lblTituloCambios.Font = new Font("Times New Roman", 14F, FontStyle.Bold);
            lblTituloCambios.ForeColor = Color.DarkGreen;
            lblTituloCambios.Location = new Point(20, 15);
            lblTituloCambios.Name = "lblTituloCambios";
            lblTituloCambios.Size = new Size(220, 28);
            lblTituloCambios.Text = "Bitacora de cambios";
            dgvVersiones.AllowUserToAddRows = false;
            dgvVersiones.AllowUserToDeleteRows = false;
            dgvVersiones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvVersiones.BackgroundColor = Color.White;
            dgvVersiones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVersiones.Location = new Point(20, 55);
            dgvVersiones.MultiSelect = false;
            dgvVersiones.Name = "dgvVersiones";
            dgvVersiones.ReadOnly = true;
            dgvVersiones.RowHeadersVisible = false;
            dgvVersiones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVersiones.Size = new Size(960, 300);
            dgvVersiones.Columns.Add("Version", "Version");
            dgvVersiones.Columns.Add("IdUsuario", "Id usuario");
            dgvVersiones.Columns.Add("Fecha", "Fecha");
            dgvVersiones.Columns.Add("Hora", "Hora");
            dgvVersiones.Columns.Add("Nombre", "Nombre");
            dgvVersiones.Columns.Add("Contrasenia", "Contraseña");
            dgvVersiones.Columns.Add("Bloqueado", "Bloqueado");
            dgvVersiones.Columns.Add("Eliminado", "Eliminado");
            dgvVersiones.Columns.Add("ModificadoPor", "Modificado por");
            dgvVersiones.Columns.Add("Activa", "Activa");
            dgvVersiones.Columns["Version"].FillWeight = 70;
            dgvVersiones.Columns["IdUsuario"].FillWeight = 60;
            dgvVersiones.Columns["Fecha"].FillWeight = 90;
            dgvVersiones.Columns["Hora"].FillWeight = 75;
            dgvVersiones.Columns["Nombre"].FillWeight = 115;
            dgvVersiones.Columns["Contrasenia"].FillWeight = 85;
            dgvVersiones.Columns["Bloqueado"].FillWeight = 85;
            dgvVersiones.Columns["Eliminado"].FillWeight = 80;
            dgvVersiones.Columns["ModificadoPor"].FillWeight = 100;
            dgvVersiones.Columns["Activa"].FillWeight = 60;
            dgvVersiones.SelectionChanged += jzat506_dgvVersiones_SelectionChanged;
            lblUsuarioCambios.AutoSize = true;
            lblUsuarioCambios.ForeColor = Color.DarkGreen;
            lblUsuarioCambios.Location = new Point(20, 378);
            lblUsuarioCambios.Name = "lblUsuarioCambios";
            lblUsuarioCambios.Size = new Size(50, 20);
            lblUsuarioCambios.Text = "Usuario";
            cmbUsuarioCambios.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbUsuarioCambios.Location = new Point(140, 375);
            cmbUsuarioCambios.Name = "cmbUsuarioCambios";
            cmbUsuarioCambios.Size = new Size(170, 23);
            lblNombreCambios.AutoSize = true;
            lblNombreCambios.ForeColor = Color.DarkGreen;
            lblNombreCambios.Location = new Point(560, 378);
            lblNombreCambios.Name = "lblNombreCambios";
            lblNombreCambios.Size = new Size(50, 20);
            lblNombreCambios.Text = "Nombre";
            cmbNombreCambios.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbNombreCambios.Location = new Point(660, 375);
            cmbNombreCambios.Name = "cmbNombreCambios";
            cmbNombreCambios.Size = new Size(170, 23);
            lblFechaInicioCambios.AutoSize = true;
            lblFechaInicioCambios.ForeColor = Color.DarkGreen;
            lblFechaInicioCambios.Location = new Point(20, 423);
            lblFechaInicioCambios.Name = "lblFechaInicioCambios";
            lblFechaInicioCambios.Size = new Size(80, 20);
            lblFechaInicioCambios.Text = "Fecha inicio";
            dtpFechaInicioCambios.Format = DateTimePickerFormat.Short;
            dtpFechaInicioCambios.Location = new Point(140, 420);
            dtpFechaInicioCambios.Name = "dtpFechaInicioCambios";
            dtpFechaInicioCambios.Size = new Size(170, 23);
            lblFechaFinCambios.AutoSize = true;
            lblFechaFinCambios.ForeColor = Color.DarkGreen;
            lblFechaFinCambios.Location = new Point(20, 468);
            lblFechaFinCambios.Name = "lblFechaFinCambios";
            lblFechaFinCambios.Size = new Size(70, 20);
            lblFechaFinCambios.Text = "Fecha fin";
            dtpFechaFinCambios.Format = DateTimePickerFormat.Short;
            dtpFechaFinCambios.Location = new Point(140, 465);
            dtpFechaFinCambios.Name = "dtpFechaFinCambios";
            dtpFechaFinCambios.Size = new Size(170, 23);
            btnAplicarCambios.BackColor = Color.White;
            btnAplicarCambios.ForeColor = Color.DarkGreen;
            btnAplicarCambios.Location = new Point(350, 416);
            btnAplicarCambios.Name = "btnAplicarCambios";
            btnAplicarCambios.Size = new Size(170, 34);
            btnAplicarCambios.Text = "Aplicar";
            btnAplicarCambios.UseVisualStyleBackColor = false;
            btnAplicarCambios.Click += jzat506_btnAplicar_Click;
            btnLimpiarCambios.BackColor = Color.White;
            btnLimpiarCambios.ForeColor = Color.DarkGreen;
            btnLimpiarCambios.Location = new Point(350, 461);
            btnLimpiarCambios.Name = "btnLimpiarCambios";
            btnLimpiarCambios.Size = new Size(170, 34);
            btnLimpiarCambios.Text = "Limpiar";
            btnLimpiarCambios.UseVisualStyleBackColor = false;
            btnLimpiarCambios.Click += jzat506_btnLimpiar_Click;
            btnSalirCambios.BackColor = Color.White;
            btnSalirCambios.ForeColor = Color.DarkGreen;
            btnSalirCambios.Location = new Point(660, 416);
            btnSalirCambios.Name = "btnSalirCambios";
            btnSalirCambios.Size = new Size(170, 34);
            btnSalirCambios.Text = "Salir";
            btnSalirCambios.UseVisualStyleBackColor = false;
            btnSalirCambios.Click += jzat506_btnSalir_Click;
            btnActivarCambios.BackColor = Color.White;
            btnActivarCambios.ForeColor = Color.DarkGreen;
            btnActivarCambios.Location = new Point(660, 461);
            btnActivarCambios.Name = "btnActivarCambios";
            btnActivarCambios.Size = new Size(170, 34);
            btnActivarCambios.Text = "Activar";
            btnActivarCambios.UseVisualStyleBackColor = false;
            btnActivarCambios.Click += jzat506_btnActivar_Click;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 224, 224);
            ClientSize = new Size(1000, 515);
            Controls.Add(lblTituloCambios);
            Controls.Add(dgvVersiones);
            Controls.Add(lblUsuarioCambios);
            Controls.Add(cmbUsuarioCambios);
            Controls.Add(lblNombreCambios);
            Controls.Add(cmbNombreCambios);
            Controls.Add(lblFechaInicioCambios);
            Controls.Add(dtpFechaInicioCambios);
            Controls.Add(lblFechaFinCambios);
            Controls.Add(dtpFechaFinCambios);
            Controls.Add(btnAplicarCambios);
            Controls.Add(btnLimpiarCambios);
            Controls.Add(btnSalirCambios);
            Controls.Add(btnActivarCambios);
            Name = "jzat506_FrmBitacoraCambios";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Bitacora de cambios";
            Load += jzat506_FrmBitacoraCambios_Load;
            FormClosing += jzat506_FrmBitacoraCambios_FormClosing;
            ((System.ComponentModel.ISupportInitialize)dgvVersiones).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTituloCambios;
        private DataGridView dgvVersiones;
        private Label lblUsuarioCambios;
        private ComboBox cmbUsuarioCambios;
        private Label lblNombreCambios;
        private ComboBox cmbNombreCambios;
        private Label lblFechaInicioCambios;
        private DateTimePicker dtpFechaInicioCambios;
        private Label lblFechaFinCambios;
        private DateTimePicker dtpFechaFinCambios;
        private Button btnAplicarCambios;
        private Button btnLimpiarCambios;
        private Button btnSalirCambios;
        private Button btnActivarCambios;
    }
}
