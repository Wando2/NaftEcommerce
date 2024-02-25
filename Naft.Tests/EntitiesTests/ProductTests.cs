namespace Naft.Tests;

public class ProductTests
{
    private readonly User _user;
    private readonly Title _title;
    private readonly Description _description;
    private readonly Price _price;
    private readonly Quantity _quantity;

    public ProductTests()
    {
        _user = new User(new Name("John", "Silva"), new Email("John@gmail.com"), new PasswordHash("123456789"));
        _title = new Title("Title");
        _description = new Description("Description");
        _price = new Price(10);
        _quantity = new Quantity(10);

    }
    
    [Fact(DisplayName = "Should be invalid when title is null")]
    public void ShouldBeInvalidWhenTitleIsNull()
    {
        var title = new Title(null);
        var description = new Description("Description");
        var price = new Price(10);
        var quantity = new Quantity(10);
        var user = new User(new Name("John", "Silva"), new Email("John@gmail.com"), new PasswordHash("123456789"));

        var product = new Product(title, description, price, quantity, null, user);

        Assert.False(product.IsValid);

    }

    [Fact(DisplayName = "Should be invalid when the title is invalid")]
    public void ShouldBeInvalidWhenTheTitleIsInvalid()
    {
        var title = new Title("a");
        var product = new Product(title, _description, _price, _quantity, null, _user);
        Assert.False(product.IsValid);
    }
    
    [Fact(DisplayName = "Should be valid when all properties are valid")]
    public void ShouldBeValidWhenAllPropertiesAreValid()
    {
        var product = new Product(_title, _description, _price, _quantity, null, _user);
        Assert.True(product.IsValid);
    }
    
}   