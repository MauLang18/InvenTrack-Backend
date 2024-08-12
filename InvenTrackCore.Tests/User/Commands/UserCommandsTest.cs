using InvenTrackCore.Application.Commons.Bases;
using InvenTrackCore.Application.Commons.Exceptions;
using InvenTrackCore.Application.UseCases.Users.Commands.CreateCommand;
using InvenTrackCore.Application.UseCases.Users.Commands.UpdateCommand;
using MediatR;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace InvenTrackCore.Tests.User.Commands;

[TestClass]
public class UserCommandsTest
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

        var command = new CreateUserCommand()
        {
            Name = "",
            LastName = "",
            UserName = "",
            PassWord = "",
            Email = "",
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
    public async Task ShouldCreateUser()
    {
        using var scope = _scopeFactory.CreateScope();
        var mediator = scope.ServiceProvider.GetRequiredService<ISender>();

        var command = new CreateUserCommand()
        {
            Name = "Juan",
            LastName = "Calvo",
            UserName = "jcalvo",
            PassWord = "123",
            Email = "jjcalvo",
            State = 1
        };

        var expected = true;

        var response = await mediator.Send(command);

        Assert.AreEqual(expected, response.IsSuccess);
    }

    [TestMethod]
    public async Task ShouldUpdateUser()
    {
        using var scope = _scopeFactory.CreateScope();
        var mediator = scope.ServiceProvider.GetRequiredService<ISender>();

        var command = new UpdateUserCommand()
        {
            UserId = 1,
            Name = "Pedro",
            LastName = "Pascal",
            UserName = "ppascal",
            PassWord = "123",
            Email = "ppascal@tranquiexpress.com",
            State = 1
        };

        var expected = true;

        var response = await mediator.Send(command);

        Assert.AreEqual(expected, response.IsSuccess);
    }
}