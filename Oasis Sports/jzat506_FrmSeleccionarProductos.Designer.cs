namespace Oasis_Sports
{
    partial class jzat506_FrmSeleccionarProductos
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
            lblProductos = new Label();
            dataGridViewProductos = new DataGridView();
            lblCantidad = new Label();
            numCantidad = new NumericUpDown();
            btnAgregarProducto = new Button();
            lblCarrito = new Label();
            dataGridViewCarrito = new DataGridView();
            lblTotal = new Label();
            btnConfirmarProductos = new Button();
            btnQuitarProducto = new Button();
            btnCerrar = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewProductos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numCantidad).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCarrito).BeginInit();
            SuspendLayout();
            //
            // lblProductos
            //
            lblProductos.AutoSize = true;
            lblProductos.ForeColor = Color.DarkGreen;
            lblProductos.Location = new Point(20, 15);
            lblProductos.Name = "lblProductos";
            lblProductos.Size = new Size(120, 20);
            lblProductos.Text = "Productos";
            //
            // dataGridViewProductos
            //
            dataGridViewProductos.AllowUserToAddRows = false;
            dataGridViewProductos.AllowUserToDeleteRows = false;
            dataGridViewProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewProductos.BackgroundColor = Color.White;
            dataGridViewProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewProductos.Location = new Point(20, 40);
            dataGridViewProductos.MultiSelect = false;
            dataGridViewProductos.Name = "dataGridViewProductos";
            dataGridViewProductos.ReadOnly = true;
            dataGridViewProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewProductos.Size = new Size(700, 180);
            //
            // lblCantidad
            //
            lblCantidad.AutoSize = true;
            lblCantidad.ForeColor = Color.DarkGreen;
            lblCantidad.Location = new Point(20, 232);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(70, 20);
            lblCantidad.Text = "Cantidad";
            //
            // numCantidad
            //
            numCantidad.Location = new Point(100, 230);
            numCantidad.Maximum = new decimal(new int[] { 100, 0, 0, 0 });
            numCantidad.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numCantidad.Name = "numCantidad";
            numCantidad.Size = new Size(80, 27);
            numCantidad.Value = new decimal(new int[] { 1, 0, 0, 0 });
            //
            // btnAgregarProducto
            //
            btnAgregarProducto.BackColor = Color.White;
            btnAgregarProducto.ForeColor = Color.DarkGreen;
            btnAgregarProducto.Location = new Point(200, 228);
            btnAgregarProducto.Name = "btnAgregarProducto";
            btnAgregarProducto.Size = new Size(120, 30);
            btnAgregarProducto.Text = "Agregar";
            btnAgregarProducto.UseVisualStyleBackColor = false;
            btnAgregarProducto.Click += jzat506_btnAgregar_Click;
            //
            // lblCarrito
            //
            lblCarrito.AutoSize = true;
            lblCarrito.ForeColor = Color.DarkGreen;
            lblCarrito.Location = new Point(20, 268);
            lblCarrito.Name = "lblCarrito";
            lblCarrito.Size = new Size(120, 20);
            lblCarrito.Text = "Carrito";
            //
            // dataGridViewCarrito
            //
            dataGridViewCarrito.AllowUserToAddRows = false;
            dataGridViewCarrito.AllowUserToDeleteRows = false;
            dataGridViewCarrito.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCarrito.BackgroundColor = Color.White;
            dataGridViewCarrito.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCarrito.Location = new Point(20, 293);
            dataGridViewCarrito.MultiSelect = false;
            dataGridViewCarrito.Name = "dataGridViewCarrito";
            dataGridViewCarrito.ReadOnly = true;
            dataGridViewCarrito.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewCarrito.Size = new Size(700, 150);
            dataGridViewCarrito.Columns.Add("Producto", "Producto");
            dataGridViewCarrito.Columns.Add("Cantidad", "Cantidad");
            dataGridViewCarrito.Columns.Add("PrecioUnitario", "Precio unitario");
            dataGridViewCarrito.Columns.Add("Subtotal", "Subtotal");
            //
            // lblTotal
            //
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            lblTotal.ForeColor = Color.DarkGreen;
            lblTotal.Location = new Point(20, 453);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(150, 24);
            lblTotal.Text = "Total: $0";
            //
            // btnQuitarProducto
            //
            btnQuitarProducto.BackColor = Color.White;
            btnQuitarProducto.ForeColor = Color.DarkGreen;
            btnQuitarProducto.Location = new Point(250, 448);
            btnQuitarProducto.Name = "btnQuitarProducto";
            btnQuitarProducto.Size = new Size(120, 32);
            btnQuitarProducto.Text = "Quitar";
            btnQuitarProducto.UseVisualStyleBackColor = false;
            btnQuitarProducto.Click += jzat506_btnQuitar_Click;
            //
            // btnConfirmarProductos
            //
            btnConfirmarProductos.BackColor = Color.White;
            btnConfirmarProductos.ForeColor = Color.DarkGreen;
            btnConfirmarProductos.Location = new Point(385, 448);
            btnConfirmarProductos.Name = "btnConfirmarProductos";
            btnConfirmarProductos.Size = new Size(220, 32);
            btnConfirmarProductos.Text = "Confirmar productos";
            btnConfirmarProductos.UseVisualStyleBackColor = false;
            btnConfirmarProductos.Click += jzat506_btnConfirmar_Click;
            //
            // btnCerrar
            //
            btnCerrar.BackColor = Color.White;
            btnCerrar.ForeColor = Color.DarkGreen;
            btnCerrar.Location = new Point(620, 448);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(100, 32);
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = false;
            btnCerrar.Click += jzat506_btnCerrar_Click;
            //
            // jzat506_FrmSeleccionarProductos
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 224, 224);
            ClientSize = new Size(742, 500);
            Controls.Add(lblProductos);
            Controls.Add(dataGridViewProductos);
            Controls.Add(lblCantidad);
            Controls.Add(numCantidad);
            Controls.Add(btnAgregarProducto);
            Controls.Add(lblCarrito);
            Controls.Add(dataGridViewCarrito);
            Controls.Add(lblTotal);
            Controls.Add(btnQuitarProducto);
            Controls.Add(btnConfirmarProductos);
            Controls.Add(btnCerrar);
            Name = "jzat506_FrmSeleccionarProductos";
            Text = "Seleccionar productos";
            Load += jzat506_FrmSeleccionarProductos_Load;
            FormClosing += jzat506_FrmSeleccionarProductos_FormClosing;
            ((System.ComponentModel.ISupportInitialize)dataGridViewProductos).EndInit();
            ((System.ComponentModel.ISupportInitialize)numCantidad).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCarrito).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblProductos;
        private DataGridView dataGridViewProductos;
        private Label lblCantidad;
        private NumericUpDown numCantidad;
        private Button btnAgregarProducto;
        private Label lblCarrito;
        private DataGridView dataGridViewCarrito;
        private Label lblTotal;
        private Button btnConfirmarProductos;
        private Button btnQuitarProducto;
        private Button btnCerrar;
    }
}
