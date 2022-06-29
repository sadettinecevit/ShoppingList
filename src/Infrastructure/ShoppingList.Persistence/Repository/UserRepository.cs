using ShoppingList.Application.Interfaces.Repositories;
using ShoppingList.Domain.Entities;
using ShoppingList.Persistence.Context;

namespace ShoppingList.Persistence.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
