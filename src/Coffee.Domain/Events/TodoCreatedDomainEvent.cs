using Coffee.Domain.AggregatesModel.TodoAggregates;

namespace Coffee.Domain.Events;

public class TodoCreatedDomainEvent : INotification
{
    public Todo Todo { get; }

    public TodoCreatedDomainEvent(Todo todo)
    {
        Todo = todo;
    }
}