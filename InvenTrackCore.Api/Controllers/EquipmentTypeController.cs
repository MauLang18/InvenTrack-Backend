using InvenTrackCore.Application.UseCases.EquipmentType.Commands.CreateCommand;
using InvenTrackCore.Application.UseCases.EquipmentType.Commands.DeleteCommand;
using InvenTrackCore.Application.UseCases.EquipmentType.Commands.UpdateCommand;
using InvenTrackCore.Application.UseCases.EquipmentType.Queries.GetAllQuery;
using InvenTrackCore.Application.UseCases.EquipmentType.Queries.GetByIdQuery;
using InvenTrackCore.Application.UseCases.EquipmentType.Queries.GetSelectQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InvenTrackCore.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EquipmentTypeController : ControllerBase
{
    private readonly IMediator _mediator;

    public EquipmentTypeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> EquipmentTypeList([FromQuery] GetAllEquipmentTypeQuery query)
    {
        var response = await _mediator.Send(query);
        return Ok(response);
    }

    [HttpGet("Select")]
    public async Task<IActionResult> EquipmentTypeSelect()
    {
        var response = await _mediator.Send(new GetSelectEquipmentTypeQuery());
        return Ok(response);
    }

    [HttpGet("{equipmentTypeId:int}")]
    public async Task<IActionResult> EquipmentTypeById(int equipmentTypeId)
    {
        var response = await _mediator.Send(new GetEquipmentTypeByIdQuery() { EquipmentTypeId = equipmentTypeId });
        return Ok(response);
    }

    [HttpPost("Create")]
    public async Task<IActionResult> EquipmentTypeCreate(CreateEquipmentTypeCommand command)
    {
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> EquipmentTypeUpdate(UpdateEquipmentTypeCommand command)
    {
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpDelete("Delete/{equipmentTypeId:int}")]
    public async Task<IActionResult> EquipmentTypeDelete(int equipmentTypeId)
    {
        var response = await _mediator.Send(new DeleteEquipmentTypeCommand() { EquipmentTypeId = equipmentTypeId });
        return Ok(response);
    }
}