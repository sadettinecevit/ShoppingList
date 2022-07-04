using ShoppingList.Application.Constants;
using ShoppingList.Application.Interfaces.Repositories;
using ShoppingList.Domain.Entities;
using ShoppingList.Infrastructure.Services.Cache.Redis;
using ShoppingList.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Persistence.Repository
{
    public class CartRepository : Repository<Cart>, ICartRepository
    {
        public CartRepository(ApplicationDbContext context, RedisCacheService redisCacheService) : base(context, redisCacheService)
        {
            cacheName = CacheNames.cartCache;
        }
    }
}
