using ShoppingList.Domain.Common;

namespace ShoppingList.Application.Interfaces.Repositories
{
    public class RepositoryResponse<T> where T : class, IBaseEntity, new()
    {
        public T Entity  { get; set; }
        public int TotalRecordCount { get; set; }
    }
}
