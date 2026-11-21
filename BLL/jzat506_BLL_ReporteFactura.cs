using System;
using System.Collections.Generic;
using DAL;
using Entidades;
using Servicios;

namespace BLL
{
    public class jzat506_BLL_ReporteFactura
    {
        private readonly jzat506_BLL_Cliente jzat506_bllCliente = new jzat506_BLL_Cliente();
        private readonly jzat506_DAL_ReporteFactura jzat506_dalReporte = new jzat506_DAL_ReporteFactura();
        private readonly jzat506_ServicioExportacion jzat506_servicioExportacion = new jzat506_ServicioExportacion();
        private readonly BLL_Evento jzat506_bllEvento = new BLL_Evento();

        public jzat506_Cliente? jzat506_BuscarCliente(int dni)
        {
            return jzat506_bllCliente.jzat506_BuscarCliente(dni);
        }

        public List<jzat506_Factura> jzat506_ListarFacturas(jzat506_Cliente cliente)
        {
            List<jzat506_Factura> facturas = jzat506_dalReporte.jzat506_ObtenerFacturasPorCliente(cliente.jzat506_Id);
            Dictionary<int, List<jzat506_DetalleFactura>> detalles = jzat506_dalReporte.jzat506_ObtenerDetallesPorCliente(cliente.jzat506_Id);

            foreach (jzat506_Factura factura in facturas)
            {
                factura.jzat506_Cliente = cliente;

                if (detalles.TryGetValue(factura.jzat506_Id, out List<jzat506_DetalleFactura>? lineas))
                    factura.jzat506_Detalles = lineas;
            }

            return facturas;
        }

        public void jzat506_ExportarFacturaPDF(jzat506_Factura factura, string ruta)
        {
            jzat506_servicioExportacion.jzat506_ExportarFacturaPDF(factura, ruta);
            jzat506_RegistrarEventoReporte("Factura exportada a PDF", 2);
        }

        public void jzat506_ExportarListadoExcel(jzat506_Cliente cliente, List<jzat506_Factura> facturas, string ruta)
        {
            jzat506_servicioExportacion.jzat506_ExportarListadoExcel(cliente, facturas, ruta);
            jzat506_RegistrarEventoReporte("Listado de facturas exportado a Excel", 2);
        }

        private void jzat506_RegistrarEventoReporte(string descripcion, int criticidad)
        {
            jzat506_bllEvento.RegistrarEvento(new Evento
            {
                Usuario = SessionManager.GetInstance().Usuario?.Username ?? "sistema",
                Modulo = "Facturas",
                Descripcion = descripcion,
                Fecha = DateTime.Now,
                Criticidad = criticidad
            });
        }
    }
}
