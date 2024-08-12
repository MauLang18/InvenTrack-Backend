using InvenTrackCore.Application.UseCases.Users.Commands.CreateCommand;
using InvenTrackCore.Application.UseCases.Users.Queries.GetAllQuery;
using InvenTrackCore.Application.UseCases.Users.Queries.GetByIdQuery;
using InvenTrackCore.Application.UseCases.Users.Queries.LoginQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InvenTrackCore.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> UserList([FromQuery] GetAllUserQuery query)
    {
        var response = await _mediator.Send(query);
        return Ok(response);
    }

    [HttpGet("{userId:int}")]
    public async Task<IActionResult> UserById(int userId)
    {
        var response = await _mediator.Send(new GetUserByIdQuery() { UserId = userId });
        return Ok(response);
    }

    [HttpPost("Create")]
    public async Task<IActionResult> UserCreate([FromBody] CreateUserCommand command)
    {
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody] LoginQuery query)
    {
        var response = await _mediator.Send(query);
        return Ok(response);
    }
}