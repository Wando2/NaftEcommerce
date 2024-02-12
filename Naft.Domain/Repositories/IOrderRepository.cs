using Naft.Domain.Entities;

namespace Naft.Domain.Repositories;

public interface IOrderRepository
{
   Task Save(Order order);
}