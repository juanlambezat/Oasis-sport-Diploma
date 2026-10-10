namespace Oasis_Sports
{
    partial class jzat506_FrmRegistrarCliente
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
            dataGridView1 = new DataGridView();
            lblDNI = new Label();
            txtDNI = new TextBox();
            lblNombre = new Label();
            txtNombre = new TextBox();
            lblApellido = new Label();
            txtApellido = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblTelefono = new Label();
            txtTelefono = new TextBox();
            lblDireccion = new Label();
            txtDireccion = new TextBox();
            btnRegistrar = new Button();
            btnModificar = new Button();
            btnEliminar = new Button();
            btnVolverCancelar = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            //
            // dataGridView1
            //
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(250, 0);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(600, 560);
            dataGridView1.CellClick += jzat506_dataGridView1_CellClick;
            //
            // lblDNI
            //
            lblDNI.AutoSize = true;
            lblDNI.ForeColor = Color.DarkGreen;
            lblDNI.Location = new Point(10, 15);
            lblDNI.Name = "lblDNI";
            lblDNI.Size = new Size(70, 21);
            lblDNI.Text = "DNI : ";
            //
            // txtDNI
            //
            txtDNI.Location = new Point(12, 37);
            txtDNI.MaxLength = 8;
            txtDNI.Name = "txtDNI";
            txtDNI.ReadOnly = true;
            txtDNI.Size = new Size(209, 29);
            txtDNI.KeyPress += jzat506_SoloDigitos_KeyPress;
            //
            // lblNombre
            //
            lblNombre.AutoSize = true;
            lblNombre.ForeColor = Color.DarkGreen;
            lblNombre.Location = new Point(10, 74);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(100, 21);
            lblNombre.Text = "NOMBRE : ";
            //
            // txtNombre
            //
            txtNombre.Location = new Point(12, 96);
            txtNombre.MaxLength = 50;
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(209, 29);
            //
            // lblApellido
            //
            lblApellido.AutoSize = true;
            lblApellido.ForeColor = Color.DarkGreen;
            lblApellido.Location = new Point(10, 133);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(100, 21);
            lblApellido.Text = "APELLIDO : ";
            //
            // txtApellido
            //
            txtApellido.Location = new Point(12, 155);
            txtApellido.MaxLength = 50;
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(209, 29);
            //
            // lblEmail
            //
            lblEmail.AutoSize = true;
            lblEmail.ForeColor = Color.DarkGreen;
            lblEmail.Location = new Point(10, 192);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(80, 21);
            lblEmail.Text = "EMAIL : ";
            //
            // txtEmail
            //
            txtEmail.Location = new Point(12, 214);
            txtEmail.MaxLength = 100;
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(209, 29);
            //
            // lblTelefono
            //
            lblTelefono.AutoSize = true;
            lblTelefono.ForeColor = Color.DarkGreen;
            lblTelefono.Location = new Point(10, 251);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(110, 21);
            lblTelefono.Text = "TELEFONO : ";
            //
            // txtTelefono
            //
            txtTelefono.Location = new Point(12, 273);
            txtTelefono.MaxLength = 10;
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(209, 29);
            txtTelefono.KeyPress += jzat506_SoloDigitos_KeyPress;
            //
            // lblDireccion
            //
            lblDireccion.AutoSize = true;
            lblDireccion.ForeColor = Color.DarkGreen;
            lblDireccion.Location = new Point(10, 310);
            lblDireccion.Name = "lblDireccion";
            lblDireccion.Size = new Size(120, 21);
            lblDireccion.Text = "DIRECCION : ";
            //
            // txtDireccion
            //
            txtDireccion.Location = new Point(12, 332);
            txtDireccion.MaxLength = 150;
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(209, 29);
            //
            // btnRegistrar
            //
            btnRegistrar.BackColor = Color.White;
            btnRegistrar.ForeColor = Color.DarkGreen;
            btnRegistrar.Location = new Point(12, 378);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(209, 35);
            btnRegistrar.Text = "REGISTRAR";
            btnRegistrar.UseVisualStyleBackColor = false;
            btnRegistrar.Click += jzat506_btnRegistrar_Click;
            //
            // btnModificar
            //
            btnModificar.BackColor = Color.White;
            btnModificar.ForeColor = Color.DarkGreen;
            btnModificar.Location = new Point(12, 424);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(209, 35);
            btnModificar.Text = "MODIFICAR";
            btnModificar.UseVisualStyleBackColor = false;
            btnModificar.Click += jzat506_btnModificar_Click;
            //
            // btnEliminar
            //
            btnEliminar.BackColor = Color.White;
            btnEliminar.ForeColor = Color.DarkGreen;
            btnEliminar.Location = new Point(12, 470);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(209, 35);
            btnEliminar.Text = "ELIMINAR";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += jzat506_btnEliminar_Click;
            //
            // btnVolverCancelar
            //
            btnVolverCancelar.BackColor = Color.White;
            btnVolverCancelar.ForeColor = Color.DarkGreen;
            btnVolverCancelar.Location = new Point(12, 516);
            btnVolverCancelar.Name = "btnVolverCancelar";
            btnVolverCancelar.Size = new Size(209, 35);
            btnVolverCancelar.Text = "VOLVER";
            btnVolverCancelar.UseVisualStyleBackColor = false;
            btnVolverCancelar.Click += jzat506_btnVolverCancelar_Click;
            //
            // jzat506_FrmRegistrarCliente
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 224, 224);
            ClientSize = new Size(850, 560);
            Controls.Add(dataGridView1);
            Controls.Add(lblDNI);
            Controls.Add(txtDNI);
            Controls.Add(lblNombre);
            Controls.Add(txtNombre);
            Controls.Add(lblApellido);
            Controls.Add(txtApellido);
            Controls.Add(lblEmail);
            Controls.Add(txtEmail);
            Controls.Add(lblTelefono);
            Controls.Add(txtTelefono);
            Controls.Add(lblDireccion);
            Controls.Add(txtDireccion);
            Controls.Add(btnRegistrar);
            Controls.Add(btnModificar);
            Controls.Add(btnEliminar);
            Controls.Add(btnVolverCancelar);
            Name = "jzat506_FrmRegistrarCliente";
            Text = "Registrar cliente";
            Load += jzat506_FrmRegistrarCliente_Load;
            FormClosing += jzat506_FrmRegistrarCliente_FormClosing;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Label lblDNI;
        private TextBox txtDNI;
        private Label lblNombre;
        private TextBox txtNombre;
        private Label lblApellido;
        private TextBox txtApellido;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblTelefono;
        private TextBox txtTelefono;
        private Label lblDireccion;
        private TextBox txtDireccion;
        private Button btnRegistrar;
        private Button btnModificar;
        private Button btnEliminar;
        private Button btnVolverCancelar;
    }
}
