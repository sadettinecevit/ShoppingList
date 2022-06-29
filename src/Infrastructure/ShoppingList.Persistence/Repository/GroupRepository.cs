using ShoppingList.Application.Interfaces.Repositories;
using ShoppingList.Domain.Entities;
using ShoppingList.Persistence.Context;

namespace ShoppingList.Persistence.Repository
{
    public class GroupRepository : Repository<Group>, IGroupRepository
    {
        public GroupRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
