namespace InvenTrackCore.Api.Middleware;

public static class HealthCheckExtension
{
    private static readonly string[] DatabaseTags = { "database" };

    public static IServiceCollection AddHealthCheck(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHealthChecks()
            .AddNpgSql(
                configuration.GetConnectionString("Connection")!,
                tags: DatabaseTags);

        services.AddHealthChecksUI()
            .AddInMemoryStorage();

        return services;
    }
}
