namespace Oasis_Sports
{
    internal static class Program
    {
       
        [STAThread]
        static void Main()
        {
            
            https:
            ApplicationConfiguration.Initialize();
            Application.Run(new FrmMenu());
        }
    }
}