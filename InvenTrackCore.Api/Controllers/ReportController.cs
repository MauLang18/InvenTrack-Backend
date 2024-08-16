using InvenTrackCore.Application.Interfaces.Services;
using InvenTrackCore.Application.UseCases.Inventory.Queries.GetByIdQuery;
using InvenTrackCore.Application.UseCases.Ticket.Queries.GetByIdQuery;
using InvenTrackCore.Utilities.Static;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InvenTrackCore.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReportController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IGenerateQRCodeService _generateQRCodeService;
    private readonly IGeneratePdfService _generatePdfService;

    public ReportController(IMediator mediator, IGenerateQRCodeService generateQRCodeService, IGeneratePdfService generatePdfService)
    {
        _mediator = mediator;
        _generateQRCodeService = generateQRCodeService;
        _generatePdfService = generatePdfService;
    }

    [HttpGet("QRCode/{inventoryId:int}")]
    public async Task<IActionResult> InventoryQRCode(int inventoryId)
    {
        var response = await _mediator.Send(new GetInventoryByIdQuery() { InventoryId = inventoryId });
        byte[] qrCodeImage = _generateQRCodeService.GenerateQRCode(response.Data);
        return File(qrCodeImage, ContentType.ContentTypeImage, $"Inventory-{inventoryId}.png");
    }

    [HttpGet("Pdf/{ticketId:int}")]
    public async Task<IActionResult> TicketPdf(int ticketId)
    {
        var response = await _mediator.Send(new GetTicketByIdQuery() { TicketId = ticketId });
        byte[] file = _generatePdfService.GeneratePdf(response.Data!);
        return File(file, ContentType.ContentTypePdf, $"Ticket-{ticketId}.pdf");
    }
}