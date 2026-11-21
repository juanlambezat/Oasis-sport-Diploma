using System;
using DAL;
using Entidades;
using Servicios;

namespace BLL
{
    public class jzat506_BLL_HistorialPedido
    {
        private readonly DAL_HistorialCambios jzat506_dalHistorial = new DAL_HistorialCambios();

        public void jzat506_RegistrarCambioEstado(jzat506_Pedido pedido, string estadoAnterior)
        {
            HistorialCambio cambio = new HistorialCambio();
            cambio.EntidadId = pedido.jzat506_Id;
            cambio.NombreEntidad = "Pedido";
            cambio.NombreCampo = "Estado";
            cambio.ValorAnterior = estadoAnterior;
            cambio.ValorNuevo = pedido.jzat506_Estado;
            cambio.Usuario = SessionManager.GetInstance().Usuario?.Username ?? "sistema";
            cambio.Fecha = DateTime.Now;

            jzat506_dalHistorial.Registrar(cambio);
        }

        public void jzat506_RegistrarAsignacion(jzat506_Pedido pedido, jzat506_Transportista transportista)
        {
            HistorialCambio cambio = new HistorialCambio();
            cambio.EntidadId = pedido.jzat506_Id;
            cambio.NombreEntidad = "Pedido";
            cambio.NombreCampo = "Transportista";
            cambio.ValorAnterior = "Sin asignar";
            cambio.ValorNuevo = transportista.ToString();
            cambio.Usuario = SessionManager.GetInstance().Usuario?.Username ?? "sistema";
            cambio.Fecha = DateTime.Now;

            jzat506_dalHistorial.Registrar(cambio);
        }
    }
}
