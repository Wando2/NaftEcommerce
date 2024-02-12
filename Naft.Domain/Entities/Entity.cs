using Flunt.Notifications;

namespace Naft.Domain.Entities;

public abstract class Entity : Notifiable<Notification>
{
    public Guid Id { get; private set; } = Guid.NewGuid();
}