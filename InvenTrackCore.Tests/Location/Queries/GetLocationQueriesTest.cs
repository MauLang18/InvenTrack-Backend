using InvenTrackCore.Application.Dtos.Location.Response;
using InvenTrackCore.Application.UseCases.Location.Queries.GetAllQueries;
using InvenTrackCore.Application.UseCases.Location.Queries.GetByIdQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace InvenTrackCore.Tests.Location.Queries;

[TestClass]
public class GetLocationQueriesTest
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
    public async Task ShouldGetAllLocation()
    {
        using var scope = _scopeFactory.CreateScope();
        var mediator = scope.ServiceProvider.GetRequiredService<ISender>();

        var query = new GetAllLocationQuery
        {

        };

        var response = await mediator.Send(query);

        Assert.IsNotNull(response);
        Assert.IsTrue(response.IsSuccess);
        Assert.IsInstanceOfType(response.Data, typeof(IEnumerable<LocationResponseDto>));
        Assert.IsTrue(response.Data.Any());
    }

    [TestMethod]
    public async Task ShouldGetLocationById()
    {
        using var scope = _scopeFactory.CreateScope();
        var mediator = scope.ServiceProvider.GetRequiredService<ISender>();

        var query = new GetLocationByIdQuery
        {
            LocationId = 1
        };

        var response = await mediator.Send(query);

        Assert.IsNotNull(response);
        Assert.IsTrue(response.IsSuccess);
    }
}