using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using Entidades;
using Servicios;

namespace Oasis_Sports
{
    public partial class FrmHistorialCambios : Form, IObserverIdioma
    {
        BLL_HistorialCambios bllHistorial = new BLL_HistorialCambios();
        int idUsuario;
        string nombreUsuario;

        public FrmHistorialCambios(int idUsuario, string nombreUsuario)
        {
            InitializeComponent();
            this.idUsuario = idUsuario;
            this.nombreUsuario = nombreUsuario;
            LanguageManager.GetInstance().Agregar(this);
        }

        public void ActualizarIdioma()
        {
            LanguageManager.GetInstance().TraducirControles(this);
        }

        private void FrmHistorialCambios_Load(object sender, EventArgs e)
        {
            LanguageManager.GetInstance().TraducirControles(this);
            lblTitulo.Text = "Historial de cambios: " + nombreUsuario;
            CargarUsuarios();
            CargarHistorial();
        }

        private void CargarHistorial()
        {
            dgvHistorial.DataSource = bllHistorial.ObtenerHistorialUsuario(idUsuario);
        }

        private void CargarUsuarios()
        {
            cmbUsuarioHistorial.DataSource = bLLUsuario.Listar();
            cmbUsuarioHistorial.DisplayMember = "Username";
            cmbUsuarioHistorial.ValueMember = "Id";
            cmbUsuarioHistorial.SelectedValue = idUsuario;
        }

        private void cmbUsuarioHistorial_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Usuario? usuario = cmbUsuarioHistorial.SelectedItem as Usuario;
            if (usuario == null)
                return;

            idUsuario = usuario.Id;
            nombreUsuario = usuario.Username;
            lblTitulo.Text = "Historial de cambios: " + nombreUsuario;
            CargarHistorial();
        }

        private string ObtenerValorActual(string campo)
        {
            foreach (Usuario usuario in bLLUsuario.Listar())
            {
                if (usuario.Id == idUsuario)
                {
                    if (campo == "Username")
                        return usuario.Username;
                    if (campo == "Bloqueado")
                        return usuario.Bloqueado ? "Sí" : "No";
                }
            }
            return "";
        }

        private void FrmHistorialCambios_FormClosing(object sender, FormClosingEventArgs e)
        {
            LanguageManager.GetInstance().Quitar(this);
        }

        BLLUsuario bLLUsuario = new BLLUsuario();
        BLL_DV bll_DV = new BLL_DV();
  
        private void button1_Click(object sender, EventArgs e)
        {
            if (dgvHistorial.CurrentRow == null)
            {
                MessageBox.Show("Seleccioná un registro de la lista.");
                return;
            }

            DataGridViewRow fila = dgvHistorial.CurrentRow;

            string campo = fila.Cells["NombreCampo"].Value?.ToString() ?? "";
            string valorAnterior = fila.Cells["ValorAnterior"].Value?.ToString() ?? "";


            if (valorAnterior == "(restauración)")
            {
                MessageBox.Show("Este registro es una restauración, no se puede volver a restaurar.");
                return;
            }


            if (campo == "Password")
            {
                MessageBox.Show("No se puede restaurar la contraseña porque está enmascarada por seguridad.");
                return;
            }

            if (valorAnterior == ObtenerValorActual(campo))
            {
                MessageBox.Show($"El campo '{campo}' ya tiene el valor '{valorAnterior}'. No hay nada para restaurar.");
                return;
            }

            DialogResult confirmacion = MessageBox.Show(
                $"¿Restaurar el campo '{campo}' al valor '{valorAnterior}'?",
                "Confirmar restauración",
                MessageBoxButtons.YesNo
            );

            if (confirmacion != DialogResult.Yes) return;

            string quienRestaura = SessionManager.GetInstance().Usuario?.Username ?? "sistema";
            bllHistorial.RestaurarCampo(idUsuario, campo, valorAnterior, quienRestaura);
            bll_DV.InicializarDVs();

            MessageBox.Show("Campo restaurado correctamente.");
            CargarUsuarios();
            CargarHistorial();
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}