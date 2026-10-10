namespace Oasis_Sports
{
    partial class jzat506_FrmCobrarVenta
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
            lblTituloCobro = new Label();
            lblTotalTexto = new Label();
            lblTotalValor = new Label();
            lblMedioPago = new Label();
            radioEfectivo = new RadioButton();
            radioTransferencia = new RadioButton();
            panelBanco = new Panel();
            lblBanco = new Label();
            txtBanco = new TextBox();
            lblNumeroCuenta = new Label();
            txtNumeroCuenta = new TextBox();
            lblTitular = new Label();
            txtTitular = new TextBox();
            btnCobrar = new Button();
            btnCancelarPago = new Button();
            panelBanco.SuspendLayout();
            SuspendLayout();
            //
            // lblTituloCobro
            //
            lblTituloCobro.AutoSize = true;
            lblTituloCobro.Font = new Font("Times New Roman", 14F, FontStyle.Bold);
            lblTituloCobro.ForeColor = Color.DarkGreen;
            lblTituloCobro.Location = new Point(20, 15);
            lblTituloCobro.Name = "lblTituloCobro";
            lblTituloCobro.Size = new Size(119, 22);
            lblTituloCobro.TabIndex = 0;
            lblTituloCobro.Text = "Cobrar venta";
            //
            // lblTotalTexto
            //
            lblTotalTexto.AutoSize = true;
            lblTotalTexto.ForeColor = Color.DarkGreen;
            lblTotalTexto.Location = new Point(20, 65);
            lblTotalTexto.Name = "lblTotalTexto";
            lblTotalTexto.Size = new Size(119, 21);
            lblTotalTexto.TabIndex = 1;
            lblTotalTexto.Text = "Total a cobrar:";
            //
            // lblTotalValor
            //
            lblTotalValor.AutoSize = true;
            lblTotalValor.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            lblTotalValor.ForeColor = Color.DarkGreen;
            lblTotalValor.Location = new Point(150, 63);
            lblTotalValor.Name = "lblTotalValor";
            lblTotalValor.Size = new Size(25, 19);
            lblTotalValor.TabIndex = 2;
            lblTotalValor.Text = "$0";
            //
            // lblMedioPago
            //
            lblMedioPago.AutoSize = true;
            lblMedioPago.ForeColor = Color.DarkGreen;
            lblMedioPago.Location = new Point(20, 105);
            lblMedioPago.Name = "lblMedioPago";
            lblMedioPago.Size = new Size(123, 21);
            lblMedioPago.TabIndex = 3;
            lblMedioPago.Text = "Medio de pago";
            //
            // radioEfectivo
            //
            radioEfectivo.AutoSize = true;
            radioEfectivo.Checked = true;
            radioEfectivo.ForeColor = Color.DarkGreen;
            radioEfectivo.Location = new Point(20, 135);
            radioEfectivo.Name = "radioEfectivo";
            radioEfectivo.Size = new Size(90, 25);
            radioEfectivo.TabIndex = 4;
            radioEfectivo.TabStop = true;
            radioEfectivo.Text = "Efectivo";
            //
            // radioTransferencia
            //
            radioTransferencia.AutoSize = true;
            radioTransferencia.ForeColor = Color.DarkGreen;
            radioTransferencia.Location = new Point(140, 135);
            radioTransferencia.Name = "radioTransferencia";
            radioTransferencia.Size = new Size(128, 25);
            radioTransferencia.TabIndex = 5;
            radioTransferencia.Text = "Transferencia";
            radioTransferencia.CheckedChanged += jzat506_radioTransferencia_CheckedChanged;
            //
            // panelBanco
            //
            panelBanco.Controls.Add(lblBanco);
            panelBanco.Controls.Add(txtBanco);
            panelBanco.Controls.Add(lblNumeroCuenta);
            panelBanco.Controls.Add(txtNumeroCuenta);
            panelBanco.Controls.Add(lblTitular);
            panelBanco.Controls.Add(txtTitular);
            panelBanco.Location = new Point(20, 170);
            panelBanco.Name = "panelBanco";
            panelBanco.Size = new Size(400, 140);
            panelBanco.TabIndex = 6;
            panelBanco.Visible = false;
            //
            // lblBanco
            //
            lblBanco.AutoSize = true;
            lblBanco.ForeColor = Color.DarkGreen;
            lblBanco.Location = new Point(0, 5);
            lblBanco.Name = "lblBanco";
            lblBanco.Size = new Size(58, 21);
            lblBanco.TabIndex = 0;
            lblBanco.Text = "Banco";
            //
            // txtBanco
            //
            txtBanco.Location = new Point(175, 2);
            txtBanco.MaxLength = 50;
            txtBanco.Name = "txtBanco";
            txtBanco.Size = new Size(225, 29);
            txtBanco.TabIndex = 1;
            //
            // lblNumeroCuenta
            //
            lblNumeroCuenta.AutoSize = true;
            lblNumeroCuenta.ForeColor = Color.DarkGreen;
            lblNumeroCuenta.Location = new Point(0, 45);
            lblNumeroCuenta.Name = "lblNumeroCuenta";
            lblNumeroCuenta.Size = new Size(146, 21);
            lblNumeroCuenta.TabIndex = 2;
            lblNumeroCuenta.Text = "Numero de cuenta";
            //
            // txtNumeroCuenta
            //
            txtNumeroCuenta.Location = new Point(175, 42);
            txtNumeroCuenta.MaxLength = 22;
            txtNumeroCuenta.Name = "txtNumeroCuenta";
            txtNumeroCuenta.Size = new Size(225, 29);
            txtNumeroCuenta.TabIndex = 3;
            txtNumeroCuenta.KeyPress += jzat506_SoloDigitos_KeyPress;
            //
            // lblTitular
            //
            lblTitular.AutoSize = true;
            lblTitular.ForeColor = Color.DarkGreen;
            lblTitular.Location = new Point(0, 85);
            lblTitular.Name = "lblTitular";
            lblTitular.Size = new Size(57, 21);
            lblTitular.TabIndex = 4;
            lblTitular.Text = "Titular";
            //
            // txtTitular
            //
            txtTitular.Location = new Point(175, 82);
            txtTitular.MaxLength = 50;
            txtTitular.Name = "txtTitular";
            txtTitular.Size = new Size(225, 29);
            txtTitular.TabIndex = 5;
            //
            // btnCobrar
            //
            btnCobrar.BackColor = Color.White;
            btnCobrar.ForeColor = Color.DarkGreen;
            btnCobrar.Location = new Point(140, 330);
            btnCobrar.Name = "btnCobrar";
            btnCobrar.Size = new Size(120, 32);
            btnCobrar.TabIndex = 7;
            btnCobrar.Text = "Cobrar";
            btnCobrar.UseVisualStyleBackColor = false;
            btnCobrar.Click += jzat506_btnCobrar_Click;
            //
            // btnCancelarPago
            //
            btnCancelarPago.BackColor = Color.White;
            btnCancelarPago.ForeColor = Color.DarkGreen;
            btnCancelarPago.Location = new Point(280, 330);
            btnCancelarPago.Name = "btnCancelarPago";
            btnCancelarPago.Size = new Size(120, 32);
            btnCancelarPago.TabIndex = 8;
            btnCancelarPago.Text = "Cancelar";
            btnCancelarPago.UseVisualStyleBackColor = false;
            btnCancelarPago.Click += jzat506_btnCancelarPago_Click;
            //
            // jzat506_FrmCobrarVenta
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 224, 224);
            ClientSize = new Size(460, 390);
            Controls.Add(lblTituloCobro);
            Controls.Add(lblTotalTexto);
            Controls.Add(lblTotalValor);
            Controls.Add(lblMedioPago);
            Controls.Add(radioEfectivo);
            Controls.Add(radioTransferencia);
            Controls.Add(panelBanco);
            Controls.Add(btnCobrar);
            Controls.Add(btnCancelarPago);
            Name = "jzat506_FrmCobrarVenta";
            Text = "Cobrar venta";
            FormClosing += jzat506_FrmCobrarVenta_FormClosing;
            Load += jzat506_FrmCobrarVenta_Load;
            panelBanco.ResumeLayout(false);
            panelBanco.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTituloCobro;
        private Label lblTotalTexto;
        private Label lblTotalValor;
        private Label lblMedioPago;
        private RadioButton radioEfectivo;
        private RadioButton radioTransferencia;
        private Panel panelBanco;
        private Label lblBanco;
        private TextBox txtBanco;
        private Label lblNumeroCuenta;
        private TextBox txtNumeroCuenta;
        private Label lblTitular;
        private TextBox txtTitular;
        private Button btnCobrar;
        private Button btnCancelarPago;
    }
}
