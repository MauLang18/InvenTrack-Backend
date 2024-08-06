using HealthChecks.UI.Client;
using InvenTrackCore.Api.Middleware;
using InvenTrackCore.Application;
using InvenTrackCore.Infrastructure;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using WatchDog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddHealthCheck(builder.Configuration);
builder.Services.AddAuthentication(builder.Configuration);
builder.Services.AddSwagger();

builder.Services.AddHttpContextAccessor();

builder.Services.AddCors(options =>
{
    options.AddPolicy("Cors", builder =>
        builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader()
    );
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseWatchDogExceptionLogger();

app.UseStaticFiles();

app.UseAuthentication();

app.UseAuthorization();

app.AddMiddlewareValidation();

app.UseCors();

app.MapControllers();

app.MapHealthChecksUI();
app.MapHealthChecks("/health", new HealthCheckOptions
{
    Predicate = _ => true,
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.UseWatchDog(configuration =>
{
    configuration.WatchPageUsername = "admin";
    configuration.WatchPagePassword = "S0port3.";
});

app.Run();

public partial class Program { }