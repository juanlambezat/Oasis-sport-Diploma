using System;
using Entidades;

namespace BLL
{
    public class jzat506_ClienteExistenteException : Exception
    {
        public jzat506_Cliente jzat506_Cliente { get; }

        public jzat506_ClienteExistenteException(jzat506_Cliente cliente)
            : base("El DNI ya esta registrado.")
        {
            jzat506_Cliente = cliente;
        }
    }
}
