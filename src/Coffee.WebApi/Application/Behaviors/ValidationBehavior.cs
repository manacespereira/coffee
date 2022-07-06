using System.ComponentModel.DataAnnotations;

namespace Coffee.WebApi.Application.Behaviors;

public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : Validatable, IRequest<TResponse>
{
    public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken,
        RequestHandlerDelegate<TResponse> next)
    {
        request.Validate();

        if (request.IsValid) return next();

        throw new ValidationException(string.Join('\n', request.Notifications.Select(x => $"{x.Key}: {x.Message}")));
    }
}