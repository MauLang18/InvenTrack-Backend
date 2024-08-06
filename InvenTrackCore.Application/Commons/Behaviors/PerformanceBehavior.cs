using MediatR;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Text.Json;
using WatchDog;

namespace InvenTrackCore.Application.Commons.Behaviors;

public class PerformanceBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly Stopwatch _stopwatch;
    private readonly ILogger<TRequest> _logger;

    public PerformanceBehavior(ILogger<TRequest> logger)
    {
        _stopwatch = new Stopwatch();
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        _stopwatch.Start();
        var response = await next();
        _stopwatch.Stop();

        var elapsedMilliseconds = _stopwatch.ElapsedMilliseconds;

        if (elapsedMilliseconds > 10)
        {
            var requestName = typeof(TRequest).Name;
            _logger
                .LogWarning("InvenTrackCore long running Request: {name}({elapsedMilliseconds} milliseconds) {@Request}",
                requestName, elapsedMilliseconds, JsonSerializer.Serialize(request));
            WatchLogger.LogWarning("InvenTrackCore long running Request: {name}({elapsedMilliseconds} milliseconds) {@Request}",
                requestName, elapsedMilliseconds.ToString(), JsonSerializer.Serialize(request));
        }

        return response;
    }
}
