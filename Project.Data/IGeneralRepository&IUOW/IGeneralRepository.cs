using System.Linq.Expressions;

namespace OnTime.Data.IGenericRepository_IUOW
{
    public interface IGeneralRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int Id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<T> GetLastOrDefaultAsync<TKey>(Expression<Func<T, TKey>> keySelector);
        public Task<T> GetEntityByPropertyWithIncludeAsync(Expression<Func<T, bool>> attributeSelector, params Expression<Func<T, object>>[] includes);


     //   IQueryable<T> Find(Expression<Func<T, bool>> predicate, bool disableTracking = true, bool includeSoftDeleted = false);

    
        IQueryable<T> Find(Expression<Func<T, bool>> predicate, bool includeSoftDeleted = false, params string[] includes);

    
        Task<T> FindOneAsync(Expression<Func<T, bool>> predicate, bool includeSoftDeleted = false, params string[] includesPaths);

        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate, bool includeSoftDeleted = false, params string[] includes);

    }
}
