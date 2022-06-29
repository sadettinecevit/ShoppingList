using ShoppingList.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Infrastructure.Services.Cache
{
    public interface IBaseCache
    {
        public Task<byte[]> GetAsync(string cacheName);
        public Task DeleteAsync(string cacheName);
        public Task CreateAsync(string cacheName, byte[] data);
    }
}
