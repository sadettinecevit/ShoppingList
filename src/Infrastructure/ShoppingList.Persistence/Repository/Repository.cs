using Microsoft.EntityFrameworkCore;
using ShoppingList.Application.Interfaces.Repositories;
using ShoppingList.Domain.Common;
using ShoppingList.Infrastructure.Services.Cache.Redis;
using ShoppingList.Persistence.Context;
using System.Text;
using System.Text.Json;

namespace ShoppingList.Persistence.Repository
{
    public class Repository<T> : RepositoryResponse<T>, IRepository<T> where T : class, IBaseEntity, new()
    {
        public string cacheName { get; set; }

        private readonly ApplicationDbContext _context;
        private readonly RedisCacheService _redisCacheService;

        public Repository(ApplicationDbContext context, RedisCacheService redisCacheService)
        {
            _context = context;
            _redisCacheService = redisCacheService;
        }

        private DbSet<T> Table { get => _context.Set<T>(); }

        public virtual async Task<RepositoryResponse<T>> Add(T entity)
        {
            T result = null;
            try
            {
                result = Table.AddAsync(entity).Result.Entity;
                await _context.SaveChangesAsync();
                await _redisCacheService.DeleteAsync(cacheName);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return new RepositoryResponse<T>()
            {
                Entity = result,
                TotalRecordCount = result != null ? 1 : 0
            };
        }

        public virtual async Task<RepositoryResponse<T>> Update(T entity)
        {
            T result = Table.Update(entity).Entity;
            int totalRecordCount = _context.SaveChanges();

            if (totalRecordCount > 0)
            {
                await _redisCacheService.DeleteAsync(cacheName);
            }

            return new RepositoryResponse<T>()
            {
                Entity = result,
                TotalRecordCount = TotalRecordCount
            };
        }

        public virtual async Task<RepositoryResponse<T>> Delete(T entity)
        {
            T result = null;
            try
            {
                result = Table.Remove(entity).Entity;
                await _redisCacheService.DeleteAsync(cacheName);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return new RepositoryResponse<T>()
            {
                Entity = result,
                TotalRecordCount = result != null ? 1 : 0
            };
        }

        public async Task<List<T>> GetAsync()
        {
            List<T> result = new List<T>();

            byte[] bytes = await _redisCacheService.GetAsync(cacheName);

            if (bytes != null)
            {
                string json = Encoding.UTF8.GetString(bytes);
                result = JsonSerializer.Deserialize<List<T>>(json);
            }
            else
            {
                result = await Table.ToListAsync<T>();
            }

            return result;
        }

        public async Task<T> GetByIdAsync(string id)
        {
            List<T> nosqlData = new List<T>();
            T result = new();

            byte[] bytes = await _redisCacheService.GetAsync(cacheName);

            if (bytes != null)
            {
                string json = Encoding.UTF8.GetString(bytes);
                nosqlData = JsonSerializer.Deserialize<List<T>>(json);
                result = nosqlData.FirstOrDefault(d => d.GetType().GetProperty("Id").GetValue(typeof(string)).ToString() == id);
            }
            else
            {
                result = await Table.FindAsync(id);
            }
            return result;
        }
    }
}
