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
    public partial class jzat506_FrmReporteInteligente : BaseForm, IObserverIdioma
    {
        private readonly jzat506_BLL_AnalisisVentas jzat506_bllAnalisis = new jzat506_BLL_AnalisisVentas();

        private jzat506_AnalisisVentas? jzat506_analisis = null;

        private static readonly CultureInfo jzat506_cultura = new CultureInfo("es-AR");

        public jzat506_FrmReporteInteligente()
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

        private void jzat506_FrmReporteInteligente_Load(object sender, EventArgs e)
        {
            LanguageManager.GetInstance().TraducirControles(this);
            jzat506_RegistrarClaves();

            dtpDesdeInteligente.Value = DateTime.Today.AddDays(-29);
            dtpHastaInteligente.Value = DateTime.Today;

            txtConclusiones.Text = "Elija un período y presione Analizar.";
        }

        private void jzat506_btnAnalizar_Click(object sender, EventArgs e)
        {
            jzat506_AnalisisVentas analisis;
            try
            {
                analisis = jzat506_bllAnalisis.jzat506_Analizar(dtpDesdeInteligente.Value, dtpHastaInteligente.Value);
            }
            catch (Exception ex)
            {
                jzat506_MostrarError(ex.Message);
                return;
            }

            jzat506_analisis = analisis;

            lblComparacion.Text = "Se compara con el período del "
                + analisis.jzat506_DesdeAnterior.ToString("dd/MM/yyyy", jzat506_cultura) + " al "
                + analisis.jzat506_HastaAnterior.ToString("dd/MM/yyyy", jzat506_cultura);

            jzat506_CargarIndicadores(analisis);
            jzat506_MostrarConclusiones(analisis);
        }

        private void jzat506_CargarIndicadores(jzat506_AnalisisVentas analisis)
        {
            dgvIndicadores.Rows.Clear();

            foreach (jzat506_IndicadorAnalisis indicador in analisis.jzat506_Indicadores)
            {
                dgvIndicadores.Rows.Add(
                    indicador.jzat506_Nombre,
                    indicador.jzat506_ValorActual,
                    indicador.jzat506_ValorAnterior,
                    indicador.jzat506_Variacion);
            }

            dgvIndicadores.ClearSelection();
        }

        private void jzat506_MostrarConclusiones(jzat506_AnalisisVentas analisis)
        {
            string texto = "";
            int numero = 1;

            foreach (string conclusion in analisis.jzat506_Conclusiones)
            {
                if (texto != "")
                    texto += Environment.NewLine + Environment.NewLine;
                texto += numero + ". " + conclusion;
                numero++;
            }

            txtConclusiones.Text = texto;
        }

        private void jzat506_btnExportarPDFInteligente_Click(object sender, EventArgs e)
        {
            if (jzat506_analisis == null)
            {
                jzat506_MostrarError("Analice un período para exportar el reporte.");
                return;
            }

            using (SaveFileDialog dialogo = new SaveFileDialog())
            {
                dialogo.Title = "Exportar reporte inteligente a PDF";
                dialogo.Filter = "Archivo PDF (*.pdf)|*.pdf";
                dialogo.FileName = "Reporte_Inteligente_" + DateTime.Today.ToString("yyyyMMdd") + ".pdf";

                if (dialogo.ShowDialog() != DialogResult.OK)
                    return;

                try
                {
                    jzat506_bllAnalisis.jzat506_ExportarPDF(jzat506_analisis, dialogo.FileName);
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
                MessageBox.Show("Archivo guardado en: " + ruta, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void jzat506_MostrarError(string mensaje)
        {
            MessageBox.Show(mensaje, "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void jzat506_btnVolverInteligente_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void jzat506_FrmReporteInteligente_FormClosing(object sender, FormClosingEventArgs e)
        {
            LanguageManager.GetInstance().Quitar(this);
        }
    }
}
