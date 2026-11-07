namespace Oasis_Sports
{
    partial class FrmGruposPermisos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtNombreGrupo = new TextBox();
            label1 = new Label();
            lstPermisosDisponibles = new ListBox();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            tvPermisosDelGrupo = new TreeView();
            btnAgregar = new Button();
            btnQuitar = new Button();
            btnGuardar = new Button();
            btnVolver = new Button();
            btnModificar = new Button();
            lblmodo = new Label();
            btnNuevo = new Button();
            btnEliminar = new Button();
            lblCodigoGrupo = new Label();
            txtCodigoGrupo = new TextBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            //
            // txtNombreGrupo
            //
            txtNombreGrupo.Location = new Point(280, 44);
            txtNombreGrupo.Name = "txtNombreGrupo";
            txtNombreGrupo.Size = new Size(210, 29);
            txtNombreGrupo.TabIndex = 0;
            //
            // label1
            //
            label1.AutoSize = true;
            label1.Location = new Point(120, 47);
            label1.ForeColor = Color.DarkGreen;
            label1.Name = "label1";
            label1.Size = new Size(152, 21);
            label1.TabIndex = 1;
            label1.Text = "Nombre de grupo: ";
            //
            // lstPermisosDisponibles
            //
            lstPermisosDisponibles.FormattingEnabled = true;
            lstPermisosDisponibles.ItemHeight = 21;
            lstPermisosDisponibles.Location = new Point(15, 25);
            lstPermisosDisponibles.ForeColor = Color.Black;
            lstPermisosDisponibles.Name = "lstPermisosDisponibles";
            lstPermisosDisponibles.Size = new Size(260, 256);
            lstPermisosDisponibles.TabIndex = 2;
            lstPermisosDisponibles.SelectedIndexChanged += lstPermisosDisponibles_SelectedIndexChanged;
            //
            // groupBox1
            //
            groupBox1.Controls.Add(lstPermisosDisponibles);
            groupBox1.Location = new Point(20, 133);
            groupBox1.ForeColor = Color.DarkGreen;
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(290, 293);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Permisos disponibles";
            //
            // groupBox2
            //
            groupBox2.Controls.Add(tvPermisosDelGrupo);
            groupBox2.Location = new Point(500, 133);
            groupBox2.ForeColor = Color.DarkGreen;
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(415, 293);
            groupBox2.TabIndex = 4;
            groupBox2.TabStop = false;
            groupBox2.Text = "Permisos del grupo";
            //
            // tvPermisosDelGrupo
            //
            tvPermisosDelGrupo.Location = new Point(10, 25);
            tvPermisosDelGrupo.ForeColor = Color.Black;
            tvPermisosDelGrupo.Name = "tvPermisosDelGrupo";
            tvPermisosDelGrupo.Size = new Size(395, 256);
            tvPermisosDelGrupo.TabIndex = 2;
            //
            // btnAgregar
            //
            btnAgregar.Location = new Point(330, 143);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(153, 38);
            btnAgregar.TabIndex = 5;
            btnAgregar.Text = "AGREGAR";
            btnAgregar.BackColor = Color.White;
            btnAgregar.ForeColor = Color.DarkGreen;
            btnAgregar.UseVisualStyleBackColor = false;
            btnAgregar.Click += btnAgregar_Click;
            //
            // btnQuitar
            //
            btnQuitar.Location = new Point(330, 196);
            btnQuitar.Name = "btnQuitar";
            btnQuitar.Size = new Size(153, 38);
            btnQuitar.TabIndex = 6;
            btnQuitar.Text = "QUITAR";
            btnQuitar.BackColor = Color.White;
            btnQuitar.ForeColor = Color.DarkGreen;
            btnQuitar.UseVisualStyleBackColor = false;
            btnQuitar.Click += btnQuitar_Click;
            //
            // btnGuardar
            //
            btnGuardar.Location = new Point(329, 306);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(153, 38);
            btnGuardar.TabIndex = 7;
            btnGuardar.Text = "GUARDAR";
            btnGuardar.BackColor = Color.White;
            btnGuardar.ForeColor = Color.DarkGreen;
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            //
            // btnVolver
            //
            btnVolver.Location = new Point(802, 445);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(113, 32);
            btnVolver.TabIndex = 8;
            btnVolver.Text = "VOLVER";
            btnVolver.BackColor = Color.White;
            btnVolver.ForeColor = Color.DarkGreen;
            btnVolver.UseVisualStyleBackColor = false;
            btnVolver.Click += button1_Click;
            //
            // btnModificar
            //
            btnModificar.Location = new Point(331, 252);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(152, 39);
            btnModificar.TabIndex = 9;
            btnModificar.Text = "MODIFICAR";
            btnModificar.BackColor = Color.White;
            btnModificar.ForeColor = Color.DarkGreen;
            btnModificar.UseVisualStyleBackColor = false;
            btnModificar.Click += btnModificar_Click;
            //
            // lblmodo
            //
            lblmodo.AutoSize = true;
            lblmodo.Location = new Point(4, 8);
            lblmodo.ForeColor = Color.DarkGreen;
            lblmodo.Name = "lblmodo";
            lblmodo.Size = new Size(76, 21);
            lblmodo.TabIndex = 10;
            lblmodo.Text = "MODO: ";
            //
            // btnNuevo
            //
            btnNuevo.Location = new Point(504, 42);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(168, 31);
            btnNuevo.TabIndex = 11;
            btnNuevo.Text = "NUEVO GRUPO";
            btnNuevo.BackColor = Color.White;
            btnNuevo.ForeColor = Color.DarkGreen;
            btnNuevo.UseVisualStyleBackColor = false;
            btnNuevo.Click += button1_Click_1;
            //
            // btnEliminar
            //
            btnEliminar.Location = new Point(329, 362);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(153, 38);
            btnEliminar.TabIndex = 12;
            btnEliminar.Text = "ELIMINAR";
            btnEliminar.BackColor = Color.White;
            btnEliminar.ForeColor = Color.DarkGreen;
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            //
            // lblCodigoGrupo
            //
            lblCodigoGrupo.AutoSize = true;
            lblCodigoGrupo.Location = new Point(120, 82);
            lblCodigoGrupo.ForeColor = Color.DarkGreen;
            lblCodigoGrupo.Name = "lblCodigoGrupo";
            lblCodigoGrupo.Size = new Size(150, 21);
            lblCodigoGrupo.TabIndex = 13;
            lblCodigoGrupo.Text = "Codigo de grupo: ";
            //
            // txtCodigoGrupo
            //
            txtCodigoGrupo.CharacterCasing = CharacterCasing.Upper;
            txtCodigoGrupo.Location = new Point(280, 79);
            txtCodigoGrupo.MaxLength = 5;
            txtCodigoGrupo.Name = "txtCodigoGrupo";
            txtCodigoGrupo.Size = new Size(90, 29);
            txtCodigoGrupo.TabIndex = 14;
            //
            // FrmGruposPermisos
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 224, 224);
            ClientSize = new Size(930, 490);
            Controls.Add(txtCodigoGrupo);
            Controls.Add(lblCodigoGrupo);
            Controls.Add(btnEliminar);
            Controls.Add(btnNuevo);
            Controls.Add(lblmodo);
            Controls.Add(btnModificar);
            Controls.Add(btnVolver);
            Controls.Add(btnGuardar);
            Controls.Add(btnQuitar);
            Controls.Add(btnAgregar);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Controls.Add(txtNombreGrupo);
            Name = "FrmGruposPermisos";
            Text = "FrmGruposPermisos";
            Load += FrmGruposPermisos_Load;
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtNombreGrupo;
        private Label label1;
        private ListBox lstPermisosDisponibles;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private TreeView tvPermisosDelGrupo;
        private Button btnAgregar;
        private Button btnQuitar;
        private Button btnGuardar;
        private Button btnVolver;
        private Button btnModificar;
        private Label lblmodo;
        private Button btnNuevo;
        private Button btnEliminar;
        private Label lblCodigoGrupo;
        private TextBox txtCodigoGrupo;
    }
}
