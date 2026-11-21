using System;
using System.Collections.Generic;
using System.Globalization;
using DAL;
using Entidades;
using Servicios;

namespace BLL
{
    public class jzat506_BLL_AnalisisVentas
    {
        private readonly jzat506_DAL_AnalisisVentas jzat506_dalAnalisis = new jzat506_DAL_AnalisisVentas();
        private readonly jzat506_ServicioExportacion jzat506_servicioExportacion = new jzat506_ServicioExportacion();
        private readonly BLL_Evento jzat506_bllEvento = new BLL_Evento();

        private static readonly CultureInfo jzat506_cultura = new CultureInfo("es-AR");

        public jzat506_AnalisisVentas jzat506_Analizar(DateTime desde, DateTime hasta)
        {
            if (desde.Date > hasta.Date)
                throw new Exception("La fecha desde no puede ser mayor que la fecha hasta.");

            int dias = (hasta.Date - desde.Date).Days + 1;

            jzat506_AnalisisVentas analisis = new jzat506_AnalisisVentas();
            analisis.jzat506_Desde = desde.Date;
            analisis.jzat506_Hasta = hasta.Date;
            analisis.jzat506_DesdeAnterior = desde.Date.AddDays(-dias);
            analisis.jzat506_HastaAnterior = desde.Date.AddDays(-1);

            DateTime d1 = analisis.jzat506_Desde;
            DateTime h1 = analisis.jzat506_Hasta;
            DateTime d0 = analisis.jzat506_DesdeAnterior;
            DateTime h0 = analisis.jzat506_HastaAnterior;

            decimal totalActual = jzat506_dalAnalisis.jzat506_ObtenerTotalVendido(d1, h1);
            decimal totalAnterior = jzat506_dalAnalisis.jzat506_ObtenerTotalVendido(d0, h0);
            int ventasActual = jzat506_dalAnalisis.jzat506_ContarVentas(d1, h1);
            int ventasAnterior = jzat506_dalAnalisis.jzat506_ContarVentas(d0, h0);
            int enviosActual = jzat506_dalAnalisis.jzat506_ContarEnvios(d1, h1);
            int enviosAnterior = jzat506_dalAnalisis.jzat506_ContarEnvios(d0, h0);

            decimal promedioActual = 0;
            if (ventasActual > 0)
                promedioActual = totalActual / ventasActual;

            decimal promedioAnterior = 0;
            if (ventasAnterior > 0)
                promedioAnterior = totalAnterior / ventasAnterior;

            jzat506_AgregarIndicador(analisis, "Total vendido", jzat506_Moneda(totalActual), jzat506_Moneda(totalAnterior), totalActual, totalAnterior);
            jzat506_AgregarIndicador(analisis, "Cantidad de ventas", ventasActual.ToString(), ventasAnterior.ToString(), ventasActual, ventasAnterior);
            jzat506_AgregarIndicador(analisis, "Venta promedio", jzat506_Moneda(promedioActual), jzat506_Moneda(promedioAnterior), promedioActual, promedioAnterior);
            jzat506_AgregarIndicador(analisis, "Envíos", enviosActual.ToString(), enviosAnterior.ToString(), enviosActual, enviosAnterior);

            if (ventasActual == 0)
            {
                analisis.jzat506_Conclusiones.Add("No hubo ventas en el período elegido, por eso no se pueden sacar conclusiones. Pruebe con otro período.");
                return analisis;
            }

            jzat506_ConcluirVentas(analisis, totalActual, totalAnterior, ventasAnterior, promedioActual, promedioAnterior);
            jzat506_ConcluirCategorias(analisis, jzat506_dalAnalisis.jzat506_ObtenerVentasPorCategoria(d1, h1), jzat506_dalAnalisis.jzat506_ObtenerVentasPorCategoria(d0, h0));
            jzat506_ConcluirProductosSinVenta(analisis, jzat506_dalAnalisis.jzat506_ObtenerProductosSinVentas(d1, h1));
            jzat506_ConcluirProductosJuntos(analisis, jzat506_dalAnalisis.jzat506_ObtenerProductosJuntos(d1, h1));
            jzat506_ConcluirZonas(analisis, jzat506_dalAnalisis.jzat506_ObtenerEnviosPorZona(d1, h1));
            jzat506_ConcluirTiempos(analisis, jzat506_dalAnalisis.jzat506_ObtenerTiempoEntregaPorZona(d1, h1));

            return analisis;
        }

