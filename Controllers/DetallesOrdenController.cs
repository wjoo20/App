using Lab04_Osis.Domain.UnitOfWork;
using Lab04_Osis.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab04_Osis.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DetallesOrdenController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        public DetallesOrdenController(IUnitOfWork uow) => _uow = uow;

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken ct)
            => Ok(await _uow.DetallesOrden.GetAllAsync(ct));

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id, CancellationToken ct)
        {
            var entity = await _uow.DetallesOrden.GetByIdAsync(ct, id);
            return entity is null ? NotFound() : Ok(entity);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DetallesOrden model, CancellationToken ct)
        {
            await _uow.DetallesOrden.AddAsync(model, ct);
            await _uow.SaveChangesAsync(ct);
            return CreatedAtAction(nameof(GetById), new { id = model.DetalleId }, model);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] DetallesOrden model, CancellationToken ct)
        {
            if (id != model.DetalleId) return BadRequest("ID mismatch");
            _uow.DetallesOrden.Update(model);
            await _uow.SaveChangesAsync(ct);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id, CancellationToken ct)
        {
            await _uow.DetallesOrden.DeleteAsync(ct, id);
            await _uow.SaveChangesAsync(ct);
            return NoContent();
        }
    }
}