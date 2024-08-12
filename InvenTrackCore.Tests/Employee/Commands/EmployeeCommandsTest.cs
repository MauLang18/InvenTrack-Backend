using InvenTrackCore.Application.Commons.Bases;
using InvenTrackCore.Application.Commons.Exceptions;
using InvenTrackCore.Application.UseCases.Employee.Commands.CreateCommand;
using InvenTrackCore.Application.UseCases.Employee.Commands.UpdateCommand;
using MediatR;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace InvenTrackCore.Tests.Employee.Commands;

[TestClass]
public class EmployeeCommandsTest
{
    private static WebApplicationFactory<Program> _factory = null!;
    private static IServiceScopeFactory _scopeFactory = null!;

    [ClassInitialize]
    public static void ClassInitialize(TestContext _)
    {
        _factory = new CustomWebApplicationFactory();
        _scopeFactory = _factory.Services.GetRequiredService<IServiceScopeFactory>();
    }

    [TestMethod]
    public async Task ShouldGetValidationErrors()
    {
        using var scope = _scopeFactory.CreateScope();
        var mediator = scope.ServiceProvider.GetRequiredService<ISender>();

        var command = new CreateEmployeeCommand()
        {
            Name = "",
            LastName = "",
            DepartmentId = 1,
            LocationId = 1,
            Email = "",
            Phone = "",
            State = 1
        };

        var expected = false;
        BaseResponse<bool> response = new();

        try
        {
            response = await mediator.Send(command);
            Assert.Fail(response.Message);
        }
        catch (ValidationException ex)
        {
            Assert.IsNotNull(ex.Errors);
            Assert.AreEqual(expected, response.IsSuccess);
        }
    }

    [TestMethod]
    public async Task ShouldCreateEmployee()
    {
        using var scope = _scopeFactory.CreateScope();
        var mediator = scope.ServiceProvider.GetRequiredService<ISender>();

        var command = new CreateEmployeeCommand()
        {
            Name = "Maurice",
            LastName = "Lang",
            DepartmentId = 1,
            LocationId = 1,
            Email = "mlang@grupostedi.com",
            Phone = "4080-7888 Ext.111",
            State = 1
        };

        var expected = true;

        var response = await mediator.Send(command);

        Assert.AreEqual(expected, response.IsSuccess);
    }

    [TestMethod]
    public async Task ShouldUpdateEmployee()
    {
        using var scope = _scopeFactory.CreateScope();
        var mediator = scope.ServiceProvider.GetRequiredService<ISender>();

        var command = new UpdateEmployeeCommand()
        {
            EmployeeId = 2,
            Name = "Maurice",
            LastName = "Lang",
            DepartmentId = 1,
            LocationId = 1,
            Email = "mlang@grupostedi.com",
            Phone = "4080-7272 Ext.101",
            State = 1
        };

        var expected = true;

        var response = await mediator.Send(command);

        Assert.AreEqual(expected, response.IsSuccess);
    }
}