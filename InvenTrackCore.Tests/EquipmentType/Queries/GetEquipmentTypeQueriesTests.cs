using InvenTrackCore.Application.Dtos.EquipmentType.Response;
using InvenTrackCore.Application.UseCases.EquipmentType.Queries.GetAllQuery;
using InvenTrackCore.Application.UseCases.EquipmentType.Queries.GetByIdQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace InvenTrackCore.Tests.EquipmentType.Queries;

[TestClass]
public class GetEquipmentTypeQueriesTest
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
    public async Task ShouldGetAllEquipmentType()
    {
        using var scope = _scopeFactory.CreateScope();
        var mediator = scope.ServiceProvider.GetRequiredService<ISender>();

        var query = new GetAllEquipmentTypeQuery
        {

        };

        var response = await mediator.Send(query);

        Assert.IsNotNull(response);
        Assert.IsTrue(response.IsSuccess);
        Assert.IsInstanceOfType(response.Data, typeof(IEnumerable<EquipmentTypeResponseDto>));
        Assert.IsTrue(response.Data.Any());
    }

    [TestMethod]
    public async Task ShouldGetEquipmentTypeById()
    {
        using var scope = _scopeFactory.CreateScope();
        var mediator = scope.ServiceProvider.GetRequiredService<ISender>();

        var query = new GetEquipmentTypeByIdQuery
        {
            EquipmentTypeId = 1
        };

        var response = await mediator.Send(query);

        Assert.IsNotNull(response);
        Assert.IsTrue(response.IsSuccess);
    }
}