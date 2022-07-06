namespace Coffee.WebApi.Application.Commands.Handlers;

public class AddTodoCommandHandler : IRequestHandler<AddTodoCommand>
{
    private readonly ITodoRepository _todoRepository;
    private readonly IMediator _mediator;

    public AddTodoCommandHandler(ITodoRepository todoRepository, IMediator mediator)
    {
        _todoRepository = todoRepository;
        _mediator = mediator;
    }

    public async Task<Unit> Handle(AddTodoCommand request, CancellationToken cancellationToken)
    {
        var todoSameTitle = await _todoRepository.GetByTitleAsync(request.Title);
        if (todoSameTitle is not null) throw new DuplicateNameException("Todo already registered with this title");
        var todo = new Todo(request.Title, request.Description);
        await _todoRepository.AddAsync(todo);
        await _todoRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        _ = _mediator.Publish(new TodoAddedIntegrationEvent(todo.Title), cancellationToken);
        return await Unit.Task;
    }
}