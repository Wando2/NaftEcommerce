using Flunt.Notifications;
using Naft.Domain.Commands;
using Naft.Domain.Commands.Interfaces;
using Naft.Domain.Entities;
using Naft.Domain.Handlers.Interfaces;
using Naft.Domain.Repositories;
using Naft.Domain.Utils;

namespace Naft.Domain.Handlers;

public class CreateOrderHandler : Notifiable<Notification>, IHandler<CreateOrderCommand>
{
    private readonly IProductRepository _productrepository;
    private readonly IUserRepository _userRepository;
    private readonly IOrderRepository _repository;
    public CreateOrderHandler(IProductRepository repository, IUserRepository userRepository, IOrderRepository orderRepository)
    {
        _productrepository = repository;
        _userRepository = userRepository;
        _repository = orderRepository;
    }
    
    public ICommandResult Handle(CreateOrderCommand command)
    {
        // Fail Fast Validation
        command.Validate();
        if (!command.IsValid)
        {
            AddNotifications(command);
            return new GenericCommandResult(false, "Pedido inválido", command.Notifications);
        }
        
        // Recupera o usuário
        var buyer = _userRepository.GetByIdAsync(command.BuyerId).Result;
        var seller = _userRepository.GetByIdAsync(command.SellerId).Result;
        
        // recupera os produtos
        var products = _productrepository.GetByIdAsync(ExtractGuids.Extract(command.Items)).Result;
        var productsList = products.ToList();

     
        
        // Gera o pedido
        var order = new Order(buyer, seller);
        
        foreach (var item in command.Items)
        {
            var product = productsList.FirstOrDefault(x => x.Id == item.Product.Id);
            order.AddItem(product, item.Quantity);
        }

        
        // Adiciona as notificações
        AddNotifications(order.Notifications);
        
        // Verifica se deu tudo certo
        if (!IsValid)
            return new GenericCommandResult(false, "Falha ao gerar o pedido", Notifications);
        
        // Salva o pedido
        _repository.Save(order);
        
        // Retorna o resultado
        return new GenericCommandResult(true, "Pedido salvo com sucesso");
    }
}