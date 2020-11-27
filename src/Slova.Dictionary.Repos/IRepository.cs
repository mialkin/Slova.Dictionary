using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Slova.Dictionary.Repos
{
    public interface IRepository<T> where T : class
    {
        // IEnumerable<T> Get(
        //     Expression<Func<T, bool>> filter = null,
        //     Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        //     string[] includeProperties = null);

        // T Get(int id);

        Task<IEnumerable<T>> GetAllAsync();

        // IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        //
        // T SingleOrDefault(Expression<Func<T, bool>> predicate);
        //
        // T First(Expression<Func<T, bool>> predicate);
        //
        // T FirstOrDefault();
        //
        // void Add(T entity);
        //
        // void AddRange(IEnumerable<T> entities);
        //
        // void Remove(T entity);
        //
        // void RemoveRange(IEnumerable<T> entities);
        //
        // void RemoveEntity(T entityToDelete);
        //
        // void UpdateEntity(T entityToUpdate);
        //
        // Task SaveChangesAsync();
    }
}