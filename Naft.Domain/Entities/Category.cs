namespace Naft.Domain.Entities;

public class Category : Entity
{
    public Category(string name, string description)
    {
        Name = name;
        Description = description;
        Products = new List<Product>();
    }
   
    
    public string Name { get; set; }
    public string Description { get; set; }
    public IEnumerable<Product> Products { get; set; }
    
    
}