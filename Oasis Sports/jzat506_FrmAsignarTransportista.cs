using BLL;
using Entidades;
using Servicios;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Oasis_Sports
{
    public partial class jzat506_FrmAsignarTransportista : BaseForm, IObserverIdioma
    {
        private readonly jzat506_BLL_Pedido jzat506_bllPedido = new jzat506_BLL_Pedido();
        private readonly jzat506_BLL_Transportista jzat506_bllTransportista = new jzat506_BLL_Transportista();

        private List<jzat506_Pedido> jzat506_pedidos = new List<jzat506_Pedido>();
        private List<jzat506_Transportista> jzat506_transportistas = new List<jzat506_Transportista>();

        public jzat506_FrmAsignarTransportista()
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

        private void jzat506_FrmAsignarTransportista_Load(object sender, EventArgs e)
        {
            LanguageManager.GetInstance().TraducirControles(this);
            jzat506_RegistrarClaves();

            jzat506_CargarGrillas();

            if (jzat506_pedidos.Count == 0)
                jzat506_MostrarAviso("No hay pedidos preparados para asignar.");
        }

        private void jzat506_CargarGrillas()
        {
            jzat506_pedidos = jzat506_bllPedido.jzat506_ListarPedidosParaAsignar();
            dgvPedidosAsignar.Rows.Clear();

            foreach (jzat506_Pedido pedido in jzat506_pedidos)
            {
                dgvPedidosAsignar.Rows.Add(
                    pedido.jzat506_Id,
                    pedido.jzat506_Factura.jzat506_Cliente.jzat506_Nombre + " " + pedido.jzat506_Factura.jzat506_Cliente.jzat506_Apellido,
                    pedido.jzat506_Envio.jzat506_Zona.jzat506_Localidad,
                    pedido.jzat506_Envio.jzat506_Direccion);
            }

            jzat506_transportistas = jzat506_bllTransportista.jzat506_ListarTransportistas();
            dgvTransportistas.Rows.Clear();

            foreach (jzat506_Transportista transportista in jzat506_transportistas)
            {
                string estado = "Libre";
                if (!transportista.jzat506_Libre())
                    estado = "Ocupado (pedido N." + transportista.jzat506_PedidoActual + ")";

                dgvTransportistas.Rows.Add(transportista.ToString(), estado);
            }

            dgvPedidosAsignar.ClearSelection();
            dgvTransportistas.ClearSelection();
        }

        private void jzat506_btnAsignar_Click(object sender, EventArgs e)
        {
            if (dgvPedidosAsignar.SelectedRows.Count == 0)
            {
                jzat506_MostrarError("Seleccione un pedido.");
                return;
            }

            if (dgvTransportistas.SelectedRows.Count == 0)
            {
                jzat506_MostrarError("Seleccione un transportista.");
                return;
            }

            jzat506_Pedido pedido = jzat506_pedidos[dgvPedidosAsignar.SelectedRows[0].Index];
            jzat506_Transportista transportista = jzat506_transportistas[dgvTransportistas.SelectedRows[0].Index];

            try
            {
                jzat506_bllPedido.jzat506_AsignarTransportista(pedido, transportista);
                jzat506_MostrarAviso("Transportista asignado.");
                jzat506_CargarGrillas();
            }
            catch (Exception ex)
            {
                jzat506_MostrarError(ex.Message);
            }
        }

        private void jzat506_MostrarAviso(string mensaje)
        {
            MessageBox.Show(mensaje, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void jzat506_MostrarError(string mensaje)
        {
            MessageBox.Show(mensaje, "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void jzat506_btnVolverAsignar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void jzat506_FrmAsignarTransportista_FormClosing(object sender, FormClosingEventArgs e)
        {
            LanguageManager.GetInstance().Quitar(this);
        }
    }
}
