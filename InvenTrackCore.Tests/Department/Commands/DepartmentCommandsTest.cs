using InvenTrackCore.Application.Commons.Bases;
using InvenTrackCore.Application.Commons.Exceptions;
using InvenTrackCore.Application.UseCases.Department.Commands.CreateCommand;
using InvenTrackCore.Application.UseCases.Department.Commands.UpdateCommand;
using MediatR;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace InvenTrackCore.Tests.Department.Commands;

[TestClass]
public class DepartmentCommandsTest
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

        var command = new CreateDepartmentCommand()
        {
            Name = "",
            Company = "Ste",
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
    public async Task ShouldCreateDepartment()
    {
        using var scope = _scopeFactory.CreateScope();
        var mediator = scope.ServiceProvider.GetRequiredService<ISender>();

        var command = new CreateDepartmentCommand()
        {
            Name = "Mercadeo",
            Company = "Stedi",
            State = 1
        };

        var expected = true;

        var response = await mediator.Send(command);

        Assert.AreEqual(expected, response.IsSuccess);
    }

    [TestMethod]
    public async Task ShouldUpdateDepartment()
    {
        using var scope = _scopeFactory.CreateScope();
        var mediator = scope.ServiceProvider.GetRequiredService<ISender>();

        var command = new UpdateDepartmentCommand()
        {
            DepartmentId = 1,
            Name = "Ventas",
            Company = "Drainsa",
            State = 0
        };

        var expected = true;

        var response = await mediator.Send(command);

        Assert.AreEqual(expected, response.IsSuccess);
    }
}