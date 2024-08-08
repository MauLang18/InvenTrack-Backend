using InvenTrackCore.Application.UseCases.Inventory.Commands.CreateCommand;
using InvenTrackCore.Application.UseCases.Inventory.Commands.DeleteCommand;
using InvenTrackCore.Application.UseCases.Inventory.Commands.UpdateCommand;
using InvenTrackCore.Application.UseCases.Inventory.Queries.GetAllQuery;
using InvenTrackCore.Application.UseCases.Inventory.Queries.GetByIdQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InvenTrackCore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public InventoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> InventoryList([FromQuery] GetAllInventoryQuery query)
        {
            var response = await _mediator.Send(query);
            return Ok(response);
        }

        [HttpGet("{inventoryId:int}")]
        public async Task<IActionResult> InventoryById(int inventoryId)
        {
            var response = await _mediator.Send(new GetInventoryByIdQuery() { InventoryId = inventoryId });
            return Ok(response);
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