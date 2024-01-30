using Flunt.Validations;

namespace Naft.Domain.Entities;

public class Name : ValueObject
{
    public Name(string firstName, string lastName)
    {
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
   
    public string FirstName { get; set; }
    public string LastName { get; set; }
}