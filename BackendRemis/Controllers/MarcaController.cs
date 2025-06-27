using Microsoft.AspNetCore.Mvc;
using BackendRemis.Application.Interfaces;
using BackendRemis.Domain.Entities;
using BackendRemis.Application.DTOs;

namespace BackendRemis.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MarcaController : ControllerBase
    {
        private readonly IMarcaRepository _marcaRepository;

        public MarcaController(IMarcaRepository marcaRepository)
        {
            _marcaRepository = marcaRepository;
        }

        // GET: api/Marca
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var marcas = await _marcaRepository.GetAllAsync();
            var result = marcas.Select(m => new MarcaDto
            {
                Id = m.Id,
                Nombre = m.Nombre
            });
            return Ok(result);
        }

        // GET: api/Marca/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var marca = await _marcaRepository.GetByIdAsync(id);
            if (marca == null)
                return NotFound();
            var result = new MarcaDto
            {
                Id = marca.Id,
                Nombre = marca.Nombre
            };
            return Ok(result);
        }

        // POST: api/Marca
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MarcaDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Nombre))
                return BadRequest("El nombre de la marca es requerido.");

            var marca = new Marca
            {
                Nombre = dto.Nombre
            };
            await _marcaRepository.AddAsync(marca);

            dto.Id = marca.Id; // Retornamos el id generado

            return CreatedAtAction(nameof(GetById), new { id = marca.Id }, dto);
        }

        // PUT: api/Marca/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] MarcaDto dto)
        {
            var marca = await _marcaRepository.GetByIdAsync(id);
            if (marca == null)
                return NotFound();

            marca.Nombre = dto.Nombre;
            await _marcaRepository.UpdateAsync(marca);

            return NoContent();
        }

        // DELETE: api/Marca/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var marca = await _marcaRepository.GetByIdAsync(id);
            if (marca == null)
                return NotFound();

            await _marcaRepository.DeleteAsync(marca);
            return NoContent();
        }
    }
}
