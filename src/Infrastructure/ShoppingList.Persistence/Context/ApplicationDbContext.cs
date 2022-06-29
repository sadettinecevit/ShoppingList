﻿using Microsoft.AspNetCore.Identity;
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

            builder.Entity<Cart>().HasOne<Cart>().WithMany().HasForeignKey();
            builder.Entity<Category>().HasOne<Category>().WithMany().HasForeignKey();
            builder.Entity<Group>().HasOne<Group>().WithMany().HasForeignKey();
            builder.Entity<Product>().HasOne<Product>().WithMany().HasForeignKey();
        }
    }
}