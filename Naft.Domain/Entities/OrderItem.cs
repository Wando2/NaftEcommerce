namespace Naft.Domain.Entities;

using Flunt.Notifications;
using Flunt.Validations;

public class OrderItem : Entity
{
    
    public OrderItem(Product product, int quantity)
    {
        
        AddNotifications(
            new Contract<Notification>()
                .Requires()
                .IsNotNull(product, "Product", "Produto nulo ou inválido")
        );

        
        if (!IsValid) return;

        // Now it's safe to access properties of product
        AddNotifications(
            new Contract<Notification>()
                .Requires()
                .IsGreaterThan(product.Quantity.Value, 0, "Quantity", "Não há estoque do produto")
                .IsGreaterThan(quantity, 0, "Quantity", "A quantidade deve ser maior que zero")
        );

        // Assuming the rest of your logic here is correct
        Product = product;
        Quantity = quantity;
        
        
    }
    
    public Product Product { get; private set; }
    public int Quantity { get;  set; }
    public decimal Price { get; private set; }
    
    
    public decimal Total() => Price * Quantity;
}