namespace Oasis_Sports
{
    partial class jzat506_FrmAsignarTransportista
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
            lblTituloAsignar = new Label();
            lblPedidosAsignar = new Label();
            dgvPedidosAsignar = new DataGridView();
            lblTransportistasAsignar = new Label();
            dgvTransportistas = new DataGridView();
            btnAsignarTransportista = new Button();
            btnVolverAsignar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvPedidosAsignar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvTransportistas).BeginInit();
            SuspendLayout();
            //
            // lblTituloAsignar
            //
            lblTituloAsignar.AutoSize = true;
            lblTituloAsignar.Font = new Font("Times New Roman", 14F, FontStyle.Bold);
            lblTituloAsignar.ForeColor = Color.DarkGreen;
            lblTituloAsignar.Location = new Point(20, 15);
            lblTituloAsignar.Name = "lblTituloAsignar";
            lblTituloAsignar.Size = new Size(260, 28);
            lblTituloAsignar.Text = "Asignar transportista";
            //
            // lblPedidosAsignar
            //
            lblPedidosAsignar.AutoSize = true;
            lblPedidosAsignar.ForeColor = Color.DarkGreen;
            lblPedidosAsignar.Location = new Point(20, 60);
            lblPedidosAsignar.Name = "lblPedidosAsignar";
            lblPedidosAsignar.Size = new Size(200, 20);
            lblPedidosAsignar.Text = "Pedidos preparados";
            //
            // dgvPedidosAsignar
            //
            dgvPedidosAsignar.AllowUserToAddRows = false;
            dgvPedidosAsignar.AllowUserToDeleteRows = false;
            dgvPedidosAsignar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPedidosAsignar.BackgroundColor = Color.White;
            dgvPedidosAsignar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPedidosAsignar.Location = new Point(20, 85);
            dgvPedidosAsignar.MultiSelect = false;
            dgvPedidosAsignar.Name = "dgvPedidosAsignar";
            dgvPedidosAsignar.ReadOnly = true;
            dgvPedidosAsignar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPedidosAsignar.Size = new Size(700, 110);
            dgvPedidosAsignar.Columns.Add("Pedido", "Pedido");
            dgvPedidosAsignar.Columns.Add("Cliente", "Cliente");
            dgvPedidosAsignar.Columns.Add("Zona", "Zona");
            dgvPedidosAsignar.Columns.Add("Direccion", "Direccion");
            dgvPedidosAsignar.Columns["Pedido"].FillWeight = 60;
            dgvPedidosAsignar.Columns["Cliente"].FillWeight = 120;
            dgvPedidosAsignar.Columns["Zona"].FillWeight = 90;
            dgvPedidosAsignar.Columns["Direccion"].FillWeight = 130;
            //
            // lblTransportistasAsignar
            //
            lblTransportistasAsignar.AutoSize = true;
            lblTransportistasAsignar.ForeColor = Color.DarkGreen;
            lblTransportistasAsignar.Location = new Point(20, 210);
            lblTransportistasAsignar.Name = "lblTransportistasAsignar";
            lblTransportistasAsignar.Size = new Size(200, 20);
            lblTransportistasAsignar.Text = "Transportistas";
            //
            // dgvTransportistas
            //
            dgvTransportistas.AllowUserToAddRows = false;
            dgvTransportistas.AllowUserToDeleteRows = false;
            dgvTransportistas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTransportistas.BackgroundColor = Color.White;
            dgvTransportistas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTransportistas.Location = new Point(20, 235);
            dgvTransportistas.MultiSelect = false;
            dgvTransportistas.Name = "dgvTransportistas";
            dgvTransportistas.ReadOnly = true;
            dgvTransportistas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTransportistas.Size = new Size(700, 150);
            dgvTransportistas.Columns.Add("Transportista", "Transportista");
            dgvTransportistas.Columns.Add("Estado", "Estado");
            //
            // btnAsignarTransportista
            //
            btnAsignarTransportista.BackColor = Color.White;
            btnAsignarTransportista.ForeColor = Color.DarkGreen;
            btnAsignarTransportista.Location = new Point(440, 405);
            btnAsignarTransportista.Name = "btnAsignarTransportista";
            btnAsignarTransportista.Size = new Size(160, 32);
            btnAsignarTransportista.Text = "Asignar";
            btnAsignarTransportista.UseVisualStyleBackColor = false;
            btnAsignarTransportista.Click += jzat506_btnAsignar_Click;
            //
            // btnVolverAsignar
            //
            btnVolverAsignar.BackColor = Color.White;
            btnVolverAsignar.ForeColor = Color.DarkGreen;
            btnVolverAsignar.Location = new Point(620, 405);
            btnVolverAsignar.Name = "btnVolverAsignar";
            btnVolverAsignar.Size = new Size(100, 32);
            btnVolverAsignar.Text = "Volver";
            btnVolverAsignar.UseVisualStyleBackColor = false;
            btnVolverAsignar.Click += jzat506_btnVolverAsignar_Click;
            //
            // jzat506_FrmAsignarTransportista
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 224, 224);
            ClientSize = new Size(742, 455);
            Controls.Add(lblTituloAsignar);
            Controls.Add(lblPedidosAsignar);
            Controls.Add(dgvPedidosAsignar);
            Controls.Add(lblTransportistasAsignar);
            Controls.Add(dgvTransportistas);
            Controls.Add(btnAsignarTransportista);
            Controls.Add(btnVolverAsignar);
            Name = "jzat506_FrmAsignarTransportista";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Asignar transportista";
            Load += jzat506_FrmAsignarTransportista_Load;
            FormClosing += jzat506_FrmAsignarTransportista_FormClosing;
            ((System.ComponentModel.ISupportInitialize)dgvPedidosAsignar).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvTransportistas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTituloAsignar;
        private Label lblPedidosAsignar;
        private DataGridView dgvPedidosAsignar;
        private Label lblTransportistasAsignar;
        private DataGridView dgvTransportistas;
        private Button btnAsignarTransportista;
        private Button btnVolverAsignar;
    }
}
