using Coffee.Domain.Events;

namespace Coffee.Domain.AggregatesModel.TodoAggregates;

public class Todo : Entity, IAggregateRoot
{
    public string Title { get; }
    public string Description { get; }
    public bool IsCompleted { get; private set; }

    public Todo(string title)
    {
        Title = title;
        AddTodoCreatedDomainEvent();
    }

    public Todo(string title, string description)
    {
        Title = title;
        Description = description;
        AddTodoCreatedDomainEvent();
    }

    private void AddTodoCreatedDomainEvent()
    {
        var todoCreatedDomainEvent = new TodoCreatedDomainEvent(this);
        AddDomainEvent(todoCreatedDomainEvent);
    }

    public void Complete()
    {
        IsCompleted = true;
        var todoCompletedDomainEvent = new TodoCompleteDomainEvent(this);
        AddDomainEvent(todoCompletedDomainEvent);
    }

    public void Incomplete()
    {
        IsCompleted = false;
        var todoIncompleteDomainEvent = new TodoIncompleteDomainEvent(this);
        AddDomainEvent(todoIncompleteDomainEvent);
    }
}