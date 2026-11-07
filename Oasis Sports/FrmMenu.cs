using BLL;
using Entidades;
using Servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Oasis_Sports
{
    public partial class FrmMenu : BaseForm, IObserverIdioma
    {
        public FrmMenu()
        {
            InitializeComponent();
            LanguageManager.GetInstance().Agregar(this);
        }

        private void RegistrarClaves()
        {
            int idIdioma = LanguageManager.GetInstance().IdIdiomaActual;
            BLL_Traduccion bll = new BLL_Traduccion();
            List<string> clavesExistentes = bll.ObtenerTodasLasClaves();

            foreach (Control c in this.Controls)
                RegistrarRecursivo(c, idIdioma, bll, clavesExistentes);
        }

        private void RegistrarRecursivo(Control c, int idIdioma, BLL_Traduccion bll, List<string> clavesExistentes)
        {
            if (c is MenuStrip ms)
            {
                RegistrarMenuItems(ms.Items, idIdioma, bll, clavesExistentes);
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
                RegistrarRecursivo(hijo, idIdioma, bll, clavesExistentes);
        }

        private void RegistrarMenuItems(ToolStripItemCollection items, int idIdioma, BLL_Traduccion bll, List<string> clavesExistentes)
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
                    RegistrarMenuItems(mi.DropDownItems, idIdioma, bll, clavesExistentes);
            }
        }


        public void ActualizarIdioma()
        {
            LanguageManager.GetInstance().TraducirControles(this);

        }


        private void FrmMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            LanguageManager.GetInstance().Quitar(this);
        }



        private void lOGINToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLogin frmLogin = new FrmLogin();

            frmLogin.Show();
            this.Hide();
        }

        private void sALIRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lOGOUTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Esta seguro de cerrar sesion?", "Confirmacion", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if (SessionManager.GetInstance().IsLogged())
                {
                    BLL_Evento bllEvento = new BLL_Evento();

                    bllEvento.RegistrarEvento(new Evento()
                    {
                        Usuario = SessionManager.GetInstance().Usuario.Username,
                        Modulo = "Login",
                        Descripcion = "Cierre de sesión",
                        Fecha = DateTime.Now,
                        Criticidad = 1
                    });

                    SessionManager.GetInstance().Logout();
                    MessageBox.Show("Sesion cerrada con exito");
                    OcultarControles();
                }
                else
                {
                    MessageBox.Show("No existe una sesion activa");
                }
            }
        }

        BLL_Permisos permisosBLL = new BLL_Permisos();

        private void FrmMenu_Load(object sender, EventArgs e)
        {
            OcultarControles();
            if (!SessionManager.GetInstance().IsLogged())
                return;

            AplicarPermisos();
            LanguageManager.GetInstance().TraducirControles(this);
            RegistrarClaves();
        }

        private void bitacoraToolStripMenuItem_Click(object sender, EventArgs e) { }

        private void bITACORAToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmBitacora frm = new FrmBitacora();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

        private void bitacoraToolStripMenuItem_VisibleChanged(object sender, EventArgs e) { }

        private void OcultarControles()
        {
            bitacoraToolStripMenuItem.Visible = false;
            bITACORAToolStripMenuItem1.Visible = false;
            gESTIONDEUSUARIOSToolStripMenuItem.Visible = false;
            gESTIONDEPERFILESToolStripMenuItem.Visible = false;
            rEGISTRARCLIENTEToolStripMenuItem.Visible = false;
            vENTASToolStripMenuItem.Visible = false;
            fACTURASToolStripMenuItem.Visible = false;
            eNVIOSToolStripMenuItem.Visible = false;
            rEPORTEDEENVIOSToolStripMenuItem.Visible = false;
            pEDIDOSToolStripMenuItem.Visible = false;
            aSIGNARTRANSPORTISTAToolStripMenuItem.Visible = false;
            dESPACHADORToolStripMenuItem.Visible = false;
            vENDEDORToolStripMenuItem.Visible = false;
            gESTIONDEIDIOMASToolStripMenuItem.Visible = false;
            cREARIDIOMAToolStripMenuItem.Visible = false;
            bITACORADECAMBIOSToolStripMenuItem.Visible = false;

        }

        private void AplicarPermisos()
        {
            if (SessionManager.GetInstance().IsLogged())
            {
                int idUsuario = SessionManager.GetInstance().Usuario.Id;
                ComponentePermiso? perfil = permisoBLL.ObtenerPerfilUsuario(idUsuario);

                bool verBitacora = TienePermiso(perfil, "SE001");
                bool verUsuarios = TienePermiso(perfil, "SE002");
                bool verPerfiles = TienePermiso(perfil, "SE003");
                bool verCambios = TienePermiso(perfil, "SE004");

                bITACORAToolStripMenuItem1.Visible = verBitacora;
                gESTIONDEUSUARIOSToolStripMenuItem.Visible = verUsuarios;
                gESTIONDEPERFILESToolStripMenuItem.Visible = verPerfiles;
                bITACORADECAMBIOSToolStripMenuItem.Visible = verCambios;
                bitacoraToolStripMenuItem.Visible = verBitacora || verUsuarios || verPerfiles || verCambios;

                bool verVentas = TienePermiso(perfil, "VE001");
                bool verClientes = TienePermiso(perfil, "VE002");
                bool verFacturas = TienePermiso(perfil, "VE003");
                bool verEnvios = TienePermiso(perfil, "VE004");
                bool verReporteEnvios = TienePermiso(perfil, "VE005");

                vENTASToolStripMenuItem.Visible = verVentas;
                rEGISTRARCLIENTEToolStripMenuItem.Visible = verClientes;
                fACTURASToolStripMenuItem.Visible = verFacturas;
                eNVIOSToolStripMenuItem.Visible = verEnvios;
                rEPORTEDEENVIOSToolStripMenuItem.Visible = verReporteEnvios;
                vENDEDORToolStripMenuItem.Visible = verVentas || verClientes || verFacturas || verEnvios || verReporteEnvios;

                bool verPedidos = TienePermiso(perfil, "DE001");
                bool verTransportista = TienePermiso(perfil, "DE002");

                pEDIDOSToolStripMenuItem.Visible = verPedidos;
                aSIGNARTRANSPORTISTAToolStripMenuItem.Visible = verTransportista;
                dESPACHADORToolStripMenuItem.Visible = verPedidos || verTransportista;

                gESTIONDEIDIOMASToolStripMenuItem.Visible = true;
                cREARIDIOMAToolStripMenuItem.Visible = TienePermiso(perfil, "ID001");
            }
        }

        private bool TienePermiso(ComponentePermiso? perfil, string codigo)
        {
            if (perfil == null)
                return false;

            return perfil.TienePermiso(codigo);
        }

        private void gESTIONDEUSUARIOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGestionUsuarios frmGestionUsuarios = new FrmGestionUsuarios();
            frmGestionUsuarios.Show();
            this.Hide();
        }

        private void gESTIONDEPERFILESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGestionPerfiles frmGestionPerfiles = new FrmGestionPerfiles();
            frmGestionPerfiles.Show();
            this.Hide();
        }

        private void gESTIONDEIDIOMASToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void jzat506_vENTASToolStripMenuItem_Click(object sender, EventArgs e)
        {
            jzat506_FrmGenerarFactura frmGenerarFactura = new jzat506_FrmGenerarFactura();
            frmGenerarFactura.Show();
            this.Hide();
        }

        private void jzat506_rEGISTRARCLIENTEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            jzat506_FrmRegistrarCliente frmRegistrarCliente = new jzat506_FrmRegistrarCliente();
            this.Hide();
            frmRegistrarCliente.ShowDialog();
            this.Show();
        }

        private void jzat506_fACTURASToolStripMenuItem_Click(object sender, EventArgs e)
        {
            jzat506_FrmConsultarFacturas frmConsultarFacturas = new jzat506_FrmConsultarFacturas();
            this.Hide();
            frmConsultarFacturas.ShowDialog();
            this.Show();
        }

        private void jzat506_eNVIOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            jzat506_FrmRegistrarEnvio frmRegistrarEnvio = new jzat506_FrmRegistrarEnvio();
            this.Hide();
            frmRegistrarEnvio.ShowDialog();
            this.Show();
        }

        private void jzat506_rEPORTEDEENVIOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            jzat506_FrmReporteEnvios frmReporteEnvios = new jzat506_FrmReporteEnvios();
            this.Hide();
            frmReporteEnvios.ShowDialog();
            this.Show();
        }

        private void jzat506_pEDIDOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            jzat506_FrmActualizarPedido frmActualizarPedido = new jzat506_FrmActualizarPedido();
            this.Hide();
            frmActualizarPedido.ShowDialog();
            this.Show();
        }

        private void jzat506_aSIGNARTRANSPORTISTAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            jzat506_FrmAsignarTransportista frmAsignarTransportista = new jzat506_FrmAsignarTransportista();
            this.Hide();
            frmAsignarTransportista.ShowDialog();
            this.Show();
        }

        private void jzat506_cAMBIARCONTRASEÑAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!SessionManager.GetInstance().IsLogged())
            {
                MessageBox.Show("Debe iniciar sesión para cambiar la contraseña.");
                return;
            }

            jzat506_FrmCambiarContrasenia frmCambiarContrasenia = new jzat506_FrmCambiarContrasenia();
            this.Hide();
            frmCambiarContrasenia.ShowDialog();
            this.Show();
        }

        private BLL_Permisos permisoBLL = new BLL_Permisos();

        private void bITACORADECAMBIOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmHistorialCambios frm = new FrmHistorialCambios(
           SessionManager.GetInstance().Usuario.Id,
           SessionManager.GetInstance().Usuario.Username);

            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

        private void sELECCIONARIDIOMAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSeleccionIdioma frmSeleccionIdioma = new FrmSeleccionIdioma();
            this.Hide();
            frmSeleccionIdioma.ShowDialog();
            this.Show();
        }

        private void cREARIDIOMAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmIdiomas frmIdiomas = new FrmIdiomas();
            frmIdiomas.Show();
            this.Hide();
        }
    }
}
