using InvenTrackCore.Application.Dtos.Department.Response;
using InvenTrackCore.Application.UseCases.Department.Queries.GetAllQuery;
using InvenTrackCore.Application.UseCases.Department.Queries.GetByIdQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace InvenTrackCore.Tests.Department.Queries;

[TestClass]
public class GetDepartmentQueriesTest
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
    public async Task ShouldGetAllDepartment()
    {
        using var scope = _scopeFactory.CreateScope();
        var mediator = scope.ServiceProvider.GetRequiredService<ISender>();

        var query = new GetAllDepartmentQuery
        {

        };

        var response = await mediator.Send(query);

        Assert.IsNotNull(response);
        Assert.IsTrue(response.IsSuccess);
        Assert.IsInstanceOfType(response.Data, typeof(IEnumerable<DepartmentResponseDto>));
        Assert.IsTrue(response.Data.Any());
    }

    [TestMethod]
    public async Task ShouldGetDepartmentById()
    {
        using var scope = _scopeFactory.CreateScope();
        var mediator = scope.ServiceProvider.GetRequiredService<ISender>();

        var query = new GetDepartmentByIdQuery
        {
            DepartmentId = 1
        };

        var response = await mediator.Send(query);

        Assert.IsNotNull(response);
        Assert.IsTrue(response.IsSuccess);
    }
}