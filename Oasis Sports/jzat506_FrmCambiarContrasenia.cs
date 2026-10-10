using BLL;
using Entidades;
using Servicios;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Oasis_Sports
{
    public partial class jzat506_FrmCambiarContrasenia : BaseForm, IObserverIdioma
    {
        private readonly BLLUsuario jzat506_bllUsuario = new BLLUsuario();

        public jzat506_FrmCambiarContrasenia()
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

        private void jzat506_FrmCambiarContrasenia_Load(object sender, EventArgs e)
        {
            LanguageManager.GetInstance().TraducirControles(this);
            jzat506_RegistrarClaves();
        }

        private void jzat506_btnGuardarContrasenia_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtActual.Text) || string.IsNullOrWhiteSpace(txtNueva.Text)
                || string.IsNullOrWhiteSpace(txtRepetir.Text))
            {
                MessageBox.Show("Complete los tres campos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtNueva.Text != txtRepetir.Text)
            {
                MessageBox.Show("La contraseña nueva no coincide con su repetición.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Usuario usuarioLogueado = SessionManager.GetInstance().Usuario;

            try
            {
                jzat506_bllUsuario.jzat506_CambiarContrasenia(usuarioLogueado.Id, usuarioLogueado.Username,
                    txtActual.Text, txtNueva.Text);

                new BLL_DV().InicializarDVs();

                new BLL_Evento().RegistrarEvento(new Evento
                {
                    Usuario = usuarioLogueado.Username,
                    Modulo = "Usuarios",
                    Descripcion = "Cambio de contraseña",
                    Fecha = DateTime.Now,
                    Criticidad = 2
                });

                MessageBox.Show("Contraseña actualizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void jzat506_btnCancelarContrasenia_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void jzat506_FrmCambiarContrasenia_FormClosing(object sender, FormClosingEventArgs e)
        {
            LanguageManager.GetInstance().Quitar(this);
        }
    }
}
