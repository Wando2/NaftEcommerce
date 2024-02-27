using Moq;
using Naft.Domain.Commands;
using Naft.Domain.Handlers;
using Naft.Domain.Repositories;

namespace Naft.Tests.HandlersTests;

public class CreateOrderHandlerTests
{
    private readonly Mock<IProductRepository> _productRepository;
    private readonly Mock<IUserRepository> _userRepository;
    private readonly Mock<IOrderRepository> _orderRepository;
    private readonly User _buyer;
    private readonly User _seller;
    private readonly Product _product1;
    
    public CreateOrderHandlerTests()
    {
        _productRepository = new Mock<IProductRepository>();
        _userRepository = new Mock<IUserRepository>();
        _orderRepository = new Mock<IOrderRepository>();
        
        var _buyer = new User(new Name("John","cena"), new Email("John@gmail.com"), new PasswordHash("123456"));
        var _seller = new User(new Name("Gabriel","Barbosa"), new Email("gabigol@gmail.com"), new PasswordHash("123456"));
        var _product1 = new Product(new Title("Produto1"), new Description("Descrição do produto 1"), new Price(10), new Quantity(10), null, _seller);

        
    }
    
    [Fact]
    public void ShouldBeValidWhenAllDataIsValid()
    {
     _productRepository.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(_product1);
     
     _userRepository.Setup(x => x.GetByIdAsync(It.Is<Guid>(id => id == Guid.Parse("00000000-0000-0000-0000-000000000001"))))
         .ReturnsAsync(_seller); // Returns _seller when Guid is 00000000-0000-0000-0000-000000000001
     _userRepository.Setup(x => x.GetByIdAsync(It.Is<Guid>(id => id == Guid.Parse("00000000-0000-0000-0000-000000000002"))))
         .ReturnsAsync(_buyer); // Returns _buyer when Guid is 00000000-0000-0000-0000-000000000002
        
        
     
    }
}