        public void jzat506_ExportarPDF(jzat506_AnalisisVentas analisis, string ruta)
        {
            jzat506_servicioExportacion.jzat506_ExportarAnalisisVentasPDF(analisis, ruta);
            jzat506_RegistrarEventoReporte("Reporte inteligente exportado a PDF", 2);
        }

        private void jzat506_ConcluirVentas(jzat506_AnalisisVentas analisis, decimal totalActual, decimal totalAnterior, int ventasAnterior, decimal promedioActual, decimal promedioAnterior)
        {
            if (ventasAnterior == 0)
            {
                analisis.jzat506_Conclusiones.Add("En el período anterior no hubo ventas, así que no se puede comparar. En este período se vendieron "
                    + jzat506_Moneda(totalActual) + ".");
                return;
            }

            string comparacion = " (" + jzat506_Moneda(totalActual) + " contra " + jzat506_Moneda(totalAnterior) + ")";
            decimal variacion = jzat506_CalcularVariacion(totalActual, totalAnterior);

            if (variacion >= 10)
                analisis.jzat506_Conclusiones.Add("Las ventas subieron un " + jzat506_Porcentaje(variacion) + " respecto al período anterior" + comparacion
                    + ". Conviene tener transportistas disponibles para acompañar la suba de envíos.");
            else if (variacion <= -10)
                analisis.jzat506_Conclusiones.Add("Las ventas bajaron un " + jzat506_Porcentaje(variacion) + " respecto al período anterior" + comparacion
                    + ". Conviene lanzar una promoción para recuperarlas.");
            else
                analisis.jzat506_Conclusiones.Add("Las ventas se mantuvieron estables respecto al período anterior" + comparacion + ".");

            decimal variacionPromedio = jzat506_CalcularVariacion(promedioActual, promedioAnterior);
            string deA = " (de " + jzat506_Moneda(promedioAnterior) + " a " + jzat506_Moneda(promedioActual) + ")";

            if (variacionPromedio <= -10)
                analisis.jzat506_Conclusiones.Add("La venta promedio bajó un " + jzat506_Porcentaje(variacionPromedio) + deA
                    + ". Conviene ofrecer productos complementarios en cada venta.");
            else if (variacionPromedio >= 10)
                analisis.jzat506_Conclusiones.Add("La venta promedio subió un " + jzat506_Porcentaje(variacionPromedio) + deA
                    + ": los clientes llevan más productos, o más caros, en cada compra.");
        }

        private void jzat506_ConcluirCategorias(jzat506_AnalisisVentas analisis, List<jzat506_ItemAnalisis> actual, List<jzat506_ItemAnalisis> anterior)
        {
            if (actual.Count == 0)
                return;

            decimal totalCategorias = 0;
            foreach (jzat506_ItemAnalisis item in actual)
                totalCategorias += item.jzat506_Valor;

            jzat506_ItemAnalisis primera = actual[0];
            decimal participacion = primera.jzat506_Valor / totalCategorias * 100;
            analisis.jzat506_Conclusiones.Add("La categoría que más vendió fue " + primera.jzat506_Nombre + ", con " + jzat506_Moneda(primera.jzat506_Valor)
                + " (el " + jzat506_Porcentaje(participacion) + " de lo vendido).");

            string categoriaSube = "";
            decimal mayorSuba = 0;
            string categoriaBaja = "";
            decimal mayorBaja = 0;

            foreach (jzat506_ItemAnalisis previo in anterior)
            {
                decimal valorActual = 0;
                foreach (jzat506_ItemAnalisis item in actual)
                {
                    if (item.jzat506_Nombre == previo.jzat506_Nombre)
                        valorActual = item.jzat506_Valor;
                }

                decimal variacion = jzat506_CalcularVariacion(valorActual, previo.jzat506_Valor);

                if (variacion > mayorSuba)
                {
                    mayorSuba = variacion;
                    categoriaSube = previo.jzat506_Nombre;
                }

                if (variacion < mayorBaja)
                {
                    mayorBaja = variacion;
                    categoriaBaja = previo.jzat506_Nombre;
                }
            }

            if (anterior.Count > 0)
            {
                foreach (jzat506_ItemAnalisis item in actual)
                {
                    bool seVendiaAntes = false;
                    foreach (jzat506_ItemAnalisis previo in anterior)
                    {
                        if (previo.jzat506_Nombre == item.jzat506_Nombre)
                            seVendiaAntes = true;
                    }

                    if (!seVendiaAntes)
                        analisis.jzat506_Conclusiones.Add("La categoría " + item.jzat506_Nombre + " no tuvo ventas en el período anterior y en este vendió "
                            + jzat506_Moneda(item.jzat506_Valor) + ". Es una categoría en crecimiento que conviene destacar.");
                }
            }

            if (categoriaSube != "")
                analisis.jzat506_Conclusiones.Add("La categoría " + categoriaSube + " fue la que más creció respecto al período anterior (+"
                    + jzat506_Porcentaje(mayorSuba) + ").");

            if (categoriaBaja != "")
                analisis.jzat506_Conclusiones.Add("La categoría " + categoriaBaja + " fue la que más cayó (-" + jzat506_Porcentaje(mayorBaja)
                    + "). Conviene revisar sus precios o darle más visibilidad.");
        }

