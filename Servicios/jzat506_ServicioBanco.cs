using System.Linq;

namespace Servicios
{
    public class jzat506_ServicioBanco
    {
        private readonly jzat506_ServicioCifrado jzat506_servicioCifrado = new jzat506_ServicioCifrado();

        public bool jzat506_AutorizarPago(string datosCifrados, decimal total)
        {
            string datos = jzat506_servicioCifrado.jzat506_Descifrar(datosCifrados);
            string[] partes = datos.Split('|');

            if (partes.Length < 2)
                return false;

            string numeroCuenta = partes[1];

            return numeroCuenta.Length == 22 && numeroCuenta.All(char.IsDigit);
        }
    }
}
