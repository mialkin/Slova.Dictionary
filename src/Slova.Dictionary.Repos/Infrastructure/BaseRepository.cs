using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Slova.Dictionary.Repos.Infrastructure
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext Context;
        private readonly DbSet<T> _set;

        protected BaseRepository(DbContext context)
        {
            Context = context;

            _set = Context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            List<T> result = await _set.ToListAsync();
            return result;
        }

        public async Task AddAsync(T entity)
        {
            await _set.AddAsync(entity);
        }

        public Task<int> SaveChangesAsync()
        {
            return Context.SaveChangesAsync();
        }
    }
}