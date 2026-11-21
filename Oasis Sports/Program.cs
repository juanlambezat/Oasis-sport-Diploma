namespace Oasis_Sports
{
    internal static class Program
    {

        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            BLL.jzat506_BLL_Instalacion instalacion = new BLL.jzat506_BLL_Instalacion();

            if (!instalacion.jzat506_BaseDisponible())
            {
                using (jzat506_FrmConfigurarBase frm = new jzat506_FrmConfigurarBase())
                {
                    if (frm.ShowDialog() != DialogResult.OK)
                        return;
                }
            }

            try
            {
                if (!instalacion.jzat506_BaseActualizada())
                {
                    instalacion.jzat506_ActualizarBase();
                    MessageBox.Show("Se encontró la base de datos de la versión anterior de Oasis Sports.\n\n" +
                        "Se actualizó a la versión nueva sin borrar ni modificar sus datos.", "Oasis Sports",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo actualizar la base de datos. La base quedó como estaba.\n\n" + ex.Message,
                    "Oasis Sports", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Application.Run(new FrmMenu());
        }
    }
}
