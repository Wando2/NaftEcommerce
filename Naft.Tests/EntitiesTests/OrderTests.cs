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
        _product = new Product(new Title("Monkey"), new Description("Description"), new Price(10), new Quantity(1), null, _user);
        _product2 = new Product(new Title("Alien"), new Description("Description"), new Price(1), new Quantity(1), null, _user);
        
    }

    
    [Fact(DisplayName = "Should be valid when all properties are valid")]
    public void ShouldBeValidWhenAllPropertiesAreValid()
    {
        var order = new Order(_user,_user2);
        Assert.True(order.IsValid);
    }
    
    
    [Fact(DisplayName = "Status should be waiting for payment when order is created")]
    public void StatusShouldBeWaitingForPaymentWhenOrderIsCreated()
    {
        var order = new Order(_user,_user2);
        Assert.Equal(EOrderStatus.WaitingPayment, order.Status);
    }
    
    [Fact(DisplayName = "Total should be 10 when product price is 10 and quantity is 1")]
    public void TotalShouldBe10WhenProductPriceIs10AndQuantityIs1()
    {
        var order = new Order(_user,_user2);
        order.AddItem(_product, 1);
        Assert.Equal(10, order.Total());
    }
    
    [Fact(DisplayName = "Status should be waiting for delivery when order is paid")]
    public void StatusShouldBeWaitingForDeliveryWhenOrderIsPaid() 
    {
        var order = new Order(_user,_user2);
        order.AddItem(_product, 1);
        order.Pay(10);
        Assert.Equal(EOrderStatus.WaitingDelivery, order.Status);
    }
    
    [Fact (DisplayName = "Status should be awaiting payment when order is paid with wrong amount")]
    public void StatusShouldBeAwaitingPaymentWhenOrderIsPaidWithWrongAmount()
    {
        var order = new Order(_user,_user2);
        order.AddItem(_product, 1);
        order.Pay(5);
        Assert.Equal(EOrderStatus.WaitingPayment, order.Status);
    }
    
    
    [Fact(DisplayName = "Status should be canceled when order is canceled")]
    public void StatusShouldBeCanceledWhenOrderIsCanceled()
    {
        var order = new Order(_user,_user2);
        order.AddItem(_product, 1);
        order.Cancel();
        Assert.Equal(EOrderStatus.Canceled, order.Status);
    }
    
    
    
}