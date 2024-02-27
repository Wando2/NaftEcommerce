using Naft.Domain.Entities;

namespace Naft.Domain.Repositories;

public interface IUserRepository
{
    Task<User> GetByIdAsync(Guid id);
    Task<User> GetByEmailAsync(string email);
    Task Save(User user);
    Task Update(User user);
    Task Delete(User user);
    
    Task EmailExists(string email);
}