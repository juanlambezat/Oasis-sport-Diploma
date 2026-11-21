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
    public partial class jzat506_FrmRegistrarEnvio : BaseForm, IObserverIdioma
    {
        private readonly jzat506_BLL_Cliente jzat506_bllCliente = new jzat506_BLL_Cliente();
        private readonly jzat506_BLL_Pedido jzat506_bllPedido = new jzat506_BLL_Pedido();
        private readonly jzat506_BLL_Zona jzat506_bllZona = new jzat506_BLL_Zona();

        private jzat506_Cliente? jzat506_cliente;
        private jzat506_Factura? jzat506_factura;
        private jzat506_ZonaCobertura? jzat506_zona;
        private List<jzat506_Factura> jzat506_facturas = new List<jzat506_Factura>();

        private static readonly CultureInfo jzat506_cultura = new CultureInfo("es-AR");

        public jzat506_FrmRegistrarEnvio()
        {
            InitializeComponent();
            LanguageManager.GetInstance().Agregar(this);
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
            if (!(c is TextBox) && !string.IsNullOrWhiteSpace(c.Name) && !string.IsNullOrWhiteSpace(c.Text)
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

        public void ActualizarIdioma()
        {
            if (this.InvokeRequired)
                this.Invoke(new Action(() => LanguageManager.GetInstance().TraducirControles(this)));
            else
                LanguageManager.GetInstance().TraducirControles(this);
        }

        private void jzat506_FrmRegistrarEnvio_Load(object sender, EventArgs e)
        {
            LanguageManager.GetInstance().TraducirControles(this);
            jzat506_RegistrarClaves();

            lblClienteEnvio.Text = "Cliente: -";
            lblCostoValor.Text = "-";

            List<jzat506_ZonaCobertura> zonas = jzat506_bllZona.jzat506_ListarZonas();

            if (zonas.Count == 0)
                jzat506_MostrarError("No hay zonas de cobertura cargadas.");
            else
                jzat506_CargarZonas(zonas);
        }

        private void jzat506_CargarZonas(List<jzat506_ZonaCobertura> zonas)
        {
            cmbZona.Items.Clear();

            foreach (jzat506_ZonaCobertura zona in zonas)
                cmbZona.Items.Add(zona);
        }

        private void jzat506_cmbZona_SelectedIndexChanged(object? sender, EventArgs e)
        {
            jzat506_zona = cmbZona.SelectedItem as jzat506_ZonaCobertura;

            if (jzat506_zona != null)
                jzat506_MostrarCosto(jzat506_zona);
        }

        private void jzat506_MostrarCosto(jzat506_ZonaCobertura zona)
        {
            if (zona.jzat506_CostoEnvio == 0)
                lblCostoValor.Text = "Gratis";
            else
                lblCostoValor.Text = zona.jzat506_CostoEnvio.ToString("C", jzat506_cultura);
        }

        private void jzat506_btnBuscarCliente_Click(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(txtDNI.Text.Trim(), @"^[1-9][0-9]{6,7}$"))
            {
                jzat506_MostrarError("El DNI debe tener 7 u 8 digitos numericos.");
                return;
            }

            int dni = int.Parse(txtDNI.Text.Trim());

            jzat506_Cliente? cliente = jzat506_bllCliente.jzat506_BuscarCliente(dni);

            if (cliente == null)
            {
                jzat506_MostrarError("El cliente no esta registrado.");
                return;
            }

            jzat506_cliente = cliente;
            lblClienteEnvio.Text = "Cliente: " + cliente.jzat506_Nombre + " " + cliente.jzat506_Apellido;

            List<jzat506_Factura> facturas = jzat506_bllPedido.jzat506_ListarFacturasSinPedido(cliente);

            if (facturas.Count == 0)
            {
                dgvFacturas.Rows.Clear();
                jzat506_factura = null;
                jzat506_MostrarError("El cliente no tiene facturas sin envio.");
                return;
            }

            jzat506_CargarFacturas(facturas);
        }

        private void jzat506_CargarFacturas(List<jzat506_Factura> facturas)
        {
            jzat506_facturas = facturas;
            dgvFacturas.Rows.Clear();

            foreach (jzat506_Factura factura in facturas)
            {
                dgvFacturas.Rows.Add(
                    factura.jzat506_Id,
                    factura.jzat506_Fecha.ToString("dd/MM/yyyy HH:mm"),
                    factura.jzat506_MedioPago,
                    factura.jzat506_Total.ToString("C", jzat506_cultura));
            }

            dgvFacturas.Rows[0].Selected = true;
            jzat506_factura = jzat506_facturas[0];
        }

        private void jzat506_dgvFacturas_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgvFacturas.SelectedRows.Count == 0)
                return;

            int posicion = dgvFacturas.SelectedRows[0].Index;

            if (posicion < jzat506_facturas.Count)
                jzat506_factura = jzat506_facturas[posicion];
        }

        private void jzat506_btnConfirmar_Click(object sender, EventArgs e)
        {
            if (!jzat506_ValidarCampos())
                return;

            string medioPago = "Sin costo";

            if (jzat506_zona!.jzat506_CostoEnvio > 0)
            {
                using (jzat506_FrmCobrarVenta frm = new jzat506_FrmCobrarVenta(jzat506_zona.jzat506_CostoEnvio))
                {
                    if (frm.ShowDialog() != DialogResult.OK)
                        return;

                    medioPago = frm.jzat506_MedioPagoConfirmado ?? "";
                }
            }

            try
            {
                jzat506_bllPedido.jzat506_RegistrarPedido(jzat506_factura!, jzat506_zona, txtDireccion.Text.Trim(), txtTelefono.Text.Trim(), medioPago);
                jzat506_MostrarAviso("Envio registrado.");
                jzat506_ReiniciarEnvio();
            }
            catch (Exception ex)
            {
                jzat506_MostrarError(ex.Message);
            }
        }

        private bool jzat506_ValidarCampos()
        {
            if (jzat506_cliente == null)
            {
                jzat506_MostrarError("Busque al cliente antes de confirmar el envio.");
                return false;
            }

            if (jzat506_factura == null)
            {
                jzat506_MostrarError("Seleccione la factura del envio.");
                return false;
            }

            if (jzat506_zona == null)
            {
                jzat506_MostrarError("Seleccione la zona de cobertura.");
                return false;
            }

            string direccion = txtDireccion.Text.Trim();

            if (direccion.Length < 5 || direccion.Length > 150)
            {
                jzat506_MostrarError("La direccion debe tener entre 5 y 150 caracteres.");
                return false;
            }

            if (!Regex.IsMatch(txtTelefono.Text.Trim(), @"^[0-9]{8,15}$"))
            {
                jzat506_MostrarError("El telefono debe tener entre 8 y 15 digitos numericos.");
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

        private void jzat506_ReiniciarEnvio()
        {
            jzat506_cliente = null;
            jzat506_factura = null;
            jzat506_facturas = new List<jzat506_Factura>();

            txtDNI.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
            dgvFacturas.Rows.Clear();
            lblClienteEnvio.Text = "Cliente: -";
        }

        private void jzat506_btnVolverEnvios_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void jzat506_FrmRegistrarEnvio_FormClosing(object sender, FormClosingEventArgs e)
        {
            LanguageManager.GetInstance().Quitar(this);
        }
    }
}
