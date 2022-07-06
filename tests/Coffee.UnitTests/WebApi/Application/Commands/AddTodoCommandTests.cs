using Coffee.WebApi.Application.Commands;

namespace Coffee.UnitTests.WebApi.Application.Commands;

public class AddTodoCommandTests
{
    [Fact]
    public void Validate_WhenEmptyTitle_IsInvalid()
    {
        var command = new AddTodoCommand();

        command.Validate();

        command.IsValid.Should().BeFalse();
        command.Notifications.Should().NotBeEmpty();
    }
    
    [Fact]
    public void Validate_WhenTitleIsFilled_IsValid()
    {
        var command = new AddTodoCommand("Todo title");

        command.Validate();

        command.IsValid.Should().BeTrue();
        command.Notifications.Should().BeEmpty();
    }
}