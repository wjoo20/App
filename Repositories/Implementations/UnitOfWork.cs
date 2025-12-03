using Lab04_Osis.Domain.Repositories;
using Lab04_Osis.Domain.UnitOfWork;
using Lab04_Osis.Infrastructure.Repositories;
using Lab04_Osis.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab04_Osis.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _ctx;

        public IGenericRepository<Cliente> Clientes { get; }
        public IGenericRepository<Producto> Productos { get; }
        public IGenericRepository<Categoria> Categorias { get; }
        public IGenericRepository<Orden> Ordenes { get; }
        public IGenericRepository<DetallesOrden> DetallesOrden { get; }
        public IGenericRepository<Pago> Pagos { get; }

        public UnitOfWork(DbContext ctx)
        {
            _ctx = ctx;
            Clientes      = new GenericRepository<Cliente>(_ctx);
            Productos     = new GenericRepository<Producto>(_ctx);
            Categorias    = new GenericRepository<Categoria>(_ctx);
            Ordenes       = new GenericRepository<Orden>(_ctx);
            DetallesOrden = new GenericRepository<DetallesOrden>(_ctx);
            Pagos         = new GenericRepository<Pago>(_ctx);
        }

        public Task<int> SaveChangesAsync(CancellationToken ct = default)
            => _ctx.SaveChangesAsync(ct);

        public ValueTask DisposeAsync()
            => _ctx.DisposeAsync();
    }
}