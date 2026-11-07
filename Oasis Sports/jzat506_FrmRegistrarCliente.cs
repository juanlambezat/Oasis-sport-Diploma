using BLL;
using Entidades;
using Servicios;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Oasis_Sports
{
    public partial class jzat506_FrmRegistrarCliente : BaseForm, IObserverIdioma
    {
        private readonly jzat506_BLL_Cliente jzat506_bllCliente = new jzat506_BLL_Cliente();
        private readonly jzat506_BLL_Serializar jzat506_bllSerializar = new jzat506_BLL_Serializar();
        private readonly jzat506_BLL_Deserializar jzat506_bllDeserializar = new jzat506_BLL_Deserializar();
        private readonly bool jzat506_dniEditable;
        private int jzat506_dni;
        private int jzat506_idClienteSeleccionado;

        public jzat506_Cliente? jzat506_ClienteRegistrado { get; private set; }

        public jzat506_FrmRegistrarCliente(int dni)
        {
            InitializeComponent();
            LanguageManager.GetInstance().Agregar(this);
            jzat506_dni = dni;
        }

        public jzat506_FrmRegistrarCliente() : this(0)
        {
            jzat506_dniEditable = true;
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

        private void jzat506_FrmRegistrarCliente_Load(object sender, EventArgs e)
        {
            LanguageManager.GetInstance().TraducirControles(this);
            jzat506_RegistrarClaves();

            if (jzat506_dniEditable)
            {
                txtDNI.ReadOnly = false;
                jzat506_CargarListado();
            }
            else
            {
                txtDNI.Text = jzat506_dni.ToString();
                dataGridView1.Visible = false;
                grpSerializacion.Visible = false;
                btnModificar.Visible = false;
                btnEliminar.Visible = false;
                btnVolverCancelar.Text = "CANCELAR";
                btnVolverCancelar.Location = btnModificar.Location;
                ClientSize = new Size(dataGridView1.Left, btnVolverCancelar.Bottom + 20);
            }
        }

        private void jzat506_btnRegistrar_Click(object sender, EventArgs e)
        {
            if (!jzat506_ValidarCampos(out string mensaje))
            {
                jzat506_MostrarError(mensaje);
                return;
            }

            if (jzat506_dniEditable)
                jzat506_dni = int.Parse(txtDNI.Text.Trim());

            try
            {
                jzat506_Cliente cliente = jzat506_bllCliente.jzat506_RegistrarCliente(
                    jzat506_dni,
                    txtNombre.Text.Trim(),
                    txtApellido.Text.Trim(),
                    txtEmail.Text.Trim(),
                    txtTelefono.Text.Trim(),
                    txtDireccion.Text.Trim());

                jzat506_MostrarAviso("Cliente registrado.");

                if (jzat506_dniEditable)
                {
                    jzat506_CargarListado();
                    jzat506_LimpiarCampos();
                }
                else
                {
                    jzat506_CerrarConCliente(cliente);
                }
            }
            catch (jzat506_ClienteExistenteException ex)
            {
                jzat506_MostrarAviso(ex.Message);

                if (jzat506_dniEditable)
                    jzat506_CargarListado();
                else
                    jzat506_CerrarConCliente(ex.jzat506_Cliente);
            }
            catch (Exception ex)
            {
                jzat506_MostrarError(ex.Message);
            }
        }

        private bool jzat506_ValidarCampos(out string mensaje)
        {
            string dni = jzat506_dniEditable ? txtDNI.Text.Trim() : jzat506_dni.ToString();

            if (!Regex.IsMatch(dni, @"^[1-9][0-9]{6,7}$"))
            {
                mensaje = "El DNI debe tener 7 u 8 digitos numericos.";
                return false;
            }

            return jzat506_ValidarDatosContacto(out mensaje);
        }

        private bool jzat506_ValidarDatosContacto(out string mensaje)
        {
            string email = txtEmail.Text.Trim();
            string telefono = txtTelefono.Text.Trim();
            string direccion = txtDireccion.Text.Trim();

            if (!jzat506_EsNombreValido(txtNombre.Text.Trim()))
            {
                mensaje = "El nombre debe tener entre 2 y 50 letras (se permiten espacios, guiones y apostrofes).";
                return false;
            }

            if (!jzat506_EsNombreValido(txtApellido.Text.Trim()))
            {
                mensaje = "El apellido debe tener entre 2 y 50 letras (se permiten espacios, guiones y apostrofes).";
                return false;
            }

            if (email != "" && (email.Length > 100 || !Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$")))
            {
                mensaje = "El email no tiene un formato valido (ejemplo: nombre@dominio.com).";
                return false;
            }

            if (telefono != "" && !Regex.IsMatch(telefono, @"^[0-9]{10}$"))
            {
                mensaje = "El telefono debe tener exactamente 10 digitos, sin espacios ni guiones (codigo de area + numero).";
                return false;
            }

            if (direccion.Length > 150)
            {
                mensaje = "La direccion no puede superar los 150 caracteres.";
                return false;
            }

            mensaje = "";
            return true;
        }

        private bool jzat506_EsNombreValido(string texto)
        {
            return texto.Length >= 2 && texto.Length <= 50 && Regex.IsMatch(texto, @"^\p{L}+([ '\-]\p{L}+)*$");
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

        private void jzat506_CerrarConCliente(jzat506_Cliente? cliente)
        {
            jzat506_ClienteRegistrado = cliente;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void jzat506_dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow fila = dataGridView1.Rows[e.RowIndex];
            jzat506_idClienteSeleccionado = Convert.ToInt32(fila.Cells["jzat506_Id"].Value);
            txtDNI.Text = fila.Cells["jzat506_DNI"].Value.ToString();
            txtNombre.Text = fila.Cells["jzat506_Nombre"].Value.ToString();
            txtApellido.Text = fila.Cells["jzat506_Apellido"].Value.ToString();
            txtEmail.Text = fila.Cells["jzat506_Email"].Value?.ToString() ?? "";
            txtTelefono.Text = fila.Cells["jzat506_Telefono"].Value?.ToString() ?? "";
            txtDireccion.Text = fila.Cells["jzat506_Direccion"].Value?.ToString() ?? "";
        }

        private void jzat506_btnModificar_Click(object sender, EventArgs e)
        {
            if (jzat506_idClienteSeleccionado == 0)
            {
                jzat506_MostrarError("Seleccione un cliente en la grilla.");
                return;
            }

            if (!jzat506_ValidarDatosContacto(out string mensaje))
            {
                jzat506_MostrarError(mensaje);
                return;
            }

            jzat506_bllCliente.jzat506_ModificarCliente(
                jzat506_idClienteSeleccionado,
                txtNombre.Text.Trim(),
                txtApellido.Text.Trim(),
                txtEmail.Text.Trim(),
                txtTelefono.Text.Trim(),
                txtDireccion.Text.Trim());

            jzat506_MostrarAviso("Cliente modificado.");
            jzat506_CargarListado();
            jzat506_LimpiarCampos();
        }

        private void jzat506_btnEliminar_Click(object sender, EventArgs e)
        {
            if (jzat506_idClienteSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un cliente en la grilla.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var lista = (List<jzat506_Cliente>)dataGridView1.DataSource;
            jzat506_Cliente cliente = lista.First(c => c.jzat506_Id == jzat506_idClienteSeleccionado);

            if (!cliente.jzat506_Activo)
            {
                MessageBox.Show("El cliente ya fue eliminado.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show($"¿Está seguro que desea eliminar al cliente {cliente.jzat506_Nombre} {cliente.jzat506_Apellido}?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                jzat506_bllCliente.jzat506_EliminarCliente(jzat506_idClienteSeleccionado);

                MessageBox.Show("El cliente fue eliminado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            jzat506_CargarListado();
            jzat506_LimpiarCampos();
        }

        private void jzat506_CargarListado()
        {
            jzat506_MostrarClientes(jzat506_bllCliente.jzat506_ListarClientes());
            btnModificar.Enabled = true;
            btnEliminar.Enabled = true;
        }

        private void jzat506_MostrarClientes(List<jzat506_Cliente> clientes)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = clientes;

            foreach (DataGridViewColumn columna in dataGridView1.Columns)
                columna.HeaderText = columna.Name.Replace("jzat506_", "");
        }

        private void jzat506_btnRutaSerializar_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialogo = new SaveFileDialog();
            dialogo.Filter = "Archivo XML (*.xml)|*.xml|Archivo JSON (*.json)|*.json";
            dialogo.FileName = "clientes";

            if (dialogo.ShowDialog() == DialogResult.OK)
                txtRutaSerializar.Text = dialogo.FileName;
        }

        private void jzat506_btnSerializar_Click(object sender, EventArgs e)
        {
            List<jzat506_Cliente>? clientes = dataGridView1.DataSource as List<jzat506_Cliente>;

            if (clientes == null || clientes.Count == 0)
            {
                jzat506_MostrarMensaje("No hay clientes en la grilla para serializar.");
                return;
            }

            if (txtRutaSerializar.Text == "")
            {
                jzat506_MostrarMensaje("Seleccione la ubicacion y el nombre del archivo.");
                return;
            }

            try
            {
                jzat506_bllSerializar.jzat506_Serializar(clientes, txtRutaSerializar.Text);
                jzat506_MostrarMensaje("Se serializaron " + clientes.Count + " clientes en el archivo " + Path.GetFileName(txtRutaSerializar.Text));
            }
            catch (Exception ex)
            {
                jzat506_MostrarMensaje("No se pudo serializar: " + ex.Message);
            }
        }

        private void jzat506_btnRutaDeserializar_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialogo = new OpenFileDialog();
            dialogo.Filter = "Archivo XML o JSON (*.xml;*.json)|*.xml;*.json";

            if (dialogo.ShowDialog() == DialogResult.OK)
                txtRutaDeserializar.Text = dialogo.FileName;
        }

        private void jzat506_btnDeserializar_Click(object sender, EventArgs e)
        {
            if (txtRutaDeserializar.Text == "")
            {
                jzat506_MostrarMensaje("Seleccione el archivo a des-serializar.");
                return;
            }

            try
            {
                List<jzat506_Cliente> clientes = jzat506_bllDeserializar.jzat506_Deserializar(txtRutaDeserializar.Text);
                jzat506_MostrarClientes(clientes);
                jzat506_LimpiarCampos();
                btnModificar.Enabled = false;
                btnEliminar.Enabled = false;
                jzat506_MostrarMensaje("Se des-serializaron " + clientes.Count + " clientes del archivo " + Path.GetFileName(txtRutaDeserializar.Text));
            }
            catch (Exception ex)
            {
                jzat506_MostrarMensaje("No se pudo des-serializar el archivo: " + ex.Message);
            }
        }

        private void jzat506_btnActualizarGrilla_Click(object sender, EventArgs e)
        {
            jzat506_CargarListado();
            jzat506_LimpiarCampos();
            jzat506_MostrarMensaje("Se cargaron los clientes de la base de datos.");
        }

        private void jzat506_MostrarMensaje(string texto)
        {
            txtMensaje.Text = texto;
        }

        private void jzat506_btnLimpiarGrilla_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            jzat506_LimpiarCampos();
            txtRutaSerializar.Clear();
            txtRutaDeserializar.Clear();
            txtMensaje.Clear();
        }

        private void jzat506_LimpiarCampos()
        {
            txtDNI.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtEmail.Clear();
            txtTelefono.Clear();
            txtDireccion.Clear();
            jzat506_idClienteSeleccionado = 0;
        }

        private void jzat506_btnVolverCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void jzat506_FrmRegistrarCliente_FormClosing(object sender, FormClosingEventArgs e)
        {
            LanguageManager.GetInstance().Quitar(this);
        }
    }
}
