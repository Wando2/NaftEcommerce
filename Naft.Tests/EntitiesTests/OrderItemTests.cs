namespace Naft.Tests;

public class OrderItemTests
{
    private readonly Product _product;
    private readonly int _quantity;
    
    public OrderItemTests()
    {
        _product = new Product(new Title("Title"), new Description("Description"), new Price(10), new Quantity(10), null, new User(new Name("John", "Silva"), new Email("john@gmail.com"), new PasswordHash("123456789")));
        _quantity = 10;
    }
    
    [Fact(DisplayName = "Should be invalid when product is null")]
    public void ShouldBeInvalidWhenProductIsNull()
    {
        var orderItem = new OrderItem(null, _quantity);
           
        Assert.False(orderItem.IsValid);
           
    }
    
    [Fact(DisplayName = "Should be invalid when quantity is invalid")]
    public void ShouldBeInvalidWhenQuantityIsInvalid()
    {
        var orderItem = new OrderItem(_product, 0);
        Assert.False(orderItem.IsValid);
    }
    
    [Fact(DisplayName = "Should be valid when all properties are valid")]
    
    public void ShouldBeValidWhenAllPropertiesAreValid()
    {
        var orderItem = new OrderItem(_product, _quantity);
        Assert.True(orderItem.IsValid);
    }
    
    [Fact(DisplayName = "Total should be 20 when product price is 10 and quantity is 2")]
    public void TotalShouldBe20WhenProductPriceIs10AndQuantityIs2()
    {
        var orderItem = new OrderItem(_product, 2);
        Assert.Equal(20, orderItem.Total());
    }
        
}