using ShoppingList.Application.Interfaces.Repositories;
using ShoppingList.Domain.Entities;
using ShoppingList.Persistence.Context;

namespace ShoppingList.Persistence.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
