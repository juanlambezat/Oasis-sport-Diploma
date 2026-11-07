using System.Globalization;
using ClosedXML.Excel;
using Entidades;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace Servicios
{
    public class jzat506_ServicioExportacion
    {
        private static readonly CultureInfo jzat506_cultura = new CultureInfo("es-AR");

        public jzat506_ServicioExportacion()
        {
            QuestPDF.Settings.License = LicenseType.Community;
        }

        public void jzat506_ExportarFacturaPDF(jzat506_Factura factura, string ruta)
        {
            Document.Create(documento =>
            {
                documento.Page(pagina =>
                {
                    pagina.Size(PageSizes.A4);
                    pagina.Margin(40);
                    pagina.DefaultTextStyle(estilo => estilo.FontSize(11));

                    pagina.Header().Column(columna =>
                    {
                        columna.Item().Text("Oasis Sports").FontSize(22).Bold().FontColor(Colors.Green.Darken3);
                        columna.Item().Text($"Factura N° {factura.jzat506_Id}").FontSize(14).SemiBold();
                        columna.Item().PaddingBottom(10).LineHorizontal(1).LineColor(Colors.Grey.Medium);
                    });

                    pagina.Content().Column(columna =>
                    {
                        columna.Spacing(4);
                        columna.Item().Text(texto =>
                        {
                            texto.Span("Cliente: ").SemiBold();
                            texto.Span($"{factura.jzat506_Cliente.jzat506_Nombre} {factura.jzat506_Cliente.jzat506_Apellido}");
                        });
                        columna.Item().Text(texto =>
                        {
                            texto.Span("DNI: ").SemiBold();
                            texto.Span(factura.jzat506_Cliente.jzat506_DNI.ToString());
                        });
                        columna.Item().Text(texto =>
                        {
                            texto.Span("Fecha: ").SemiBold();
                            texto.Span(factura.jzat506_Fecha.ToString("dd/MM/yyyy HH:mm", jzat506_cultura));
                        });
                        columna.Item().Text(texto =>
                        {
                            texto.Span("Medio de pago: ").SemiBold();
                            texto.Span(factura.jzat506_MedioPago);
                        });

                        columna.Item().PaddingTop(14).Table(tabla =>
                        {
                            tabla.ColumnsDefinition(columnas =>
                            {
                                columnas.RelativeColumn(5);
                                columnas.RelativeColumn(1.5f);
                                columnas.RelativeColumn(2.5f);
                                columnas.RelativeColumn(2.5f);
                            });

                            tabla.Header(encabezado =>
                            {
                                encabezado.Cell().Element(jzat506_CeldaEncabezado).Text("Producto");
                                encabezado.Cell().Element(jzat506_CeldaEncabezado).AlignRight().Text("Cantidad");
                                encabezado.Cell().Element(jzat506_CeldaEncabezado).AlignRight().Text("Precio unitario");
                                encabezado.Cell().Element(jzat506_CeldaEncabezado).AlignRight().Text("Subtotal");
                            });

                            foreach (jzat506_DetalleFactura detalle in factura.jzat506_Detalles)
                            {
                                tabla.Cell().Element(jzat506_CeldaCuerpo).Text($"{detalle.jzat506_Producto.jzat506_Codigo} - {detalle.jzat506_Producto.jzat506_Nombre}");
                                tabla.Cell().Element(jzat506_CeldaCuerpo).AlignRight().Text(detalle.jzat506_Cantidad.ToString());
                                tabla.Cell().Element(jzat506_CeldaCuerpo).AlignRight().Text(detalle.jzat506_PrecioUnitario.ToString("C", jzat506_cultura));
                                tabla.Cell().Element(jzat506_CeldaCuerpo).AlignRight().Text((detalle.jzat506_Cantidad * detalle.jzat506_PrecioUnitario).ToString("C", jzat506_cultura));
                            }
                        });

                        columna.Item().PaddingTop(10).AlignRight().Text($"Total: {factura.jzat506_Total.ToString("C", jzat506_cultura)}").FontSize(14).Bold();
                    });

                    pagina.Footer().Row(fila =>
                    {
                        fila.RelativeItem().Text("Documento interno de Oasis Sports, sin validez fiscal.").FontSize(9).FontColor(Colors.Grey.Darken1);
                        fila.AutoItem().Text(texto =>
                        {
                            texto.DefaultTextStyle(estilo => estilo.FontSize(9).FontColor(Colors.Grey.Darken1));
                            texto.Span("Página ");
                            texto.CurrentPageNumber();
                            texto.Span(" de ");
                            texto.TotalPages();
                        });
                    });
                });
            }).GeneratePdf(ruta);
        }

        public void jzat506_ExportarListadoExcel(jzat506_Cliente cliente, List<jzat506_Factura> facturas, string ruta)
        {
            using (XLWorkbook libro = new XLWorkbook())
            {
                IXLWorksheet hojaFacturas = libro.Worksheets.Add("Facturas");
                hojaFacturas.Cell(1, 1).Value = $"Facturas de {cliente.jzat506_Nombre} {cliente.jzat506_Apellido} (DNI {cliente.jzat506_DNI})";
                hojaFacturas.Cell(1, 1).Style.Font.Bold = true;
                hojaFacturas.Cell(1, 1).Style.Font.FontSize = 13;

                string[] titulosFacturas = { "N° factura", "Fecha", "Medio de pago", "Total" };
                for (int i = 0; i < titulosFacturas.Length; i++)
                    hojaFacturas.Cell(3, i + 1).Value = titulosFacturas[i];
                jzat506_EstiloEncabezado(hojaFacturas.Range(3, 1, 3, titulosFacturas.Length));

                int fila = 4;
                foreach (jzat506_Factura factura in facturas)
                {
                    hojaFacturas.Cell(fila, 1).Value = factura.jzat506_Id;
                    hojaFacturas.Cell(fila, 2).Value = factura.jzat506_Fecha;
                    hojaFacturas.Cell(fila, 2).Style.DateFormat.Format = "dd/mm/yyyy hh:mm";
                    hojaFacturas.Cell(fila, 3).Value = factura.jzat506_MedioPago;
                    hojaFacturas.Cell(fila, 4).Value = factura.jzat506_Total;
                    hojaFacturas.Cell(fila, 4).Style.NumberFormat.Format = "$ #,##0.00";
                    fila++;
                }

                hojaFacturas.Cell(fila + 1, 3).Value = "Total general";
                hojaFacturas.Cell(fila + 1, 3).Style.Font.Bold = true;
                hojaFacturas.Cell(fila + 1, 4).Value = facturas.Sum(f => f.jzat506_Total);
                hojaFacturas.Cell(fila + 1, 4).Style.Font.Bold = true;
                hojaFacturas.Cell(fila + 1, 4).Style.NumberFormat.Format = "$ #,##0.00";
                hojaFacturas.Columns().AdjustToContents();

                IXLWorksheet hojaDetalle = libro.Worksheets.Add("Detalle");
                string[] titulosDetalle = { "N° factura", "Código", "Producto", "Cantidad", "Precio unitario", "Subtotal" };
                for (int i = 0; i < titulosDetalle.Length; i++)
                    hojaDetalle.Cell(1, i + 1).Value = titulosDetalle[i];
                jzat506_EstiloEncabezado(hojaDetalle.Range(1, 1, 1, titulosDetalle.Length));

                int filaDetalle = 2;
                foreach (jzat506_Factura factura in facturas)
                {
                    foreach (jzat506_DetalleFactura detalle in factura.jzat506_Detalles)
                    {
                        hojaDetalle.Cell(filaDetalle, 1).Value = factura.jzat506_Id;
                        hojaDetalle.Cell(filaDetalle, 2).Value = detalle.jzat506_Producto.jzat506_Codigo;
                        hojaDetalle.Cell(filaDetalle, 3).Value = detalle.jzat506_Producto.jzat506_Nombre;
                        hojaDetalle.Cell(filaDetalle, 4).Value = detalle.jzat506_Cantidad;
                        hojaDetalle.Cell(filaDetalle, 5).Value = detalle.jzat506_PrecioUnitario;
                        hojaDetalle.Cell(filaDetalle, 5).Style.NumberFormat.Format = "$ #,##0.00";
                        hojaDetalle.Cell(filaDetalle, 6).Value = detalle.jzat506_Cantidad * detalle.jzat506_PrecioUnitario;
                        hojaDetalle.Cell(filaDetalle, 6).Style.NumberFormat.Format = "$ #,##0.00";
                        filaDetalle++;
                    }
                }
                hojaDetalle.Columns().AdjustToContents();

                libro.SaveAs(ruta);
            }
        }

        public void jzat506_ExportarReporteEnviosPDF(List<jzat506_Pedido> pedidos, string resumen, string ruta)
        {
            Document.Create(documento =>
            {
                documento.Page(pagina =>
                {
                    pagina.Size(PageSizes.A4.Landscape());
                    pagina.Margin(30);
                    pagina.DefaultTextStyle(estilo => estilo.FontSize(10));

                    pagina.Header().Column(columna =>
                    {
                        columna.Item().Text("Oasis Sports").FontSize(22).Bold().FontColor(Colors.Green.Darken3);
                        columna.Item().Text("Reporte de envios").FontSize(14).SemiBold();
                        columna.Item().PaddingBottom(8).LineHorizontal(1).LineColor(Colors.Grey.Medium);
                    });

                    pagina.Content().Column(columna =>
                    {
                        columna.Spacing(4);

                        columna.Item().Table(tabla =>
                        {
                            tabla.ColumnsDefinition(columnas =>
                            {
                                columnas.RelativeColumn(1);
                                columnas.RelativeColumn(2);
                                columnas.RelativeColumn(2.8f);
                                columnas.RelativeColumn(1.2f);
                                columnas.RelativeColumn(2.2f);
                                columnas.RelativeColumn(1.8f);
                                columnas.RelativeColumn(1.8f);
                                columnas.RelativeColumn(2);
                                columnas.RelativeColumn(2.6f);
                            });

                            tabla.Header(encabezado =>
                            {
                                encabezado.Cell().Element(jzat506_CeldaEncabezado).Text("Pedido");
                                encabezado.Cell().Element(jzat506_CeldaEncabezado).Text("Fecha");
                                encabezado.Cell().Element(jzat506_CeldaEncabezado).Text("Cliente");
                                encabezado.Cell().Element(jzat506_CeldaEncabezado).Text("Factura");
                                encabezado.Cell().Element(jzat506_CeldaEncabezado).Text("Zona");
                                encabezado.Cell().Element(jzat506_CeldaEncabezado).Text("Estado");
                                encabezado.Cell().Element(jzat506_CeldaEncabezado).AlignRight().Text("Costo");
                                encabezado.Cell().Element(jzat506_CeldaEncabezado).Text("Medio de pago");
                                encabezado.Cell().Element(jzat506_CeldaEncabezado).Text("Transportista");
                            });

                            foreach (jzat506_Pedido pedido in pedidos)
                            {
                                tabla.Cell().Element(jzat506_CeldaCuerpo).Text(pedido.jzat506_Id.ToString());
                                tabla.Cell().Element(jzat506_CeldaCuerpo).Text(pedido.jzat506_Fecha.ToString("dd/MM/yyyy", jzat506_cultura));
                                tabla.Cell().Element(jzat506_CeldaCuerpo).Text(pedido.jzat506_Factura.jzat506_Cliente.jzat506_Nombre + " " + pedido.jzat506_Factura.jzat506_Cliente.jzat506_Apellido);
                                tabla.Cell().Element(jzat506_CeldaCuerpo).Text(pedido.jzat506_Factura.jzat506_Id.ToString());
                                tabla.Cell().Element(jzat506_CeldaCuerpo).Text(pedido.jzat506_Envio.jzat506_Zona.jzat506_Localidad);
                                tabla.Cell().Element(jzat506_CeldaCuerpo).Text(pedido.jzat506_Estado);
                                tabla.Cell().Element(jzat506_CeldaCuerpo).AlignRight().Text(pedido.jzat506_Envio.jzat506_CostoEnvio.ToString("C", jzat506_cultura));
                                tabla.Cell().Element(jzat506_CeldaCuerpo).Text(pedido.jzat506_Envio.jzat506_MedioPago);
                                tabla.Cell().Element(jzat506_CeldaCuerpo).Text(pedido.jzat506_Envio.jzat506_Transportista != null ? pedido.jzat506_Envio.jzat506_Transportista.ToString() : "Sin asignar");
                            }
                        });

                        columna.Item().PaddingTop(12).Text("Resumen").FontSize(12).Bold();

                        string[] lineas = resumen.Split(Environment.NewLine);
                        foreach (string linea in lineas)
                            columna.Item().Text(linea);
                    });

                    pagina.Footer().Row(fila =>
                    {
                        fila.RelativeItem().Text("Documento interno de Oasis Sports.").FontSize(9).FontColor(Colors.Grey.Darken1);
                        fila.AutoItem().Text(texto =>
                        {
                            texto.DefaultTextStyle(estilo => estilo.FontSize(9).FontColor(Colors.Grey.Darken1));
                            texto.Span("Página ");
                            texto.CurrentPageNumber();
                            texto.Span(" de ");
                            texto.TotalPages();
                        });
                    });
                });
            }).GeneratePdf(ruta);
        }

        public void jzat506_ExportarReporteEnviosExcel(List<jzat506_Pedido> pedidos, string resumen, string ruta)
        {
            using (XLWorkbook libro = new XLWorkbook())
            {
                IXLWorksheet hoja = libro.Worksheets.Add("Envios");
                hoja.Cell(1, 1).Value = "Reporte de envios";
                hoja.Cell(1, 1).Style.Font.Bold = true;
                hoja.Cell(1, 1).Style.Font.FontSize = 13;

                string[] titulos = { "Pedido", "Fecha", "Cliente", "Factura", "Zona", "Estado", "Costo", "Medio de pago", "Transportista" };
                for (int i = 0; i < titulos.Length; i++)
                    hoja.Cell(3, i + 1).Value = titulos[i];
                jzat506_EstiloEncabezado(hoja.Range(3, 1, 3, titulos.Length));

                int fila = 4;
                foreach (jzat506_Pedido pedido in pedidos)
                {
                    hoja.Cell(fila, 1).Value = pedido.jzat506_Id;
                    hoja.Cell(fila, 2).Value = pedido.jzat506_Fecha;
                    hoja.Cell(fila, 2).Style.DateFormat.Format = "dd/mm/yyyy";
                    hoja.Cell(fila, 3).Value = pedido.jzat506_Factura.jzat506_Cliente.jzat506_Nombre + " " + pedido.jzat506_Factura.jzat506_Cliente.jzat506_Apellido;
                    hoja.Cell(fila, 4).Value = pedido.jzat506_Factura.jzat506_Id;
                    hoja.Cell(fila, 5).Value = pedido.jzat506_Envio.jzat506_Zona.jzat506_Localidad;
                    hoja.Cell(fila, 6).Value = pedido.jzat506_Estado;
                    hoja.Cell(fila, 7).Value = pedido.jzat506_Envio.jzat506_CostoEnvio;
                    hoja.Cell(fila, 7).Style.NumberFormat.Format = "$ #,##0.00";
                    hoja.Cell(fila, 8).Value = pedido.jzat506_Envio.jzat506_MedioPago;
                    hoja.Cell(fila, 9).Value = pedido.jzat506_Envio.jzat506_Transportista != null ? pedido.jzat506_Envio.jzat506_Transportista.ToString() : "Sin asignar";
                    fila++;
                }

                fila = fila + 1;
                hoja.Cell(fila, 1).Value = "Resumen";
                hoja.Cell(fila, 1).Style.Font.Bold = true;
                fila++;

                string[] lineas = resumen.Split(Environment.NewLine);
                foreach (string linea in lineas)
                {
                    hoja.Cell(fila, 1).Value = linea;
                    fila++;
                }

                hoja.Columns().AdjustToContents();
                hoja.Column(1).Width = 10;

                libro.SaveAs(ruta);
            }
        }

        private static IContainer jzat506_CeldaEncabezado(IContainer contenedor)
        {
            return contenedor.Background(Colors.Green.Lighten4).BorderBottom(1).BorderColor(Colors.Green.Darken3).Padding(5).DefaultTextStyle(estilo => estilo.SemiBold());
        }

        private static IContainer jzat506_CeldaCuerpo(IContainer contenedor)
        {
            return contenedor.BorderBottom(0.5f).BorderColor(Colors.Grey.Lighten1).Padding(5);
        }

        private static void jzat506_EstiloEncabezado(IXLRange rango)
        {
            rango.Style.Font.Bold = true;
            rango.Style.Fill.BackgroundColor = XLColor.FromHtml("#D5E8D4");
            rango.Style.Border.BottomBorder = XLBorderStyleValues.Thin;
        }
    }
}
