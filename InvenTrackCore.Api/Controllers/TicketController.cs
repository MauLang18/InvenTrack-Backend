using InvenTrackCore.Application.UseCases.Ticket.Commands.CreateCommand;
using InvenTrackCore.Application.UseCases.Ticket.Commands.DeleteCommand;
using InvenTrackCore.Application.UseCases.Ticket.Queries.GetAllQuery;
using InvenTrackCore.Application.UseCases.Ticket.Queries.GetByIdQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InvenTrackCore.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TicketController : ControllerBase
{
    private readonly IMediator _mediator;

    public TicketController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> TicketList([FromQuery] GetAllTicketQuery query)
    {
        var response = await _mediator.Send(query);
        return Ok(response);
    }

    [HttpGet("{ticketId:int}")]
    public async Task<IActionResult> TicketById(int ticketId)
    {
        var response = await _mediator.Send(new GetTicketByIdQuery() { TicketId = ticketId });
        return Ok(response);
    }

    [HttpPost("Create")]
    public async Task<IActionResult> TicketCreate([FromBody] CreateTicketCommand command)
    {
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpDelete("Delete/{ticketId:int}")]
    public async Task<IActionResult> TicketDelete(int ticketId)
    {
        var response = await _mediator.Send(new DeleteTicketCommand() { TicketId = ticketId });
        return Ok(response);
    }
}