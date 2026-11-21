namespace Entidades
{
    public class jzat506_DetalleFactura : IVerificable
    {
        public int jzat506_Id { get; set; }
        public jzat506_Producto jzat506_Producto { get; set; } = null!;
        public int jzat506_Cantidad { get; set; }
        public decimal jzat506_PrecioUnitario { get; set; }
        public int jzat506_DVH { get; set; }

        public int ObtenerIdParaDV() => jzat506_Id;

        public int[] ObtenerCamposParaDV()
        {
            return new int[]
            {
                jzat506_Id                                            * 1,
                (jzat506_Producto != null ? jzat506_Producto.jzat506_Id : 0) * 3,
                jzat506_Cantidad                                      * 7,
                (int)decimal.Round(jzat506_PrecioUnitario * 100)      * 11
            };
        }
    }
}
