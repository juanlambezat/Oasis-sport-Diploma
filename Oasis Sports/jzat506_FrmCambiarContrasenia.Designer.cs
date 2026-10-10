namespace Oasis_Sports
{
    partial class jzat506_FrmCambiarContrasenia
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
            lblTituloContrasenia = new Label();
            lblActual = new Label();
            txtActual = new TextBox();
            lblNueva = new Label();
            txtNueva = new TextBox();
            lblRepetir = new Label();
            txtRepetir = new TextBox();
            btnGuardarContrasenia = new Button();
            btnCancelarContrasenia = new Button();
            SuspendLayout();
            //
            // lblTituloContrasenia
            //
            lblTituloContrasenia.AutoSize = true;
            lblTituloContrasenia.Font = new Font("Times New Roman", 14F, FontStyle.Bold);
            lblTituloContrasenia.ForeColor = Color.DarkGreen;
            lblTituloContrasenia.Location = new Point(20, 15);
            lblTituloContrasenia.Name = "lblTituloContrasenia";
            lblTituloContrasenia.Size = new Size(260, 28);
            lblTituloContrasenia.Text = "Cambiar contraseña";
            //
            // lblActual
            //
            lblActual.AutoSize = true;
            lblActual.ForeColor = Color.DarkGreen;
            lblActual.Location = new Point(20, 65);
            lblActual.Name = "lblActual";
            lblActual.Size = new Size(160, 20);
            lblActual.Text = "Contraseña actual";
            //
            // txtActual
            //
            txtActual.Location = new Point(20, 87);
            txtActual.Name = "txtActual";
            txtActual.PasswordChar = '*';
            txtActual.Size = new Size(260, 27);
            //
            // lblNueva
            //
            lblNueva.AutoSize = true;
            lblNueva.ForeColor = Color.DarkGreen;
            lblNueva.Location = new Point(20, 125);
            lblNueva.Name = "lblNueva";
            lblNueva.Size = new Size(160, 20);
            lblNueva.Text = "Contraseña nueva";
            //
            // txtNueva
            //
            txtNueva.Location = new Point(20, 147);
            txtNueva.Name = "txtNueva";
            txtNueva.PasswordChar = '*';
            txtNueva.Size = new Size(260, 27);
            //
            // lblRepetir
            //
            lblRepetir.AutoSize = true;
            lblRepetir.ForeColor = Color.DarkGreen;
            lblRepetir.Location = new Point(20, 185);
            lblRepetir.Name = "lblRepetir";
            lblRepetir.Size = new Size(220, 20);
            lblRepetir.Text = "Repetir contraseña nueva";
            //
            // txtRepetir
            //
            txtRepetir.Location = new Point(20, 207);
            txtRepetir.Name = "txtRepetir";
            txtRepetir.PasswordChar = '*';
            txtRepetir.Size = new Size(260, 27);
            //
            // btnGuardarContrasenia
            //
            btnGuardarContrasenia.BackColor = Color.White;
            btnGuardarContrasenia.ForeColor = Color.DarkGreen;
            btnGuardarContrasenia.Location = new Point(20, 250);
            btnGuardarContrasenia.Name = "btnGuardarContrasenia";
            btnGuardarContrasenia.Size = new Size(120, 35);
            btnGuardarContrasenia.Text = "GUARDAR";
            btnGuardarContrasenia.UseVisualStyleBackColor = false;
            btnGuardarContrasenia.Click += jzat506_btnGuardarContrasenia_Click;
            //
            // btnCancelarContrasenia
            //
            btnCancelarContrasenia.BackColor = Color.White;
            btnCancelarContrasenia.ForeColor = Color.DarkGreen;
            btnCancelarContrasenia.Location = new Point(160, 250);
            btnCancelarContrasenia.Name = "btnCancelarContrasenia";
            btnCancelarContrasenia.Size = new Size(120, 35);
            btnCancelarContrasenia.Text = "CANCELAR";
            btnCancelarContrasenia.UseVisualStyleBackColor = false;
            btnCancelarContrasenia.Click += jzat506_btnCancelarContrasenia_Click;
            //
            // jzat506_FrmCambiarContrasenia
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 224, 224);
            ClientSize = new Size(300, 310);
            Controls.Add(lblTituloContrasenia);
            Controls.Add(lblActual);
            Controls.Add(txtActual);
            Controls.Add(lblNueva);
            Controls.Add(txtNueva);
            Controls.Add(lblRepetir);
            Controls.Add(txtRepetir);
            Controls.Add(btnGuardarContrasenia);
            Controls.Add(btnCancelarContrasenia);
            Name = "jzat506_FrmCambiarContrasenia";
            Text = "Cambiar contraseña";
            Load += jzat506_FrmCambiarContrasenia_Load;
            FormClosing += jzat506_FrmCambiarContrasenia_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTituloContrasenia;
        private Label lblActual;
        private TextBox txtActual;
        private Label lblNueva;
        private TextBox txtNueva;
        private Label lblRepetir;
        private TextBox txtRepetir;
        private Button btnGuardarContrasenia;
        private Button btnCancelarContrasenia;
    }
}
