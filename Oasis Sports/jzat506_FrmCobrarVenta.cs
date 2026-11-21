using BLL;
using Entidades;
using Servicios;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Oasis_Sports
{
    public partial class jzat506_FrmCobrarVenta : BaseForm, IObserverIdioma
    {
        private readonly jzat506_BLL_Pago jzat506_bllPago = new jzat506_BLL_Pago();
        private readonly decimal jzat506_total;

        private static readonly CultureInfo jzat506_cultura = new CultureInfo("es-AR");

        public string? jzat506_MedioPagoConfirmado { get; private set; }

        public jzat506_FrmCobrarVenta(decimal total)
        {
            InitializeComponent();
            LanguageManager.GetInstance().Agregar(this);
            jzat506_total = total;
        }

        private void jzat506_RegistrarClaves()
        {
            int idIdioma = LanguageManager.GetInstance().IdIdiomaActual;
            BLL_Traduccion bll = new BLL_Traduccion();
            List<string> clavesExistentes = bll.ObtenerTodasLasClaves();

            foreach (Control c in this.Controls)
                jzat506_RegistrarRecursivo(c, idIdioma, bll, clavesExistentes);
        }

        private void jzat506_RegistrarRecursivo(Control c, int idIdioma, BLL_Traduccion bll, List<string> clavesExistentes)
        {
            if (c is MenuStrip ms)
            {
                jzat506_RegistrarMenuItems(ms.Items, idIdioma, bll, clavesExistentes);
                return;
            }

            if (!string.IsNullOrWhiteSpace(c.Name) && !string.IsNullOrWhiteSpace(c.Text)
                && !clavesExistentes.Contains(c.Name))
            {
                bll.GuardarOActualizar(new Traduccion
                {
                    IdIdioma = idIdioma,
                    Clave = c.Name,
                    Texto = c.Text
                });
                clavesExistentes.Add(c.Name);
            }

            foreach (Control hijo in c.Controls)
                jzat506_RegistrarRecursivo(hijo, idIdioma, bll, clavesExistentes);
        }

        private void jzat506_RegistrarMenuItems(ToolStripItemCollection items, int idIdioma, BLL_Traduccion bll, List<string> clavesExistentes)
        {
            foreach (ToolStripItem item in items)
            {
                if (!string.IsNullOrWhiteSpace(item.Name) && !string.IsNullOrWhiteSpace(item.Text)
                    && !clavesExistentes.Contains(item.Name))
                {
                    bll.GuardarOActualizar(new Traduccion
                    {
                        IdIdioma = idIdioma,
                        Clave = item.Name,
                        Texto = item.Text
                    });
                    clavesExistentes.Add(item.Name);
                }

                if (item is ToolStripMenuItem mi && mi.DropDownItems.Count > 0)
                    jzat506_RegistrarMenuItems(mi.DropDownItems, idIdioma, bll, clavesExistentes);
            }
        }

        public void ActualizarIdioma()
        {
            if (this.InvokeRequired)
                this.Invoke(new Action(() => LanguageManager.GetInstance().TraducirControles(this)));
            else
                LanguageManager.GetInstance().TraducirControles(this);
        }

        private void jzat506_FrmCobrarVenta_Load(object sender, EventArgs e)
        {
            LanguageManager.GetInstance().TraducirControles(this);
            jzat506_RegistrarClaves();

            lblTotalValor.Text = jzat506_total.ToString("C", jzat506_cultura);
        }

        private void jzat506_radioTransferencia_CheckedChanged(object sender, EventArgs e)
        {
            panelBanco.Visible = radioTransferencia.Checked;
        }

        private void jzat506_btnCobrar_Click(object sender, EventArgs e)
        {
            if (!jzat506_ValidarCampos(out string mensaje))
            {
                jzat506_MostrarError(mensaje);
                return;
            }

            jzat506_DatosPago datosPago = new jzat506_DatosPago
            {
                jzat506_MedioPago = radioEfectivo.Checked ? "Efectivo" : "Transferencia",
                jzat506_Banco = txtBanco.Text.Trim(),
                jzat506_NumeroCuenta = txtNumeroCuenta.Text.Trim(),
                jzat506_Titular = txtTitular.Text.Trim()
            };

            try
            {
                jzat506_bllPago.jzat506_CobrarVenta(jzat506_total, datosPago);
                jzat506_MedioPagoConfirmado = datosPago.jzat506_MedioPago;
                jzat506_MostrarAviso("Pago confirmado.");
                jzat506_CerrarConPago();
            }
            catch (Exception ex)
            {
                jzat506_MostrarError(ex.Message);
            }
        }

        private bool jzat506_ValidarCampos(out string mensaje)
        {
            mensaje = "";

            if (radioEfectivo.Checked)
                return true;

            string banco = txtBanco.Text.Trim();
            string numeroCuenta = txtNumeroCuenta.Text.Trim();
            string titular = txtTitular.Text.Trim();

            if (banco.Length < 2 || banco.Length > 50 || !Regex.IsMatch(banco, @"^\p{L}[\p{L} .'\-]*$"))
            {
                mensaje = "El banco debe tener entre 2 y 50 letras (se permiten espacios, puntos y guiones).";
                return false;
            }

            if (!Regex.IsMatch(numeroCuenta, @"^[0-9]{22}$"))
            {
                mensaje = "El numero de cuenta debe tener exactamente 22 digitos numericos.";
                return false;
            }

            if (titular.Length < 2 || titular.Length > 50 || !Regex.IsMatch(titular, @"^\p{L}+([ '\-]\p{L}+)*$"))
            {
                mensaje = "El titular debe tener entre 2 y 50 letras (se permiten espacios, guiones y apostrofes).";
                return false;
            }

            return true;
        }

        private void jzat506_SoloDigitos_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && (e.KeyChar < '0' || e.KeyChar > '9'))
                e.Handled = true;
        }

        private void jzat506_MostrarError(string mensaje)
        {
            MessageBox.Show(mensaje, "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void jzat506_MostrarAviso(string mensaje)
        {
            MessageBox.Show(mensaje, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void jzat506_CerrarConPago()
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void jzat506_btnCancelarPago_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void jzat506_FrmCobrarVenta_FormClosing(object sender, FormClosingEventArgs e)
        {
            LanguageManager.GetInstance().Quitar(this);
        }
    }
}
