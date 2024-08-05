using InvenTrackCore.Application.Interfaces.Persistence;
using InvenTrackCore.Application.Interfaces.Services;
using InvenTrackCore.Infrastructure.Persistence.Context;
using InvenTrackCore.Infrastructure.Persistence.Repositories;
using InvenTrackCore.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InvenTrackCore.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
        {
            var assembly = typeof(ApplicationDbContext).Assembly.FullName;

            services.AddDbContext<ApplicationDbContext>(
                options => options.UseNpgsql(configuration.GetConnectionString("Connection"),
                b => b.MigrationsAssembly(assembly)));

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<ITicketDetailRepository, TicketDetailRepository>();
            services.AddScoped<IUsersRepository, UsersRepository>();

            services.AddTransient<IOrderingQuery, OrderingQuery>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}