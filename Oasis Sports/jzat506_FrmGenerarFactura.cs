using BLL;
using Entidades;
using Servicios;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Oasis_Sports
{
    public partial class jzat506_FrmGenerarFactura : BaseForm, IObserverIdioma
    {
        private readonly jzat506_BLL_Cliente jzat506_bllCliente = new jzat506_BLL_Cliente();
        private readonly jzat506_BLL_Factura jzat506_bllFactura = new jzat506_BLL_Factura();

        private jzat506_Cliente? jzat506_cliente;
        private List<jzat506_DetalleFactura> jzat506_detalles = new List<jzat506_DetalleFactura>();
        private string? jzat506_medioPagoConfirmado;

        private static readonly CultureInfo jzat506_cultura = new CultureInfo("es-AR");

        public jzat506_FrmGenerarFactura()
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

        private void jzat506_FrmGenerarFactura_Load(object sender, EventArgs e)
        {
            LanguageManager.GetInstance().TraducirControles(this);
            jzat506_RegistrarClaves();

            jzat506_ReiniciarVenta();
        }

        private void jzat506_btnSeleccionarProductos_Click(object sender, EventArgs e)
        {
            using (jzat506_FrmSeleccionarProductos frm = new jzat506_FrmSeleccionarProductos())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    jzat506_detalles = frm.jzat506_Carrito;
                    jzat506_ActualizarGrillaCarrito();

                    if (jzat506_medioPagoConfirmado != null)
                    {
                        jzat506_AnularPago();
                        MessageBox.Show("Cambiaron los productos, por lo que el pago confirmado anteriormente quedo sin efecto. Debe cobrar la venta nuevamente.",
                            "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void jzat506_AnularPago()
        {
            jzat506_medioPagoConfirmado = null;
            lblEstadoPago.Text = "Pago: pendiente";
            btnCobrarVenta.Enabled = true;
        }

        private void jzat506_ActualizarGrillaCarrito()
        {
            dataGridViewCarrito.Rows.Clear();
            foreach (jzat506_DetalleFactura detalle in jzat506_detalles)
            {
                dataGridViewCarrito.Rows.Add(
                    detalle.jzat506_Producto.jzat506_Nombre,
                    detalle.jzat506_Cantidad,
                    detalle.jzat506_PrecioUnitario.ToString("C", jzat506_cultura),
                    (detalle.jzat506_Cantidad * detalle.jzat506_PrecioUnitario).ToString("C", jzat506_cultura));
            }

            decimal total = jzat506_detalles.Sum(d => d.jzat506_Cantidad * d.jzat506_PrecioUnitario);
            lblTotalCarrito.Text = "Total: " + total.ToString("C", jzat506_cultura);
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
                using (jzat506_FrmRegistrarCliente frm = new jzat506_FrmRegistrarCliente(dni))
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                        cliente = frm.jzat506_ClienteRegistrado;
                }
            }

            if (cliente == null)
                return;

            if (!cliente.jzat506_Activo)
            {
                jzat506_MostrarError("El cliente fue eliminado y no se le puede facturar.");
                return;
            }

            jzat506_cliente = cliente;
            jzat506_CargarDatosCliente(cliente);
        }

        private void jzat506_CargarDatosCliente(jzat506_Cliente cliente)
        {
            lblClienteInfo.Text = $"Cliente: {cliente.jzat506_Nombre} {cliente.jzat506_Apellido}";
        }

        private void jzat506_txtDNI_TextChanged(object? sender, EventArgs e)
        {
            jzat506_cliente = null;
            lblClienteInfo.Text = "Cliente: -";
        }

        private void jzat506_SoloDigitos_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && (e.KeyChar < '0' || e.KeyChar > '9'))
                e.Handled = true;
        }

        private void jzat506_btnCobrarVenta_Click(object sender, EventArgs e)
        {
            if (jzat506_detalles.Count == 0)
            {
                jzat506_MostrarError("Seleccione los productos antes de cobrar.");
                return;
            }

            decimal total = jzat506_detalles.Sum(d => d.jzat506_Cantidad * d.jzat506_PrecioUnitario);

            using (jzat506_FrmCobrarVenta frm = new jzat506_FrmCobrarVenta(total))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    jzat506_medioPagoConfirmado = frm.jzat506_MedioPagoConfirmado;
                    lblEstadoPago.Text = "Pago: " + jzat506_medioPagoConfirmado + " confirmado";
                    btnCobrarVenta.Enabled = false;
                }
            }
        }

        private void jzat506_btnGenerar_Click(object sender, EventArgs e)
        {
            if (!jzat506_ValidarVenta())
                return;

            jzat506_Factura factura = jzat506_bllFactura.jzat506_GenerarFactura(jzat506_cliente!, jzat506_detalles, jzat506_medioPagoConfirmado!);

            jzat506_MostrarFactura(factura);
            jzat506_ReiniciarVenta();
        }

        private bool jzat506_ValidarVenta()
        {
            if (jzat506_cliente == null)
            {
                jzat506_MostrarError("Busque o registre al cliente antes de generar la factura.");
                return false;
            }

            if (jzat506_detalles.Count == 0)
            {
                jzat506_MostrarError("Seleccione los productos antes de generar la factura.");
                return false;
            }

            if (jzat506_medioPagoConfirmado == null)
            {
                jzat506_MostrarError("Cobre la venta antes de generar la factura.");
                return false;
            }

            return true;
        }

        private void jzat506_MostrarFactura(jzat506_Factura factura)
        {
            string detalle = string.Join("\n", factura.jzat506_Detalles.Select(d =>
                $"{d.jzat506_Cantidad} x {d.jzat506_Producto.jzat506_Nombre} = {(d.jzat506_Cantidad * d.jzat506_PrecioUnitario).ToString("C", jzat506_cultura)}"));

            string mensaje = $"Factura N.{factura.jzat506_Id}\n" +
                              $"Cliente: {factura.jzat506_Cliente.jzat506_Nombre} {factura.jzat506_Cliente.jzat506_Apellido}\n" +
                              $"Fecha: {factura.jzat506_Fecha}\n" +
                              $"Medio de pago: {factura.jzat506_MedioPago}\n\n" +
                              $"{detalle}\n\n" +
                              $"Total: {factura.jzat506_Total.ToString("C", jzat506_cultura)}\n\n" +
                              "Entregue la factura y los productos al cliente.";

            MessageBox.Show(mensaje, "Factura generada", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void jzat506_MostrarError(string mensaje)
        {
            MessageBox.Show(mensaje, "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void jzat506_ReiniciarVenta()
        {
            jzat506_cliente = null;
            jzat506_detalles = new List<jzat506_DetalleFactura>();

            txtDNI.Clear();
            lblClienteInfo.Text = "Cliente: -";
            jzat506_AnularPago();
            dataGridViewCarrito.Rows.Clear();
            lblTotalCarrito.Text = "Total: " + 0m.ToString("C", jzat506_cultura);
        }

        private void jzat506_btnVolverVentas_Click(object sender, EventArgs e)
        {
            FrmMenu frmMenu = new FrmMenu();
            frmMenu.Show();
            this.Hide();
        }

        private void jzat506_FrmGenerarFactura_FormClosing(object sender, FormClosingEventArgs e)
        {
            LanguageManager.GetInstance().Quitar(this);
        }
    }
}
