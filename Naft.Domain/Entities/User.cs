using Naft.Domain.ValueObjects;

namespace Naft.Domain.Entities;

public class User : Entity
{
    public Name Name { get; private set; }
    public Email Email { get; private set; }
    public Address Address { get; private set; }
    public PasswordHash Password { get; private set; }
    public IEnumerable<Product> Products => _products;
    private IList<Product> _products { get; set; }
   
    public Slug Slug { get; private set; }
    
    public User(Name name, Email email, Address address, PasswordHash password)
    {
        Name = name;
        Email = email;
        Address = address;
        Password = password;
        _products = new List<Product>();
        Slug = new Slug(name.FirstName);
        
        AddNotifications(name, email, address, password);
    }
    
    
    
}