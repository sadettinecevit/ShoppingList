using ShoppingList.Domain.Common;

namespace ShoppingList.Application.Interfaces.Repositories
{
    public interface IRepository<T> where T : class, IBaseEntity, new()
    {
        Task<List<T>> GetAsync();
        Task<T> GetByIdAsync(string id);
        Task<int> Add(T entity);
        Task<int> Update(T entity);
        Task<int> Delete(T entity);
    }
}
