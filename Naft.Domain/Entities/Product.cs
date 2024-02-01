
using System.Collections;
using Naft.Domain.ValueObjects;

namespace Naft.Domain.Entities;

public class Product : Entity 
{
    public Product(Title title, Description description, Price price, Quantity quantity, Image image, User user)
    {
        Title = title;
        Description = description;
        Price = price;
        Quantity = quantity;
        Image = image;
        User = user;
        _categories = new List<Category>();
        
        
        AddNotifications(title, description, price, quantity, image, user);
    }
    
    public Title Title { get; private set; }
    public Description Description { get; private set; }
    public Price Price { get; private set; }
    public Quantity Quantity { get; private set; }
    public Image Image { get; private set; }
    public User User { get; private set; }
    public IEnumerable<Category> Categories => _categories;
    private IList<Category> _categories { get; set; }
    
    public bool AddCategory(Category category)
    {
        if (_categories.Contains(category))
            return false;
        
        _categories.Add(category);
        return true;
    }
    
    
    
}