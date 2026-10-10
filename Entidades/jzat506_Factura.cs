using System;
using System.Collections.Generic;

namespace Entidades
{
    public class jzat506_Factura : IVerificable
    {
        public int jzat506_Id { get; set; }
        public DateTime jzat506_Fecha { get; set; }
        public decimal jzat506_Total { get; set; }
        public string jzat506_MedioPago { get; set; } = "";
        public jzat506_Cliente jzat506_Cliente { get; set; } = null!;
        public List<jzat506_DetalleFactura> jzat506_Detalles { get; set; } = new List<jzat506_DetalleFactura>();
        public int jzat506_DVH { get; set; }

        public int ObtenerIdParaDV() => jzat506_Id;

        public int[] ObtenerCamposParaDV()
        {
            int fechaComoNumero = jzat506_Fecha.Year * 10000 + jzat506_Fecha.Month * 100 + jzat506_Fecha.Day;

            return new int[]
            {
                jzat506_Id                                              * 1,
                fechaComoNumero                                         * 3,
                (int)decimal.Round(jzat506_Total * 100)                 * 7,
                jzat506_SumaASCII(jzat506_MedioPago)                    * 11,
                (jzat506_Cliente != null ? jzat506_Cliente.jzat506_Id : 0) * 13
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
