using BLL;
using Entidades;
using Servicios;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace Oasis_Sports
{
    public partial class jzat506_FrmSeleccionarProductos : BaseForm, IObserverIdioma
    {
        private readonly jzat506_BLL_Producto jzat506_bllProducto = new jzat506_BLL_Producto();
        private readonly List<jzat506_DetalleFactura> jzat506_carrito = new List<jzat506_DetalleFactura>();

        private const decimal jzat506_TotalMaximo = 10000000m;

        private static readonly CultureInfo jzat506_cultura = new CultureInfo("es-AR");

        public List<jzat506_DetalleFactura> jzat506_Carrito => jzat506_carrito;

        public jzat506_FrmSeleccionarProductos()
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

        private void jzat506_FrmSeleccionarProductos_Load(object sender, EventArgs e)
        {
            LanguageManager.GetInstance().TraducirControles(this);
            jzat506_RegistrarClaves();

            List<jzat506_Producto> lista = jzat506_bllProducto.jzat506_ListarProductos();
            jzat506_CargarGrilla(lista);
        }

        private void jzat506_CargarGrilla(List<jzat506_Producto> lista)
        {
            dataGridViewProductos.DataSource = lista;
            if (dataGridViewProductos.Columns.Contains("jzat506_DVH"))
                dataGridViewProductos.Columns["jzat506_DVH"].Visible = false;

            foreach (DataGridViewColumn columna in dataGridViewProductos.Columns)
                columna.HeaderText = columna.Name.Replace("jzat506_", "");

            if (dataGridViewProductos.Columns.Contains("jzat506_Precio"))
            {
                dataGridViewProductos.Columns["jzat506_Precio"].DefaultCellStyle.Format = "C";
                dataGridViewProductos.Columns["jzat506_Precio"].DefaultCellStyle.FormatProvider = jzat506_cultura;
            }
        }

        private void jzat506_btnAgregar_Click(object sender, EventArgs e)
        {
            if (dataGridViewProductos.CurrentRow == null)
            {
                jzat506_MostrarError("Seleccione un producto de la lista.");
                return;
            }

            jzat506_Producto producto = (jzat506_Producto)dataGridViewProductos.CurrentRow.DataBoundItem;
            int cantidad = (int)numCantidad.Value;

            jzat506_DetalleFactura? existente = jzat506_carrito.FirstOrDefault(d => d.jzat506_Producto.jzat506_Id == producto.jzat506_Id);

            try
            {
                int cantidadTotal = cantidad + (existente?.jzat506_Cantidad ?? 0);
                jzat506_DetalleFactura detalle = jzat506_bllProducto.jzat506_ArmarDetalle(producto, cantidadTotal);

                decimal totalResultante = jzat506_carrito.Where(d => d != existente).Sum(d => d.jzat506_Cantidad * d.jzat506_PrecioUnitario)
                                          + detalle.jzat506_Cantidad * detalle.jzat506_PrecioUnitario;

                if (totalResultante > jzat506_TotalMaximo)
                {
                    jzat506_MostrarError($"El total de la venta no puede superar {jzat506_TotalMaximo.ToString("C", jzat506_cultura)}.");
                    return;
                }

                jzat506_ActualizarCarrito(detalle);
            }
            catch (Exception ex)
            {
                string aclaracion = existente != null ? $" Ya hay {existente.jzat506_Cantidad} en el carrito." : "";
                jzat506_MostrarError(ex.Message + aclaracion);
            }
        }

        private void jzat506_ActualizarCarrito(jzat506_DetalleFactura detalle)
        {
            int indice = jzat506_carrito.FindIndex(d => d.jzat506_Producto.jzat506_Id == detalle.jzat506_Producto.jzat506_Id);

            if (indice >= 0)
                jzat506_carrito[indice] = detalle;
            else
                jzat506_carrito.Add(detalle);

            jzat506_RefrescarCarrito();
        }

        private void jzat506_RefrescarCarrito()
        {
            dataGridViewCarrito.Rows.Clear();

            foreach (jzat506_DetalleFactura detalle in jzat506_carrito)
            {
                dataGridViewCarrito.Rows.Add(
                    detalle.jzat506_Producto.jzat506_Nombre,
                    detalle.jzat506_Cantidad,
                    detalle.jzat506_PrecioUnitario.ToString("C", jzat506_cultura),
                    (detalle.jzat506_Cantidad * detalle.jzat506_PrecioUnitario).ToString("C", jzat506_cultura));
            }

            decimal total = jzat506_carrito.Sum(d => d.jzat506_Cantidad * d.jzat506_PrecioUnitario);
            lblTotal.Text = "Total: " + total.ToString("C", jzat506_cultura);
        }

        private void jzat506_btnQuitar_Click(object sender, EventArgs e)
        {
            if (dataGridViewCarrito.CurrentRow == null)
            {
                jzat506_MostrarError("Seleccione un producto del carrito para quitarlo.");
                return;
            }

            jzat506_carrito.RemoveAt(dataGridViewCarrito.CurrentRow.Index);
            jzat506_RefrescarCarrito();
        }

        private void jzat506_btnConfirmar_Click(object sender, EventArgs e)
        {
            if (jzat506_carrito.Count > 0)
                jzat506_CerrarConSeleccion();
            else
                jzat506_MostrarError("Debe agregarse al menos un producto.");
        }

        private void jzat506_MostrarError(string mensaje)
        {
            MessageBox.Show(mensaje, "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void jzat506_CerrarConSeleccion()
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void jzat506_btnCerrar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void jzat506_FrmSeleccionarProductos_FormClosing(object sender, FormClosingEventArgs e)
        {
            LanguageManager.GetInstance().Quitar(this);
        }
    }
}
