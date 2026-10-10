namespace Entidades
{
    public class jzat506_Producto : IVerificable
    {
        public int jzat506_Id { get; set; }
        public string jzat506_Codigo { get; set; } = "";
        public string jzat506_Nombre { get; set; } = "";
        public string jzat506_Categoria { get; set; } = "";
        public decimal jzat506_Precio { get; set; }
        public int jzat506_DVH { get; set; }

        public int ObtenerIdParaDV() => jzat506_Id;

        public int[] ObtenerCamposParaDV()
        {
            return new int[]
            {
                jzat506_Id                                * 1,
                jzat506_SumaASCII(jzat506_Codigo)          * 3,
                jzat506_SumaASCII(jzat506_Nombre)          * 7,
                jzat506_SumaASCII(jzat506_Categoria)       * 11,
                (int)decimal.Round(jzat506_Precio * 100)   * 13
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
