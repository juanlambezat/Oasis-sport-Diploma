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
            lblTituloFactura.Size = new Size(220, 28);
            lblTituloFactura.Text = "Generar factura";
            //
            // lblDNIVenta
            //
            lblDNIVenta.AutoSize = true;
            lblDNIVenta.ForeColor = Color.DarkGreen;
            lblDNIVenta.Location = new Point(20, 65);
            lblDNIVenta.Name = "lblDNIVenta";
            lblDNIVenta.Size = new Size(50, 20);
            lblDNIVenta.Text = "DNI";
            //
            // txtDNI
            //
            txtDNI.Location = new Point(90, 62);
            txtDNI.MaxLength = 8;
            txtDNI.Name = "txtDNI";
            txtDNI.Size = new Size(150, 27);
            txtDNI.TextChanged += jzat506_txtDNI_TextChanged;
            txtDNI.KeyPress += jzat506_SoloDigitos_KeyPress;
            //
            // btnBuscarCliente
            //
            btnBuscarCliente.BackColor = Color.White;
            btnBuscarCliente.ForeColor = Color.DarkGreen;
            btnBuscarCliente.Location = new Point(250, 60);
            btnBuscarCliente.Name = "btnBuscarCliente";
            btnBuscarCliente.Size = new Size(90, 30);
            btnBuscarCliente.Text = "Buscar";
            btnBuscarCliente.UseVisualStyleBackColor = false;
            btnBuscarCliente.Click += jzat506_btnBuscarCliente_Click;
            //
            // lblClienteInfo
            //
            lblClienteInfo.AutoSize = true;
            lblClienteInfo.ForeColor = Color.DarkGreen;
            lblClienteInfo.Location = new Point(350, 65);
            lblClienteInfo.Name = "lblClienteInfo";
            lblClienteInfo.Size = new Size(300, 20);
            lblClienteInfo.Text = "Cliente: -";
            //
            // btnSeleccionarProductos
            //
            btnSeleccionarProductos.BackColor = Color.White;
            btnSeleccionarProductos.ForeColor = Color.DarkGreen;
            btnSeleccionarProductos.Location = new Point(20, 105);
            btnSeleccionarProductos.Name = "btnSeleccionarProductos";
            btnSeleccionarProductos.Size = new Size(230, 32);
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
            dataGridViewCarrito.Location = new Point(20, 150);
            dataGridViewCarrito.Name = "dataGridViewCarrito";
            dataGridViewCarrito.ReadOnly = true;
            dataGridViewCarrito.Size = new Size(680, 150);
            dataGridViewCarrito.Columns.Add("Producto", "Producto");
            dataGridViewCarrito.Columns.Add("Cantidad", "Cantidad");
            dataGridViewCarrito.Columns.Add("PrecioUnitario", "Precio unitario");
            dataGridViewCarrito.Columns.Add("Subtotal", "Subtotal");
            //
            // lblTotalCarrito
            //
            lblTotalCarrito.AutoSize = true;
            lblTotalCarrito.Font = new Font("Times New Roman", 11F, FontStyle.Bold);
            lblTotalCarrito.ForeColor = Color.DarkGreen;
            lblTotalCarrito.Location = new Point(20, 310);
            lblTotalCarrito.Name = "lblTotalCarrito";
            lblTotalCarrito.Size = new Size(150, 22);
            lblTotalCarrito.Text = "Total: $0";
            //
            // btnCobrarVenta
            //
            btnCobrarVenta.BackColor = Color.White;
            btnCobrarVenta.ForeColor = Color.DarkGreen;
            btnCobrarVenta.Location = new Point(20, 345);
            btnCobrarVenta.Name = "btnCobrarVenta";
            btnCobrarVenta.Size = new Size(150, 32);
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
            lblEstadoPago.Size = new Size(220, 20);
            lblEstadoPago.Text = "Pago: pendiente";
            //
            // btnGenerar
            //
            btnGenerar.BackColor = Color.White;
            btnGenerar.ForeColor = Color.DarkGreen;
            btnGenerar.Location = new Point(540, 345);
            btnGenerar.Name = "btnGenerar";
            btnGenerar.Size = new Size(160, 32);
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
            Load += jzat506_FrmGenerarFactura_Load;
            FormClosing += jzat506_FrmGenerarFactura_FormClosing;
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
    }
}
