using Microsoft.EntityFrameworkCore;
using ShoppingList.Domain.Entities;

namespace ShoppingList.Application.Interfaces.Context
{
    public interface IApplicationDbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<Group> Groups { get; set; }
        DbSet<Cart> Carts { get; set; }
    }
}
