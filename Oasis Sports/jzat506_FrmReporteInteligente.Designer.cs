namespace Oasis_Sports
{
    partial class jzat506_FrmReporteInteligente
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
            lblTituloInteligente = new Label();
            lblDesdeInteligente = new Label();
            dtpDesdeInteligente = new DateTimePicker();
            lblHastaInteligente = new Label();
            dtpHastaInteligente = new DateTimePicker();
            btnAnalizar = new Button();
            lblComparacion = new Label();
            lblIndicadores = new Label();
            dgvIndicadores = new DataGridView();
            colIndicador = new DataGridViewTextBoxColumn();
            colPeriodoElegido = new DataGridViewTextBoxColumn();
            colPeriodoAnterior = new DataGridViewTextBoxColumn();
            colVariacion = new DataGridViewTextBoxColumn();
            lblConclusiones = new Label();
            txtConclusiones = new TextBox();
            btnExportarPDFInteligente = new Button();
            btnVolverInteligente = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvIndicadores).BeginInit();
            SuspendLayout();
            lblTituloInteligente.AutoSize = true;
            lblTituloInteligente.Font = new Font("Times New Roman", 14F, FontStyle.Bold);
            lblTituloInteligente.ForeColor = Color.DarkGreen;
            lblTituloInteligente.Location = new Point(20, 15);
            lblTituloInteligente.Name = "lblTituloInteligente";
            lblTituloInteligente.Size = new Size(176, 22);
            lblTituloInteligente.TabIndex = 0;
            lblTituloInteligente.Text = "Reporte inteligente";
            lblDesdeInteligente.AutoSize = true;
            lblDesdeInteligente.ForeColor = Color.DarkGreen;
            lblDesdeInteligente.Location = new Point(20, 65);
            lblDesdeInteligente.Name = "lblDesdeInteligente";
            lblDesdeInteligente.Size = new Size(57, 21);
            lblDesdeInteligente.TabIndex = 1;
            lblDesdeInteligente.Text = "Desde";
            dtpDesdeInteligente.Format = DateTimePickerFormat.Short;
            dtpDesdeInteligente.Location = new Point(88, 62);
            dtpDesdeInteligente.Name = "dtpDesdeInteligente";
            dtpDesdeInteligente.Size = new Size(120, 29);
            dtpDesdeInteligente.TabIndex = 2;
            lblHastaInteligente.AutoSize = true;
            lblHastaInteligente.ForeColor = Color.DarkGreen;
            lblHastaInteligente.Location = new Point(222, 65);
            lblHastaInteligente.Name = "lblHastaInteligente";
            lblHastaInteligente.Size = new Size(52, 21);
            lblHastaInteligente.TabIndex = 3;
            lblHastaInteligente.Text = "Hasta";
            dtpHastaInteligente.Format = DateTimePickerFormat.Short;
            dtpHastaInteligente.Location = new Point(285, 62);
            dtpHastaInteligente.Name = "dtpHastaInteligente";
            dtpHastaInteligente.Size = new Size(120, 29);
            dtpHastaInteligente.TabIndex = 4;
            btnAnalizar.BackColor = Color.White;
            btnAnalizar.ForeColor = Color.DarkGreen;
            btnAnalizar.Location = new Point(422, 61);
            btnAnalizar.Name = "btnAnalizar";
            btnAnalizar.Size = new Size(110, 31);
            btnAnalizar.TabIndex = 5;
            btnAnalizar.Text = "Analizar";
            btnAnalizar.UseVisualStyleBackColor = false;
            btnAnalizar.Click += jzat506_btnAnalizar_Click;
            lblComparacion.AutoSize = true;
            lblComparacion.Font = new Font("Times New Roman", 11F, FontStyle.Italic);
            lblComparacion.ForeColor = Color.DarkGreen;
            lblComparacion.Location = new Point(548, 68);
            lblComparacion.Name = "lblComparacion";
            lblComparacion.Size = new Size(0, 17);
            lblComparacion.TabIndex = 6;
            lblIndicadores.AutoSize = true;
            lblIndicadores.Font = new Font("Times New Roman", 14F, FontStyle.Bold);
            lblIndicadores.ForeColor = Color.DarkGreen;
            lblIndicadores.Location = new Point(20, 105);
            lblIndicadores.Name = "lblIndicadores";
            lblIndicadores.Size = new Size(106, 22);
            lblIndicadores.TabIndex = 7;
            lblIndicadores.Text = "Indicadores";
            dgvIndicadores.AllowUserToAddRows = false;
            dgvIndicadores.AllowUserToDeleteRows = false;
            dgvIndicadores.AllowUserToResizeRows = false;
            dgvIndicadores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvIndicadores.BackgroundColor = Color.White;
            dgvIndicadores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvIndicadores.Columns.AddRange(new DataGridViewColumn[] { colIndicador, colPeriodoElegido, colPeriodoAnterior, colVariacion });
            dgvIndicadores.Location = new Point(20, 135);
            dgvIndicadores.Name = "dgvIndicadores";
            dgvIndicadores.ReadOnly = true;
            dgvIndicadores.RowHeadersVisible = false;
            dgvIndicadores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvIndicadores.ScrollBars = ScrollBars.None;
            dgvIndicadores.Size = new Size(955, 134);
            dgvIndicadores.TabIndex = 8;
            colIndicador.HeaderText = "Indicador";
            colIndicador.Name = "colIndicador";
            colIndicador.ReadOnly = true;
            colPeriodoElegido.HeaderText = "Período elegido";
            colPeriodoElegido.Name = "colPeriodoElegido";
            colPeriodoElegido.ReadOnly = true;
            colPeriodoAnterior.HeaderText = "Período anterior";
            colPeriodoAnterior.Name = "colPeriodoAnterior";
            colPeriodoAnterior.ReadOnly = true;
            colVariacion.HeaderText = "Variación";
            colVariacion.Name = "colVariacion";
            colVariacion.ReadOnly = true;
            lblConclusiones.AutoSize = true;
            lblConclusiones.Font = new Font("Times New Roman", 14F, FontStyle.Bold);
            lblConclusiones.ForeColor = Color.DarkGreen;
            lblConclusiones.Location = new Point(20, 281);
            lblConclusiones.Name = "lblConclusiones";
            lblConclusiones.Size = new Size(283, 22);
            lblConclusiones.TabIndex = 9;
            lblConclusiones.Text = "Conclusiones y recomendaciones";
            txtConclusiones.BackColor = Color.White;
            txtConclusiones.Font = new Font("Times New Roman", 12F);
            txtConclusiones.Location = new Point(20, 311);
            txtConclusiones.Multiline = true;
            txtConclusiones.Name = "txtConclusiones";
            txtConclusiones.ReadOnly = true;
            txtConclusiones.ScrollBars = ScrollBars.Vertical;
            txtConclusiones.Size = new Size(955, 151);
            txtConclusiones.TabIndex = 10;
            btnExportarPDFInteligente.BackColor = Color.White;
            btnExportarPDFInteligente.ForeColor = Color.DarkGreen;
            btnExportarPDFInteligente.Location = new Point(725, 475);
            btnExportarPDFInteligente.Name = "btnExportarPDFInteligente";
            btnExportarPDFInteligente.Size = new Size(140, 32);
            btnExportarPDFInteligente.TabIndex = 11;
            btnExportarPDFInteligente.Text = "Exportar a PDF";
            btnExportarPDFInteligente.UseVisualStyleBackColor = false;
            btnExportarPDFInteligente.Click += jzat506_btnExportarPDFInteligente_Click;
            btnVolverInteligente.BackColor = Color.White;
            btnVolverInteligente.ForeColor = Color.DarkGreen;
            btnVolverInteligente.Location = new Point(875, 475);
            btnVolverInteligente.Name = "btnVolverInteligente";
            btnVolverInteligente.Size = new Size(100, 32);
            btnVolverInteligente.TabIndex = 12;
            btnVolverInteligente.Text = "Volver";
            btnVolverInteligente.UseVisualStyleBackColor = false;
            btnVolverInteligente.Click += jzat506_btnVolverInteligente_Click;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 224, 224);
            ClientSize = new Size(997, 525);
            Controls.Add(lblTituloInteligente);
            Controls.Add(lblDesdeInteligente);
            Controls.Add(dtpDesdeInteligente);
            Controls.Add(lblHastaInteligente);
            Controls.Add(dtpHastaInteligente);
            Controls.Add(btnAnalizar);
            Controls.Add(lblComparacion);
            Controls.Add(lblIndicadores);
            Controls.Add(dgvIndicadores);
            Controls.Add(lblConclusiones);
            Controls.Add(txtConclusiones);
            Controls.Add(btnExportarPDFInteligente);
            Controls.Add(btnVolverInteligente);
            Name = "jzat506_FrmReporteInteligente";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Reporte inteligente";
            FormClosing += jzat506_FrmReporteInteligente_FormClosing;
            Load += jzat506_FrmReporteInteligente_Load;
            ((System.ComponentModel.ISupportInitialize)dgvIndicadores).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTituloInteligente;
        private Label lblDesdeInteligente;
        private DateTimePicker dtpDesdeInteligente;
        private Label lblHastaInteligente;
        private DateTimePicker dtpHastaInteligente;
        private Button btnAnalizar;
        private Label lblComparacion;
        private Label lblIndicadores;
        private DataGridView dgvIndicadores;
        private DataGridViewTextBoxColumn colIndicador;
        private DataGridViewTextBoxColumn colPeriodoElegido;
        private DataGridViewTextBoxColumn colPeriodoAnterior;
        private DataGridViewTextBoxColumn colVariacion;
        private Label lblConclusiones;
        private TextBox txtConclusiones;
        private Button btnExportarPDFInteligente;
        private Button btnVolverInteligente;
    }
}
