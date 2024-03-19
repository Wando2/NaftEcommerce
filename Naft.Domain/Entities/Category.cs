using Naft.Domain.ValueObjects;

namespace Naft.Domain.Entities;

public class Category : Entity
{
    public Category(string name)
    {
        Name = name;
        Products = new List<Product>();
    }
   
    
    public string Name { get; set; }

    public IEnumerable<Product> Products { get; set; }
    
    
}