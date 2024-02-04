using Naft.Domain.Entities;

namespace Naft.Domain.Repositories;

public interface IUserRepository
{
    Task<User> GetByIdAsync(Guid id);
}