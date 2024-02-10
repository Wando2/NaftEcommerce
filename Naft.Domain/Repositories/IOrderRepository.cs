using Naft.Domain.Entities;

namespace Naft.Domain.Repositories;

public interface IOrderRepository
{
    public void Save(Order order);
}