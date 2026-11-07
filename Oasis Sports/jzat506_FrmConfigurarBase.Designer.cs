namespace Oasis_Sports
{
    partial class jzat506_FrmConfigurarBase
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTituloConfigurar = new Label();
            lblExplicacionConfigurar = new Label();
            lblServidorConfigurar = new Label();
            cmbServidorConfigurar = new ComboBox();
            btnCrearBase = new Button();
            btnSalirConfigurar = new Button();
            SuspendLayout();
            //
            // lblTituloConfigurar
            //
            lblTituloConfigurar.AutoSize = true;
            lblTituloConfigurar.Font = new Font("Times New Roman", 14F, FontStyle.Bold);
            lblTituloConfigurar.ForeColor = Color.DarkGreen;
            lblTituloConfigurar.Location = new Point(20, 18);
            lblTituloConfigurar.Name = "lblTituloConfigurar";
            lblTituloConfigurar.Size = new Size(300, 21);
            lblTituloConfigurar.TabIndex = 0;
            lblTituloConfigurar.Text = "Configuración de la base de datos";
            //
            // lblExplicacionConfigurar
            //
            lblExplicacionConfigurar.ForeColor = Color.DarkGreen;
            lblExplicacionConfigurar.Location = new Point(20, 52);
            lblExplicacionConfigurar.Name = "lblExplicacionConfigurar";
            lblExplicacionConfigurar.Size = new Size(520, 70);
            lblExplicacionConfigurar.TabIndex = 1;
            lblExplicacionConfigurar.Text = "No se encontró la base de datos de Oasis Sports. Elija o escriba el servidor SQL Server donde se va a crear.";
            //
            // lblServidorConfigurar
            //
            lblServidorConfigurar.AutoSize = true;
            lblServidorConfigurar.ForeColor = Color.DarkGreen;
            lblServidorConfigurar.Location = new Point(20, 140);
            lblServidorConfigurar.Name = "lblServidorConfigurar";
            lblServidorConfigurar.Size = new Size(80, 21);
            lblServidorConfigurar.TabIndex = 2;
            lblServidorConfigurar.Text = "Servidor:";
            //
            // cmbServidorConfigurar
            //
            cmbServidorConfigurar.Location = new Point(120, 136);
            cmbServidorConfigurar.Name = "cmbServidorConfigurar";
            cmbServidorConfigurar.Size = new Size(320, 29);
            cmbServidorConfigurar.TabIndex = 3;
            //
            // btnCrearBase
            //
            btnCrearBase.BackColor = Color.White;
            btnCrearBase.ForeColor = Color.DarkGreen;
            btnCrearBase.Location = new Point(120, 190);
            btnCrearBase.Name = "btnCrearBase";
            btnCrearBase.Size = new Size(260, 38);
            btnCrearBase.TabIndex = 4;
            btnCrearBase.Text = "CREAR BASE DE DATOS";
            btnCrearBase.UseVisualStyleBackColor = false;
            btnCrearBase.Click += jzat506_btnCrearBase_Click;
            //
            // btnSalirConfigurar
            //
            btnSalirConfigurar.BackColor = Color.White;
            btnSalirConfigurar.ForeColor = Color.DarkGreen;
            btnSalirConfigurar.Location = new Point(395, 190);
            btnSalirConfigurar.Name = "btnSalirConfigurar";
            btnSalirConfigurar.Size = new Size(120, 38);
            btnSalirConfigurar.TabIndex = 5;
            btnSalirConfigurar.Text = "SALIR";
            btnSalirConfigurar.UseVisualStyleBackColor = false;
            btnSalirConfigurar.Click += jzat506_btnSalirConfigurar_Click;
            //
            // jzat506_FrmConfigurarBase
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 224, 224);
            ClientSize = new Size(560, 250);
            Controls.Add(btnSalirConfigurar);
            Controls.Add(btnCrearBase);
            Controls.Add(cmbServidorConfigurar);
            Controls.Add(lblServidorConfigurar);
            Controls.Add(lblExplicacionConfigurar);
            Controls.Add(lblTituloConfigurar);
            Name = "jzat506_FrmConfigurarBase";
            Text = "Oasis Sports";
            Load += jzat506_FrmConfigurarBase_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblTituloConfigurar;
        private Label lblExplicacionConfigurar;
        private Label lblServidorConfigurar;
        private ComboBox cmbServidorConfigurar;
        private Button btnCrearBase;
        private Button btnSalirConfigurar;
    }
}
