using InvenTrackCore.Application.UseCases.Employee.Commands.CreateCommand;
using InvenTrackCore.Application.UseCases.Employee.Commands.DeleteCommand;
using InvenTrackCore.Application.UseCases.Employee.Commands.UpdateCommand;
using InvenTrackCore.Application.UseCases.Employee.Queries.GetAllQuery;
using InvenTrackCore.Application.UseCases.Employee.Queries.GetByIdQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InvenTrackCore.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private readonly IMediator _mediator;

    public EmployeeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> EmployeeList([FromQuery] GetAllEmployeeQuery query)
    {
        var response = await _mediator.Send(query);
        return Ok(response);
    }

    [HttpGet("{employeeId:int}")]
    public async Task<IActionResult> EmployeeById(int employeeId)
    {
        var response = await _mediator.Send(new GetEmployeeByIdQuery() { EmployeeId = employeeId });
        return Ok(response);
    }

    [HttpPost("Create")]
    public async Task<IActionResult> EmployeeCreate([FromBody] CreateEmployeeCommand command)
    {
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> EmployeeUpdate([FromBody] UpdateEmployeeCommand command)
    {
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpDelete("Delete/{employeeId:int}")]
    public async Task<IActionResult> EmployeeDelete(int employeeId)
    {
        var response = await _mediator.Send(new DeleteEmployeeCommand() { EmployeeId = employeeId });
        return Ok(response);
    }
}