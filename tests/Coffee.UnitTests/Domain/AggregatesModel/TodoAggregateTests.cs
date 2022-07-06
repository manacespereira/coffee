using System.Linq;
using Coffee.Domain.AggregatesModel.TodoAggregates;
using Coffee.Domain.Events;

namespace Coffee.UnitTests.Domain.AggregatesModel;

public class TodoAggregateTests
{
    [Fact]
    public void Complete_WhenCalled_IsCompleteIsTrue()
    {
        const string title = "my todo title";
        var todo = new Todo(title);

        todo.Complete();

        todo.IsCompleted.Should().BeTrue();
    }

    [Fact]
    public void Incomplete_WhenCalled_IsCompleteIsFalse()
    {
        const string title = "my todo title";
        var todo = new Todo(title);

        todo.Incomplete();

        todo.IsCompleted.Should().BeFalse();
    }

    [Fact]
    public void CreateTodo_RaiseTodoCreatedDomainEvent()
    {
        const string title = "my todo title";

        var todo = new Todo(title);

        todo.DomainEvents.Should().HaveCount(1);
        todo.DomainEvents.First().Should().BeOfType<TodoCreatedDomainEvent>();
    }

    [Fact]
    public void Complete_WhenCalled_RaiseEvent()
    {
        const string title = "my todo title";
        var todo = new Todo(title);

        todo.Complete();

        todo.DomainEvents.Should().HaveCount(2);
        todo.DomainEvents.Last().Should().BeOfType<TodoCompleteDomainEvent>();
    }

    [Fact]
    public void Incomplete_WhenCalled_RaiseEvent()
    {
        const string title = "my todo title";
        var todo = new Todo(title);

        todo.Incomplete();

        todo.DomainEvents.Should().HaveCount(2);
        todo.DomainEvents.Last().Should().BeOfType<TodoIncompleteDomainEvent>();
    }
}