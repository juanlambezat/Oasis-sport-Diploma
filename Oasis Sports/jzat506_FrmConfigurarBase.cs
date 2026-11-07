using BLL;
using System;
using System.Windows.Forms;

namespace Oasis_Sports
{
    public partial class jzat506_FrmConfigurarBase : BaseForm
    {
        private readonly jzat506_BLL_Instalacion jzat506_bllInstalacion = new jzat506_BLL_Instalacion();

        public jzat506_FrmConfigurarBase()
        {
            InitializeComponent();
        }

        private void jzat506_FrmConfigurarBase_Load(object sender, EventArgs e)
        {
            cmbServidorConfigurar.Items.Add(".");
            cmbServidorConfigurar.Items.Add(".\\SQLEXPRESS");
            cmbServidorConfigurar.Items.Add("(localdb)\\MSSQLLocalDB");
            cmbServidorConfigurar.Text = jzat506_bllInstalacion.jzat506_ServidorActual();
        }

        private void jzat506_btnCrearBase_Click(object sender, EventArgs e)
        {
            string servidor = cmbServidorConfigurar.Text.Trim();

            Cursor = Cursors.WaitCursor;
            btnCrearBase.Enabled = false;

            try
            {
                jzat506_bllInstalacion.jzat506_CrearBase(servidor);
                Cursor = Cursors.Default;
                MessageBox.Show("La base de datos quedó lista en el servidor " + servidor + ".", "Oasis Sports",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                btnCrearBase.Enabled = true;
                MessageBox.Show("No se pudo crear la base de datos en el servidor " + servidor + ".\n\n" + ex.Message,
                    "Oasis Sports", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void jzat506_btnSalirConfigurar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
