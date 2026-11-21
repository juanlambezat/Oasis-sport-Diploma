using BLL;
using Entidades;
using Servicios;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace Oasis_Sports
{
    public partial class jzat506_FrmReporteEnvios : BaseForm, IObserverIdioma
    {
        private readonly jzat506_BLL_ReporteEnvio jzat506_bllReporte = new jzat506_BLL_ReporteEnvio();

        private List<jzat506_Pedido> jzat506_pedidos = new List<jzat506_Pedido>();
        private string jzat506_resumen = "";

        private static readonly CultureInfo jzat506_cultura = new CultureInfo("es-AR");

        public jzat506_FrmReporteEnvios()
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
            bool esTextoFijo = c is Label || c is Button;

            if (esTextoFijo && !string.IsNullOrWhiteSpace(c.Name) && !string.IsNullOrWhiteSpace(c.Text)
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

        private void jzat506_FrmReporteEnvios_Load(object sender, EventArgs e)
        {
            LanguageManager.GetInstance().TraducirControles(this);
            jzat506_RegistrarClaves();

            cmbEstado.Items.Add("Todos");
            cmbEstado.Items.Add("Pendiente");
            cmbEstado.Items.Add("Preparando");
            cmbEstado.Items.Add("Despachado");
            cmbEstado.Items.Add("En camino");
            cmbEstado.Items.Add("Entregado");
            cmbEstado.SelectedIndex = 0;

            cmbZonaReporte.Items.Add("Todas");
            foreach (jzat506_ZonaCobertura zona in jzat506_bllReporte.jzat506_ListarZonas())
                cmbZonaReporte.Items.Add(zona);
            cmbZonaReporte.SelectedIndex = 0;

            dtpDesde.Value = DateTime.Today.AddDays(-30);
            dtpHasta.Value = DateTime.Today;

            lblResumenEnvios.Text = "Elija los filtros y presione Buscar.";
        }

        private void jzat506_btnBuscarEnvios_Click(object sender, EventArgs e)
        {
            string estado = "";
            if (cmbEstado.SelectedIndex > 0)
                estado = cmbEstado.SelectedItem!.ToString()!;

            jzat506_ZonaCobertura? zona = cmbZonaReporte.SelectedItem as jzat506_ZonaCobertura;

            List<jzat506_Pedido> pedidos;
            try
            {
                pedidos = jzat506_bllReporte.jzat506_ListarEnvios(dtpDesde.Value, dtpHasta.Value, estado, zona);
            }
            catch (Exception ex)
            {
                jzat506_MostrarError(ex.Message);
                return;
            }

            jzat506_CargarGrilla(pedidos);

            jzat506_resumen = jzat506_bllReporte.jzat506_ArmarResumen(pedidos);
            lblResumenEnvios.Text = jzat506_resumen;

            if (pedidos.Count == 0)
                jzat506_MostrarAviso("No hay envios para los filtros elegidos.");
        }

        private void jzat506_CargarGrilla(List<jzat506_Pedido> pedidos)
        {
            jzat506_pedidos = pedidos;
            dgvEnvios.Rows.Clear();

            foreach (jzat506_Pedido pedido in pedidos)
            {
                dgvEnvios.Rows.Add(
                    pedido.jzat506_Id,
                    pedido.jzat506_Fecha.ToString("dd/MM/yyyy", jzat506_cultura),
                    pedido.jzat506_Factura.jzat506_Cliente.jzat506_Nombre + " " + pedido.jzat506_Factura.jzat506_Cliente.jzat506_Apellido,
                    pedido.jzat506_Factura.jzat506_Id,
                    pedido.jzat506_Envio.jzat506_Zona.jzat506_Localidad,
                    pedido.jzat506_Estado,
                    pedido.jzat506_Envio.jzat506_CostoEnvio.ToString("C", jzat506_cultura),
                    pedido.jzat506_Envio.jzat506_MedioPago,
                    pedido.jzat506_Envio.jzat506_Transportista != null ? pedido.jzat506_Envio.jzat506_Transportista.ToString() : "Sin asignar");
            }
        }

        private void jzat506_btnExportarPDF_Click(object sender, EventArgs e)
        {
            if (jzat506_pedidos.Count == 0)
            {
                jzat506_MostrarError("Busque envios para exportar el reporte.");
                return;
            }

            using (SaveFileDialog dialogo = new SaveFileDialog())
            {
                dialogo.Title = "Exportar reporte de envios a PDF";
                dialogo.Filter = "Archivo PDF (*.pdf)|*.pdf";
                dialogo.FileName = "Reporte_Envios_" + DateTime.Today.ToString("yyyyMMdd") + ".pdf";

                if (dialogo.ShowDialog() != DialogResult.OK)
                    return;

                try
                {
                    jzat506_bllReporte.jzat506_ExportarPDF(jzat506_pedidos, jzat506_resumen, dialogo.FileName);
                    jzat506_AbrirArchivo(dialogo.FileName);
                }
                catch (IOException)
                {
                    jzat506_MostrarError("No se pudo guardar el archivo. Verifique que no este abierto en otro programa.");
                }
                catch (Exception ex)
                {
                    jzat506_MostrarError("No se pudo exportar: " + ex.Message);
                }
            }
        }

        private void jzat506_btnExportarExcel_Click(object sender, EventArgs e)
        {
            if (jzat506_pedidos.Count == 0)
            {
                jzat506_MostrarError("Busque envios para exportar el reporte.");
                return;
            }

            using (SaveFileDialog dialogo = new SaveFileDialog())
            {
                dialogo.Title = "Exportar reporte de envios a Excel";
                dialogo.Filter = "Libro de Excel (*.xlsx)|*.xlsx";
                dialogo.FileName = "Reporte_Envios_" + DateTime.Today.ToString("yyyyMMdd") + ".xlsx";

                if (dialogo.ShowDialog() != DialogResult.OK)
                    return;

                try
                {
                    jzat506_bllReporte.jzat506_ExportarExcel(jzat506_pedidos, jzat506_resumen, dialogo.FileName);
                    jzat506_AbrirArchivo(dialogo.FileName);
                }
                catch (IOException)
                {
                    jzat506_MostrarError("No se pudo guardar el archivo. Verifique que no este abierto en otro programa.");
                }
                catch (Exception ex)
                {
                    jzat506_MostrarError("No se pudo exportar: " + ex.Message);
                }
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

        private void jzat506_MostrarError(string mensaje)
        {
            MessageBox.Show(mensaje, "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void jzat506_MostrarAviso(string mensaje)
        {
            MessageBox.Show(mensaje, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void jzat506_btnVolverReporte_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void jzat506_FrmReporteEnvios_FormClosing(object sender, FormClosingEventArgs e)
        {
            LanguageManager.GetInstance().Quitar(this);
        }
    }
}
