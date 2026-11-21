using System;

namespace Entidades
{
    public class jzat506_Usuario_C
    {
        public int jzat506_IdVersion { get; set; }
        public int jzat506_IdUsuario { get; set; }
        public string jzat506_NombreUsuario { get; set; } = "";
        public string jzat506_Contrasenia { get; set; } = "";
        public bool jzat506_Bloqueado { get; set; }
        public bool jzat506_Eliminado { get; set; }
        public DateTime jzat506_Fecha { get; set; }
        public TimeSpan jzat506_Hora { get; set; }
        public string jzat506_Usuario { get; set; } = "";
        public bool jzat506_Activo { get; set; }
    }
}
