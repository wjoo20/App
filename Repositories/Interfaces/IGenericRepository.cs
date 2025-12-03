using System.Linq.Expressions;

namespace Lab04_Osis.Domain.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync(CancellationToken ct = default);
        Task<T?> GetByIdAsync(CancellationToken ct = default, params object[] keyValues);
        Task AddAsync(T entity, CancellationToken ct = default);
        void Update(T entity);
        Task DeleteAsync(CancellationToken ct = default, params object[] keyValues);
        Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate, CancellationToken ct = default);
    }
}