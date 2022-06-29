using ShoppingList.Application.Interfaces.Repositories;
using ShoppingList.Domain.Entities;
using ShoppingList.Persistence.Context;

namespace ShoppingList.Persistence.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
