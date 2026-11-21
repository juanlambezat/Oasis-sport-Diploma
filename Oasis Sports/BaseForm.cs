using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Oasis_Sports
{
    public partial class BaseForm : Form
    {
        public BaseForm()
        {
            InitializeComponent();


            this.Font = new Font("Times New Roman", 14F, FontStyle.Regular);
            this.ForeColor = Color.Black;
            this.BackColor = Color.DarkGray;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.None; 
            this.Padding = new Padding(2);  
        }

        private void BaseForm_Load(object sender, EventArgs e)
        {

        }

        protected bool jzat506_ConBotonAyuda = true;

        protected override void OnLoad(EventArgs e)
        {
            if (!DesignMode && jzat506_ConBotonAyuda)
                jzat506_AgregarBotonAyuda();
            base.OnLoad(e);
        }

        private void jzat506_AgregarBotonAyuda()
        {
            Button btnAyuda = new Button();
            btnAyuda.Name = "btnAyuda";
            btnAyuda.Text = "?";
            btnAyuda.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            btnAyuda.ForeColor = Color.DarkGreen;
            btnAyuda.BackColor = Color.White;
            btnAyuda.Size = new Size(30, 30);
            btnAyuda.Location = new Point(this.ClientSize.Width - 34, 4);
            btnAyuda.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAyuda.TabStop = false;
            btnAyuda.Click += jzat506_btnAyuda_Click;
            this.Controls.Add(btnAyuda);
            btnAyuda.BringToFront();
        }

        protected void jzat506_UbicarAyuda(int x, int y)
        {
            Control[] encontrados = this.Controls.Find("btnAyuda", false);
            if (encontrados.Length == 0)
                return;

            encontrados[0].Anchor = AnchorStyles.Top | AnchorStyles.Left;
            encontrados[0].Location = new Point(x, y);
        }

        private void jzat506_btnAyuda_Click(object? sender, EventArgs e)
        {
            jzat506_AbrirAyuda(this.GetType().Name);
        }

        public static void jzat506_AbrirAyuda(string pantalla)
        {
            string ruta = Path.Combine(AppContext.BaseDirectory, "Ayuda", pantalla + ".pdf");

            if (!File.Exists(ruta))
            {
                MessageBox.Show("No se encontró la ayuda de esta pantalla.", "Ayuda", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Process.Start(new ProcessStartInfo(ruta) { UseShellExecute = true });
            }
            catch (Exception)
            {
                MessageBox.Show("No se pudo abrir la ayuda. Verifique que haya un programa para ver archivos PDF.", "Ayuda", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
