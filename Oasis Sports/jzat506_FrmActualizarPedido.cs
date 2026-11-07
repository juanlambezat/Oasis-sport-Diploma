using BLL;
using Entidades;
using Servicios;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace Oasis_Sports
{
    public partial class jzat506_FrmActualizarPedido : BaseForm, IObserverIdioma
    {
        private readonly jzat506_BLL_Pedido jzat506_bllPedido = new jzat506_BLL_Pedido();

        private List<jzat506_Pedido> jzat506_pedidos = new List<jzat506_Pedido>();
        private jzat506_Pedido? jzat506_pedido;

        private static readonly CultureInfo jzat506_cultura = new CultureInfo("es-AR");

        public jzat506_FrmActualizarPedido()
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

        private void jzat506_FrmActualizarPedido_Load(object sender, EventArgs e)
        {
            LanguageManager.GetInstance().TraducirControles(this);
            jzat506_RegistrarClaves();

            List<jzat506_Pedido> pedidos = jzat506_bllPedido.jzat506_ListarPedidosNoEntregados();

            if (pedidos.Count == 0)
                jzat506_MostrarAviso("No hay pedidos para actualizar.");
            else
                jzat506_CargarGrilla(pedidos);
        }

        private void jzat506_CargarGrilla(List<jzat506_Pedido> pedidos)
        {
            jzat506_pedidos = pedidos;
            dgvPedidos.Rows.Clear();
            jzat506_pedido = null;
            txtDetalle.Clear();

            foreach (jzat506_Pedido pedido in pedidos)
            {
                dgvPedidos.Rows.Add(
                    pedido.jzat506_Id,
                    pedido.jzat506_Factura.jzat506_Cliente.jzat506_Nombre + " " + pedido.jzat506_Factura.jzat506_Cliente.jzat506_Apellido,
                    pedido.jzat506_Envio.jzat506_Zona.jzat506_Localidad,
                    pedido.jzat506_Estado,
                    pedido.jzat506_Envio.jzat506_Transportista != null ? pedido.jzat506_Envio.jzat506_Transportista.ToString() : "Sin asignar");
            }

            if (dgvPedidos.Rows.Count > 0)
            {
                dgvPedidos.Rows[0].Selected = true;
                jzat506_dgvPedidos_SelectionChanged(dgvPedidos, EventArgs.Empty);
            }
        }

        private void jzat506_dgvPedidos_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgvPedidos.SelectedRows.Count == 0)
                return;

            int posicion = dgvPedidos.SelectedRows[0].Index;

            if (posicion >= jzat506_pedidos.Count)
                return;

            jzat506_pedido = jzat506_pedidos[posicion];
            jzat506_MostrarDetalle(jzat506_pedido);
        }

        private void jzat506_MostrarDetalle(jzat506_Pedido pedido)
        {
            string salto = Environment.NewLine;

            string detalle = "Pedido N." + pedido.jzat506_Id + salto;
            detalle += "Estado: " + pedido.jzat506_Estado + salto;
            detalle += "Cliente: " + pedido.jzat506_Factura.jzat506_Cliente.jzat506_Nombre + " " + pedido.jzat506_Factura.jzat506_Cliente.jzat506_Apellido + salto;
            detalle += "Direccion: " + pedido.jzat506_Envio.jzat506_Direccion + salto;
            detalle += "Telefono: " + pedido.jzat506_Envio.jzat506_Telefono + salto;
            detalle += "Zona: " + pedido.jzat506_Envio.jzat506_Zona.ToString() + salto;
            detalle += "Transportista: " + (pedido.jzat506_Envio.jzat506_Transportista != null ? pedido.jzat506_Envio.jzat506_Transportista.ToString() : "Sin asignar") + salto + salto;
            detalle += "Productos de la factura N." + pedido.jzat506_Factura.jzat506_Id + ":" + salto;

            foreach (jzat506_DetalleFactura producto in pedido.jzat506_Factura.jzat506_Detalles)
                detalle += producto.jzat506_Cantidad + " x " + producto.jzat506_Producto.jzat506_Nombre + salto;

            txtDetalle.Text = detalle;
        }

        private void jzat506_btnAvanzar_Click(object sender, EventArgs e)
        {
            if (jzat506_pedido == null)
            {
                jzat506_MostrarError("Seleccione un pedido.");
                return;
            }

            try
            {
                jzat506_bllPedido.jzat506_AvanzarEstado(jzat506_pedido);
                jzat506_RefrescarGrilla();
            }
            catch (Exception ex)
            {
                jzat506_MostrarError(ex.Message);
            }
        }

        private void jzat506_RefrescarGrilla()
        {
            List<jzat506_Pedido> pendientes = new List<jzat506_Pedido>();

            foreach (jzat506_Pedido pedido in jzat506_pedidos)
            {
                if (pedido.jzat506_Estado != "Entregado")
                    pendientes.Add(pedido);
            }

            jzat506_CargarGrilla(pendientes);
        }

        private void jzat506_MostrarAviso(string mensaje)
        {
            MessageBox.Show(mensaje, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void jzat506_MostrarError(string mensaje)
        {
            MessageBox.Show(mensaje, "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void jzat506_btnVolverPedidos_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void jzat506_FrmActualizarPedido_FormClosing(object sender, FormClosingEventArgs e)
        {
            LanguageManager.GetInstance().Quitar(this);
        }
    }
}
