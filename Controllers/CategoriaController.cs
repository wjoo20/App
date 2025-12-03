using Lab04_Osis.Domain.UnitOfWork;
using Lab04_Osis.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab04_Osis.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriasController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        public CategoriasController(IUnitOfWork uow) => _uow = uow;

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken ct)
            => Ok(await _uow.Categorias.GetAllAsync(ct));

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id, CancellationToken ct)
        {
            var entity = await _uow.Categorias.GetByIdAsync(ct, id);
            return entity is null ? NotFound() : Ok(entity);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Categoria model, CancellationToken ct)
        {
            await _uow.Categorias.AddAsync(model, ct);
            await _uow.SaveChangesAsync(ct);
            return CreatedAtAction(nameof(GetById), new { id = model.CategoriaId }, model);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] Categoria model, CancellationToken ct)
        {
            if (id != model.CategoriaId) return BadRequest("ID mismatch");
            _uow.Categorias.Update(model);
            await _uow.SaveChangesAsync(ct);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id, CancellationToken ct)
        {
            await _uow.Categorias.DeleteAsync(ct, id);
            await _uow.SaveChangesAsync(ct);
            return NoContent();
        }
    }
}