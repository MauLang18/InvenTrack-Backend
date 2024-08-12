using InvenTrackCore.Application.Dtos.Users.Response;
using InvenTrackCore.Application.UseCases.Users.Queries.GetAllQuery;
using InvenTrackCore.Application.UseCases.Users.Queries.GetByIdQuery;
using InvenTrackCore.Application.UseCases.Users.Queries.LoginQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace InvenTrackCore.Tests.User.Queries;

[TestClass]
public class GetUserQueriesTest
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
    public async Task ShouldGetAllUser()
    {
        using var scope = _scopeFactory.CreateScope();
        var mediator = scope.ServiceProvider.GetRequiredService<ISender>();

        var query = new GetAllUserQuery
        {

        };

        var response = await mediator.Send(query);

        Assert.IsNotNull(response);
        Assert.IsTrue(response.IsSuccess);
        Assert.IsInstanceOfType(response.Data, typeof(IEnumerable<UsersResponseDto>));
        Assert.IsTrue(response.Data.Any());
    }

    [TestMethod]
    public async Task ShouldGetUserById()
    {
        using var scope = _scopeFactory.CreateScope();
        var mediator = scope.ServiceProvider.GetRequiredService<ISender>();

        var query = new GetUserByIdQuery
        {
            UserId = 1
        };

        var response = await mediator.Send(query);

        Assert.IsNotNull(response);
        Assert.IsTrue(response.IsSuccess);
    }

    [TestMethod]
    public async Task ShouldLogin()
    {
        using var scope = _scopeFactory.CreateScope();
        var mediator = scope.ServiceProvider.GetRequiredService<ISender>();

        var query = new LoginQuery
        {
            UserName = "mlang",
            PassWord = "Ml@ng18Ti"
        };

        var response = await mediator.Send(query);

        Assert.IsNotNull(response);
        Assert.IsTrue(response.IsSuccess);
    }
}