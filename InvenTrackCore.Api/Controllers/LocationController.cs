using InvenTrackCore.Application.UseCases.Location.Commands.CreateCommand;
using InvenTrackCore.Application.UseCases.Location.Commands.DeleteCommand;
using InvenTrackCore.Application.UseCases.Location.Commands.UpdateCommand;
using InvenTrackCore.Application.UseCases.Location.Queries.GetAllQueries;
using InvenTrackCore.Application.UseCases.Location.Queries.GetByIdQueries;
using InvenTrackCore.Application.UseCases.Location.Queries.GetSelectQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InvenTrackCore.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LocationController : ControllerBase
{
    private readonly IMediator _mediator;

    public LocationController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> LocationList([FromQuery] GetAllLocationQuery query)
    {
        var response = await _mediator.Send(query);
        return Ok(response);
    }

    [HttpGet("Select")]
    public async Task<IActionResult> LocationSelect()
    {
        var response = await _mediator.Send(new GetSelectLocationQuery());
        return Ok(response);
    }

    [HttpGet("{locationId:int}")]
    public async Task<IActionResult> LocationById(int locationId)
    {
        var response = await _mediator.Send(new GetLocationByIdQuery() { LocationId = locationId });
        return Ok(response);
    }

    [HttpPost("Create")]
    public async Task<IActionResult> LocationCreate([FromBody] CreateLocationCommand command)
    {
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> LocationUpdate([FromBody] UpdateLocationCommand command)
    {
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpDelete("Delete/{locationId:int}")]
    public async Task<IActionResult> LocationDelete(int locationId)
    {
        var response = await _mediator.Send(new DeleteLocationCommand() { LocationId = locationId });
        return Ok(response);
    }
}