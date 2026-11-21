using System;
using System.Collections.Generic;
using System.Linq;
using DAL;
using Entidades;
using Servicios;

namespace BLL
{
    public class jzat506_BLL_Factura
    {
        private readonly jzat506_DAL_Factura jzat506_dalFactura = new jzat506_DAL_Factura();
        private readonly ValidadorDeIntegridad jzat506_validador = new ValidadorDeIntegridad();
        private readonly BLL_Evento jzat506_bllEvento = new BLL_Evento();

        public jzat506_Factura jzat506_GenerarFactura(jzat506_Cliente cliente, List<jzat506_DetalleFactura> detalles,
            string medioPago)
        {
            jzat506_Factura factura = new jzat506_Factura
            {
                jzat506_Cliente = cliente,
                jzat506_Detalles = detalles,
                jzat506_MedioPago = medioPago,
                jzat506_Fecha = DateTime.Now,
                jzat506_Total = detalles.Sum(d => d.jzat506_Cantidad * d.jzat506_PrecioUnitario)
            };

            factura.jzat506_Id = jzat506_dalFactura.jzat506_InsertarFactura(factura);

            int dvhFactura = jzat506_validador.CalcularDV(factura);
            factura.jzat506_DVH = dvhFactura;
            jzat506_dalFactura.jzat506_ActualizarDVH(factura.jzat506_Id, dvhFactura);

            foreach (jzat506_DetalleFactura detalle in factura.jzat506_Detalles)
            {
                int dvhDetalle = jzat506_validador.CalcularDV(detalle);
                detalle.jzat506_DVH = dvhDetalle;
                jzat506_dalFactura.jzat506_ActualizarDVHDetalle(detalle.jzat506_Id, dvhDetalle);
            }

            List<jzat506_Factura> todasLasFacturas = jzat506_dalFactura.jzat506_ObtenerTodas();
            int dvvFactura = jzat506_validador.CalcularDVV(todasLasFacturas.Cast<IVerificable>().ToList());
            jzat506_dalFactura.jzat506_ActualizarDVV(dvvFactura);

            List<jzat506_DetalleFactura> todosLosDetalles = jzat506_dalFactura.jzat506_ObtenerTodosDetalles();
            int dvvDetalle = jzat506_validador.CalcularDVV(todosLosDetalles.Cast<IVerificable>().ToList());
            jzat506_dalFactura.jzat506_ActualizarDVVDetalle(dvvDetalle);

            jzat506_bllEvento.RegistrarEvento(new Evento
            {
                Usuario = SessionManager.GetInstance().Usuario?.Username ?? "sistema",
                Modulo = "Ventas",
                Descripcion = "Factura generada",
                Fecha = DateTime.Now,
                Criticidad = 2
            });

            return factura;
        }
    }
}
