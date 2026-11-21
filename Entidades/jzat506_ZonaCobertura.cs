using System;

namespace Entidades
{
    public class jzat506_ZonaCobertura
    {
        public int jzat506_Id { get; set; }
        public string jzat506_Localidad { get; set; } = "";
        public string jzat506_CodigoPostal { get; set; } = "";
        public decimal jzat506_CostoEnvio { get; set; }

        public override string ToString()
        {
            return jzat506_Localidad + " (" + jzat506_CodigoPostal + ")";
        }
    }
}
