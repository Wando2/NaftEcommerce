using Flunt.Notifications;
using Flunt.Validations;

namespace Naft.Domain.ValueObjects;

public class Email : ValueObject
{
    public Email(string emailAddress)
    {
        EmailAddress = emailAddress;
        
        AddNotifications(new Contract<Notification>()
            .Requires()
            .IsEmail(EmailAddress, nameof(EmailAddress), "Email inválido")
        );
    }
    
    public string EmailAddress { get; private set; }
    
}