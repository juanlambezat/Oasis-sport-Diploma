namespace Oasis_Sports
{
    partial class jzat506_FrmGenerarFactura
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
            lblTituloFactura = new Label();
            lblDNIVenta = new Label();
            txtDNI = new TextBox();
            btnBuscarCliente = new Button();
            lblClienteInfo = new Label();
            btnSeleccionarProductos = new Button();
            dataGridViewCarrito = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            lblTotalCarrito = new Label();
            btnCobrarVenta = new Button();
            lblEstadoPago = new Label();
            btnGenerar = new Button();
            btnVolverVentas = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCarrito).BeginInit();
            SuspendLayout();
            // 
            // lblTituloFactura
            // 
            lblTituloFactura.AutoSize = true;
            lblTituloFactura.Font = new Font("Times New Roman", 14F, FontStyle.Bold);
            lblTituloFactura.ForeColor = Color.DarkGreen;
            lblTituloFactura.Location = new Point(20, 15);
            lblTituloFactura.Name = "lblTituloFactura";
            lblTituloFactura.Size = new Size(143, 22);
            lblTituloFactura.TabIndex = 0;
            lblTituloFactura.Text = "Generar factura";
            // 
            // lblDNIVenta
            // 
            lblDNIVenta.AutoSize = true;
            lblDNIVenta.ForeColor = Color.DarkGreen;
            lblDNIVenta.Location = new Point(20, 65);
            lblDNIVenta.Name = "lblDNIVenta";
            lblDNIVenta.Size = new Size(42, 21);
            lblDNIVenta.TabIndex = 1;
            lblDNIVenta.Text = "DNI";
            // 
            // txtDNI
            // 
            txtDNI.Location = new Point(117, 62);
            txtDNI.MaxLength = 8;
            txtDNI.Name = "txtDNI";
            txtDNI.Size = new Size(150, 29);
            txtDNI.TabIndex = 2;
            txtDNI.TextChanged += jzat506_txtDNI_TextChanged;
            txtDNI.KeyPress += jzat506_SoloDigitos_KeyPress;
            // 
            // btnBuscarCliente
            // 
            btnBuscarCliente.BackColor = Color.White;
            btnBuscarCliente.ForeColor = Color.DarkGreen;
            btnBuscarCliente.Location = new Point(275, 60);
            btnBuscarCliente.Name = "btnBuscarCliente";
            btnBuscarCliente.Size = new Size(90, 30);
            btnBuscarCliente.TabIndex = 3;
            btnBuscarCliente.Text = "Buscar";
            btnBuscarCliente.UseVisualStyleBackColor = false;
            btnBuscarCliente.Click += jzat506_btnBuscarCliente_Click;
            // 
            // lblClienteInfo
            // 
            lblClienteInfo.AutoSize = true;
            lblClienteInfo.ForeColor = Color.DarkGreen;
            lblClienteInfo.Location = new Point(378, 65);
            lblClienteInfo.Name = "lblClienteInfo";
            lblClienteInfo.Size = new Size(76, 21);
            lblClienteInfo.TabIndex = 4;
            lblClienteInfo.Text = "Cliente: -";
            // 
            // btnSeleccionarProductos
            // 
            btnSeleccionarProductos.BackColor = Color.White;
            btnSeleccionarProductos.ForeColor = Color.DarkGreen;
            btnSeleccionarProductos.Location = new Point(20, 105);
            btnSeleccionarProductos.Name = "btnSeleccionarProductos";
            btnSeleccionarProductos.Size = new Size(230, 32);
            btnSeleccionarProductos.TabIndex = 5;
            btnSeleccionarProductos.Text = "Seleccionar productos";
            btnSeleccionarProductos.UseVisualStyleBackColor = false;
            btnSeleccionarProductos.Click += jzat506_btnSeleccionarProductos_Click;
            // 
            // dataGridViewCarrito
            // 
            dataGridViewCarrito.AllowUserToAddRows = false;
            dataGridViewCarrito.AllowUserToDeleteRows = false;
            dataGridViewCarrito.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCarrito.BackgroundColor = Color.White;
            dataGridViewCarrito.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCarrito.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4 });
            dataGridViewCarrito.Location = new Point(20, 150);
            dataGridViewCarrito.Name = "dataGridViewCarrito";
            dataGridViewCarrito.ReadOnly = true;
            dataGridViewCarrito.Size = new Size(680, 150);
            dataGridViewCarrito.TabIndex = 6;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.HeaderText = "Producto";
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.HeaderText = "Cantidad";
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.HeaderText = "Precio unitario";
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.HeaderText = "Subtotal";
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // lblTotalCarrito
            // 
            lblTotalCarrito.AutoSize = true;
            lblTotalCarrito.Font = new Font("Times New Roman", 11F, FontStyle.Bold);
            lblTotalCarrito.ForeColor = Color.DarkGreen;
            lblTotalCarrito.Location = new Point(20, 310);
            lblTotalCarrito.Name = "lblTotalCarrito";
            lblTotalCarrito.Size = new Size(66, 17);
            lblTotalCarrito.TabIndex = 7;
            lblTotalCarrito.Text = "Total: $0";
            // 
            // btnCobrarVenta
            // 
            btnCobrarVenta.BackColor = Color.White;
            btnCobrarVenta.ForeColor = Color.DarkGreen;
            btnCobrarVenta.Location = new Point(20, 345);
            btnCobrarVenta.Name = "btnCobrarVenta";
            btnCobrarVenta.Size = new Size(150, 32);
            btnCobrarVenta.TabIndex = 8;
            btnCobrarVenta.Text = "Cobrar venta";
            btnCobrarVenta.UseVisualStyleBackColor = false;
            btnCobrarVenta.Click += jzat506_btnCobrarVenta_Click;
            // 
            // lblEstadoPago
            // 
            lblEstadoPago.AutoSize = true;
            lblEstadoPago.ForeColor = Color.DarkGreen;
            lblEstadoPago.Location = new Point(190, 352);
            lblEstadoPago.Name = "lblEstadoPago";
            lblEstadoPago.Size = new Size(128, 21);
            lblEstadoPago.TabIndex = 9;
            lblEstadoPago.Text = "Pago: pendiente";
            // 
            // btnGenerar
            // 
            btnGenerar.BackColor = Color.White;
            btnGenerar.ForeColor = Color.DarkGreen;
            btnGenerar.Location = new Point(540, 345);
            btnGenerar.Name = "btnGenerar";
            btnGenerar.Size = new Size(160, 32);
            btnGenerar.TabIndex = 10;
            btnGenerar.Text = "Generar factura";
            btnGenerar.UseVisualStyleBackColor = false;
            btnGenerar.Click += jzat506_btnGenerar_Click;
            // 
            // btnVolverVentas
            // 
            btnVolverVentas.BackColor = Color.White;
            btnVolverVentas.ForeColor = Color.DarkGreen;
            btnVolverVentas.Location = new Point(600, 400);
            btnVolverVentas.Name = "btnVolverVentas";
            btnVolverVentas.Size = new Size(100, 32);
            btnVolverVentas.TabIndex = 11;
            btnVolverVentas.Text = "Volver";
            btnVolverVentas.UseVisualStyleBackColor = false;
            btnVolverVentas.Click += jzat506_btnVolverVentas_Click;
            // 
            // jzat506_FrmGenerarFactura
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 224, 224);
            ClientSize = new Size(722, 450);
            Controls.Add(lblTituloFactura);
            Controls.Add(lblDNIVenta);
            Controls.Add(txtDNI);
            Controls.Add(btnBuscarCliente);
            Controls.Add(lblClienteInfo);
            Controls.Add(btnSeleccionarProductos);
            Controls.Add(dataGridViewCarrito);
            Controls.Add(lblTotalCarrito);
            Controls.Add(btnCobrarVenta);
            Controls.Add(lblEstadoPago);
            Controls.Add(btnGenerar);
            Controls.Add(btnVolverVentas);
            Name = "jzat506_FrmGenerarFactura";
            Text = "Ventas";
            FormClosing += jzat506_FrmGenerarFactura_FormClosing;
            Load += jzat506_FrmGenerarFactura_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewCarrito).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTituloFactura;
        private Label lblDNIVenta;
        private TextBox txtDNI;
        private Button btnBuscarCliente;
        private Label lblClienteInfo;
        private Button btnSeleccionarProductos;
        private DataGridView dataGridViewCarrito;
        private Label lblTotalCarrito;
        private Button btnCobrarVenta;
        private Label lblEstadoPago;
        private Button btnGenerar;
        private Button btnVolverVentas;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
    }
}
