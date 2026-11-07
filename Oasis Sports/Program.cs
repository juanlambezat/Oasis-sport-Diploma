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

            Application.Run(new FrmMenu());
        }
    }
}
