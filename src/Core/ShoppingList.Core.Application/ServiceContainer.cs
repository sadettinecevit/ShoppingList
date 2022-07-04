using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ShoppingList.Application
{
    public static class ServiceContainer
    {
        public static void AddApplicationService(this IServiceCollection service, IConfiguration configuration = null)
        {
        }
    }
}
