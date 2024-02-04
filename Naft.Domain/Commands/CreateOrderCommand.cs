using Flunt.Notifications;
using Flunt.Validations;
using Naft.Domain.Commands.Interfaces;
using Naft.Domain.Entities;

namespace Naft.Domain.Commands;

public class CreateOrderCommand :Notifiable<Notification>, ICommand, ICommandResult
{
    public CreateOrderCommand(User buyer, User seller, IList<OrderItem> items)
    {
        Buyer = buyer;
        Seller = seller;
        Items = items;
    }
    
   
    public User Buyer { get; private set; }
    public User Seller { get; private  set; }
    public IList<OrderItem> Items { get; private set; }
    
 

    public void Validate()
    {
        AddNotifications(new Contract<Order>()
            .Requires()
            .IsNotNull(Buyer, "Buyer", "O comprador não pode ser nulo")
            .IsNotNull(Seller, "Seller", "O vendedor não pode ser nulo")
            .IsGreaterThan(Items.Count, 0, "Items", "A lista de produtos não pode ser vazia")
        );
    }
    
}