using System;

namespace Entidades
{
    public class jzat506_Cliente : IVerificable
    {
        public int jzat506_Id { get; set; }
        public int jzat506_DNI { get; set; }
        public string jzat506_Nombre { get; set; } = "";
        public string jzat506_Apellido { get; set; } = "";
        public string jzat506_Email { get; set; } = "";
        public string jzat506_Telefono { get; set; } = "";
        public string jzat506_Direccion { get; set; } = "";
        public bool jzat506_Activo { get; set; } = true;
        public int jzat506_DVH { get; set; }

        public int ObtenerIdParaDV() => jzat506_Id;

        public int[] ObtenerCamposParaDV()
        {
            return new int[]
            {
                jzat506_Id                    * 1,
                jzat506_DNI                   * 3,
                jzat506_SumaASCII(jzat506_Nombre)     * 7,
                jzat506_SumaASCII(jzat506_Apellido)   * 11,
                jzat506_SumaASCII(jzat506_Email)      * 13,
                jzat506_SumaASCII(jzat506_Telefono)   * 17,
                jzat506_SumaASCII(jzat506_Direccion)  * 19,
                (jzat506_Activo ? 1 : 0)       * 23
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
