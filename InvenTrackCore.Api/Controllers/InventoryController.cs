using InvenTrackCore.Application.Interfaces.Services;
using InvenTrackCore.Application.UseCases.Inventory.Commands.CreateCommand;
using InvenTrackCore.Application.UseCases.Inventory.Commands.DeleteCommand;
using InvenTrackCore.Application.UseCases.Inventory.Commands.UpdateCommand;
using InvenTrackCore.Application.UseCases.Inventory.Queries.GetAllQuery;
using InvenTrackCore.Application.UseCases.Inventory.Queries.GetByIdQuery;
using InvenTrackCore.Utilities.Static;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InvenTrackCore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IGenerateQRCodeService _generateQRCodeService;
        private readonly IGenerateExcelService _generateExcelService;

        public InventoryController(IMediator mediator, IGenerateQRCodeService generateQRCodeService, IGenerateExcelService generateExcelService)
        {
            _mediator = mediator;
            _generateQRCodeService = generateQRCodeService;
            _generateExcelService = generateExcelService;
        }

        [HttpGet]
        public async Task<IActionResult> InventoryList([FromQuery] GetAllInventoryQuery query)
        {
            var response = await _mediator.Send(query);

            if ((bool)query.Download!)
            {
                var columnNames = ExcelColumnNames.GetColumnsInventory();
                byte[] fileBytes = _generateExcelService.GenerateExcel(response.Data!, columnNames);
                return File(fileBytes, ContentType.ContentTypeExcel, "Inventory-Excel");
            }

            return Ok(response);
        }

        [HttpGet("{inventoryId:int}")]
        public async Task<IActionResult> InventoryById(int inventoryId)
        {
            var response = await _mediator.Send(new GetInventoryByIdQuery() { InventoryId = inventoryId });
            return Ok(response);
        }

        [HttpGet("QRCode/{inventoryId:int}")]
        public async Task<IActionResult> InventoryQRCode(int inventoryId)
        {
            var response = await _mediator.Send(new GetInventoryByIdQuery() { InventoryId = inventoryId });
            byte[] qrCodeImage = _generateQRCodeService.GenerateQRCode(response.Data);
            return File(qrCodeImage, ContentType.ContentTypeImage, $"Inventory-{inventoryId}-QRCode.png");
        }

        [HttpPost("Create")]
        public async Task<IActionResult> InventoryCreate([FromForm] CreateInventoryCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> InventoryUpdate([FromForm] UpdateInventoryCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("Delete/{inventoryId:int}")]
        public async Task<IActionResult> InventoryDelete(int inventoryId)
        {
            var response = await _mediator.Send(new DeleteInventoryCommand() { InventoryId = inventoryId });
            return Ok(response);
        }
    }
}