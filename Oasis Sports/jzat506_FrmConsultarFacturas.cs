using BLL;
using Entidades;
using Servicios;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Oasis_Sports
{
    public partial class jzat506_FrmConsultarFacturas : BaseForm, IObserverIdioma
    {
        private readonly jzat506_BLL_ReporteFactura jzat506_bllReporte = new jzat506_BLL_ReporteFactura();
        private static readonly CultureInfo jzat506_cultura = new CultureInfo("es-AR");

        private jzat506_Cliente? jzat506_cliente;
        private List<jzat506_Factura> jzat506_facturas = new List<jzat506_Factura>();

        public jzat506_FrmConsultarFacturas()
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

        private void jzat506_FrmConsultarFacturas_Load(object sender, EventArgs e)
        {
            LanguageManager.GetInstance().TraducirControles(this);
            jzat506_RegistrarClaves();

            jzat506_LimpiarResultados();
        }

        private void jzat506_btnBuscarFacturas_Click(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(txtDNIConsulta.Text.Trim(), @"^[1-9][0-9]{6,7}$"))
            {
                jzat506_MostrarError("El DNI debe tener 7 u 8 digitos numericos.");
                return;
            }

            int dni = int.Parse(txtDNIConsulta.Text.Trim());

            jzat506_Cliente? cliente = jzat506_bllReporte.jzat506_BuscarCliente(dni);

            if (cliente == null)
            {
                jzat506_LimpiarResultados();
                jzat506_MostrarError("No existe un cliente con ese DNI.");
                return;
            }

            jzat506_cliente = cliente;
            jzat506_facturas = jzat506_bllReporte.jzat506_ListarFacturas(cliente);

            lblClienteConsulta.Text = $"Cliente: {cliente.jzat506_Nombre} {cliente.jzat506_Apellido}"
                + (cliente.jzat506_Activo ? "" : " (dado de baja)");

            jzat506_CargarGrillaFacturas();

            if (jzat506_facturas.Count == 0)
                jzat506_MostrarAviso("El cliente no tiene facturas registradas.");
        }

        private void jzat506_CargarGrillaFacturas()
        {
            dataGridViewFacturas.Rows.Clear();

            foreach (jzat506_Factura factura in jzat506_facturas)
            {
                dataGridViewFacturas.Rows.Add(
                    factura.jzat506_Id,
                    factura.jzat506_Fecha.ToString("dd/MM/yyyy HH:mm", jzat506_cultura),
                    factura.jzat506_MedioPago,
                    factura.jzat506_Total.ToString("C", jzat506_cultura));
            }

            if (dataGridViewFacturas.Rows.Count > 0)
            {
                dataGridViewFacturas.CurrentCell = dataGridViewFacturas.Rows[0].Cells[0];
                dataGridViewFacturas.Rows[0].Selected = true;
            }

            jzat506_MostrarDetalle();
        }

        private jzat506_Factura? jzat506_FacturaSeleccionada()
        {
            if (dataGridViewFacturas.SelectedRows.Count == 0)
                return null;

            int idFactura = Convert.ToInt32(dataGridViewFacturas.SelectedRows[0].Cells[0].Value);
            return jzat506_facturas.FirstOrDefault(f => f.jzat506_Id == idFactura);
        }

        private void jzat506_dataGridViewFacturas_SelectionChanged(object? sender, EventArgs e)
        {
            jzat506_MostrarDetalle();
        }

        private void jzat506_MostrarDetalle()
        {
            dataGridViewDetalleFactura.Rows.Clear();

            jzat506_Factura? factura = jzat506_FacturaSeleccionada();

            if (factura == null)
            {
                lblTotalSeleccionada.Text = "Total: " + 0m.ToString("C", jzat506_cultura);
                return;
            }

            foreach (jzat506_DetalleFactura detalle in factura.jzat506_Detalles)
            {
                dataGridViewDetalleFactura.Rows.Add(
                    detalle.jzat506_Producto.jzat506_Nombre,
                    detalle.jzat506_Cantidad,
                    detalle.jzat506_PrecioUnitario.ToString("C", jzat506_cultura),
                    (detalle.jzat506_Cantidad * detalle.jzat506_PrecioUnitario).ToString("C", jzat506_cultura));
            }

            lblTotalSeleccionada.Text = "Total: " + factura.jzat506_Total.ToString("C", jzat506_cultura);
        }

        private void jzat506_btnExportarPDF_Click(object sender, EventArgs e)
        {
            jzat506_Factura? factura = jzat506_FacturaSeleccionada();

            if (factura == null)
            {
                jzat506_MostrarError("Seleccione una factura de la lista.");
                return;
            }

            using (SaveFileDialog dialogo = new SaveFileDialog())
            {
                dialogo.Title = "Exportar factura a PDF";
                dialogo.Filter = "Archivo PDF (*.pdf)|*.pdf";
                dialogo.FileName = $"Factura_{factura.jzat506_Id}.pdf";

                if (dialogo.ShowDialog() != DialogResult.OK)
                    return;

                jzat506_Exportar(() => jzat506_bllReporte.jzat506_ExportarFacturaPDF(factura, dialogo.FileName), dialogo.FileName);
            }
        }

        private void jzat506_btnExportarExcel_Click(object sender, EventArgs e)
        {
            if (jzat506_cliente == null || jzat506_facturas.Count == 0)
            {
                jzat506_MostrarError("Busque un cliente con facturas para exportar el listado.");
                return;
            }

            using (SaveFileDialog dialogo = new SaveFileDialog())
            {
                dialogo.Title = "Exportar listado a Excel";
                dialogo.Filter = "Libro de Excel (*.xlsx)|*.xlsx";
                dialogo.FileName = $"Facturas_{jzat506_cliente.jzat506_DNI}.xlsx";

                if (dialogo.ShowDialog() != DialogResult.OK)
                    return;

                jzat506_Exportar(() => jzat506_bllReporte.jzat506_ExportarListadoExcel(jzat506_cliente, jzat506_facturas, dialogo.FileName), dialogo.FileName);
            }
        }

        private void jzat506_Exportar(Action exportacion, string ruta)
        {
            try
            {
                exportacion();
                jzat506_AbrirArchivo(ruta);
            }
            catch (IOException)
            {
                jzat506_MostrarError("No se pudo guardar el archivo. Verifique que no este abierto en otro programa.");
            }
            catch (UnauthorizedAccessException)
            {
                jzat506_MostrarError("No se tiene permiso para guardar en esa ubicacion.");
            }
            catch (Exception ex)
            {
                jzat506_MostrarError("No se pudo exportar: " + ex.Message);
            }
        }

        private void jzat506_AbrirArchivo(string ruta)
        {
            try
            {
                Process.Start(new ProcessStartInfo(ruta) { UseShellExecute = true });
            }
            catch (Exception)
            {
                jzat506_MostrarAviso("Archivo guardado en: " + ruta);
            }
        }

        private void jzat506_txtDNIConsulta_TextChanged(object? sender, EventArgs e)
        {
            jzat506_LimpiarResultados();
        }

        private void jzat506_LimpiarResultados()
        {
            jzat506_cliente = null;
            jzat506_facturas = new List<jzat506_Factura>();
            lblClienteConsulta.Text = "Cliente: -";
            dataGridViewFacturas.Rows.Clear();
            dataGridViewDetalleFactura.Rows.Clear();
            lblTotalSeleccionada.Text = "Total: " + 0m.ToString("C", jzat506_cultura);
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

        private void jzat506_btnVolverFacturas_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void jzat506_FrmConsultarFacturas_FormClosing(object sender, FormClosingEventArgs e)
        {
            LanguageManager.GetInstance().Quitar(this);
        }
    }
}
