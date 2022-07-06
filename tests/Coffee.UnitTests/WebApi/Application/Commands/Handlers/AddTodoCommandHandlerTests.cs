using System.Data;
using System.Threading;
using System.Threading.Tasks;
using Coffee.Domain.AggregatesModel.TodoAggregates;
using Coffee.Domain.Core;
using Coffee.WebApi.Application.Commands;
using Coffee.WebApi.Application.Commands.Handlers;
using Coffee.WebApi.Application.Events;
using MediatR;
using Moq;

namespace Coffee.UnitTests.WebApi.Application.Commands.Handlers;

public class AddTodoCommandHandlerTests
{
    private readonly Mock<ITodoRepository> _todoRepositoryMock;
    private readonly Mock<IMediator> _mediatorMock;
    private readonly AddTodoCommandHandler _sut;

    public AddTodoCommandHandlerTests()
    {
        _todoRepositoryMock = new Mock<ITodoRepository>();
        _todoRepositoryMock.Setup(x => x.UnitOfWork).Returns(Mock.Of<IUnitOfWork>());

        _mediatorMock = new Mock<IMediator>();
        _sut = new AddTodoCommandHandler(_todoRepositoryMock.Object, _mediatorMock.Object);
    }

    [Fact]
    public async Task Handle_WhenNoExactSameTitleIsFound_AddTodo()
    {
        var command = new AddTodoCommand("title");

        var result = await _sut.Handle(command, CancellationToken.None);

        _todoRepositoryMock.Verify(x => x.AddAsync(It.Is<Todo>(t => t.Title == "title")), Times.Once);
        _todoRepositoryMock.Verify(x => x.UnitOfWork.SaveEntitiesAsync(CancellationToken.None), Times.Once);
        result.Should().BeOfType<Unit>();
    }

    [Fact]
    public async Task Handle_WhenExactSameTitleIsFound_ThrowsException()
    {
        var command = new AddTodoCommand("title");
        _todoRepositoryMock.Setup(x => x.GetByTitleAsync("title")).ReturnsAsync(new Todo("title"));

        var action = async () => await _sut.Handle(command, CancellationToken.None);

        _todoRepositoryMock.Verify(x => x.AddAsync(It.Is<Todo>(t => t.Title == "title")), Times.Never);
        await action.Should().ThrowAsync<DuplicateNameException>();
    }

    [Fact]
    public async Task Handle_WhenTodoAdded_SendTodoAddedIntegrationEvent()
    {
        var command = new AddTodoCommand("title");

        await _sut.Handle(command, CancellationToken.None);

        _todoRepositoryMock.Verify(x => x.AddAsync(It.Is<Todo>(t => t.Title == "title")), Times.Once);
        _mediatorMock.Verify(
            x => x.Publish(It.Is<TodoAddedIntegrationEvent>(e => e.Title == "title"), CancellationToken.None),
            Times.Once);
    }
}