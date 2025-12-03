using Lab04_Osis.Domain.Repositories;
using Lab04_Osis.Models;

namespace Lab04_Osis.Domain.UnitOfWork
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IGenericRepository<Cliente> Clientes { get; }
        IGenericRepository<Producto> Productos { get; }
        IGenericRepository<Categoria> Categorias { get; }
        IGenericRepository<Orden> Ordenes { get; }
        IGenericRepository<DetallesOrden> DetallesOrden { get; }
        IGenericRepository<Pago> Pagos { get; }

        Task<int> SaveChangesAsync(CancellationToken ct = default);
    }
}