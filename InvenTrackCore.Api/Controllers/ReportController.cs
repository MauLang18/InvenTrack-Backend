using InvenTrackCore.Application.Interfaces.Services;
using InvenTrackCore.Application.UseCases.Inventory.Queries.GetByIdQuery;
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

    public ReportController(IMediator mediator, IGenerateQRCodeService generateQRCodeService)
    {
        _mediator = mediator;
        _generateQRCodeService = generateQRCodeService;
    }

    [HttpGet("QRCode/{inventoryId:int}")]
    public async Task<IActionResult> InventoryQRCode(int inventoryId)
    {
        var response = await _mediator.Send(new GetInventoryByIdQuery() { InventoryId = inventoryId });
        byte[] qrCodeImage = _generateQRCodeService.GenerateQRCode(response.Data);
        return File(qrCodeImage, ContentType.ContentTypeImage, $"Inventory-{inventoryId}-QRCode.png");
    }
}