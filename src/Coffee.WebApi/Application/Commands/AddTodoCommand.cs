namespace Coffee.WebApi.Application.Commands;

public class AddTodoCommand : Command
{
    public AddTodoCommand()
    {
    }

    public AddTodoCommand(string title)
    {
        Title = title;
    }

    public AddTodoCommand(string title, string description)
    {
        Title = title;
        Description = description;
    }

    public string Title { get; set; }
    public string Description { get; set; }

    public override void Validate()
    {
        var contract = new Contract<Notification>()
            .IsNotNullOrEmpty(Title, nameof(Title));
        AddNotifications(contract);
    }
}