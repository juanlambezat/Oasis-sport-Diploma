using System;
using System.Collections.Generic;
using DAL;
using Entidades;
using Servicios;

namespace BLL
{
    public class jzat506_BLL_Pedido
    {
        private readonly jzat506_DAL_Pedido jzat506_dalPedido = new jzat506_DAL_Pedido();
        private readonly jzat506_DAL_Transportista jzat506_dalTransportista = new jzat506_DAL_Transportista();
        private readonly jzat506_BLL_Transportista jzat506_bllTransportista = new jzat506_BLL_Transportista();
        private readonly ValidadorDeIntegridad jzat506_validador = new ValidadorDeIntegridad();
        private readonly BLL_Evento jzat506_bllEvento = new BLL_Evento();
        private readonly jzat506_BLL_HistorialPedido jzat506_bllHistorial = new jzat506_BLL_HistorialPedido();

        public List<jzat506_Factura> jzat506_ListarFacturasSinPedido(jzat506_Cliente cliente)
        {
            return jzat506_dalPedido.jzat506_ObtenerFacturasSinPedido(cliente.jzat506_Id);
        }

        public jzat506_Pedido jzat506_RegistrarPedido(jzat506_Factura factura, jzat506_ZonaCobertura zona,
            string direccion, string telefono, string medioPago)
        {
            jzat506_Envio envio = new jzat506_Envio();
            envio.jzat506_Zona = zona;
            envio.jzat506_Direccion = direccion;
            envio.jzat506_Telefono = telefono;
            envio.jzat506_CostoEnvio = zona.jzat506_CostoEnvio;
            envio.jzat506_MedioPago = medioPago;

            jzat506_Pedido pedido = new jzat506_Pedido();
            pedido.jzat506_Factura = factura;
            pedido.jzat506_Fecha = DateTime.Now;
            pedido.jzat506_Estado = "Pendiente";
            pedido.jzat506_Envio = envio;

            jzat506_dalPedido.jzat506_InsertarPedido(pedido, envio);

            int dvhPedido = jzat506_validador.CalcularDV(pedido);
            pedido.jzat506_DVH = dvhPedido;
            jzat506_dalPedido.jzat506_ActualizarDVH(pedido.jzat506_Id, dvhPedido);

            int dvhEnvio = jzat506_validador.CalcularDV(envio);
            envio.jzat506_DVH = dvhEnvio;
            jzat506_dalPedido.jzat506_ActualizarDVHEnvio(envio.jzat506_Id, dvhEnvio);

            jzat506_ActualizarDVVPedido();
            jzat506_ActualizarDVVEnvio();

            jzat506_bllEvento.RegistrarEvento(new Evento
            {
                Usuario = SessionManager.GetInstance().Usuario?.Username ?? "sistema",
                Modulo = "Envios",
                Descripcion = "Pedido registrado",
                Fecha = DateTime.Now,
                Criticidad = 2
            });

            return pedido;
        }

        public List<jzat506_Pedido> jzat506_ListarPedidosNoEntregados()
        {
            return jzat506_dalPedido.jzat506_ObtenerNoEntregados();
        }

        public List<jzat506_Pedido> jzat506_ListarPedidosParaAsignar()
        {
            List<jzat506_Pedido> paraAsignar = new List<jzat506_Pedido>();

            foreach (jzat506_Pedido pedido in jzat506_dalPedido.jzat506_ObtenerNoEntregados())
            {
                if (pedido.jzat506_Estado == "Preparando" && pedido.jzat506_Envio.jzat506_Transportista == null)
                    paraAsignar.Add(pedido);
            }

            return paraAsignar;
        }

        public void jzat506_AsignarTransportista(jzat506_Pedido pedido, jzat506_Transportista transportista)
        {
            if (pedido.jzat506_Estado != "Preparando")
                throw new Exception("Solo se puede asignar transportista a un pedido en estado Preparando.");

            if (pedido.jzat506_Envio.jzat506_Transportista != null)
                throw new Exception("El pedido ya tiene un transportista asignado.");

            bool libre = false;
            foreach (jzat506_Transportista t in jzat506_bllTransportista.jzat506_ListarLibres())
            {
                if (t.jzat506_Id == transportista.jzat506_Id)
                    libre = true;
            }

            if (!libre)
                throw new Exception("El transportista esta ocupado con otro pedido.");

            jzat506_dalTransportista.jzat506_AsignarTransportista(pedido.jzat506_Envio.jzat506_Id, transportista.jzat506_Id);
            pedido.jzat506_Envio.jzat506_Transportista = transportista;

            int dvhEnvio = jzat506_validador.CalcularDV(pedido.jzat506_Envio);
            pedido.jzat506_Envio.jzat506_DVH = dvhEnvio;
            jzat506_dalPedido.jzat506_ActualizarDVHEnvio(pedido.jzat506_Envio.jzat506_Id, dvhEnvio);

            jzat506_ActualizarDVVEnvio();

            jzat506_bllHistorial.jzat506_RegistrarAsignacion(pedido, transportista);

            jzat506_bllEvento.RegistrarEvento(new Evento
            {
                Usuario = SessionManager.GetInstance().Usuario?.Username ?? "sistema",
                Modulo = "Envios",
                Descripcion = "Transportista asignado",
                Fecha = DateTime.Now,
                Criticidad = 2
            });
        }

        public jzat506_Pedido jzat506_AvanzarEstado(jzat506_Pedido pedido)
        {
            string estadoAnterior = pedido.jzat506_Estado;

            if (estadoAnterior == "Preparando" && pedido.jzat506_Envio.jzat506_Transportista == null)
                throw new Exception("Asigne un transportista antes de despachar el pedido.");

            string estadoNuevo = jzat506_ObtenerSiguienteEstado(estadoAnterior);

            jzat506_dalPedido.jzat506_ActualizarEstado(pedido.jzat506_Id, estadoNuevo);
            pedido.jzat506_Estado = estadoNuevo;

            int dvh = jzat506_validador.CalcularDV(pedido);
            pedido.jzat506_DVH = dvh;
            jzat506_dalPedido.jzat506_ActualizarDVH(pedido.jzat506_Id, dvh);

            jzat506_ActualizarDVVPedido();

            jzat506_bllHistorial.jzat506_RegistrarCambioEstado(pedido, estadoAnterior);

            return pedido;
        }

        private string jzat506_ObtenerSiguienteEstado(string estado)
        {
            if (estado == "Pendiente")
                return "Preparando";
            if (estado == "Preparando")
                return "Despachado";
            if (estado == "Despachado")
                return "En camino";
            if (estado == "En camino")
                return "Entregado";

            throw new Exception("El pedido no puede cambiar de estado.");
        }

        private void jzat506_ActualizarDVVPedido()
        {
            List<jzat506_Pedido> pedidos = jzat506_dalPedido.jzat506_ObtenerTodos();
            List<IVerificable> objetos = new List<IVerificable>();
            foreach (jzat506_Pedido p in pedidos)
                objetos.Add(p);

            int dvv = jzat506_validador.CalcularDVV(objetos);
            jzat506_dalPedido.jzat506_ActualizarDVV(dvv);
        }

        private void jzat506_ActualizarDVVEnvio()
        {
            List<jzat506_Envio> envios = jzat506_dalPedido.jzat506_ObtenerTodosEnvios();
            List<IVerificable> objetos = new List<IVerificable>();
            foreach (jzat506_Envio e in envios)
                objetos.Add(e);

            int dvv = jzat506_validador.CalcularDVV(objetos);
            jzat506_dalPedido.jzat506_ActualizarDVVEnvio(dvv);
        }
    }
}
