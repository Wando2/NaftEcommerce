using Flunt.Notifications;
using Flunt.Validations;
using Naft.Domain.Commands.Interfaces;
using Naft.Domain.Entities;
using Naft.Domain.ValueObjects;

namespace Naft.Domain.Commands;

public class CreateUserCommand : Notifiable<Notification>, ICommand , ICommandResult
{
    private Name Name { get; set; }
    private Email Email { get;  set; }
    private PasswordHash Password { get; set; }
    public IList<Product> Products { get; private set; }
    public Slug Slug { get; private set; }
    
    public CreateUserCommand(Name name, Email email, PasswordHash password)
    {
        Name = name;
        Email = email;
        Password = password;
        Products = new List<Product>();
        Slug = new Slug(name.FirstName);
    }


    public void Validate()
    {
        AddNotifications(new Contract<User>()
            .Requires()
            .IsNotNull(Name, "Name", "O nome não pode ser nulo")
            .IsNotNull(Email, "Email", "O email não pode ser nulo")
            .IsNotNull(Password, "Password", "A senha não pode ser nula")
        );
    }
}