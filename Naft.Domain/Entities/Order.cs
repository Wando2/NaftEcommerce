using Naft.Domain.Entities.Enum;

namespace Naft.Domain.Entities;

public class Order : Entity
{
    
    public Order(User seller, User buyer)
    {
        
        Seller = seller;
        Buyer = buyer;
        Date = DateTime.Now;
        Status = EOrderStatus.WaitingPayment;
        _Items = new List<OrderItem>();
        
        AddNotifications(seller, buyer);
        
        
    }
    
    
    public User Seller { get; private set; }
    public User Buyer { get; private set; }
    public DateTime Date { get; private set; }
    public EOrderStatus Status { get; private set; }
    public IList<OrderItem> _Items { get; private set; }
    private IEnumerable<OrderItem> Items => _Items;

    public Guid Number => new();
    
    public decimal Total() => Items.Sum(item => item.Total());
 
    
    public void AddItem(Product product, int quantity)
    {
            
        var item = new OrderItem(product, quantity);
        if (item.IsValid)
            _Items.Add(item);
            
    }
    
    public void Pay(decimal amount)
    {
        if(amount == Total())
            Status = EOrderStatus.WaitingDelivery;
    }
    
    
    public void Cancel()
    {
        Status = EOrderStatus.Canceled;
    }
    
    public void Deliver()
    {
        Status = EOrderStatus.Finished;
    }
    
    public bool HasItems => Items.Any();
    
}