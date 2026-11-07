namespace Oasis_Sports
{
    partial class jzat506_FrmActualizarPedido
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
            lblTituloPedidos = new Label();
            dgvPedidos = new DataGridView();
            lblDetalleTexto = new Label();
            txtDetalle = new TextBox();
            btnAvanzarEstado = new Button();
            btnVolverPedidos = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvPedidos).BeginInit();
            SuspendLayout();
            //
            // lblTituloPedidos
            //
            lblTituloPedidos.AutoSize = true;
            lblTituloPedidos.Font = new Font("Times New Roman", 14F, FontStyle.Bold);
            lblTituloPedidos.ForeColor = Color.DarkGreen;
            lblTituloPedidos.Location = new Point(20, 15);
            lblTituloPedidos.Name = "lblTituloPedidos";
            lblTituloPedidos.Size = new Size(260, 28);
            lblTituloPedidos.Text = "Pedidos a entregar";
            //
            // dgvPedidos
            //
            dgvPedidos.AllowUserToAddRows = false;
            dgvPedidos.AllowUserToDeleteRows = false;
            dgvPedidos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPedidos.BackgroundColor = Color.White;
            dgvPedidos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPedidos.Location = new Point(20, 60);
            dgvPedidos.MultiSelect = false;
            dgvPedidos.Name = "dgvPedidos";
            dgvPedidos.ReadOnly = true;
            dgvPedidos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPedidos.Size = new Size(700, 160);
            dgvPedidos.Columns.Add("Pedido", "Pedido");
            dgvPedidos.Columns.Add("Cliente", "Cliente");
            dgvPedidos.Columns.Add("Zona", "Zona");
            dgvPedidos.Columns.Add("Estado", "Estado");
            dgvPedidos.Columns.Add("Transportista", "Transportista");
            dgvPedidos.SelectionChanged += jzat506_dgvPedidos_SelectionChanged;
            //
            // lblDetalleTexto
            //
            lblDetalleTexto.AutoSize = true;
            lblDetalleTexto.ForeColor = Color.DarkGreen;
            lblDetalleTexto.Location = new Point(20, 235);
            lblDetalleTexto.Name = "lblDetalleTexto";
            lblDetalleTexto.Size = new Size(200, 20);
            lblDetalleTexto.Text = "Detalle del pedido";
            //
            // txtDetalle
            //
            txtDetalle.Location = new Point(20, 260);
            txtDetalle.Multiline = true;
            txtDetalle.Name = "txtDetalle";
            txtDetalle.ReadOnly = true;
            txtDetalle.ScrollBars = ScrollBars.Vertical;
            txtDetalle.Size = new Size(700, 160);
            //
            // btnAvanzarEstado
            //
            btnAvanzarEstado.BackColor = Color.White;
            btnAvanzarEstado.ForeColor = Color.DarkGreen;
            btnAvanzarEstado.Location = new Point(440, 440);
            btnAvanzarEstado.Name = "btnAvanzarEstado";
            btnAvanzarEstado.Size = new Size(160, 32);
            btnAvanzarEstado.Text = "Avanzar estado";
            btnAvanzarEstado.UseVisualStyleBackColor = false;
            btnAvanzarEstado.Click += jzat506_btnAvanzar_Click;
            //
            // btnVolverPedidos
            //
            btnVolverPedidos.BackColor = Color.White;
            btnVolverPedidos.ForeColor = Color.DarkGreen;
            btnVolverPedidos.Location = new Point(620, 440);
            btnVolverPedidos.Name = "btnVolverPedidos";
            btnVolverPedidos.Size = new Size(100, 32);
            btnVolverPedidos.Text = "Volver";
            btnVolverPedidos.UseVisualStyleBackColor = false;
            btnVolverPedidos.Click += jzat506_btnVolverPedidos_Click;
            //
            // jzat506_FrmActualizarPedido
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 224, 224);
            ClientSize = new Size(742, 490);
            Controls.Add(lblTituloPedidos);
            Controls.Add(dgvPedidos);
            Controls.Add(lblDetalleTexto);
            Controls.Add(txtDetalle);
            Controls.Add(btnAvanzarEstado);
            Controls.Add(btnVolverPedidos);
            Name = "jzat506_FrmActualizarPedido";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Pedidos";
            Load += jzat506_FrmActualizarPedido_Load;
            FormClosing += jzat506_FrmActualizarPedido_FormClosing;
            ((System.ComponentModel.ISupportInitialize)dgvPedidos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTituloPedidos;
        private DataGridView dgvPedidos;
        private Label lblDetalleTexto;
        private TextBox txtDetalle;
        private Button btnAvanzarEstado;
        private Button btnVolverPedidos;
    }
}
