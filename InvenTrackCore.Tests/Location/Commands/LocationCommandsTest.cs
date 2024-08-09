using InvenTrackCore.Application.Commons.Bases;
using InvenTrackCore.Application.Commons.Exceptions;
using InvenTrackCore.Application.UseCases.Location.Commands.CreateCommand;
using InvenTrackCore.Application.UseCases.Location.Commands.UpdateCommand;
using MediatR;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace InvenTrackCore.Tests.Location.Commands;

[TestClass]
public class LocationCommandsTest
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

        var command = new CreateLocationCommand()
        {
            Name = "",
            Address = "",
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
    public async Task ShouldCreateLocation()
    {
        using var scope = _scopeFactory.CreateScope();
        var mediator = scope.ServiceProvider.GetRequiredService<ISender>();

        var command = new CreateLocationCommand()
        {
            Name = "Bodega 43",
            Address = "Parque Condal",
            State = 1
        };

        var expected = true;

        var response = await mediator.Send(command);

        Assert.AreEqual(expected, response.IsSuccess);
    }

    [TestMethod]
    public async Task ShouldUpdateLocation()
    {
        using var scope = _scopeFactory.CreateScope();
        var mediator = scope.ServiceProvider.GetRequiredService<ISender>();

        var command = new UpdateLocationCommand()
        {
            LocationId = 1,
            Name = "Bodega 64",
            Address = "Parque Condal Tibás",
            State = 1
        };

        var expected = true;

        var response = await mediator.Send(command);

        Assert.AreEqual(expected, response.IsSuccess);
    }
}