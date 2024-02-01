using Flunt.Notifications;
using Flunt.Validations;

namespace Naft.Domain.ValueObjects;

public class Quantity : ValueObject
{
    public Quantity(int value)
    {
        Value = value;
        
        AddNotifications(new Contract<Notification>()
            .Requires()
            .IsLowerThan(0,Value, nameof(Value), "A quantidade deve ser maior que 0")
        );
    }

    public int Value { get; private set; }
}