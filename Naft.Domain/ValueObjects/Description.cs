using Flunt.Notifications;
using Flunt.Validations;

namespace Naft.Domain.ValueObjects;

public class Description : ValueObject
{
    public Description(string description)
    {
        AddNotifications(new Contract<Description>()
            .IsNotNullOrEmpty(description,"Description.DescriptionText", "A descrição é obrigatória")
        );
        
        if (!IsValid)
            return;
        
        DescriptionText = description;

        AddNotifications(new Contract<Notification>()
            .Requires()
            .IsLowerThan(1,DescriptionText.Length, nameof(DescriptionText), "A descrição deve ter pelo menos 1 caractere")
            .IsGreaterThan(1000,DescriptionText.Length, nameof(DescriptionText), " A descrição deve ter no máximo 1000 caracteres")
        );
    }
    
    public string DescriptionText { get; private set; }
    
}