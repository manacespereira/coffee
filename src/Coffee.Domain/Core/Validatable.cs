using Flunt.Notifications;

namespace Coffee.Domain.Core;

public abstract class Validatable : Notifiable<Notification>
{
    public abstract void Validate();
}