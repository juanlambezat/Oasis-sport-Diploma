using System.Collections.Generic;
using System.Linq;
using DAL;
using Entidades;
using Servicios;

namespace BLL
{
    public class jzat506_BLL_Cliente
    {
        private readonly jzat506_DAL_Cliente jzat506_dalCliente = new jzat506_DAL_Cliente();
        private readonly ValidadorDeIntegridad jzat506_validador = new ValidadorDeIntegridad();
        private readonly BLL_Evento jzat506_bllEvento = new BLL_Evento();

        public jzat506_Cliente? jzat506_BuscarCliente(int dni)
        {
            return jzat506_dalCliente.jzat506_ObtenerPorDNI(dni);
        }

        public List<jzat506_Cliente> jzat506_ListarClientes()
        {
            return jzat506_dalCliente.jzat506_ObtenerTodos();
        }

        public jzat506_Cliente jzat506_RegistrarCliente(int dni, string nombre, string apellido, string email,
            string telefono, string direccion)
        {
            jzat506_Cliente? existente = jzat506_dalCliente.jzat506_ObtenerPorDNI(dni);
            if (existente != null)
                throw new jzat506_ClienteExistenteException(existente);

            jzat506_Cliente cliente = new jzat506_Cliente
            {
                jzat506_DNI = dni,
                jzat506_Nombre = nombre,
                jzat506_Apellido = apellido,
                jzat506_Email = email,
                jzat506_Telefono = telefono,
                jzat506_Direccion = direccion
            };

            cliente.jzat506_Id = jzat506_dalCliente.jzat506_InsertarCliente(cliente);
            jzat506_RecalcularDV(cliente);
            jzat506_RegistrarEventoCliente("Alta de cliente", 2);

            return cliente;
        }

        public void jzat506_ModificarCliente(int idCliente, string nombre, string apellido, string email,
            string telefono, string direccion)
        {
            jzat506_Cliente cliente = new jzat506_Cliente
            {
                jzat506_Id = idCliente,
                jzat506_Nombre = nombre,
                jzat506_Apellido = apellido,
                jzat506_Email = email,
                jzat506_Telefono = telefono,
                jzat506_Direccion = direccion
            };

            jzat506_dalCliente.jzat506_ModificarCliente(cliente);

            jzat506_Cliente actualizado = jzat506_dalCliente.jzat506_ObtenerTodos().First(c => c.jzat506_Id == idCliente);
            jzat506_RecalcularDV(actualizado);
            jzat506_RegistrarEventoCliente("Modificacion de cliente", 2);
        }

        public void jzat506_EliminarCliente(int idCliente)
        {
            jzat506_dalCliente.jzat506_EliminarCliente(idCliente);

            jzat506_Cliente cliente = jzat506_dalCliente.jzat506_ObtenerTodos().First(c => c.jzat506_Id == idCliente);
            jzat506_RecalcularDV(cliente);
            jzat506_RegistrarEventoCliente("Eliminacion de cliente: " + cliente.jzat506_Nombre + " " + cliente.jzat506_Apellido, 3);
        }

        private void jzat506_RecalcularDV(jzat506_Cliente cliente)
        {
            int dvh = jzat506_validador.CalcularDV(cliente);
            cliente.jzat506_DVH = dvh;
            jzat506_dalCliente.jzat506_ActualizarDVH(cliente.jzat506_Id, dvh);

            List<jzat506_Cliente> todos = jzat506_dalCliente.jzat506_ObtenerTodos();
            int dvv = jzat506_validador.CalcularDVV(todos.Cast<IVerificable>().ToList());
            jzat506_dalCliente.jzat506_ActualizarDVV(dvv);
        }

        private void jzat506_RegistrarEventoCliente(string descripcion, int criticidad)
        {
            jzat506_bllEvento.RegistrarEvento(new Evento
            {
                Usuario = SessionManager.GetInstance().Usuario?.Username ?? "sistema",
                Modulo = "Clientes",
                Descripcion = descripcion,
                Fecha = System.DateTime.Now,
                Criticidad = criticidad
            });
        }
    }
}
