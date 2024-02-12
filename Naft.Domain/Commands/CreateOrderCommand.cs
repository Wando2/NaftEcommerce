using Flunt.Notifications;
using Flunt.Validations;
using MediatR;
using Naft.Domain.Commands.Interfaces;
using Naft.Domain.Entities;

namespace Naft.Domain.Commands;

public class CreateOrderCommand :Notifiable<Notification>, ICommand , IRequest<GenericCommandResult>
{
    public CreateOrderCommand(Guid buyerId,Guid sellerId, IList<OrderItem> items)
    {
        BuyerId = buyerId;
        SellerId = sellerId;
        Items = items;
    }
    
   
    public Guid BuyerId { get; private set; }
    public Guid SellerId { get; private set; }
    public IList<OrderItem> Items { get; private set; }
    
 

    public void Validate()
    {
        AddNotifications(new Contract<Order>()
            .Requires()
            .IsNotNull(BuyerId, "BuyerId", "O comprador não pode ser nulo")
            .IsNotNull(SellerId, "SellerId", "O vendedor não pode ser nulo")
            .IsGreaterThan(Items.Count, 0, "Items", "A lista de produtos não pode ser vazia")
        );
    }
    
}