using Flunt.Notifications;
using MediatR;
using Naft.Domain.Commands;
using Naft.Domain.Commands.Interfaces;
using Naft.Domain.Entities;
using Naft.Domain.Handlers.Interfaces;
using Naft.Domain.Repositories;
using Naft.Domain.Utils;

namespace Naft.Domain.Handlers;

public class CreateOrderHandler :Notifiable<Notification>, IRequestHandler<CreateOrderCommand, GenericCommandResult>
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
    
    public async Task<GenericCommandResult> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
    {
        // Fail Fast Validation
        command.Validate();
        if (!command.IsValid)
        {
            return new GenericCommandResult(false, "Pedido inválido", command.Notifications);
        }
        
        // Recupera o usuário
        var buyer = await _userRepository.GetByIdAsync(command.BuyerId);
        var seller = await _userRepository.GetByIdAsync(command.SellerId);
        
        // recupera os produtos
        var products = await _productrepository.GetByIdAsync(ExtractGuids.Extract(command.Items));
        var productsList = products.ToList();

     
        
        // Gera o pedido
        var order = new Order(buyer, seller);
        
        foreach (var item in command.Items)
        {
            var product = productsList.FirstOrDefault(x => x.Id == item.Product.Id);
            order.AddItem(product, item.Quantity);
        }

        
        // Adiciona as notificações
        //AddNotifications(order.Notifications) as notificações já estão no command;
        
        // Verifica se deu tudo certo
        if (!order.IsValid)
            return new GenericCommandResult(false, "Falha ao gerar o pedido", order.Notifications);
        
        // Salva o pedido
         await _repository.Save(order);
        
        // Retorna o resultado
        return new GenericCommandResult(true, "Pedido salvo com sucesso", order);
    }
}