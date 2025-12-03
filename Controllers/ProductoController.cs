using Lab04_Osis.Domain.UnitOfWork;
using Lab04_Osis.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab04_Osis.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        public ProductosController(IUnitOfWork uow) => _uow = uow;

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken ct)
            => Ok(await _uow.Productos.GetAllAsync(ct));

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id, CancellationToken ct)
        {
            var entity = await _uow.Productos.GetByIdAsync(ct, id);
            return entity is null ? NotFound() : Ok(entity);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Producto model, CancellationToken ct)
        {
            await _uow.Productos.AddAsync(model, ct);
            await _uow.SaveChangesAsync(ct);
            return CreatedAtAction(nameof(GetById), new { id = model.ProductoId }, model);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] Producto model, CancellationToken ct)
        {
            if (id != model.ProductoId) return BadRequest("ID mismatch");
            _uow.Productos.Update(model);
            await _uow.SaveChangesAsync(ct);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id, CancellationToken ct)
        {
            await _uow.Productos.DeleteAsync(ct, id);
            await _uow.SaveChangesAsync(ct);
            return NoContent();
        }
    }
}