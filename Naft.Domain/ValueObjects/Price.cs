using Flunt.Notifications;
using Flunt.Validations;

namespace Naft.Domain.ValueObjects;

public class Price : ValueObject
{
    
    public Price(decimal value)
    {
       Value = value;

       AddNotifications(new Contract<Notification>()
           .Requires()
           .IsLowerThan(0,Value, nameof(Value), "Price must be greater than 0")
       );
    }
    
    public decimal Value { get; set; }
    
    
}