using BackendRemis.Application.DTOs;
using BackendRemis.Application.Interfaces;
using BackendRemis.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BackendRemis.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChoferController : ControllerBase
    {
        private readonly IChoferRepository _choferRepository;

        public ChoferController(IChoferRepository choferRepository)
        {
            _choferRepository = choferRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var choferes = await _choferRepository.GetAllAsync();
            var result = choferes.Select(c => new ChoferDetailDto
            {
                Id = c.Id,
                Nombre = c.Nombre,
                Apellido = c.Apellido,
                Telefono = c.Telefono,
                Direccion = c.Direccion,
                Email = c.Email,
                DNI = c.DNI,
                Cuitcuil = c.CUIT_CUIL,
                NumeroLicencia = c.NumeroLicencia,
                FechaVencimientoLicencia = c.FechaVencimientoLicencia,
                TelefonosExtra = c.TelefonosExtra?.Select(te => te.Telefono).ToList() ?? new(),
                DireccionesExtra = c.DireccionesExtra?.Select(de => de.Direccion).ToList() ?? new()
            });

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var c = await _choferRepository.GetByIdAsync(id);
            if (c == null) return NotFound();

            var result = new ChoferDetailDto
            {
                Id = c.Id,
                Nombre = c.Nombre,
                Apellido = c.Apellido,
                Telefono = c.Telefono,
                Direccion = c.Direccion,
                Email = c.Email,
                DNI = c.DNI,
                Cuitcuil = c.CUIT_CUIL,
                NumeroLicencia = c.NumeroLicencia,
                FechaVencimientoLicencia = c.FechaVencimientoLicencia,
                TelefonosExtra = c.TelefonosExtra?.Select(te => te.Telefono).ToList() ?? new(),
                DireccionesExtra = c.DireccionesExtra?.Select(de => de.Direccion).ToList() ?? new()
            };

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ChoferCreateDto dto)
        {
            var chofer = new Chofer
            {
                Nombre = dto.Nombre,
                Apellido = dto.Apellido,
                Telefono = dto.Telefono,
                Direccion = dto.Direccion,
                Email = dto.Email,
                DNI = dto.DNI,
                CUIT_CUIL = dto.Cuitcuil,
                NumeroLicencia = dto.NumeroLicencia,
                FechaVencimientoLicencia = dto.FechaVencimientoLicencia,
                TelefonosExtra = dto.TelefonosExtra?.Select(t => new TelefonoExtra { Telefono = t }).ToList(),
                DireccionesExtra = dto.DireccionesExtra?.Select(d => new DireccionExtra { Direccion = d }).ToList()
            };

            await _choferRepository.AddAsync(chofer);

            return CreatedAtAction(nameof(GetById), new { id = chofer.Id }, chofer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] ChoferCreateDto dto)
        {
            var chofer = await _choferRepository.GetByIdAsync(id);
            if (chofer == null) return NotFound();

            chofer.Nombre = dto.Nombre;
            chofer.Apellido = dto.Apellido;
            chofer.Telefono = dto.Telefono;
            chofer.Direccion = dto.Direccion;
            chofer.Email = dto.Email;
            chofer.DNI = dto.DNI;
            chofer.CUIT_CUIL = dto.Cuitcuil;
            chofer.NumeroLicencia = dto.NumeroLicencia;
            chofer.FechaVencimientoLicencia = dto.FechaVencimientoLicencia;
            chofer.TelefonosExtra = dto.TelefonosExtra?.Select(t => new TelefonoExtra { Telefono = t }).ToList();
            chofer.DireccionesExtra = dto.DireccionesExtra?.Select(d => new DireccionExtra { Direccion = d }).ToList();

            await _choferRepository.UpdateAsync(chofer);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var chofer = await _choferRepository.GetByIdAsync(id);
            if (chofer == null) return NotFound();

            await _choferRepository.DeleteAsync(chofer);
            return NoContent();
        }
    }
}
