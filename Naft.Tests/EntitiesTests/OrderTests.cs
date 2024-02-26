using Naft.Domain.Entities.Enum;

namespace Naft.Tests;

public class OrderTests
{
   private readonly Product _product;
   private readonly Product _product2;
    private readonly User _user;
    private readonly User _user2;

    public OrderTests()
    {
        _user = new User(new Name("John", "Silva"), new Email("JohnCalvo@gmail.com"), new PasswordHash("123456789"));
        _user2 = new User(new Name("Gabriel", "Barbosa"), new Email("gabigol@gmail.com"), new PasswordHash("123456789"));
        _product = new Product(new Title("Carro"), new Description("Description"), new Price(10), new Quantity(1), null, _user);
        _product2 = new Product(new Title("Roupa"), new Description("Description"), new Price(1), new Quantity(1), null, _user);
        
    }

    [Fact(DisplayName = "Should be invalid when any of users is null")]
    public void ShouldBeInvalidWhenUserIsNull()
    {
        var order = new Order(null, _user2);
        Assert.False(order.IsValid);
    }
    
    
    [Fact(DisplayName = "Status should be waiting for payment when order is created")]
    public void StatusShouldBeWaitingForPaymentWhenOrderIsCreated()
    {
        var order = new Order(_user,_user2);
        Assert.Equal(EOrderStatus.WaitingPayment, order.Status);
    }
}