using BackendRemis.Application.DTOs;
using BackendRemis.Application.Interfaces;
using BackendRemis.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BackendRemis.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DuenioAutoController : ControllerBase
    {
        private readonly IDuenioAutoRepository _duenioAutoRepository;

        public DuenioAutoController(IDuenioAutoRepository duenioAutoRepository)
        {
            _duenioAutoRepository = duenioAutoRepository;
        }

        // GET: api/DuenioAuto
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var duenios = await _duenioAutoRepository.GetAllAsync();
            var result = duenios.Select(d => new DuenioAutoDetailDto
            {
                Id = d.Id,
                Nombre = d.Nombre,
                Apellido = d.Apellido,
                Telefono = d.Telefono,
                Direccion = d.Direccion,
                Email = d.Email,
                DNI = d.DNI,
                CUIT_CUIL = d.CUIT_CUIL,
                TelefonosExtra = d.TelefonosExtra?.Select(te => te.Telefono).ToList(),
                DireccionesExtra = d.DireccionesExtra?.Select(de => de.Direccion).ToList(),
                Autos = d.Autos?.Select(a => new AutoSimpleDto
                {
                    Id = a.Id,
                    Patente = a.Patente,
                    Marca = a.Marca?.Nombre,
                    Modelo = a.Modelo?.Nombre
                }).ToList()
            });

            return Ok(result);
        }

        // GET: api/DuenioAuto/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var d = await _duenioAutoRepository.GetByIdAsync(id);
            if (d == null) return NotFound();

            var result = new DuenioAutoDetailDto
            {
                Id = d.Id,
                Nombre = d.Nombre,
                Apellido = d.Apellido,
                Telefono = d.Telefono,
                Direccion = d.Direccion,
                Email = d.Email,
                DNI = d.DNI,
                CUIT_CUIL = d.CUIT_CUIL,
                TelefonosExtra = d.TelefonosExtra?.Select(te => te.Telefono).ToList(),
                DireccionesExtra = d.DireccionesExtra?.Select(de => de.Direccion).ToList(),
                Autos = d.Autos?.Select(a => new AutoSimpleDto
                {
                    Id = a.Id,
                    Patente = a.Patente,
                    Marca = a.Marca?.Nombre,
                    Modelo = a.Modelo?.Nombre
                }).ToList()
            };
            return Ok(result);
        }

        // POST: api/DuenioAuto
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DuenioAutoCreateDto dto)
        {
            var duenio = new DuenioAuto
            {
                Nombre = dto.Nombre,
                Apellido = dto.Apellido,
                Telefono = dto.Telefono,
                Direccion = dto.Direccion,
                Email = dto.Email,
                DNI = dto.DNI,
                CUIT_CUIL = dto.CUIT_CUIL,
                TelefonosExtra = dto.TelefonosExtra?.Select(t => new TelefonoExtra { Telefono = t }).ToList(),
                DireccionesExtra = dto.DireccionesExtra?.Select(d => new DireccionExtra { Direccion = d }).ToList()
            };

            await _duenioAutoRepository.AddAsync(duenio);
            // Devuelve el detalle recién creado
            var result = new DuenioAutoDetailDto
            {
                Id = duenio.Id,
                Nombre = duenio.Nombre,
                Apellido = duenio.Apellido,
                Telefono = duenio.Telefono,
                Direccion = duenio.Direccion,
                Email = duenio.Email,
                DNI = duenio.DNI,
                CUIT_CUIL = duenio.CUIT_CUIL,
                TelefonosExtra = duenio.TelefonosExtra?.Select(te => te.Telefono).ToList(),
                DireccionesExtra = duenio.DireccionesExtra?.Select(de => de.Direccion).ToList(),
                Autos = new List<AutoSimpleDto>() // vacío al crear
            };
            return CreatedAtAction(nameof(GetById), new { id = duenio.Id }, result);
        }

        // PUT: api/DuenioAuto/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] DuenioAutoCreateDto dto)
        {
            var duenio = await _duenioAutoRepository.GetByIdAsync(id);
            if (duenio == null) return NotFound();

            duenio.Nombre = dto.Nombre;
            duenio.Apellido = dto.Apellido;
            duenio.Telefono = dto.Telefono;
            duenio.Direccion = dto.Direccion;
            duenio.Email = dto.Email;
            duenio.DNI = dto.DNI;
            duenio.CUIT_CUIL = dto.CUIT_CUIL;
            duenio.TelefonosExtra = dto.TelefonosExtra?.Select(t => new TelefonoExtra { Telefono = t }).ToList();
            duenio.DireccionesExtra = dto.DireccionesExtra?.Select(d => new DireccionExtra { Direccion = d }).ToList();

            await _duenioAutoRepository.UpdateAsync(duenio);
            return NoContent();
        }

        // DELETE: api/DuenioAuto/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var duenio = await _duenioAutoRepository.GetByIdAsync(id);
            if (duenio == null) return NotFound();

            // --- MENSAJE PREVENTIVO ---
            // En una API REST "pura", el backend no puede "mostrar mensaje y preguntar" al usuario,
            // pero SÍ podés rechazar el borrado si tiene autos asociados, o devolver un error con mensaje.
            if (duenio.Autos != null && duenio.Autos.Count > 0)
            {
                return BadRequest("No se puede eliminar el dueño: tiene autos asociados. Elimine los autos primero.");
            }

            await _duenioAutoRepository.DeleteAsync(duenio);
            return NoContent();
        }
    }

}
