using Coffee.Domain.AggregatesModel.TodoAggregates;

namespace Coffee.Domain.Events;

public class TodoCompleteDomainEvent : INotification
{
    public Todo Todo { get; }

    public TodoCompleteDomainEvent(Todo todo)
    {
        Todo = todo;
    }
}