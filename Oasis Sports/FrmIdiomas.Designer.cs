namespace Oasis_Sports
{
    partial class FrmIdiomas
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
            cmbIdiomas = new ComboBox();
            lstClaves = new ListBox();
            txtClave = new TextBox();
            txtTexto = new TextBox();
            txtNuevoIdioma = new TextBox();
            btnGuardarTraduccion = new Button();
            btnNuevoIdioma = new Button();
            btnCambiarIdioma = new Button();
            lblIdiomaActivo = new Label();
            lblClaves = new Label();
            lblClave = new Label();
            lblTexto = new Label();
            lblNuevoIdioma = new Label();
            btnVolver = new Button();
            lblIdioma = new Label();
            grpTraduccion = new GroupBox();
            grpTraduccion.SuspendLayout();
            SuspendLayout();
            // 
            // cmbIdiomas
            // 
            cmbIdiomas.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbIdiomas.Location = new Point(49, 323);
            cmbIdiomas.Name = "cmbIdiomas";
            cmbIdiomas.Size = new Size(190, 29);
            cmbIdiomas.TabIndex = 5;
            // 
            // lstClaves
            // 
            lstClaves.ItemHeight = 21;
            lstClaves.Location = new Point(422, 92);
            lstClaves.Name = "lstClaves";
            lstClaves.Size = new Size(270, 361);
            lstClaves.TabIndex = 7;
            lstClaves.SelectedIndexChanged += lstClaves_SelectedIndexChanged;
            // 
            // txtClave
            // 
            txtClave.Location = new Point(29, 36);
            txtClave.Name = "txtClave";
            txtClave.ReadOnly = true;
            txtClave.Size = new Size(190, 29);
            txtClave.TabIndex = 8;
            // 
            // txtTexto
            // 
            txtTexto.Location = new Point(29, 95);
            txtTexto.Name = "txtTexto";
            txtTexto.Size = new Size(190, 29);
            txtTexto.TabIndex = 9;
            // 
            // txtNuevoIdioma
            // 
            txtNuevoIdioma.Location = new Point(49, 95);
            txtNuevoIdioma.Name = "txtNuevoIdioma";
            txtNuevoIdioma.Size = new Size(190, 29);
            txtNuevoIdioma.TabIndex = 12;
            // 
            // btnGuardarTraduccion
            // 
            btnGuardarTraduccion.BackColor = Color.White;
            btnGuardarTraduccion.ForeColor = Color.DarkGreen;
            btnGuardarTraduccion.Location = new Point(246, 47);
            btnGuardarTraduccion.Name = "btnGuardarTraduccion";
            btnGuardarTraduccion.Size = new Size(130, 58);
            btnGuardarTraduccion.TabIndex = 10;
            btnGuardarTraduccion.Text = "Guardar traducción";
            btnGuardarTraduccion.UseVisualStyleBackColor = false;
            btnGuardarTraduccion.Click += btnGuardarTraduccion_Click;
            // 
            // btnNuevoIdioma
            // 
            btnNuevoIdioma.BackColor = Color.White;
            btnNuevoIdioma.ForeColor = Color.DarkGreen;
            btnNuevoIdioma.Location = new Point(266, 92);
            btnNuevoIdioma.Name = "btnNuevoIdioma";
            btnNuevoIdioma.Size = new Size(130, 32);
            btnNuevoIdioma.TabIndex = 13;
            btnNuevoIdioma.Text = "Crear idioma";
            btnNuevoIdioma.UseVisualStyleBackColor = false;
            btnNuevoIdioma.Click += btnNuevoIdioma_Click;
            // 
            // btnCambiarIdioma
            // 
            btnCambiarIdioma.BackColor = Color.White;
            btnCambiarIdioma.ForeColor = Color.DarkGreen;
            btnCambiarIdioma.Location = new Point(266, 315);
            btnCambiarIdioma.Name = "btnCambiarIdioma";
            btnCambiarIdioma.Size = new Size(130, 43);
            btnCambiarIdioma.TabIndex = 6;
            btnCambiarIdioma.Text = "Aplicar idioma";
            btnCambiarIdioma.UseVisualStyleBackColor = false;
            btnCambiarIdioma.Click += btnCambiarIdioma_Click;
            // 
            // lblIdiomaActivo
            // 
            lblIdiomaActivo.AutoSize = true;
            lblIdiomaActivo.ForeColor = Color.DarkGreen;
            lblIdiomaActivo.Location = new Point(49, 294);
            lblIdiomaActivo.Name = "lblIdiomaActivo";
            lblIdiomaActivo.Size = new Size(100, 23);
            lblIdiomaActivo.TabIndex = 0;
            lblIdiomaActivo.Text = "Idioma";
            // 
            // lblClaves
            // 
            lblClaves.AutoSize = true;
            lblClaves.ForeColor = Color.DarkGreen;
            lblClaves.Location = new Point(422, 62);
            lblClaves.Name = "lblClaves";
            lblClaves.Size = new Size(100, 23);
            lblClaves.TabIndex = 1;
            lblClaves.Text = "Claves";
            // 
            // lblClave
            // 
            lblClave.AutoSize = true;
            lblClave.ForeColor = Color.DarkGreen;
            lblClave.Location = new Point(29, 9);
            lblClave.Name = "lblClave";
            lblClave.Size = new Size(100, 23);
            lblClave.TabIndex = 2;
            lblClave.Text = "Clave";
            // 
            // lblTexto
            // 
            lblTexto.AutoSize = true;
            lblTexto.ForeColor = Color.DarkGreen;
            lblTexto.Location = new Point(29, 68);
            lblTexto.Name = "lblTexto";
            lblTexto.Size = new Size(100, 23);
            lblTexto.TabIndex = 3;
            lblTexto.Text = "Traducción";
            // 
            // lblNuevoIdioma
            // 
            lblNuevoIdioma.AutoSize = true;
            lblNuevoIdioma.ForeColor = Color.DarkGreen;
            lblNuevoIdioma.Location = new Point(49, 66);
            lblNuevoIdioma.Name = "lblNuevoIdioma";
            lblNuevoIdioma.Size = new Size(100, 23);
            lblNuevoIdioma.TabIndex = 4;
            lblNuevoIdioma.Text = "Nuevo idioma";
            // 
            // btnVolver
            // 
            btnVolver.BackColor = Color.White;
            btnVolver.ForeColor = Color.DarkGreen;
            btnVolver.Location = new Point(20, 405);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(98, 38);
            btnVolver.TabIndex = 14;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = false;
            btnVolver.Click += button1_Click;
            // 
            // lblIdioma
            // 
            lblIdioma.AutoSize = true;
            lblIdioma.Font = new Font("Times New Roman", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblIdioma.ForeColor = Color.DarkGreen;
            lblIdioma.Location = new Point(247, 25);
            lblIdioma.Name = "lblIdioma";
            lblIdioma.Size = new Size(197, 27);
            lblIdioma.TabIndex = 15;
            lblIdioma.Text = "Gestion de Idiomas";
            // 
            // grpTraduccion
            // 
            grpTraduccion.Controls.Add(lblClave);
            grpTraduccion.Controls.Add(lblTexto);
            grpTraduccion.Controls.Add(btnGuardarTraduccion);
            grpTraduccion.Controls.Add(txtTexto);
            grpTraduccion.Controls.Add(txtClave);
            grpTraduccion.Location = new Point(20, 155);
            grpTraduccion.Name = "grpTraduccion";
            grpTraduccion.Size = new Size(396, 137);
            grpTraduccion.TabIndex = 16;
            grpTraduccion.TabStop = false;
            // 
            // FrmIdiomas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            BackColor = Color.FromArgb(224, 224, 224);
            ClientSize = new Size(700, 470);
            Controls.Add(grpTraduccion);
            Controls.Add(lblIdioma);
            Controls.Add(lstClaves);
            Controls.Add(lblIdiomaActivo);
            Controls.Add(lblClaves);
            Controls.Add(lblNuevoIdioma);
            Controls.Add(cmbIdiomas);
            Controls.Add(btnCambiarIdioma);
            Controls.Add(txtNuevoIdioma);
            Controls.Add(btnNuevoIdioma);
            Controls.Add(btnVolver);
            Name = "FrmIdiomas";
            Text = "Gestión de Idiomas";
            FormClosing += FrmIdiomas_FormClosing;
            Load += FrmIdiomas_Load;
            grpTraduccion.ResumeLayout(false);
            grpTraduccion.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private ComboBox cmbIdiomas;
        private ListBox lstClaves;
        private TextBox txtClave;
        private TextBox txtTexto;
        private TextBox txtNuevoIdioma;
        private Button btnGuardarTraduccion;
        private Button btnNuevoIdioma;
        private Button btnCambiarIdioma;
        private Label lblIdiomaActivo;
        private Label lblClaves;
        private Label lblClave;
        private Label lblTexto;
        private Label lblNuevoIdioma;
        private Button btnVolver;
        private Label lblIdioma;
        private GroupBox grpTraduccion;
    }
}
