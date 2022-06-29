using Microsoft.EntityFrameworkCore.Storage;
using ShoppingList.Application.Interfaces.Repositories;
using ShoppingList.Application.Interfaces.UnitOfWork;
using ShoppingList.Persistence.Context;

namespace ShoppingList.Persistence.UnitOfWork
{
    public class UnitOfWorkService : IUnitOfWorkService
    {
        private readonly ApplicationDbContext _context;
        public ICartRepository _cartRepository { get; }
        public ICategoryRepository _categoryRepository { get; }
        public IGroupRepository _groupRepository { get; }
        public IProductRepository _productRepository { get; }
        public IUserRepository _userRepository { get; }

        public UnitOfWorkService(ApplicationDbContext context, IUserRepository userRepository
            , ICartRepository cartRepository, ICategoryRepository categoryRepository
            , IProductRepository productRepository, IGroupRepository groupRepository)
        {
            _context = context;
            _userRepository = userRepository;
            _cartRepository = cartRepository;
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
            _groupRepository = groupRepository;
        }

        public async Task<IDbContextTransaction> BeginTansactionAsync() => await _context.Database.BeginTransactionAsync();

        public async ValueTask DisposeAsync() { }
    }
}
