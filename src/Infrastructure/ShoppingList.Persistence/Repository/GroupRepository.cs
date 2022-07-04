using ShoppingList.Application.Constants;
using ShoppingList.Application.Interfaces.Repositories;
using ShoppingList.Domain.Entities;
using ShoppingList.Infrastructure.Services.Cache.Redis;
using ShoppingList.Persistence.Context;

namespace ShoppingList.Persistence.Repository
{
    public class GroupRepository : Repository<Group>, IGroupRepository
    {
        public GroupRepository(ApplicationDbContext context, RedisCacheService redisCacheService) : base(context, redisCacheService)
        {
            cacheName = CacheNames.groupCache;
        }
    }
}
