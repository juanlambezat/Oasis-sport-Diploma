namespace Oasis_Sports
{
    partial class jzat506_FrmRegistrarEnvio
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
            lblTituloEnvio = new Label();
            lblDNIEnvio = new Label();
            txtDNI = new TextBox();
            btnBuscarCliente = new Button();
            lblClienteEnvio = new Label();
            lblFacturasEnvio = new Label();
            dgvFacturas = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            lblZonaEnvio = new Label();
            cmbZona = new ComboBox();
            lblCostoTexto = new Label();
            lblCostoValor = new Label();
            lblDireccionEnvio = new Label();
            txtDireccion = new TextBox();
            lblTelefonoEnvio = new Label();
            txtTelefono = new TextBox();
            btnConfirmarEnvio = new Button();
            btnVolverEnvios = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvFacturas).BeginInit();
            SuspendLayout();
            // 
            // lblTituloEnvio
            // 
            lblTituloEnvio.AutoSize = true;
            lblTituloEnvio.Font = new Font("Times New Roman", 14F, FontStyle.Bold);
            lblTituloEnvio.ForeColor = Color.DarkGreen;
            lblTituloEnvio.Location = new Point(20, 15);
            lblTituloEnvio.Name = "lblTituloEnvio";
            lblTituloEnvio.Size = new Size(136, 22);
            lblTituloEnvio.TabIndex = 0;
            lblTituloEnvio.Text = "Registrar envio";
            // 
            // lblDNIEnvio
            // 
            lblDNIEnvio.AutoSize = true;
            lblDNIEnvio.ForeColor = Color.DarkGreen;
            lblDNIEnvio.Location = new Point(20, 65);
            lblDNIEnvio.Name = "lblDNIEnvio";
            lblDNIEnvio.Size = new Size(42, 21);
            lblDNIEnvio.TabIndex = 1;
            lblDNIEnvio.Text = "DNI";
            // 
            // txtDNI
            // 
            txtDNI.Location = new Point(118, 62);
            txtDNI.MaxLength = 8;
            txtDNI.Name = "txtDNI";
            txtDNI.Size = new Size(150, 29);
            txtDNI.TabIndex = 2;
            txtDNI.KeyPress += jzat506_SoloDigitos_KeyPress;
            // 
            // btnBuscarCliente
            // 
            btnBuscarCliente.BackColor = Color.White;
            btnBuscarCliente.ForeColor = Color.DarkGreen;
            btnBuscarCliente.Location = new Point(284, 60);
            btnBuscarCliente.Name = "btnBuscarCliente";
            btnBuscarCliente.Size = new Size(90, 30);
            btnBuscarCliente.TabIndex = 3;
            btnBuscarCliente.Text = "Buscar";
            btnBuscarCliente.UseVisualStyleBackColor = false;
            btnBuscarCliente.Click += jzat506_btnBuscarCliente_Click;
            // 
            // lblClienteEnvio
            // 
            lblClienteEnvio.AutoSize = true;
            lblClienteEnvio.ForeColor = Color.DarkGreen;
            lblClienteEnvio.Location = new Point(350, 65);
            lblClienteEnvio.Name = "lblClienteEnvio";
            lblClienteEnvio.Size = new Size(0, 21);
            lblClienteEnvio.TabIndex = 4;
            // 
            // lblFacturasEnvio
            // 
            lblFacturasEnvio.AutoSize = true;
            lblFacturasEnvio.ForeColor = Color.DarkGreen;
            lblFacturasEnvio.Location = new Point(20, 105);
            lblFacturasEnvio.Name = "lblFacturasEnvio";
            lblFacturasEnvio.Size = new Size(145, 21);
            lblFacturasEnvio.TabIndex = 5;
            lblFacturasEnvio.Text = "Facturas sin envio";
            // 
            // dgvFacturas
            // 
            dgvFacturas.AllowUserToAddRows = false;
            dgvFacturas.AllowUserToDeleteRows = false;
            dgvFacturas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvFacturas.BackgroundColor = Color.White;
            dgvFacturas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFacturas.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4 });
            dgvFacturas.Location = new Point(20, 130);
            dgvFacturas.MultiSelect = false;
            dgvFacturas.Name = "dgvFacturas";
            dgvFacturas.ReadOnly = true;
            dgvFacturas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvFacturas.Size = new Size(700, 130);
            dgvFacturas.TabIndex = 6;
            dgvFacturas.SelectionChanged += jzat506_dgvFacturas_SelectionChanged;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.HeaderText = "Numero";
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
            // lblZonaEnvio
            // 
            lblZonaEnvio.AutoSize = true;
            lblZonaEnvio.ForeColor = Color.DarkGreen;
            lblZonaEnvio.Location = new Point(20, 285);
            lblZonaEnvio.Name = "lblZonaEnvio";
            lblZonaEnvio.Size = new Size(147, 21);
            lblZonaEnvio.TabIndex = 7;
            lblZonaEnvio.Text = "Zona de cobertura";
            // 
            // cmbZona
            // 
            cmbZona.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbZona.Location = new Point(200, 282);
            cmbZona.Name = "cmbZona";
            cmbZona.Size = new Size(240, 29);
            cmbZona.TabIndex = 8;
            cmbZona.SelectedIndexChanged += jzat506_cmbZona_SelectedIndexChanged;
            // 
            // lblCostoTexto
            // 
            lblCostoTexto.AutoSize = true;
            lblCostoTexto.ForeColor = Color.DarkGreen;
            lblCostoTexto.Location = new Point(470, 285);
            lblCostoTexto.Name = "lblCostoTexto";
            lblCostoTexto.Size = new Size(132, 21);
            lblCostoTexto.TabIndex = 9;
            lblCostoTexto.Text = "Costo del envio:";
            // 
            // lblCostoValor
            // 
            lblCostoValor.AutoSize = true;
            lblCostoValor.Font = new Font("Times New Roman", 11F, FontStyle.Bold);
            lblCostoValor.ForeColor = Color.DarkGreen;
            lblCostoValor.Location = new Point(610, 283);
            lblCostoValor.Name = "lblCostoValor";
            lblCostoValor.Size = new Size(0, 17);
            lblCostoValor.TabIndex = 10;
            // 
            // lblDireccionEnvio
            // 
            lblDireccionEnvio.AutoSize = true;
            lblDireccionEnvio.ForeColor = Color.DarkGreen;
            lblDireccionEnvio.Location = new Point(20, 330);
            lblDireccionEnvio.Name = "lblDireccionEnvio";
            lblDireccionEnvio.Size = new Size(163, 21);
            lblDireccionEnvio.TabIndex = 11;
            lblDireccionEnvio.Text = "Direccion de entrega";
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(200, 327);
            txtDireccion.MaxLength = 150;
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(400, 29);
            txtDireccion.TabIndex = 12;
            // 
            // lblTelefonoEnvio
            // 
            lblTelefonoEnvio.AutoSize = true;
            lblTelefonoEnvio.ForeColor = Color.DarkGreen;
            lblTelefonoEnvio.Location = new Point(20, 372);
            lblTelefonoEnvio.Name = "lblTelefonoEnvio";
            lblTelefonoEnvio.Size = new Size(169, 21);
            lblTelefonoEnvio.TabIndex = 13;
            lblTelefonoEnvio.Text = "Telefono de contacto";
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(200, 369);
            txtTelefono.MaxLength = 15;
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(200, 29);
            txtTelefono.TabIndex = 14;
            txtTelefono.KeyPress += jzat506_SoloDigitos_KeyPress;
            // 
            // btnConfirmarEnvio
            // 
            btnConfirmarEnvio.BackColor = Color.White;
            btnConfirmarEnvio.ForeColor = Color.DarkGreen;
            btnConfirmarEnvio.Location = new Point(440, 420);
            btnConfirmarEnvio.Name = "btnConfirmarEnvio";
            btnConfirmarEnvio.Size = new Size(160, 32);
            btnConfirmarEnvio.TabIndex = 15;
            btnConfirmarEnvio.Text = "Confirmar envio";
            btnConfirmarEnvio.UseVisualStyleBackColor = false;
            btnConfirmarEnvio.Click += jzat506_btnConfirmar_Click;
            // 
            // btnVolverEnvios
            // 
            btnVolverEnvios.BackColor = Color.White;
            btnVolverEnvios.ForeColor = Color.DarkGreen;
            btnVolverEnvios.Location = new Point(620, 420);
            btnVolverEnvios.Name = "btnVolverEnvios";
            btnVolverEnvios.Size = new Size(100, 32);
            btnVolverEnvios.TabIndex = 16;
            btnVolverEnvios.Text = "Volver";
            btnVolverEnvios.UseVisualStyleBackColor = false;
            btnVolverEnvios.Click += jzat506_btnVolverEnvios_Click;
            // 
            // jzat506_FrmRegistrarEnvio
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 224, 224);
            ClientSize = new Size(742, 475);
            Controls.Add(lblTituloEnvio);
            Controls.Add(lblDNIEnvio);
            Controls.Add(txtDNI);
            Controls.Add(btnBuscarCliente);
            Controls.Add(lblClienteEnvio);
            Controls.Add(lblFacturasEnvio);
            Controls.Add(dgvFacturas);
            Controls.Add(lblZonaEnvio);
            Controls.Add(cmbZona);
            Controls.Add(lblCostoTexto);
            Controls.Add(lblCostoValor);
            Controls.Add(lblDireccionEnvio);
            Controls.Add(txtDireccion);
            Controls.Add(lblTelefonoEnvio);
            Controls.Add(txtTelefono);
            Controls.Add(btnConfirmarEnvio);
            Controls.Add(btnVolverEnvios);
            Name = "jzat506_FrmRegistrarEnvio";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Envios";
            FormClosing += jzat506_FrmRegistrarEnvio_FormClosing;
            Load += jzat506_FrmRegistrarEnvio_Load;
            ((System.ComponentModel.ISupportInitialize)dgvFacturas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTituloEnvio;
        private Label lblDNIEnvio;
        private TextBox txtDNI;
        private Button btnBuscarCliente;
        private Label lblClienteEnvio;
        private Label lblFacturasEnvio;
        private DataGridView dgvFacturas;
        private Label lblZonaEnvio;
        private ComboBox cmbZona;
        private Label lblCostoTexto;
        private Label lblCostoValor;
        private Label lblDireccionEnvio;
        private TextBox txtDireccion;
        private Label lblTelefonoEnvio;
        private TextBox txtTelefono;
        private Button btnConfirmarEnvio;
        private Button btnVolverEnvios;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
    }
}
