using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShoppingList.Application;
using ShoppingList.Application.Interfaces.Repositories;
using ShoppingList.Application.Interfaces.UnitOfWork;
using ShoppingList.Domain.Entities;
using ShoppingList.Persistence.Context;
using ShoppingList.Persistence.Repository;
using ShoppingList.Persistence.UnitOfWork;
using System.Reflection;

namespace ShoppingList.Persistence
{
    public static class ServiceContainer
    {
        public static void AddPersistenceService(this IServiceCollection services, IConfiguration configuration = null)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration?.GetConnectionString("Default")));

            services.AddTransient<ICartRepository, CartRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IGroupRepository, GroupRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUnitOfWorkService, UnitOfWorkService>();

            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddApplicationService(configuration);
        }
    }
}
