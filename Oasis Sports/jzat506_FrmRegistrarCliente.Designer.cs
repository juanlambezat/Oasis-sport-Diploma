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
            components = new System.ComponentModel.Container();
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
            grpSerializacion = new GroupBox();
            btnSerializar = new Button();
            txtRutaSerializar = new TextBox();
            btnRutaSerializar = new Button();
            btnDeserializar = new Button();
            txtRutaDeserializar = new TextBox();
            btnRutaDeserializar = new Button();
            btnActualizarGrilla = new Button();
            btnLimpiarGrilla = new Button();
            lblMensaje = new Label();
            txtMensaje = new TextBox();
            toolTip1 = new ToolTip(components);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            grpSerializacion.SuspendLayout();
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
            dataGridView1.TabIndex = 0;
            dataGridView1.CellClick += jzat506_dataGridView1_CellClick;
            // 
            // lblDNI
            // 
            lblDNI.AutoSize = true;
            lblDNI.ForeColor = Color.DarkGreen;
            lblDNI.Location = new Point(10, 15);
            lblDNI.Name = "lblDNI";
            lblDNI.Size = new Size(56, 21);
            lblDNI.TabIndex = 1;
            lblDNI.Text = "DNI : ";
            // 
            // txtDNI
            // 
            txtDNI.Location = new Point(12, 37);
            txtDNI.MaxLength = 8;
            txtDNI.Name = "txtDNI";
            txtDNI.ReadOnly = true;
            txtDNI.Size = new Size(209, 29);
            txtDNI.TabIndex = 2;
            txtDNI.KeyPress += jzat506_SoloDigitos_KeyPress;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.ForeColor = Color.DarkGreen;
            lblNombre.Location = new Point(10, 74);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(103, 21);
            lblNombre.TabIndex = 3;
            lblNombre.Text = "NOMBRE : ";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(12, 96);
            txtNombre.MaxLength = 50;
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(209, 29);
            txtNombre.TabIndex = 4;
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.ForeColor = Color.DarkGreen;
            lblApellido.Location = new Point(10, 133);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(114, 21);
            lblApellido.TabIndex = 5;
            lblApellido.Text = "APELLIDO : ";
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(12, 155);
            txtApellido.MaxLength = 50;
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(209, 29);
            txtApellido.TabIndex = 6;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.ForeColor = Color.DarkGreen;
            lblEmail.Location = new Point(10, 192);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(80, 21);
            lblEmail.TabIndex = 7;
            lblEmail.Text = "EMAIL : ";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(12, 214);
            txtEmail.MaxLength = 100;
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(209, 29);
            txtEmail.TabIndex = 8;
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.ForeColor = Color.DarkGreen;
            lblTelefono.Location = new Point(10, 251);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(121, 21);
            lblTelefono.TabIndex = 9;
            lblTelefono.Text = "TELEFONO : ";
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(12, 273);
            txtTelefono.MaxLength = 10;
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(209, 29);
            txtTelefono.TabIndex = 10;
            txtTelefono.KeyPress += jzat506_SoloDigitos_KeyPress;
            // 
            // lblDireccion
            // 
            lblDireccion.AutoSize = true;
            lblDireccion.ForeColor = Color.DarkGreen;
            lblDireccion.Location = new Point(10, 310);
            lblDireccion.Name = "lblDireccion";
            lblDireccion.Size = new Size(126, 21);
            lblDireccion.TabIndex = 11;
            lblDireccion.Text = "DIRECCION : ";
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(12, 332);
            txtDireccion.MaxLength = 150;
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(209, 29);
            txtDireccion.TabIndex = 12;
            // 
            // btnRegistrar
            // 
            btnRegistrar.BackColor = Color.White;
            btnRegistrar.ForeColor = Color.DarkGreen;
            btnRegistrar.Location = new Point(12, 378);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(209, 35);
            btnRegistrar.TabIndex = 13;
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
            btnModificar.TabIndex = 14;
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
            btnEliminar.TabIndex = 15;
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
            btnVolverCancelar.TabIndex = 16;
            btnVolverCancelar.Text = "VOLVER";
            btnVolverCancelar.UseVisualStyleBackColor = false;
            btnVolverCancelar.Click += jzat506_btnVolverCancelar_Click;
            // 
            // grpSerializacion
            // 
            grpSerializacion.Controls.Add(btnSerializar);
            grpSerializacion.Controls.Add(txtRutaSerializar);
            grpSerializacion.Controls.Add(btnRutaSerializar);
            grpSerializacion.Controls.Add(btnDeserializar);
            grpSerializacion.Controls.Add(txtRutaDeserializar);
            grpSerializacion.Controls.Add(btnRutaDeserializar);
            grpSerializacion.Controls.Add(btnActualizarGrilla);
            grpSerializacion.Controls.Add(btnLimpiarGrilla);
            grpSerializacion.Controls.Add(lblMensaje);
            grpSerializacion.Controls.Add(txtMensaje);
            grpSerializacion.ForeColor = Color.DarkGreen;
            grpSerializacion.Location = new Point(10, 570);
            grpSerializacion.Name = "grpSerializacion";
            grpSerializacion.Size = new Size(830, 175);
            grpSerializacion.TabIndex = 17;
            grpSerializacion.TabStop = false;
            grpSerializacion.Text = "SERIALIZACION";
            // 
            // btnSerializar
            // 
            btnSerializar.BackColor = Color.White;
            btnSerializar.ForeColor = Color.DarkGreen;
            btnSerializar.Location = new Point(15, 30);
            btnSerializar.Name = "btnSerializar";
            btnSerializar.Size = new Size(185, 35);
            btnSerializar.TabIndex = 0;
            btnSerializar.Text = "SERIALIZAR";
            btnSerializar.UseVisualStyleBackColor = false;
            btnSerializar.Click += jzat506_btnSerializar_Click;
            // 
            // txtRutaSerializar
            // 
            txtRutaSerializar.Location = new Point(210, 33);
            txtRutaSerializar.Name = "txtRutaSerializar";
            txtRutaSerializar.ReadOnly = true;
            txtRutaSerializar.Size = new Size(320, 29);
            txtRutaSerializar.TabIndex = 1;
            // 
            // btnRutaSerializar
            // 
            btnRutaSerializar.BackColor = Color.White;
            btnRutaSerializar.ForeColor = Color.DarkGreen;
            btnRutaSerializar.Location = new Point(535, 32);
            btnRutaSerializar.Name = "btnRutaSerializar";
            btnRutaSerializar.Size = new Size(45, 31);
            btnRutaSerializar.TabIndex = 2;
            btnRutaSerializar.Text = "...";
            btnRutaSerializar.UseVisualStyleBackColor = false;
            btnRutaSerializar.Click += jzat506_btnRutaSerializar_Click;
            // 
            // btnDeserializar
            // 
            btnDeserializar.BackColor = Color.White;
            btnDeserializar.ForeColor = Color.DarkGreen;
            btnDeserializar.Location = new Point(15, 75);
            btnDeserializar.Name = "btnDeserializar";
            btnDeserializar.Size = new Size(185, 35);
            btnDeserializar.TabIndex = 3;
            btnDeserializar.Text = "DES-SERIALIZAR";
            btnDeserializar.UseVisualStyleBackColor = false;
            btnDeserializar.Click += jzat506_btnDeserializar_Click;
            // 
            // txtRutaDeserializar
            // 
            txtRutaDeserializar.Location = new Point(210, 78);
            txtRutaDeserializar.Name = "txtRutaDeserializar";
            txtRutaDeserializar.ReadOnly = true;
            txtRutaDeserializar.Size = new Size(320, 29);
            txtRutaDeserializar.TabIndex = 4;
            // 
            // btnRutaDeserializar
            // 
            btnRutaDeserializar.BackColor = Color.White;
            btnRutaDeserializar.ForeColor = Color.DarkGreen;
            btnRutaDeserializar.Location = new Point(535, 77);
            btnRutaDeserializar.Name = "btnRutaDeserializar";
            btnRutaDeserializar.Size = new Size(45, 31);
            btnRutaDeserializar.TabIndex = 5;
            btnRutaDeserializar.Text = "...";
            btnRutaDeserializar.UseVisualStyleBackColor = false;
            btnRutaDeserializar.Click += jzat506_btnRutaDeserializar_Click;
            // 
            // btnActualizarGrilla
            // 
            btnActualizarGrilla.BackColor = Color.White;
            btnActualizarGrilla.ForeColor = Color.DarkGreen;
            btnActualizarGrilla.Location = new Point(15, 125);
            btnActualizarGrilla.Name = "btnActualizarGrilla";
            btnActualizarGrilla.Size = new Size(185, 35);
            btnActualizarGrilla.TabIndex = 6;
            btnActualizarGrilla.Text = "ACTUALIZAR";
            toolTip1.SetToolTip(btnActualizarGrilla, "Vuelve a cargar en la grilla los clientes de la base de datos.");
            btnActualizarGrilla.UseVisualStyleBackColor = false;
            btnActualizarGrilla.Click += jzat506_btnActualizarGrilla_Click;
            // 
            // btnLimpiarGrilla
            // 
            btnLimpiarGrilla.BackColor = Color.White;
            btnLimpiarGrilla.ForeColor = Color.DarkGreen;
            btnLimpiarGrilla.Location = new Point(210, 125);
            btnLimpiarGrilla.Name = "btnLimpiarGrilla";
            btnLimpiarGrilla.Size = new Size(185, 35);
            btnLimpiarGrilla.TabIndex = 7;
            btnLimpiarGrilla.Text = "LIMPIAR";
            toolTip1.SetToolTip(btnLimpiarGrilla, "Borra la grilla, las rutas de los archivos y el mensaje.");
            btnLimpiarGrilla.UseVisualStyleBackColor = false;
            btnLimpiarGrilla.Click += jzat506_btnLimpiarGrilla_Click;
            // 
            // lblMensaje
            // 
            lblMensaje.AutoSize = true;
            lblMensaje.ForeColor = Color.DarkGreen;
            lblMensaje.Location = new Point(595, 25);
            lblMensaje.Name = "lblMensaje";
            lblMensaje.Size = new Size(106, 21);
            lblMensaje.TabIndex = 8;
            lblMensaje.Text = "MENSAJE : ";
            // 
            // txtMensaje
            // 
            txtMensaje.Location = new Point(597, 50);
            txtMensaje.Multiline = true;
            txtMensaje.Name = "txtMensaje";
            txtMensaje.ReadOnly = true;
            txtMensaje.Size = new Size(220, 110);
            txtMensaje.TabIndex = 9;
            // 
            // jzat506_FrmRegistrarCliente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 224, 224);
            ClientSize = new Size(876, 755);
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
            Controls.Add(grpSerializacion);
            Name = "jzat506_FrmRegistrarCliente";
            Text = "Registrar cliente";
            FormClosing += jzat506_FrmRegistrarCliente_FormClosing;
            Load += jzat506_FrmRegistrarCliente_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            grpSerializacion.ResumeLayout(false);
            grpSerializacion.PerformLayout();
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
        private GroupBox grpSerializacion;
        private Button btnSerializar;
        private TextBox txtRutaSerializar;
        private Button btnRutaSerializar;
        private Button btnDeserializar;
        private TextBox txtRutaDeserializar;
        private Button btnRutaDeserializar;
        private Button btnActualizarGrilla;
        private Button btnLimpiarGrilla;
        private Label lblMensaje;
        private TextBox txtMensaje;
        private ToolTip toolTip1;
    }
}
