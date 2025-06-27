using BackendRemis.Application.DTOs;
using BackendRemis.Application.Interfaces;
using BackendRemis.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BackendRemis.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ModeloController : ControllerBase
    {
        private readonly IModeloRepository _modeloRepository;

        public ModeloController(IModeloRepository modeloRepository)
        {
            _modeloRepository = modeloRepository;
        }

        // GET: api/Modelo
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var modelos = await _modeloRepository.GetAllAsync();
            var result = modelos.Select(m => new ModeloDto
            {
                Id = m.Id,
                Nombre = m.Nombre,
                MarcaId = m.MarcaId
            });
            return Ok(result);
        }

        // GET: api/Modelo/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var modelo = await _modeloRepository.GetByIdAsync(id);
            if (modelo == null) return NotFound();
            var dto = new ModeloDto
            {
                Id = modelo.Id,
                Nombre = modelo.Nombre,
                MarcaId = modelo.MarcaId
            };
            return Ok(dto);
        }

        // POST: api/Modelo
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ModeloCreateDto dto)
        {
            var modelo = new Modelo
            {
                Nombre = dto.Nombre,
                MarcaId = dto.MarcaId
            };

            await _modeloRepository.AddAsync(modelo);

            var result = new ModeloDto
            {
                Id = modelo.Id,
                Nombre = modelo.Nombre,
                MarcaId = modelo.MarcaId
            };

            return CreatedAtAction(nameof(GetById), new { id = modelo.Id }, result);
        }

        // PUT: api/Modelo/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] ModeloCreateDto dto)
        {
            var modelo = await _modeloRepository.GetByIdAsync(id);
            if (modelo == null) return NotFound();

            modelo.Nombre = dto.Nombre;
            modelo.MarcaId = dto.MarcaId;

            await _modeloRepository.UpdateAsync(modelo);
            return NoContent();
        }

        // DELETE: api/Modelo/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var modelo = await _modeloRepository.GetByIdAsync(id);
            if (modelo == null) return NotFound();

            await _modeloRepository.DeleteAsync(modelo);
            return NoContent();
        }
    }
}
