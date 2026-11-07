using System;
using System.Collections.Generic;
using System.Globalization;
using DAL;
using Entidades;
using Servicios;

namespace BLL
{
    public class jzat506_BLL_ReporteEnvio
    {
        private readonly jzat506_DAL_ReporteEnvio jzat506_dalReporte = new jzat506_DAL_ReporteEnvio();
        private readonly jzat506_BLL_Zona jzat506_bllZona = new jzat506_BLL_Zona();
        private readonly jzat506_ServicioExportacion jzat506_servicioExportacion = new jzat506_ServicioExportacion();
        private readonly BLL_Evento jzat506_bllEvento = new BLL_Evento();

        private static readonly CultureInfo jzat506_cultura = new CultureInfo("es-AR");

        public List<jzat506_ZonaCobertura> jzat506_ListarZonas()
        {
            return jzat506_bllZona.jzat506_ListarZonas();
        }

        public List<jzat506_Pedido> jzat506_ListarEnvios(DateTime desde, DateTime hasta, string estado, jzat506_ZonaCobertura? zona)
        {
            if (desde.Date > hasta.Date)
                throw new Exception("La fecha desde no puede ser mayor que la fecha hasta.");

            int idZona = 0;
            if (zona != null)
                idZona = zona.jzat506_Id;

            return jzat506_dalReporte.jzat506_ObtenerEnvios(desde, hasta, estado, idZona);
        }

        public decimal jzat506_CalcularTotalCobrado(List<jzat506_Pedido> pedidos)
        {
            decimal total = 0;

            foreach (jzat506_Pedido pedido in pedidos)
                total += pedido.jzat506_Envio.jzat506_CostoEnvio;

            return total;
        }

        public decimal jzat506_CalcularTotalPorMedioPago(List<jzat506_Pedido> pedidos, string medioPago)
        {
            decimal total = 0;

            foreach (jzat506_Pedido pedido in pedidos)
            {
                if (pedido.jzat506_Envio.jzat506_MedioPago == medioPago)
                    total += pedido.jzat506_Envio.jzat506_CostoEnvio;
            }

            return total;
        }

        public int jzat506_ContarPorMedioPago(List<jzat506_Pedido> pedidos, string medioPago)
        {
            int cantidad = 0;

            foreach (jzat506_Pedido pedido in pedidos)
            {
                if (pedido.jzat506_Envio.jzat506_MedioPago == medioPago)
                    cantidad++;
            }

            return cantidad;
        }

        public int jzat506_ContarPorEstado(List<jzat506_Pedido> pedidos, string estado)
        {
            int cantidad = 0;

            foreach (jzat506_Pedido pedido in pedidos)
            {
                if (pedido.jzat506_Estado == estado)
                    cantidad++;
            }

            return cantidad;
        }

        public string jzat506_ArmarResumen(List<jzat506_Pedido> pedidos)
        {
            string salto = Environment.NewLine;

            string resumen = "Envios: " + pedidos.Count + "   Total cobrado: " + jzat506_CalcularTotalCobrado(pedidos).ToString("C", jzat506_cultura) + salto;

            resumen += "Efectivo: " + jzat506_CalcularTotalPorMedioPago(pedidos, "Efectivo").ToString("C", jzat506_cultura);
            resumen += "   Transferencia: " + jzat506_CalcularTotalPorMedioPago(pedidos, "Transferencia").ToString("C", jzat506_cultura);
            resumen += "   Sin costo: " + jzat506_ContarPorMedioPago(pedidos, "Sin costo") + " envios" + salto;

            resumen += "Pendiente: " + jzat506_ContarPorEstado(pedidos, "Pendiente");
            resumen += "   Preparando: " + jzat506_ContarPorEstado(pedidos, "Preparando");
            resumen += "   Despachado: " + jzat506_ContarPorEstado(pedidos, "Despachado");
            resumen += "   En camino: " + jzat506_ContarPorEstado(pedidos, "En camino");
            resumen += "   Entregado: " + jzat506_ContarPorEstado(pedidos, "Entregado");

            return resumen;
        }

        public void jzat506_ExportarPDF(List<jzat506_Pedido> pedidos, string resumen, string ruta)
        {
            jzat506_servicioExportacion.jzat506_ExportarReporteEnviosPDF(pedidos, resumen, ruta);
            jzat506_RegistrarEventoReporte("Reporte de envios exportado a PDF", 2);
        }

        public void jzat506_ExportarExcel(List<jzat506_Pedido> pedidos, string resumen, string ruta)
        {
            jzat506_servicioExportacion.jzat506_ExportarReporteEnviosExcel(pedidos, resumen, ruta);
            jzat506_RegistrarEventoReporte("Reporte de envios exportado a Excel", 2);
        }

        private void jzat506_RegistrarEventoReporte(string descripcion, int criticidad)
        {
            jzat506_bllEvento.RegistrarEvento(new Evento
            {
                Usuario = SessionManager.GetInstance().Usuario?.Username ?? "sistema",
                Modulo = "Envios",
                Descripcion = descripcion,
                Fecha = DateTime.Now,
                Criticidad = criticidad
            });
        }
    }
}
