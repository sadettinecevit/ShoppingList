using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Storage;
using ShoppingList.Application.Interfaces.Repositories;
using ShoppingList.Domain.Entities;

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
        public UserManager<User> _userManager { get; }
        public RoleManager<IdentityRole> _roleManager { get; }
    }
}
