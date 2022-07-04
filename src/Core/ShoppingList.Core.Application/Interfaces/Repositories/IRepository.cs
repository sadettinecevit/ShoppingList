using ShoppingList.Domain.Common;

namespace ShoppingList.Application.Interfaces.Repositories
{
    public interface IRepository<T> where T : class, IBaseEntity, new()
    {
        Task<List<T>> GetAsync();
        Task<T> GetByIdAsync(string id);
        Task<RepositoryResponse<T>> Add(T entity);
        Task<RepositoryResponse<T>> Update(T entity);
        Task<RepositoryResponse<T>> Delete(T entity);
    }
}
