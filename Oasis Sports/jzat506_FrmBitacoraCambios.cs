using BLL;
using Entidades;
using Servicios;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Oasis_Sports
{
    public partial class jzat506_FrmBitacoraCambios : BaseForm, IObserverIdioma
    {
        private readonly jzat506_BLL_Usuario_C jzat506_bllUsuarioC = new jzat506_BLL_Usuario_C();
        private readonly BLLUsuario jzat506_bllUsuario = new BLLUsuario();

        private List<jzat506_Usuario_C> jzat506_versiones = new List<jzat506_Usuario_C>();
        private jzat506_Usuario_C? jzat506_versionSeleccionada;

        public jzat506_FrmBitacoraCambios()
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

        private void jzat506_FrmBitacoraCambios_Load(object sender, EventArgs e)
        {
            LanguageManager.GetInstance().TraducirControles(this);
            jzat506_RegistrarClaves();

            jzat506_CargarVersiones();
            jzat506_CargarFiltros(jzat506_versiones);

            if (jzat506_versiones.Count == 0)
                jzat506_MostrarAviso("No hay cambios registrados.");
        }

        private void jzat506_CargarVersiones()
        {
            jzat506_versiones = jzat506_bllUsuarioC.jzat506_ListarVersiones();
            jzat506_MostrarVersiones(jzat506_versiones);
        }

        private void jzat506_CargarFiltros(List<jzat506_Usuario_C> versiones)
        {
            List<Usuario> usuarios = new List<Usuario>();
            usuarios.Add(new Usuario { Id = 0, Username = "(Todos)" });
            usuarios.AddRange(jzat506_bllUsuario.Listar());

            cmbUsuarioCambios.DataSource = usuarios;
            cmbUsuarioCambios.DisplayMember = "Username";
            cmbUsuarioCambios.ValueMember = "Id";

            List<string> nombres = new List<string>();
            foreach (jzat506_Usuario_C version in versiones)
            {
                if (!nombres.Contains(version.jzat506_NombreUsuario))
                    nombres.Add(version.jzat506_NombreUsuario);
            }
            nombres.Sort();
            nombres.Insert(0, "(Todos)");

            cmbNombreCambios.DataSource = nombres;

            dtpFechaInicioCambios.Value = jzat506_FechaMasVieja();
            dtpFechaFinCambios.Value = DateTime.Today;
        }

        private DateTime jzat506_FechaMasVieja()
        {
            DateTime fecha = DateTime.Today;
            foreach (jzat506_Usuario_C version in jzat506_versiones)
            {
                if (version.jzat506_Fecha < fecha)
                    fecha = version.jzat506_Fecha;
            }
            return fecha;
        }

        private void jzat506_MostrarVersiones(List<jzat506_Usuario_C> versiones)
        {
            dgvVersiones.Rows.Clear();

            foreach (jzat506_Usuario_C version in versiones)
            {
                dgvVersiones.Rows.Add(
                    version.jzat506_IdVersion,
                    version.jzat506_IdUsuario,
                    version.jzat506_Fecha.ToString("dd/MM/yyyy"),
                    version.jzat506_Hora.ToString(@"hh\:mm\:ss"),
                    version.jzat506_NombreUsuario,
                    "***",
                    version.jzat506_Bloqueado ? "Si" : "No",
                    version.jzat506_Eliminado ? "Si" : "No",
                    version.jzat506_Usuario,
                    version.jzat506_Activo ? "Si" : "No");
            }

            dgvVersiones.ClearSelection();
            jzat506_versionSeleccionada = null;
        }

        private void jzat506_btnAplicar_Click(object? sender, EventArgs e)
        {
            jzat506_FiltrarVersiones();
        }

        private void jzat506_btnLimpiar_Click(object? sender, EventArgs e)
        {
            jzat506_LimpiarFiltros();
        }

        private void jzat506_LimpiarFiltros()
        {
            cmbUsuarioCambios.SelectedIndex = 0;
            cmbNombreCambios.SelectedIndex = 0;
            dtpFechaInicioCambios.Value = jzat506_FechaMasVieja();
            dtpFechaFinCambios.Value = DateTime.Today;
            jzat506_MostrarVersiones(jzat506_versiones);
        }

        private void jzat506_FiltrarVersiones()
        {
            int idUsuario = 0;
            if (cmbUsuarioCambios.SelectedValue != null)
                idUsuario = Convert.ToInt32(cmbUsuarioCambios.SelectedValue);

            string nombre = cmbNombreCambios.SelectedItem?.ToString() ?? "(Todos)";
            DateTime desde = dtpFechaInicioCambios.Value.Date;
            DateTime hasta = dtpFechaFinCambios.Value.Date;

            List<jzat506_Usuario_C> filtradas = new List<jzat506_Usuario_C>();

            foreach (jzat506_Usuario_C version in jzat506_versiones)
            {
                if (idUsuario != 0 && version.jzat506_IdUsuario != idUsuario)
                    continue;

                if (nombre != "(Todos)" && version.jzat506_NombreUsuario != nombre)
                    continue;

                if (version.jzat506_Fecha.Date < desde || version.jzat506_Fecha.Date > hasta)
                    continue;

                filtradas.Add(version);
            }

            jzat506_MostrarVersiones(filtradas);
        }

        private void jzat506_dgvVersiones_SelectionChanged(object? sender, EventArgs e)
        {
            jzat506_versionSeleccionada = null;

            if (dgvVersiones.SelectedRows.Count == 0)
                return;

            int idVersion = Convert.ToInt32(dgvVersiones.SelectedRows[0].Cells["Version"].Value);

            foreach (jzat506_Usuario_C version in jzat506_versiones)
            {
                if (version.jzat506_IdVersion == idVersion)
                    jzat506_versionSeleccionada = version;
            }
        }

        private void jzat506_btnActivar_Click(object? sender, EventArgs e)
        {
            if (jzat506_versionSeleccionada == null)
            {
                jzat506_MostrarError("Seleccione una versión de la lista.");
                return;
            }

            try
            {
                jzat506_bllUsuarioC.jzat506_ActivarVersion(jzat506_versionSeleccionada, SessionManager.GetInstance().Usuario.Id);
                jzat506_MostrarAviso("Versión activada.");
                jzat506_CargarVersiones();
                jzat506_FiltrarVersiones();
            }
            catch (Exception ex)
            {
                jzat506_MostrarError(ex.Message);
            }
        }

        private void jzat506_btnSalir_Click(object? sender, EventArgs e)
        {
            this.Close();
        }

        private void jzat506_MostrarError(string mensaje)
        {
            MessageBox.Show(mensaje, "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void jzat506_MostrarAviso(string mensaje)
        {
            MessageBox.Show(mensaje, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void jzat506_FrmBitacoraCambios_FormClosing(object? sender, FormClosingEventArgs e)
        {
            LanguageManager.GetInstance().Quitar(this);
        }
    }
}
