using Naft.Domain.Entities;

namespace Naft.Domain.Repositories;

public interface IProductRepository
{
    Task<Product> GetByIdAsync(Guid id);
    
    Task<IEnumerable<Product>> GetByIdAsync(IEnumerable<Guid> ids);
    
    Task<IEnumerable<Product>> GetAllAsync();
    Task AddAsync(Product product);
    Task UpdateAsync(Product product);
    Task DeleteAsync(Product product);
    
}