        private void jzat506_ConcluirProductosSinVenta(jzat506_AnalisisVentas analisis, List<string> productos)
        {
            if (productos.Count == 0)
            {
                analisis.jzat506_Conclusiones.Add("Todos los productos se vendieron al menos una vez en el período.");
                return;
            }

            string nombres = "";
            for (int i = 0; i < productos.Count && i < 4; i++)
            {
                if (i > 0)
                    nombres += ", ";
                nombres += productos[i];
            }

            if (productos.Count > 4)
                nombres += " y " + (productos.Count - 4) + " más";

            if (productos.Count == 1)
                analisis.jzat506_Conclusiones.Add("El producto " + nombres + " no se vendió en el período. Conviene ponerlo en promoción.");
            else
                analisis.jzat506_Conclusiones.Add(productos.Count + " productos no se vendieron en el período (" + nombres + "). Conviene ponerlos en promoción.");
        }

        private void jzat506_ConcluirProductosJuntos(jzat506_AnalisisVentas analisis, List<jzat506_ItemAnalisis> pares)
        {
            if (pares.Count == 0)
            {
                analisis.jzat506_Conclusiones.Add("No hay productos que se compren juntos con frecuencia en el período.");
                return;
            }

            foreach (jzat506_ItemAnalisis par in pares)
                analisis.jzat506_Conclusiones.Add("«" + par.jzat506_Nombre + "» y «" + par.jzat506_Nombre2 + "» se compraron juntos en "
                    + par.jzat506_Cantidad + " ventas. Conviene armar un combo con los dos.");
        }

        private void jzat506_ConcluirZonas(jzat506_AnalisisVentas analisis, List<jzat506_ItemAnalisis> zonas)
        {
            if (zonas.Count == 0)
            {
                analisis.jzat506_Conclusiones.Add("No hubo envíos en el período.");
                return;
            }

            int total = 0;
            foreach (jzat506_ItemAnalisis zona in zonas)
                total += zona.jzat506_Cantidad;

            jzat506_ItemAnalisis primera = zonas[0];
            decimal porcentaje = (decimal)primera.jzat506_Cantidad / total * 100;

            if (zonas.Count == 1)
                analisis.jzat506_Conclusiones.Add("Todos los envíos del período fueron a " + primera.jzat506_Nombre
                    + ". Conviene tener un transportista disponible para esa zona.");
            else if (porcentaje >= 40)
                analisis.jzat506_Conclusiones.Add("El " + jzat506_Porcentaje(porcentaje) + " de los envíos fue a " + primera.jzat506_Nombre
                    + " (" + primera.jzat506_Cantidad + " de " + total + "). Conviene tener un transportista disponible para esa zona.");
            else
                analisis.jzat506_Conclusiones.Add("Los envíos están repartidos entre las zonas. La que más recibió fue " + primera.jzat506_Nombre
                    + " (" + primera.jzat506_Cantidad + " de " + total + ").");
        }

