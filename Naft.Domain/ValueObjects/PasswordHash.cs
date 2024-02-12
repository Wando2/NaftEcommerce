using Flunt.Validations;
using SecureIdentity.Password;

namespace Naft.Domain.ValueObjects;

public class PasswordHash : ValueObject
{
    
    public PasswordHash(string passwordHash)
    {
        AddNotifications(new Contract<PasswordHash>()
            .Requires()
            .IsNotNull(passwordHash, nameof(passwordHash), "A senha não pode ser nula")
        );
        
        if (!IsValid)
            return;
        
        AddNotifications(new Contract<PasswordHash>()
            .Requires()
            .IsLowerThan(5,passwordHash.Length, nameof(passwordHash), "A senha deve ter no mínimo 5 caracteres")
            .IsGreaterThan(20,passwordHash.Length, nameof(passwordHash), "A senha deve ter no máximo 20 caracteres")
        );
        
        PasswordHashText =  PasswordHasher.Hash(passwordHash);
    }
    
    public string PasswordHashText { get; private set; }
    
}