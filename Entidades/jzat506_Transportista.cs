using System;

namespace Entidades
{
    public class jzat506_Transportista
    {
        public int jzat506_Id { get; set; }
        public string jzat506_Nombre { get; set; } = "";
        public string jzat506_Apellido { get; set; } = "";
        public int jzat506_PedidoActual { get; set; }

        public bool jzat506_Libre()
        {
            return jzat506_PedidoActual == 0;
        }

        public override string ToString()
        {
            return jzat506_Nombre + " " + jzat506_Apellido;
        }
    }
}
