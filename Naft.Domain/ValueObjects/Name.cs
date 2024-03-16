using Flunt.Validations;

namespace Naft.Domain.ValueObjects;

public class Name : ValueObject
{
   
   
    public string FirstName { get; set; }
    public string LastName { get; set; }
    
    public Name(string firstName, string lastName)
    {
        AddNotifications(new Contract<Name>()
            .IsNotNullOrEmpty(firstName, "Name.firstName", "O nome é obrigatório")
            .IsNotNullOrEmpty(lastName, "Name.lastName", "O sobrenome é obrigatório")
            
        );
        
        if (!IsValid)
            return;
        
        FirstName = firstName;
        LastName = lastName;
        
        AddNotifications(new Contract<Name>()
            .Requires()
            .IsLowerThan(2,FirstName.Length, "Name.FirstName", "First Name must be at least 3 characters")
            .IsLowerThan(2,LastName.Length, "Name.LastName", "Last Name must be at least 3 characters")
            .IsGreaterThan(39,FirstName.Length, "Name.FirstName", "First Name must be at most 40 characters")
            .IsGreaterThan(39,LastName.Length, "Name.LastName", "Last Name must be at most 40 characters")
        
        );
        
    }
    
    public Name()
    {
    }
}