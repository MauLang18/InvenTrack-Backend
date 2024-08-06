namespace InvenTrackCore.Api.Middleware;

public static class HealthCheckExtension
{
    public static IServiceCollection AddHealthCheck(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHealthChecks()
            .AddNpgSql(
            configuration.GetConnectionString("Connection")!,
            tags: new[] { "database" });

        services.AddHealthChecksUI()
            .AddInMemoryStorage();

        return services;
    }
}