using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Orders.Dtos;
using ArarasHealthHub.Application.Interfaces.Services;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace ArarasHealthHub.Infrastructure.Services
{
    public class PdfService : IPdfService
    {
        public async Task<byte[]> GeneratePickingListAsync(OrderDto order)
        {
            var primaryColor = "#2e6e3a";

            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4.Landscape());
                    page.Margin(1, Unit.Centimetre);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(9).FontFamily(Fonts.Verdana));

                    // --- CABEÇALHO ---
                    page.Header().Row(row =>
                    {
                        row.RelativeItem().Column(col =>
                        {
                            col.Item().Text($"Lista de Separação - Pedido #{order.Id}")
                                .FontSize(16).SemiBold().FontColor(primaryColor);

                            col.Item().Text($"Data de Solicitação: {order.CreatedAt:dd/MM/yyyy HH:mm}");
                            col.Item().Text($"Unidade: {order.OrderFacility!.Name}");
                        });

                        row.ConstantItem(100).AlignRight().Column(col =>
                        {
                            col.Item().Height(50).Placeholder();
                        });
                    });

                    // --- CONTEÚDO ---
                    page.Content().PaddingVertical(10).Column(column =>
                    {
                        column.Item().Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.ConstantColumn(25);  // #
                                columns.RelativeColumn(3);   // PRODUTO
                                columns.RelativeColumn(2);   // MARCA
                                columns.RelativeColumn(1);   // QTD SOLICITADA
                                columns.RelativeColumn(1);   // QTD APROVADA
                                columns.RelativeColumn(2);   // LOTE / VALIDADE
                                columns.RelativeColumn(1.5f);// QTD LOTE DISP.
                                columns.ConstantColumn(40);  // CHECK (V)
                            });

                            table.Header(header =>
                            {
                                header.Cell().Element(CellStyle).Text("#");
                                header.Cell().Element(CellStyle).Text("PRODUTO");
                                header.Cell().Element(CellStyle).Text("MARCA");
                                header.Cell().Element(CellStyle).AlignCenter().Text("SOLICITADA");
                                header.Cell().Element(CellStyle).AlignCenter().Text("APROVADA");
                                header.Cell().Element(CellStyle).Text("LOTE - VALIDADE");
                                header.Cell().Element(CellStyle).AlignCenter().Text("DISP. LOTE");
                                header.Cell().Element(CellStyle).AlignCenter().Text("CONF.");

                                IContainer CellStyle(IContainer container)
                                {
                                    return container.DefaultTextStyle(x => x.SemiBold().FontSize(8))
                                                    .PaddingVertical(5)
                                                    .BorderBottom(0.5f)
                                                    .BorderColor(primaryColor);
                                }
                            });

                            int itemIndex = 1;
                            foreach (var item in order.OrderItems)
                            {
                                foreach (var lot in item.LotsToSeparate!)
                                {
                                    table.Cell().Element(RowStyle).Text($"{itemIndex++}");
                                    table.Cell().Element(RowStyle).Text(item.ProductName);
                                    table.Cell().Element(RowStyle).Text(item.ProductName);
                                    table.Cell().Element(RowStyle).AlignCenter().Text($"{item.RequestedQuantity}");
                                    table.Cell().Element(RowStyle).AlignCenter().Text($"{item.ApprovedQuantity}");
                                    table.Cell().Element(RowStyle).Text($"{lot.Batch} - {lot.ExpiryDate:dd/MM/yyyy}");
                                    table.Cell().Element(RowStyle).AlignCenter().Text($"{lot.QuantityToSeparate}");
                                    table.Cell().Element(RowStyle).AlignCenter().PaddingVertical(2).Height(15).Width(15).Border(0.5f).BorderColor(Colors.Grey.Medium);

                                    IContainer RowStyle(IContainer container)
                                    {
                                        return container.BorderBottom(0.5f)
                                                        .BorderColor(Colors.Grey.Lighten2)
                                                        .PaddingVertical(4)
                                                        .AlignMiddle();
                                    }
                                }
                            }
                        });
                    });

                    // --- RODAPÉ ---
                    page.Footer().Column(footerCol =>
                    {
                        footerCol.Item().PaddingBottom(10).Row(row =>
                        {
                            row.RelativeItem();
                            row.ConstantItem(200).Column(c =>
                            {
                                c.Item().PaddingBottom(5).AlignCenter().Text("_________________________________");
                                c.Item().AlignCenter().Text("Responsável").FontSize(9);
                            });
                        });

                        footerCol.Item().LineHorizontal(0.5f).LineColor(Colors.Grey.Darken1);
                        footerCol.Item().Row(row =>
                        {
                            var now = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                            row.RelativeItem().Text($"Araras Health Hub - Impresso em: {now}").FontSize(8).Italic().FontColor(Colors.Grey.Darken2);

                            row.RelativeItem().AlignRight().Text(x =>
                            {
                                x.Span("Página ").FontSize(8);
                                x.CurrentPageNumber().FontSize(8);
                                x.Span(" de ").FontSize(8);
                                x.TotalPages().FontSize(8);
                            });
                        });
                    });
                });
            });

            return document.GeneratePdf();
        }
    }
}
