using Flunt.Notifications;
using Flunt.Validations;

namespace Naft.Domain.ValueObjects;

public class Title : ValueObject
{
    public Title(string title) 
    {
        TitleName = title;
        
        AddNotifications(new Contract<Notification>()
            .Requires()
            .IsLowerThan(1,TitleName.Length, nameof(TitleName), "O título deve ter pelo menos 1 caractere")
            .IsGreaterThan(100,TitleName.Length, nameof(TitleName), " O título deve ter no máximo 100 caracteres")
            
        );
    }
    
    public string TitleName { get; set; }
}