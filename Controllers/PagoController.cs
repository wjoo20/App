using Lab04_Osis.Domain.UnitOfWork;
using Lab04_Osis.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab04_Osis.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PagosController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        public PagosController(IUnitOfWork uow) => _uow = uow;

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken ct)
            => Ok(await _uow.Pagos.GetAllAsync(ct));

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id, CancellationToken ct)
        {
            var entity = await _uow.Pagos.GetByIdAsync(ct, id);
            return entity is null ? NotFound() : Ok(entity);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Pago model, CancellationToken ct)
        {
            await _uow.Pagos.AddAsync(model, ct);
            await _uow.SaveChangesAsync(ct);
            return CreatedAtAction(nameof(GetById), new { id = model.PagoId }, model);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] Pago model, CancellationToken ct)
        {
            if (id != model.PagoId) return BadRequest("ID mismatch");
            _uow.Pagos.Update(model);
            await _uow.SaveChangesAsync(ct);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id, CancellationToken ct)
        {
            await _uow.Pagos.DeleteAsync(ct, id);
            await _uow.SaveChangesAsync(ct);
            return NoContent();
        }
    }
}