namespace Oasis_Sports
{
    partial class FrmGestionPerfiles
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
            treeView1 = new TreeView();
            lblPerfilUsuario = new Label();
            cmbUsuarios = new ComboBox();
            lblUsuario = new Label();
            btnAsignarPerfil = new Button();
            btnQuitarPerfil = new Button();
            lstDisponibles = new ListBox();
            btnVolver = new Button();
            btnCrearGP = new Button();
            lblPerfiles = new Label();
            SuspendLayout();
            //
            // treeView1
            //
            treeView1.Location = new Point(316, 53);
            treeView1.Name = "treeView1";
            treeView1.Size = new Size(510, 492);
            treeView1.TabIndex = 0;
            //
            // lblPerfilUsuario
            //
            lblPerfilUsuario.AutoSize = true;
            lblPerfilUsuario.Location = new Point(316, 18);
            lblPerfilUsuario.ForeColor = Color.DarkGreen;
            lblPerfilUsuario.Name = "lblPerfilUsuario";
            lblPerfilUsuario.Size = new Size(189, 21);
            lblPerfilUsuario.TabIndex = 1;
            lblPerfilUsuario.Text = "PERFIL DEL USUARIO";
            //
            // cmbUsuarios
            //
            cmbUsuarios.FormattingEnabled = true;
            cmbUsuarios.Location = new Point(34, 77);
            cmbUsuarios.Name = "cmbUsuarios";
            cmbUsuarios.Size = new Size(195, 29);
            cmbUsuarios.TabIndex = 2;
            cmbUsuarios.SelectedIndexChanged += cmbUsuarios_SelectedIndexChanged;
            //
            // lblUsuario
            //
            lblUsuario.AutoSize = true;
            lblUsuario.Location = new Point(34, 53);
            lblUsuario.ForeColor = Color.DarkGreen;
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(76, 21);
            lblUsuario.TabIndex = 3;
            lblUsuario.Text = "Usuarios";
            //
            // btnAsignarPerfil
            //
            btnAsignarPerfil.Location = new Point(32, 330);
            btnAsignarPerfil.Name = "btnAsignarPerfil";
            btnAsignarPerfil.Size = new Size(192, 43);
            btnAsignarPerfil.TabIndex = 4;
            btnAsignarPerfil.Text = "ASIGNAR PERFIL";
            btnAsignarPerfil.BackColor = Color.White;
            btnAsignarPerfil.ForeColor = Color.DarkGreen;
            btnAsignarPerfil.UseVisualStyleBackColor = false;
            btnAsignarPerfil.Click += btnAsignarPerfil_Click;
            //
            // btnQuitarPerfil
            //
            btnQuitarPerfil.Location = new Point(32, 379);
            btnQuitarPerfil.Name = "btnQuitarPerfil";
            btnQuitarPerfil.Size = new Size(192, 43);
            btnQuitarPerfil.TabIndex = 5;
            btnQuitarPerfil.Text = "QUITAR PERFIL";
            btnQuitarPerfil.BackColor = Color.White;
            btnQuitarPerfil.ForeColor = Color.DarkGreen;
            btnQuitarPerfil.UseVisualStyleBackColor = false;
            btnQuitarPerfil.Click += btnQuitarPerfil_Click;
            //
            // lstDisponibles
            //
            lstDisponibles.FormattingEnabled = true;
            lstDisponibles.ItemHeight = 21;
            lstDisponibles.Location = new Point(32, 140);
            lstDisponibles.Name = "lstDisponibles";
            lstDisponibles.Size = new Size(270, 172);
            lstDisponibles.TabIndex = 6;
            //
            // btnVolver
            //
            btnVolver.Location = new Point(32, 502);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(192, 43);
            btnVolver.TabIndex = 7;
            btnVolver.Text = "VOLVER";
            btnVolver.BackColor = Color.White;
            btnVolver.ForeColor = Color.DarkGreen;
            btnVolver.UseVisualStyleBackColor = false;
            btnVolver.Click += button1_Click;
            //
            // btnCrearGP
            //
            btnCrearGP.Location = new Point(32, 437);
            btnCrearGP.Name = "btnCrearGP";
            btnCrearGP.Size = new Size(192, 54);
            btnCrearGP.TabIndex = 8;
            btnCrearGP.Text = "GRUPO DE PERMISOS";
            btnCrearGP.BackColor = Color.White;
            btnCrearGP.ForeColor = Color.DarkGreen;
            btnCrearGP.UseVisualStyleBackColor = false;
            btnCrearGP.Click += button1_Click_1;
            //
            // lblPerfiles
            //
            lblPerfiles.AutoSize = true;
            lblPerfiles.Location = new Point(32, 115);
            lblPerfiles.ForeColor = Color.DarkGreen;
            lblPerfiles.Name = "lblPerfiles";
            lblPerfiles.Size = new Size(76, 21);
            lblPerfiles.TabIndex = 9;
            lblPerfiles.Text = "PERFILES";
            //
            // FrmGestionPerfiles
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 224, 224);
            ClientSize = new Size(869, 609);
            Controls.Add(lblPerfiles);
            Controls.Add(btnCrearGP);
            Controls.Add(btnVolver);
            Controls.Add(lstDisponibles);
            Controls.Add(btnQuitarPerfil);
            Controls.Add(btnAsignarPerfil);
            Controls.Add(lblUsuario);
            Controls.Add(cmbUsuarios);
            Controls.Add(lblPerfilUsuario);
            Controls.Add(treeView1);
            Name = "FrmGestionPerfiles";
            Text = "FrmGestionPerfiles";
            FormClosing += FrmGestionPerfiles_FormClosing;
            Load += FrmGestionPerfiles_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TreeView treeView1;
        private Label lblPerfilUsuario;
        private ComboBox cmbUsuarios;
        private Label lblUsuario;
        private Button btnAsignarPerfil;
        private Button btnQuitarPerfil;
        private ListBox lstDisponibles;
        private Button btnVolver;
        private Button btnCrearGP;
        private Label lblPerfiles;
    }
}
