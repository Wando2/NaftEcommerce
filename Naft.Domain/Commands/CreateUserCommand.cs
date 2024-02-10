using Flunt.Notifications;
using Flunt.Validations;
using Naft.Domain.Commands.Interfaces;
using Naft.Domain.Entities;
using Naft.Domain.ValueObjects;

namespace Naft.Domain.Commands;

public class CreateUserCommand : Notifiable<Notification>, ICommand
{
    private Name Name { get; set; }
    private Email Email { get;  set; }
    private PasswordHash Password { get; set; }
 
    
    public CreateUserCommand(Name name, Email email, PasswordHash password)
    {
        Name = name;
        Email = email;
        Password = password;
    
    }


    public void Validate()
    {
        AddNotifications(new Contract<ICommandResult>()
            .Requires()
            .IsNotNull(Name, "Name", "O nome não pode ser nulo")
            .IsNotNull(Email, "Email", "O email não pode ser nulo")
            .IsNotNull(Password, "Password", "A senha não pode ser nula")
        );
    }
}