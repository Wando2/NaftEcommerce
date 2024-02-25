using Flunt.Notifications;
using Flunt.Validations;

namespace Naft.Domain.ValueObjects;

public class Title : ValueObject
{
    public Title(string title) 
    {
        AddNotifications(new Contract<Title>()
            .IsNotNullOrEmpty(title,"Title.TitleName", "O título é obrigatório)")
        );
        
        if (!IsValid)
            return;
        
        TitleName = title;
        
        AddNotifications(new Contract<Notification>()
            .Requires()
            .IsLowerThan(2,TitleName.Length, nameof(TitleName), "O título deve ter pelo menos 2 caractere")
            .IsGreaterThan(100,TitleName.Length, nameof(TitleName), " O título deve ter no máximo 100 caracteres")
            
        );
    }
    
    public string TitleName { get; set; }
}