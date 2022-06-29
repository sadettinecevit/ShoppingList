using Microsoft.EntityFrameworkCore;
using ShoppingList.Application.Interfaces.Repositories;
using ShoppingList.Domain.Common;
using ShoppingList.Persistence.Context;

namespace ShoppingList.Persistence.Repository
{
    public class Repository<T> : IRepository<T> where T : class, IBaseEntity, new()
    {
        private readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        private DbSet<T> Table { get => _context.Set<T>(); }

        public virtual async Task<int> Add(T entity)
        {
            await Table.AddAsync(entity);
            return await _context.SaveChangesAsync();
        }

        public virtual async Task<int> Update(T entity)
        {
            Table.Update(entity);
            return await _context.SaveChangesAsync();
        }

        public virtual async Task<int> Delete(T entity)
        {
            Table.Remove(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAsync() => await Table.ToListAsync<T>();

        public async Task<T> GetByIdAsync(string id) => await Table.FindAsync(id);
    }
}
