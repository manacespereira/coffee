using Coffee.Domain.AggregatesModel.TodoAggregates;

namespace Coffee.Domain.Events;

public class TodoIncompleteDomainEvent : INotification
{
    public Todo Todo { get; }

    public TodoIncompleteDomainEvent(Todo todo)
    {
        Todo = todo;
    }
}