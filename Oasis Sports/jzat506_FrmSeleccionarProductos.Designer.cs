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
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
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
            lblProductos.Size = new Size(88, 21);
            lblProductos.TabIndex = 0;
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
            dataGridViewProductos.TabIndex = 1;
            // 
            // lblCantidad
            // 
            lblCantidad.AutoSize = true;
            lblCantidad.ForeColor = Color.DarkGreen;
            lblCantidad.Location = new Point(20, 232);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(77, 21);
            lblCantidad.TabIndex = 2;
            lblCantidad.Text = "Cantidad";
            // 
            // numCantidad
            // 
            numCantidad.Location = new Point(138, 228);
            numCantidad.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numCantidad.Name = "numCantidad";
            numCantidad.Size = new Size(80, 29);
            numCantidad.TabIndex = 3;
            numCantidad.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // btnAgregarProducto
            // 
            btnAgregarProducto.BackColor = Color.White;
            btnAgregarProducto.ForeColor = Color.DarkGreen;
            btnAgregarProducto.Location = new Point(233, 227);
            btnAgregarProducto.Name = "btnAgregarProducto";
            btnAgregarProducto.Size = new Size(120, 30);
            btnAgregarProducto.TabIndex = 4;
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
            lblCarrito.Size = new Size(62, 21);
            lblCarrito.TabIndex = 5;
            lblCarrito.Text = "Carrito";
            // 
            // dataGridViewCarrito
            // 
            dataGridViewCarrito.AllowUserToAddRows = false;
            dataGridViewCarrito.AllowUserToDeleteRows = false;
            dataGridViewCarrito.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCarrito.BackgroundColor = Color.White;
            dataGridViewCarrito.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCarrito.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4 });
            dataGridViewCarrito.Location = new Point(20, 293);
            dataGridViewCarrito.MultiSelect = false;
            dataGridViewCarrito.Name = "dataGridViewCarrito";
            dataGridViewCarrito.ReadOnly = true;
            dataGridViewCarrito.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewCarrito.Size = new Size(700, 150);
            dataGridViewCarrito.TabIndex = 6;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            lblTotal.ForeColor = Color.DarkGreen;
            lblTotal.Location = new Point(20, 453);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(68, 19);
            lblTotal.TabIndex = 7;
            lblTotal.Text = "Total: $0";
            // 
            // btnConfirmarProductos
            // 
            btnConfirmarProductos.BackColor = Color.White;
            btnConfirmarProductos.ForeColor = Color.DarkGreen;
            btnConfirmarProductos.Location = new Point(385, 448);
            btnConfirmarProductos.Name = "btnConfirmarProductos";
            btnConfirmarProductos.Size = new Size(220, 32);
            btnConfirmarProductos.TabIndex = 9;
            btnConfirmarProductos.Text = "Confirmar productos";
            btnConfirmarProductos.UseVisualStyleBackColor = false;
            btnConfirmarProductos.Click += jzat506_btnConfirmar_Click;
            // 
            // btnQuitarProducto
            // 
            btnQuitarProducto.BackColor = Color.White;
            btnQuitarProducto.ForeColor = Color.DarkGreen;
            btnQuitarProducto.Location = new Point(250, 448);
            btnQuitarProducto.Name = "btnQuitarProducto";
            btnQuitarProducto.Size = new Size(120, 32);
            btnQuitarProducto.TabIndex = 8;
            btnQuitarProducto.Text = "Quitar";
            btnQuitarProducto.UseVisualStyleBackColor = false;
            btnQuitarProducto.Click += jzat506_btnQuitar_Click;
            // 
            // btnCerrar
            // 
            btnCerrar.BackColor = Color.White;
            btnCerrar.ForeColor = Color.DarkGreen;
            btnCerrar.Location = new Point(620, 448);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(100, 32);
            btnCerrar.TabIndex = 10;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = false;
            btnCerrar.Click += jzat506_btnCerrar_Click;
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
            FormClosing += jzat506_FrmSeleccionarProductos_FormClosing;
            Load += jzat506_FrmSeleccionarProductos_Load;
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
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
    }
}
