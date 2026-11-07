namespace Oasis_Sports
{
    partial class jzat506_FrmConsultarFacturas
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
            lblTituloFacturas = new Label();
            lblDNIConsulta = new Label();
            txtDNIConsulta = new TextBox();
            btnBuscarFacturas = new Button();
            lblClienteConsulta = new Label();
            lblFacturasCliente = new Label();
            dataGridViewFacturas = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            lblDetalleFactura = new Label();
            dataGridViewDetalleFactura = new DataGridView();
            dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn6 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn7 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn8 = new DataGridViewTextBoxColumn();
            lblTotalSeleccionada = new Label();
            btnExportarPDF = new Button();
            btnExportarExcel = new Button();
            btnVolverFacturas = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewFacturas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewDetalleFactura).BeginInit();
            SuspendLayout();
            // 
            // lblTituloFacturas
            // 
            lblTituloFacturas.AutoSize = true;
            lblTituloFacturas.Font = new Font("Times New Roman", 14F, FontStyle.Bold);
            lblTituloFacturas.ForeColor = Color.DarkGreen;
            lblTituloFacturas.Location = new Point(20, 15);
            lblTituloFacturas.Name = "lblTituloFacturas";
            lblTituloFacturas.Size = new Size(163, 22);
            lblTituloFacturas.TabIndex = 0;
            lblTituloFacturas.Text = "Consultar facturas";
            // 
            // lblDNIConsulta
            // 
            lblDNIConsulta.AutoSize = true;
            lblDNIConsulta.ForeColor = Color.DarkGreen;
            lblDNIConsulta.Location = new Point(20, 65);
            lblDNIConsulta.Name = "lblDNIConsulta";
            lblDNIConsulta.Size = new Size(42, 21);
            lblDNIConsulta.TabIndex = 1;
            lblDNIConsulta.Text = "DNI";
            // 
            // txtDNIConsulta
            // 
            txtDNIConsulta.Location = new Point(113, 62);
            txtDNIConsulta.MaxLength = 8;
            txtDNIConsulta.Name = "txtDNIConsulta";
            txtDNIConsulta.Size = new Size(150, 29);
            txtDNIConsulta.TabIndex = 2;
            txtDNIConsulta.TextChanged += jzat506_txtDNIConsulta_TextChanged;
            txtDNIConsulta.KeyPress += jzat506_SoloDigitos_KeyPress;
            // 
            // btnBuscarFacturas
            // 
            btnBuscarFacturas.BackColor = Color.White;
            btnBuscarFacturas.ForeColor = Color.DarkGreen;
            btnBuscarFacturas.Location = new Point(272, 60);
            btnBuscarFacturas.Name = "btnBuscarFacturas";
            btnBuscarFacturas.Size = new Size(110, 30);
            btnBuscarFacturas.TabIndex = 3;
            btnBuscarFacturas.Text = "Buscar";
            btnBuscarFacturas.UseVisualStyleBackColor = false;
            btnBuscarFacturas.Click += jzat506_btnBuscarFacturas_Click;
            // 
            // lblClienteConsulta
            // 
            lblClienteConsulta.AutoSize = true;
            lblClienteConsulta.ForeColor = Color.DarkGreen;
            lblClienteConsulta.Location = new Point(397, 65);
            lblClienteConsulta.Name = "lblClienteConsulta";
            lblClienteConsulta.Size = new Size(76, 21);
            lblClienteConsulta.TabIndex = 4;
            lblClienteConsulta.Text = "Cliente: -";
            // 
            // lblFacturasCliente
            // 
            lblFacturasCliente.AutoSize = true;
            lblFacturasCliente.ForeColor = Color.DarkGreen;
            lblFacturasCliente.Location = new Point(20, 108);
            lblFacturasCliente.Name = "lblFacturasCliente";
            lblFacturasCliente.Size = new Size(153, 21);
            lblFacturasCliente.TabIndex = 5;
            lblFacturasCliente.Text = "Facturas del cliente";
            // 
            // dataGridViewFacturas
            // 
            dataGridViewFacturas.AllowUserToAddRows = false;
            dataGridViewFacturas.AllowUserToDeleteRows = false;
            dataGridViewFacturas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewFacturas.BackgroundColor = Color.White;
            dataGridViewFacturas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewFacturas.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4 });
            dataGridViewFacturas.Location = new Point(20, 135);
            dataGridViewFacturas.MultiSelect = false;
            dataGridViewFacturas.Name = "dataGridViewFacturas";
            dataGridViewFacturas.ReadOnly = true;
            dataGridViewFacturas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewFacturas.Size = new Size(820, 170);
            dataGridViewFacturas.TabIndex = 6;
            dataGridViewFacturas.SelectionChanged += jzat506_dataGridViewFacturas_SelectionChanged;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.HeaderText = "N° factura";
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
            dataGridViewTextBoxColumn3.HeaderText = "Medio de pago";
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.HeaderText = "Total";
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // lblDetalleFactura
            // 
            lblDetalleFactura.AutoSize = true;
            lblDetalleFactura.ForeColor = Color.DarkGreen;
            lblDetalleFactura.Location = new Point(20, 318);
            lblDetalleFactura.Name = "lblDetalleFactura";
            lblDetalleFactura.Size = new Size(256, 21);
            lblDetalleFactura.TabIndex = 7;
            lblDetalleFactura.Text = "Detalle de la factura seleccionada";
            // 
            // dataGridViewDetalleFactura
            // 
            dataGridViewDetalleFactura.AllowUserToAddRows = false;
            dataGridViewDetalleFactura.AllowUserToDeleteRows = false;
            dataGridViewDetalleFactura.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewDetalleFactura.BackgroundColor = Color.White;
            dataGridViewDetalleFactura.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewDetalleFactura.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn5, dataGridViewTextBoxColumn6, dataGridViewTextBoxColumn7, dataGridViewTextBoxColumn8 });
            dataGridViewDetalleFactura.Location = new Point(20, 345);
            dataGridViewDetalleFactura.Name = "dataGridViewDetalleFactura";
            dataGridViewDetalleFactura.ReadOnly = true;
            dataGridViewDetalleFactura.Size = new Size(820, 150);
            dataGridViewDetalleFactura.TabIndex = 8;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewTextBoxColumn5.HeaderText = "Producto";
            dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            dataGridViewTextBoxColumn6.HeaderText = "Cantidad";
            dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            dataGridViewTextBoxColumn7.HeaderText = "Precio unitario";
            dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            dataGridViewTextBoxColumn8.HeaderText = "Subtotal";
            dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // lblTotalSeleccionada
            // 
            lblTotalSeleccionada.AutoSize = true;
            lblTotalSeleccionada.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            lblTotalSeleccionada.ForeColor = Color.DarkGreen;
            lblTotalSeleccionada.Location = new Point(20, 505);
            lblTotalSeleccionada.Name = "lblTotalSeleccionada";
            lblTotalSeleccionada.Size = new Size(68, 19);
            lblTotalSeleccionada.TabIndex = 9;
            lblTotalSeleccionada.Text = "Total: $0";
            // 
            // btnExportarPDF
            // 
            btnExportarPDF.BackColor = Color.White;
            btnExportarPDF.ForeColor = Color.DarkGreen;
            btnExportarPDF.Location = new Point(20, 545);
            btnExportarPDF.Name = "btnExportarPDF";
            btnExportarPDF.Size = new Size(260, 35);
            btnExportarPDF.TabIndex = 10;
            btnExportarPDF.Text = "Exportar factura a PDF";
            btnExportarPDF.UseVisualStyleBackColor = false;
            btnExportarPDF.Click += jzat506_btnExportarPDF_Click;
            // 
            // btnExportarExcel
            // 
            btnExportarExcel.BackColor = Color.White;
            btnExportarExcel.ForeColor = Color.DarkGreen;
            btnExportarExcel.Location = new Point(295, 545);
            btnExportarExcel.Name = "btnExportarExcel";
            btnExportarExcel.Size = new Size(280, 35);
            btnExportarExcel.TabIndex = 11;
            btnExportarExcel.Text = "Exportar listado a Excel";
            btnExportarExcel.UseVisualStyleBackColor = false;
            btnExportarExcel.Click += jzat506_btnExportarExcel_Click;
            // 
            // btnVolverFacturas
            // 
            btnVolverFacturas.BackColor = Color.White;
            btnVolverFacturas.ForeColor = Color.DarkGreen;
            btnVolverFacturas.Location = new Point(740, 545);
            btnVolverFacturas.Name = "btnVolverFacturas";
            btnVolverFacturas.Size = new Size(100, 35);
            btnVolverFacturas.TabIndex = 12;
            btnVolverFacturas.Text = "Volver";
            btnVolverFacturas.UseVisualStyleBackColor = false;
            btnVolverFacturas.Click += jzat506_btnVolverFacturas_Click;
            // 
            // jzat506_FrmConsultarFacturas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 224, 224);
            ClientSize = new Size(860, 600);
            Controls.Add(lblTituloFacturas);
            Controls.Add(lblDNIConsulta);
            Controls.Add(txtDNIConsulta);
            Controls.Add(btnBuscarFacturas);
            Controls.Add(lblClienteConsulta);
            Controls.Add(lblFacturasCliente);
            Controls.Add(dataGridViewFacturas);
            Controls.Add(lblDetalleFactura);
            Controls.Add(dataGridViewDetalleFactura);
            Controls.Add(lblTotalSeleccionada);
            Controls.Add(btnExportarPDF);
            Controls.Add(btnExportarExcel);
            Controls.Add(btnVolverFacturas);
            Name = "jzat506_FrmConsultarFacturas";
            Text = "Consultar facturas";
            FormClosing += jzat506_FrmConsultarFacturas_FormClosing;
            Load += jzat506_FrmConsultarFacturas_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewFacturas).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewDetalleFactura).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTituloFacturas;
        private Label lblDNIConsulta;
        private TextBox txtDNIConsulta;
        private Button btnBuscarFacturas;
        private Label lblClienteConsulta;
        private Label lblFacturasCliente;
        private DataGridView dataGridViewFacturas;
        private Label lblDetalleFactura;
        private DataGridView dataGridViewDetalleFactura;
        private Label lblTotalSeleccionada;
        private Button btnExportarPDF;
        private Button btnExportarExcel;
        private Button btnVolverFacturas;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
    }
}
