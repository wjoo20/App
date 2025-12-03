using System.Linq.Expressions;
using Lab04_Osis.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Lab04_Osis.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly DbContext _ctx;
        protected readonly DbSet<T> _set;

        public GenericRepository(DbContext context)
        {
            _ctx = context;
            _set = _ctx.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync(CancellationToken ct = default)
            => await _set.AsNoTracking().ToListAsync(ct);

        public async Task<T?> GetByIdAsync(CancellationToken ct = default, params object[] keyValues)
            => await _set.FindAsync(keyValues, ct);

        public async Task AddAsync(T entity, CancellationToken ct = default)
            => await _set.AddAsync(entity, ct);

        public void Update(T entity)
            => _set.Update(entity);

        public async Task DeleteAsync(CancellationToken ct = default, params object[] keyValues)
        {
            var entity = await _set.FindAsync(keyValues, ct);
            if (entity is not null) _set.Remove(entity);
        }

        public Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate, CancellationToken ct = default)
            => _set.AsNoTracking().AnyAsync(predicate, ct);
    }
}