        private void jzat506_ConcluirTiempos(jzat506_AnalisisVentas analisis, List<jzat506_ItemAnalisis> tiempos)
        {
            if (tiempos.Count == 0)
            {
                analisis.jzat506_Conclusiones.Add("Todavía no hay pedidos entregados en el período para medir los tiempos de entrega.");
                return;
            }

            if (tiempos.Count == 1)
            {
                analisis.jzat506_Conclusiones.Add("Los pedidos a " + tiempos[0].jzat506_Nombre + " tardaron en promedio "
                    + jzat506_FormatearTiempo(tiempos[0].jzat506_Valor) + " en entregarse.");
                return;
            }

            jzat506_ItemAnalisis lenta = tiempos[0];
            decimal horasResto = 0;
            int pedidosResto = 0;
            for (int i = 1; i < tiempos.Count; i++)
            {
                horasResto += tiempos[i].jzat506_Valor * tiempos[i].jzat506_Cantidad;
                pedidosResto += tiempos[i].jzat506_Cantidad;
            }
            decimal promedioResto = horasResto / pedidosResto;

            if (promedioResto > 0 && lenta.jzat506_Valor >= promedioResto * 1.5m)
            {
                decimal veces = Math.Round(lenta.jzat506_Valor / promedioResto, 1);
                analisis.jzat506_Conclusiones.Add("Los envíos a " + lenta.jzat506_Nombre + " tardan en promedio " + jzat506_FormatearTiempo(lenta.jzat506_Valor)
                    + ", " + veces.ToString("0.#", jzat506_cultura) + " veces más que en el resto de las zonas (" + jzat506_FormatearTiempo(promedioResto)
                    + "). Conviene revisar la asignación de transportistas en esa zona.");
            }
            else
            {
                decimal promedioGeneral = (horasResto + lenta.jzat506_Valor * lenta.jzat506_Cantidad) / (pedidosResto + lenta.jzat506_Cantidad);
                analisis.jzat506_Conclusiones.Add("Los tiempos de entrega son parejos entre las zonas: un pedido tarda en promedio "
                    + jzat506_FormatearTiempo(promedioGeneral) + " en entregarse.");
            }
        }

        private void jzat506_AgregarIndicador(jzat506_AnalisisVentas analisis, string nombre, string textoActual, string textoAnterior, decimal actual, decimal anterior)
        {
            jzat506_IndicadorAnalisis indicador = new jzat506_IndicadorAnalisis();
            indicador.jzat506_Nombre = nombre;
            indicador.jzat506_ValorActual = textoActual;
            indicador.jzat506_ValorAnterior = textoAnterior;

            if (anterior == 0)
            {
                indicador.jzat506_Variacion = "Sin datos";
            }
            else
            {
                decimal variacion = jzat506_CalcularVariacion(actual, anterior);
                string signo = variacion > 0 ? "+" : "-";
                if (variacion == 0)
                    signo = "";
                indicador.jzat506_Variacion = signo + jzat506_Porcentaje(variacion);
            }

            analisis.jzat506_Indicadores.Add(indicador);
        }

        private decimal jzat506_CalcularVariacion(decimal actual, decimal anterior)
        {
            if (anterior == 0)
                return 0;

            return Math.Round((actual - anterior) / anterior * 100, 0);
        }

        private string jzat506_Porcentaje(decimal valor)
        {
            return Math.Abs(Math.Round(valor, 0)).ToString("N0", jzat506_cultura) + " %";
        }

        private string jzat506_Moneda(decimal valor)
        {
            return valor.ToString("C", jzat506_cultura);
        }

        private string jzat506_FormatearTiempo(decimal horas)
        {
            if (horas < 1)
            {
                decimal minutos = Math.Round(horas * 60, 0);
                if (minutos < 1)
                    return "menos de un minuto";
                if (minutos == 1)
                    return "1 minuto";
                return minutos.ToString("N0", jzat506_cultura) + " minutos";
            }

            if (horas < 24)
            {
                decimal horasRedondeadas = Math.Round(horas, 1);
                if (horasRedondeadas == 1)
                    return "1 hora";
                return horasRedondeadas.ToString("0.#", jzat506_cultura) + " horas";
            }

            decimal dias = Math.Round(horas / 24, 1);
            if (dias == 1)
                return "1 día";
            return dias.ToString("0.#", jzat506_cultura) + " días";
        }

        private void jzat506_RegistrarEventoReporte(string descripcion, int criticidad)
        {
            jzat506_bllEvento.RegistrarEvento(new Evento
            {
                Usuario = SessionManager.GetInstance().Usuario?.Username ?? "sistema",
                Modulo = "Ventas",
                Descripcion = descripcion,
                Fecha = DateTime.Now,
                Criticidad = criticidad
            });
        }
    }
}
