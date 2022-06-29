using Microsoft.EntityFrameworkCore.Storage;
using ShoppingList.Application.Interfaces.Repositories;

namespace ShoppingList.Application.Interfaces.UnitOfWork
{
    public interface IUnitOfWorkService : IAsyncDisposable
    {
        Task<IDbContextTransaction> BeginTansactionAsync();
        public ICartRepository _cartRepository { get; }
        public ICategoryRepository _categoryRepository { get; }
        public IGroupRepository _groupRepository { get; }
        public IProductRepository _productRepository { get; }
        public IUserRepository _userRepository { get; }
    }
}
