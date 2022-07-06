namespace Coffee.Domain.Core;

public abstract class Command : Validatable, IRequest
{
}

public abstract class Command<TResponse> : Validatable, IRequest<TResponse>
{
}