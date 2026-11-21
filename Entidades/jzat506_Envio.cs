using System;

namespace Entidades
{
    public class jzat506_Envio : IVerificable
    {
        public int jzat506_Id { get; set; }
        public jzat506_ZonaCobertura jzat506_Zona { get; set; } = null!;
        public string jzat506_Direccion { get; set; } = "";
        public string jzat506_Telefono { get; set; } = "";
        public decimal jzat506_CostoEnvio { get; set; }
        public string jzat506_MedioPago { get; set; } = "";
        public jzat506_Transportista? jzat506_Transportista { get; set; }
        public int jzat506_DVH { get; set; }

        public int ObtenerIdParaDV() => jzat506_Id;

        public int[] ObtenerCamposParaDV()
        {
            return new int[]
            {
                jzat506_Id                                                  * 1,
                (jzat506_Zona != null ? jzat506_Zona.jzat506_Id : 0)        * 3,
                jzat506_SumaASCII(jzat506_Direccion)                        * 7,
                jzat506_SumaASCII(jzat506_Telefono)                         * 11,
                (int)decimal.Round(jzat506_CostoEnvio * 100)                * 13,
                jzat506_SumaASCII(jzat506_MedioPago)                        * 17,
                (jzat506_Transportista != null ? jzat506_Transportista.jzat506_Id : 0) * 19
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
