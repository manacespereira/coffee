namespace Coffee.WebApi.Application.Events;

public class TodoAddedIntegrationEvent : INotification
{
    public TodoAddedIntegrationEvent(string title)
    {
        Title = title;
    }

    public string Title { get; set; }
}