namespace Oasis_Sports
{
    partial class jzat506_FrmReporteEnvios
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
            lblTituloReporte = new Label();
            lblDesdeReporte = new Label();
            dtpDesde = new DateTimePicker();
            lblHastaReporte = new Label();
            dtpHasta = new DateTimePicker();
            lblEstadoReporte = new Label();
            cmbEstado = new ComboBox();
            lblZonaReporte = new Label();
            cmbZonaReporte = new ComboBox();
            btnBuscarEnvios = new Button();
            dgvEnvios = new DataGridView();
            lblResumenEnvios = new Label();
            btnExportarPDFEnvios = new Button();
            btnExportarExcelEnvios = new Button();
            btnVolverReporte = new Button();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn6 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn7 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn8 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn9 = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvEnvios).BeginInit();
            SuspendLayout();
            // 
            // lblTituloReporte
            // 
            lblTituloReporte.AutoSize = true;
            lblTituloReporte.Font = new Font("Times New Roman", 14F, FontStyle.Bold);
            lblTituloReporte.ForeColor = Color.DarkGreen;
            lblTituloReporte.Location = new Point(20, 15);
            lblTituloReporte.Name = "lblTituloReporte";
            lblTituloReporte.Size = new Size(156, 22);
            lblTituloReporte.TabIndex = 0;
            lblTituloReporte.Text = "Reporte de envios";
            // 
            // lblDesdeReporte
            // 
            lblDesdeReporte.AutoSize = true;
            lblDesdeReporte.ForeColor = Color.DarkGreen;
            lblDesdeReporte.Location = new Point(20, 65);
            lblDesdeReporte.Name = "lblDesdeReporte";
            lblDesdeReporte.Size = new Size(57, 21);
            lblDesdeReporte.TabIndex = 1;
            lblDesdeReporte.Text = "Desde";
            // 
            // dtpDesde
            // 
            dtpDesde.Format = DateTimePickerFormat.Short;
            dtpDesde.Location = new Point(88, 62);
            dtpDesde.Name = "dtpDesde";
            dtpDesde.Size = new Size(110, 29);
            dtpDesde.TabIndex = 2;
            // 
            // lblHastaReporte
            // 
            lblHastaReporte.AutoSize = true;
            lblHastaReporte.ForeColor = Color.DarkGreen;
            lblHastaReporte.Location = new Point(205, 65);
            lblHastaReporte.Name = "lblHastaReporte";
            lblHastaReporte.Size = new Size(52, 21);
            lblHastaReporte.TabIndex = 3;
            lblHastaReporte.Text = "Hasta";
            // 
            // dtpHasta
            // 
            dtpHasta.Format = DateTimePickerFormat.Short;
            dtpHasta.Location = new Point(270, 62);
            dtpHasta.Name = "dtpHasta";
            dtpHasta.Size = new Size(110, 29);
            dtpHasta.TabIndex = 4;
            // 
            // lblEstadoReporte
            // 
            lblEstadoReporte.AutoSize = true;
            lblEstadoReporte.ForeColor = Color.DarkGreen;
            lblEstadoReporte.Location = new Point(390, 65);
            lblEstadoReporte.Name = "lblEstadoReporte";
            lblEstadoReporte.Size = new Size(62, 21);
            lblEstadoReporte.TabIndex = 5;
            lblEstadoReporte.Text = "Estado";
            // 
            // cmbEstado
            // 
            cmbEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEstado.Location = new Point(465, 62);
            cmbEstado.Name = "cmbEstado";
            cmbEstado.Size = new Size(130, 29);
            cmbEstado.TabIndex = 6;
            // 
            // lblZonaReporte
            // 
            lblZonaReporte.AutoSize = true;
            lblZonaReporte.ForeColor = Color.DarkGreen;
            lblZonaReporte.Location = new Point(605, 65);
            lblZonaReporte.Name = "lblZonaReporte";
            lblZonaReporte.Size = new Size(48, 21);
            lblZonaReporte.TabIndex = 7;
            lblZonaReporte.Text = "Zona";
            // 
            // cmbZonaReporte
            // 
            cmbZonaReporte.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbZonaReporte.Location = new Point(667, 62);
            cmbZonaReporte.Name = "cmbZonaReporte";
            cmbZonaReporte.Size = new Size(180, 29);
            cmbZonaReporte.TabIndex = 8;
            // 
            // btnBuscarEnvios
            // 
            btnBuscarEnvios.BackColor = Color.White;
            btnBuscarEnvios.ForeColor = Color.DarkGreen;
            btnBuscarEnvios.Location = new Point(20, 105);
            btnBuscarEnvios.Name = "btnBuscarEnvios";
            btnBuscarEnvios.Size = new Size(100, 30);
            btnBuscarEnvios.TabIndex = 9;
            btnBuscarEnvios.Text = "Buscar";
            btnBuscarEnvios.UseVisualStyleBackColor = false;
            btnBuscarEnvios.Click += jzat506_btnBuscarEnvios_Click;
            // 
            // dgvEnvios
            // 
            dgvEnvios.AllowUserToAddRows = false;
            dgvEnvios.AllowUserToDeleteRows = false;
            dgvEnvios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEnvios.BackgroundColor = Color.White;
            dgvEnvios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEnvios.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4, dataGridViewTextBoxColumn5, dataGridViewTextBoxColumn6, dataGridViewTextBoxColumn7, dataGridViewTextBoxColumn8, dataGridViewTextBoxColumn9 });
            dgvEnvios.Location = new Point(20, 150);
            dgvEnvios.Name = "dgvEnvios";
            dgvEnvios.ReadOnly = true;
            dgvEnvios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEnvios.Size = new Size(955, 230);
            dgvEnvios.TabIndex = 10;
            // 
            // lblResumenEnvios
            // 
            lblResumenEnvios.Font = new Font("Times New Roman", 11F, FontStyle.Bold);
            lblResumenEnvios.ForeColor = Color.DarkGreen;
            lblResumenEnvios.Location = new Point(20, 390);
            lblResumenEnvios.Name = "lblResumenEnvios";
            lblResumenEnvios.Size = new Size(955, 70);
            lblResumenEnvios.TabIndex = 11;
            // 
            // btnExportarPDFEnvios
            // 
            btnExportarPDFEnvios.BackColor = Color.White;
            btnExportarPDFEnvios.ForeColor = Color.DarkGreen;
            btnExportarPDFEnvios.Location = new Point(545, 475);
            btnExportarPDFEnvios.Name = "btnExportarPDFEnvios";
            btnExportarPDFEnvios.Size = new Size(140, 32);
            btnExportarPDFEnvios.TabIndex = 12;
            btnExportarPDFEnvios.Text = "Exportar a PDF";
            btnExportarPDFEnvios.UseVisualStyleBackColor = false;
            btnExportarPDFEnvios.Click += jzat506_btnExportarPDF_Click;
            // 
            // btnExportarExcelEnvios
            // 
            btnExportarExcelEnvios.BackColor = Color.White;
            btnExportarExcelEnvios.ForeColor = Color.DarkGreen;
            btnExportarExcelEnvios.Location = new Point(695, 475);
            btnExportarExcelEnvios.Name = "btnExportarExcelEnvios";
            btnExportarExcelEnvios.Size = new Size(160, 32);
            btnExportarExcelEnvios.TabIndex = 13;
            btnExportarExcelEnvios.Text = "Exportar a Excel";
            btnExportarExcelEnvios.UseVisualStyleBackColor = false;
            btnExportarExcelEnvios.Click += jzat506_btnExportarExcel_Click;
            // 
            // btnVolverReporte
            // 
            btnVolverReporte.BackColor = Color.White;
            btnVolverReporte.ForeColor = Color.DarkGreen;
            btnVolverReporte.Location = new Point(875, 475);
            btnVolverReporte.Name = "btnVolverReporte";
            btnVolverReporte.Size = new Size(100, 32);
            btnVolverReporte.TabIndex = 14;
            btnVolverReporte.Text = "Volver";
            btnVolverReporte.UseVisualStyleBackColor = false;
            btnVolverReporte.Click += jzat506_btnVolverReporte_Click;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.HeaderText = "Pedido";
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.HeaderText = "Fecha";
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.HeaderText = "Cliente";
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.HeaderText = "Factura";
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewTextBoxColumn5.HeaderText = "Zona";
            dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            dataGridViewTextBoxColumn6.HeaderText = "Estado";
            dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            dataGridViewTextBoxColumn7.HeaderText = "Costo";
            dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            dataGridViewTextBoxColumn8.HeaderText = "Medio de pago";
            dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn9
            // 
            dataGridViewTextBoxColumn9.HeaderText = "Transportista";
            dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            dataGridViewTextBoxColumn9.ReadOnly = true;
            // 
            // jzat506_FrmReporteEnvios
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 224, 224);
            ClientSize = new Size(997, 525);
            Controls.Add(lblTituloReporte);
            Controls.Add(lblDesdeReporte);
            Controls.Add(dtpDesde);
            Controls.Add(lblHastaReporte);
            Controls.Add(dtpHasta);
            Controls.Add(lblEstadoReporte);
            Controls.Add(cmbEstado);
            Controls.Add(lblZonaReporte);
            Controls.Add(cmbZonaReporte);
            Controls.Add(btnBuscarEnvios);
            Controls.Add(dgvEnvios);
            Controls.Add(lblResumenEnvios);
            Controls.Add(btnExportarPDFEnvios);
            Controls.Add(btnExportarExcelEnvios);
            Controls.Add(btnVolverReporte);
            Name = "jzat506_FrmReporteEnvios";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Reporte de envios";
            FormClosing += jzat506_FrmReporteEnvios_FormClosing;
            Load += jzat506_FrmReporteEnvios_Load;
            ((System.ComponentModel.ISupportInitialize)dgvEnvios).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTituloReporte;
        private Label lblDesdeReporte;
        private DateTimePicker dtpDesde;
        private Label lblHastaReporte;
        private DateTimePicker dtpHasta;
        private Label lblEstadoReporte;
        private ComboBox cmbEstado;
        private Label lblZonaReporte;
        private ComboBox cmbZonaReporte;
        private Button btnBuscarEnvios;
        private DataGridView dgvEnvios;
        private Label lblResumenEnvios;
        private Button btnExportarPDFEnvios;
        private Button btnExportarExcelEnvios;
        private Button btnVolverReporte;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
    }
}


