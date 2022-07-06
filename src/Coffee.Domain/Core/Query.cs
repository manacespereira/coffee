namespace Coffee.Domain.Core;

public abstract class Query<TResponse> : Validatable, IRequest<TResponse>
{
}