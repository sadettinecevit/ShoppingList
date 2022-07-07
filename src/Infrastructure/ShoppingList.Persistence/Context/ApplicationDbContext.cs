using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShoppingList.Application.Interfaces.Context;
using ShoppingList.Domain.Entities;

namespace ShoppingList.Persistence.Context
{
    public class ApplicationDbContext : IdentityDbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Cart> Carts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //builder.Entity<Cart>().HasOne(p => p.Id).WithMany().HasForeignKey(p=>p.Owner).IsRequired();
            //builder.Entity<Category>().HasOne(p => p.Id).WithMany().HasForeignKey(p=>p.Cart).IsRequired();
            //builder.Entity<Group>().HasOne(p => p.Id).WithMany().HasForeignKey(p=>p.Category).IsRequired();
            //builder.Entity<Product>().HasOne(p => p.Id).WithMany().HasForeignKey(p=>p.Group).IsRequired();
            //builder.Entity<User>().HasOne(p => p.Id).WithMany();
        }
    }
}
