using Naft.Domain.Entities;

namespace Naft.Domain.Repositories;

public interface ICategoryRepository
{
    Task<Category> Get(string name);
}