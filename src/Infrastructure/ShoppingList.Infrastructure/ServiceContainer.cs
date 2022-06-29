using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShoppingList.Infrastructure.Services.Cache.Redis;
using ShoppingList.Infrastructure.Services.MessageQueue;

namespace ShoppingList.Infrastructure
{
    public static class ServiceContainer
    {
        public static void AddInfrastructureService(this IServiceCollection services, IConfiguration configuration = null)
        {
            services.AddStackExchangeRedisCache(options =>
            {
                options.InstanceName = "ShoppingListRedisCacheServer";
                options.Configuration = "localhost";
            });

            services.AddSingleton<RedisCacheService>();
            services.AddScoped<IRabbitMqService, RabbitMqService>();
        }
    }
}
