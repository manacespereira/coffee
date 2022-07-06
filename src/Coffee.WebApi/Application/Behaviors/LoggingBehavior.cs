namespace Coffee.WebApi.Application.Behaviors;

public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;

    public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken,
        RequestHandlerDelegate<TResponse> next)
    {
        var requestName = typeof(TRequest).Name;
        var startTime = DateTime.Now;

        _logger.LogInformation("----- Handling request {Name} ({@Request})", requestName, request);

        var response = await next();

        var endTime = DateTime.Now;
        var duration = endTime - startTime;

        _logger.LogInformation("----- Request {Name} handled ({Duration:g} ms)", requestName, duration);

        return response;
    }
}