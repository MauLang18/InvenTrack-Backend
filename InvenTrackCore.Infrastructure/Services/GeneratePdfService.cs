using InvenTrackCore.Application.Dtos.Ticket.Response;
using InvenTrackCore.Application.Interfaces.Services;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace InvenTrackCore.Infrastructure.Services
{
    public class GeneratePdfService : IGeneratePdfService
    {
        public byte[] GeneratePdf(TicketByIdResponseDto ticket)
        {
            using var stream = new MemoryStream();
            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(30);
                    page.Size(PageSizes.A4);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(11));

                    page.Header()
                        .AlignCenter()
                        .Text("Boleta de Entrega de Equipos")
                        .SemiBold()
                        .FontSize(18)
                        .FontColor(Colors.Blue.Darken2);

                    page.Content().PaddingVertical(30).Column(column =>
                    {
                        column.Item().PaddingBottom(10).Row(row =>
                        {
                            row.RelativeItem().Column(col =>
                            {
                                col.Item().Text("Ticket ID:").Bold().FontSize(14);
                                col.Item().Text(ticket!.TicketId.ToString()).FontSize(14);
                            });

                            row.RelativeItem().Column(col =>
                            {
                                col.Item().Text("Fecha:").Bold().FontSize(14);
                                col.Item().Text(DateTime.Now.ToString("dd/MM/yyyy")).FontSize(14);
                            });
                        });

                        column.Item().PaddingTop(20).AlignCenter().Text("Datos Generales")
                            .Bold().FontSize(16).FontColor(Colors.Black);

                        column.Item().PaddingVertical(10).Row(row =>
                        {
                            row.RelativeItem().Column(col =>
                            {
                                col.Item().Text("Asignado a:").Bold();
                                col.Item().Text(ticket!.AssignedTo ?? "-");
                            });

                            row.RelativeItem().Column(col =>
                            {
                                col.Item().Text("Recibido por:").Bold();
                                col.Item().Text(ticket!.ReceivedBy ?? "-");
                            });

                            row.RelativeItem().Column(col =>
                            {
                                col.Item().Text("Entregado por:").Bold();
                                col.Item().Text(ticket!.DeliveredBy);
                            });
                        });

                        column.Item().PaddingBottom(10).Row(row =>
                        {
                            row.RelativeItem().Column(col =>
                            {
                                col.Item().Text("Departamento:").Bold();
                                col.Item().Text(ticket!.Department);
                            });
                        });

                        column.Item().PaddingBottom(10).Row(row =>
                        {
                            row.RelativeItem().Column(col =>
                            {
                                col.Item().Text("Ubicación:").Bold();
                                col.Item().Text(ticket!.Location);
                            });
                        });

                        column.Item().Text("Descripción de equipos:").Bold();
                        column.Item().Text(ticket!.Details ?? "N/A");

                        if (ticket.TicketDetails != null && ticket.TicketDetails.Count > 0)
                        {
                            column.Item().PaddingVertical(15).Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.ConstantColumn(50);
                                    columns.RelativeColumn(2);
                                    columns.RelativeColumn(2);
                                    columns.RelativeColumn(2);
                                    columns.RelativeColumn(2);
                                    columns.RelativeColumn(2);
                                });

                                table.Header(header =>
                                {
                                    header.Cell().Element(CellStyle).Text("ID");
                                    header.Cell().Element(CellStyle).Text("Código");
                                    header.Cell().Element(CellStyle).Text("Tipo de Equipo");
                                    header.Cell().Element(CellStyle).Text("Marca");
                                    header.Cell().Element(CellStyle).Text("Serie");
                                    header.Cell().Element(CellStyle).Text("Modelo");

                                    static IContainer CellStyle(IContainer container) => container.DefaultTextStyle(x => x.SemiBold()).BorderBottom(1).PaddingVertical(5);
                                });

                                foreach (var detail in ticket.TicketDetails)
                                {
                                    table.Cell().Element(CellStyle).Text(detail.InventoryId.ToString());
                                    table.Cell().Element(CellStyle).Text(detail.Code);
                                    table.Cell().Element(CellStyle).Text(detail.EquipmentType);
                                    table.Cell().Element(CellStyle).Text(detail.Brand);
                                    table.Cell().Element(CellStyle).Text(detail.Series);
                                    table.Cell().Element(CellStyle).Text(detail.Model);
                                }

                                static IContainer CellStyle(IContainer container) => container.BorderBottom(1).PaddingVertical(5);
                            });
                        }

                        column.Item().PaddingTop(20).Row(row =>
                        {
                            row.RelativeItem().Column(col =>
                            {
                                col.Item().Text("_________________________");
                                col.Item().AlignCenter().Text("Firma del Asignado");
                            });

                            row.RelativeItem().Column(col =>
                            {
                                col.Item().Text("_________________________");
                                col.Item().AlignCenter().Text("Firma del Recibido");
                            });

                            row.RelativeItem().Column(col =>
                            {
                                col.Item().Text("_________________________");
                                col.Item().AlignCenter().Text("Firma del Entregado");
                            });
                        });
                    });

                    page.Footer()
                        .AlignCenter()
                        .Text(x =>
                        {
                            x.Span("Fecha de emisión: ");
                            x.Span(DateTime.Now.ToString("dd/MM/yyyy")).SemiBold();
                        });
                });
            });

            document.GeneratePdf(stream);

            return stream.ToArray();
        }
    }
}