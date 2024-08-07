using InvenTrackCore.Application.Dtos.Employee.Response;
using InvenTrackCore.Application.UseCases.Employee.Queries.GetAllQuery;
using InvenTrackCore.Application.UseCases.Employee.Queries.GetByIdQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace InvenTrackCore.Tests.Employee.Queries;

[TestClass]
public class GetEmployeeQueriesTest
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
    public async Task ShouldGetAllEmployee()
    {
        using var scope = _scopeFactory.CreateScope();
        var mediator = scope.ServiceProvider.GetRequiredService<ISender>();

        var query = new GetAllEmployeeQuery
        {

        };

        var response = await mediator.Send(query);

        Assert.IsNotNull(response);
        Assert.IsTrue(response.IsSuccess);
        Assert.IsInstanceOfType(response.Data, typeof(IEnumerable<EmployeeResponseDto>));
        Assert.IsTrue(response.Data.Any());
    }

    [TestMethod]
    public async Task ShouldGetEmployeeById()
    {
        using var scope = _scopeFactory.CreateScope();
        var mediator = scope.ServiceProvider.GetRequiredService<ISender>();

        var query = new GetEmployeeByIdQuery
        {
            EmployeeId = 2
        };

        var response = await mediator.Send(query);

        Assert.IsNotNull(response);
        Assert.IsTrue(response.IsSuccess);
    }
}