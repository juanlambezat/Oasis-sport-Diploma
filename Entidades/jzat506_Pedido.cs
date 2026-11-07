using System;

namespace Entidades
{
    public class jzat506_Pedido : IVerificable
    {
        public int jzat506_Id { get; set; }
        public jzat506_Factura jzat506_Factura { get; set; } = null!;
        public DateTime jzat506_Fecha { get; set; }
        public string jzat506_Estado { get; set; } = "";
        public jzat506_Envio jzat506_Envio { get; set; } = null!;
        public int jzat506_DVH { get; set; }

        public int ObtenerIdParaDV() => jzat506_Id;

        public int[] ObtenerCamposParaDV()
        {
            int fechaComoNumero = jzat506_Fecha.Year * 10000 + jzat506_Fecha.Month * 100 + jzat506_Fecha.Day;

            return new int[]
            {
                jzat506_Id                                                      * 1,
                (jzat506_Factura != null ? jzat506_Factura.jzat506_Id : 0)      * 3,
                fechaComoNumero                                                 * 7,
                jzat506_SumaASCII(jzat506_Estado)                               * 11
            };
        }

        private int jzat506_SumaASCII(string texto)
        {
            int suma = 0;
            if (!string.IsNullOrEmpty(texto))
                foreach (char c in texto)
                    suma += (int)c;
            return suma;
        }
    }
}
