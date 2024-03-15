using Moq;
using Naft.Domain.Commands;
using Naft.Domain.Handlers;
using Naft.Domain.Repositories;



namespace Naft.Tests.HandlersTests;

public class CreateOrderHandlerTests
{
    private readonly Mock<IProductRepository> _productRepository = new();
    private readonly Mock<IUserRepository> _userRepository = new();
    private readonly Mock<IOrderRepository> _orderRepository = new();
    private readonly CreateOrderHandler _handler;
    private readonly User _seller;
    private readonly Product _product1;
    private readonly Guid _sellerId = Guid.Parse("00000000-0000-0000-0000-000000000001");
    private readonly Guid _buyerId = Guid.Parse("00000000-0000-0000-0000-000000000002");

    public CreateOrderHandlerTests()
    {
        // Common setup for all tests goes here
        var buyer = new User(new Name("John", "Cena"), new Email("John@gmail.com"), new PasswordHash("123456"));
        _seller = new User(new Name("Gabriel", "Barbosa"), new Email("gabigol@gmail.com"), new PasswordHash("123456"));
        _product1 = new Product(new Title("Monkey"), new Description("Description"), new Price(10), new Quantity(1), null, _seller);

        var testProducts = new List<Product>
        {
            _product1
        };

        _productRepository
            .Setup(repo => repo.GetByIdAsync(It.IsAny<IEnumerable<Guid>>()))
            .ReturnsAsync((IEnumerable<Guid> ids) => testProducts.Where(p => ids.Contains(p.Id)));

        _userRepository.Setup(x => x.GetByIdAsync(_sellerId))
            .ReturnsAsync(_seller); // Returns _seller when correct Guid is provided

        _userRepository.Setup(x => x.GetByIdAsync(_buyerId))
            .ReturnsAsync(buyer); // Returns _buyer when correct Guid is provided

        _handler = new CreateOrderHandler(_productRepository.Object, _userRepository.Object, _orderRepository.Object);
    }

    
    
    [Fact]
    public void ShouldReturnSuccessWhenAllDataIsValid()
    {
        // Arrange
        var command = new CreateOrderCommand(_buyerId, _sellerId, new List<OrderItem>
        {
            new OrderItem(_product1, 1)
        });

        // Act
        var result = _handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.True(result.Result.Success);
    }
    
    [Fact(DisplayName = "Should be invalid when command is invalid")]
    public void ShouldBeInvalidWhenCommandIsInvalid()
    {
        // Arrange
        var command = new CreateOrderCommand(Guid.Empty, Guid.Empty, new List<OrderItem>());

        // Act
        var result = _handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.False(result.Result.Success);
    }
    
    [Fact(DisplayName = "Should be invalid when the product is not found")]
    public void ShouldBeInvalidWhenTheProductIsNotFound()
    {
        // Act
        var command = new CreateOrderCommand(_buyerId, _sellerId, new List<OrderItem>
        {
            new OrderItem(new Product(new Title("Non-existent"), new Description("Description"), new Price(10), new Quantity(1), null, _seller), 1)
        });

        // Assert
        var result = _handler.Handle(command, CancellationToken.None);
        Assert.False(result.Result.Success);
    }
}