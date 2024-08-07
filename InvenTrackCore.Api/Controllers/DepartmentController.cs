using InvenTrackCore.Application.UseCases.Department.Commands.CreateCommand;
using InvenTrackCore.Application.UseCases.Department.Commands.DeleteCommand;
using InvenTrackCore.Application.UseCases.Department.Commands.UpdateCommand;
using InvenTrackCore.Application.UseCases.Department.Queries.GetAllQuery;
using InvenTrackCore.Application.UseCases.Department.Queries.GetByIdQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InvenTrackCore.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DepartmentController : ControllerBase
{
    private readonly IMediator _mediator;

    public DepartmentController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> DeparmentList([FromQuery] GetAllDepartmentQuery query)
    {
        var response = await _mediator.Send(query);
        return Ok(response);
    }

    [HttpGet("{departmentId:int}")]
    public async Task<IActionResult> DepartmentById(int departmentId)
    {
        var response = await _mediator.Send(new GetDepartmentByIdQuery() { DepartmentId = departmentId });
        return Ok(response);
    }

    [HttpPost("Create")]
    public async Task<IActionResult> DeparmentCreate([FromBody] CreateDepartmentCommand command)
    {
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> DepartmentUpdate([FromBody] UpdateDepartmentCommand command)
    {
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpDelete("Delete/{departmentId:int}")]
    public async Task<IActionResult> DepartmentDelete(int departmentId)
    {
        var response = await _mediator.Send(new DeleteDepartmentCommand() { DepartmentId = departmentId });
        return Ok(response);
    }
}