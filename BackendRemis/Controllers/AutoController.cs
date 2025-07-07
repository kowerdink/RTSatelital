using BackendRemis.Application.DTOs;
using BackendRemis.Application.Interfaces;
using BackendRemis.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BackendRemis.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AutoController : ControllerBase
    {
        private readonly IAutoRepository _autoRepository;
        private readonly IMarcaRepository _marcaRepository;
        private readonly IModeloRepository _modeloRepository;
        private readonly IDuenioAutoRepository _duenioAutoRepository;
        private readonly IChoferRepository _choferRepository;

        public AutoController(
            IAutoRepository autoRepository,
            IMarcaRepository marcaRepository,
            IModeloRepository modeloRepository,
            IDuenioAutoRepository duenioAutoRepository,
            IChoferRepository choferRepository)
        {
            _autoRepository = autoRepository;
            _marcaRepository = marcaRepository;
            _modeloRepository = modeloRepository;
            _duenioAutoRepository = duenioAutoRepository;
            _choferRepository = choferRepository;
        }

        // GET: api/Auto
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var autos = await _autoRepository.GetAllAsync();
            var result = autos.Select(a => new AutoDetailDto
            {
                Id = a.Id,
                Patente = a.Patente,
                Color = a.Color,
                Anio = a.Anio,
                NumeroMovil = a.NumeroMovil,
                Seguro = a.Seguro,
                FechaVencimientoSeguro = a.FechaVencimientoSeguro,
                FechaVencimientoVTV = a.FechaVencimientoVTV,
                Marca = a.Marca?.Nombre ?? "",
                Modelo = a.Modelo?.Nombre ?? "",
                Estado = a.Estado.ToString(),
                DuenioAutoId = a.DuenioAutoId,
                DuenioNombre = a.DuenioAuto != null ? $"{a.DuenioAuto.Nombre} {a.DuenioAuto.Apellido}" : "",
                ChoferId = a.ChoferId,
                ChoferNombre = a.Chofer != null ? $"{a.Chofer.Nombre} {a.Chofer.Apellido}" : null
            });
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var auto = await _autoRepository.GetByIdAsync(id);

            if (auto == null)
                return NotFound();

            var dto = new AutoDetailDto
            {
                Id = auto.Id,
                Patente = auto.Patente,
                Color = auto.Color,
                NumeroMovil = auto.NumeroMovil,
                Anio = auto.Anio,
                Seguro = auto.Seguro,
                FechaVencimientoSeguro = auto.FechaVencimientoSeguro,
                FechaVencimientoVTV = auto.FechaVencimientoVTV,
                Marca = auto.Marca?.Nombre ?? "",
                Modelo = auto.Modelo?.Nombre ?? "",
                Estado = auto.Estado.ToString(),
                DuenioNombre = $"{auto.DuenioAuto?.Nombre} {auto.DuenioAuto?.Apellido}",
                ChoferesAsignados = auto.AutoChoferes?
                    .Where(ac => ac.EstaHabilitado)
                    .Select(ac => new ChoferSimpleDto
                    {
                        Id = ac.Chofer.Id,
                        Nombre = ac.Chofer.Nombre,
                        Apellido = ac.Chofer.Apellido,
                        Telefono = ac.Chofer.Telefono
                    })
                    .ToList() ?? new List<ChoferSimpleDto>()
            };

            return Ok(dto);
        }

        // POST: api/Auto
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AutoCreateDto dto)
        {
            // Validaciones
            var marca = await _marcaRepository.GetByIdAsync(dto.MarcaId);
            if (marca == null) return BadRequest("Marca no encontrada.");
            var modelo = await _modeloRepository.GetByIdAsync(dto.ModeloId);
            if (modelo == null) return BadRequest("Modelo no encontrado.");
            var duenio = await _duenioAutoRepository.GetByIdAsync(dto.DuenioAutoId);
            if (duenio == null) return BadRequest("Dueño no encontrado.");

            Chofer? chofer = null;
            if (dto.ChoferId.HasValue)
            {
                chofer = await _choferRepository.GetByIdAsync(dto.ChoferId.Value);
                if (chofer == null) return BadRequest("Chofer no encontrado.");
            }

            var auto = new Auto
            {
                Patente = dto.Patente,
                MarcaId = dto.MarcaId,
                ModeloId = dto.ModeloId,
                Anio = dto.Anio,
                Color = dto.Color,
                NumeroMovil = dto.NumeroMovil,
                Seguro = dto.Seguro,
                FechaVencimientoSeguro = dto.FechaVencimientoSeguro,
                FechaVencimientoVTV = dto.FechaVencimientoVTV,
                DuenioAutoId = dto.DuenioAutoId,
                ChoferId = dto.ChoferId
            };

            await _autoRepository.AddAsync(auto);

            var result = new AutoDetailDto
            {
                Id = auto.Id,
                Patente = auto.Patente,
                Color = auto.Color,
                Anio = auto.Anio,
                NumeroMovil = auto.NumeroMovil,
                Seguro = auto.Seguro,
                FechaVencimientoSeguro = auto.FechaVencimientoSeguro,
                FechaVencimientoVTV = auto.FechaVencimientoVTV,
                Marca = marca.Nombre,
                Modelo = modelo.Nombre,
                Estado = auto.Estado.ToString(),
                DuenioAutoId = duenio.Id,
                DuenioNombre = $"{duenio.Nombre} {duenio.Apellido}",
                ChoferId = auto.ChoferId,
                ChoferNombre = chofer != null ? $"{chofer.Nombre} {chofer.Apellido}" : null
            };
            return CreatedAtAction(nameof(GetById), new { id = auto.Id }, result);
        }

        // PUT: api/Auto/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] AutoCreateDto dto)
        {
            var auto = await _autoRepository.GetByIdAsync(id);
            if (auto == null) return NotFound();

            var marca = await _marcaRepository.GetByIdAsync(dto.MarcaId);
            if (marca == null) return BadRequest("Marca no encontrada.");
            var modelo = await _modeloRepository.GetByIdAsync(dto.ModeloId);
            if (modelo == null) return BadRequest("Modelo no encontrado.");
            var duenio = await _duenioAutoRepository.GetByIdAsync(dto.DuenioAutoId);
            if (duenio == null) return BadRequest("Dueño no encontrado.");

            Chofer? chofer = null;
            if (dto.ChoferId.HasValue)
            {
                chofer = await _choferRepository.GetByIdAsync(dto.ChoferId.Value);
                if (chofer == null) return BadRequest("Chofer no encontrado.");
            }

            auto.Patente = dto.Patente;
            auto.MarcaId = dto.MarcaId;
            auto.ModeloId = dto.ModeloId;
            auto.Anio = dto.Anio;
            auto.Color = dto.Color;
            auto.NumeroMovil = dto.NumeroMovil;
            auto.Seguro = dto.Seguro;
            auto.FechaVencimientoSeguro = dto.FechaVencimientoSeguro;
            auto.FechaVencimientoVTV = dto.FechaVencimientoVTV;
            auto.DuenioAutoId = dto.DuenioAutoId;
            auto.ChoferId = dto.ChoferId;

            await _autoRepository.UpdateAsync(auto);
            return NoContent();
        }

        // DELETE: api/Auto/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var auto = await _autoRepository.GetByIdAsync(id);
            if (auto == null) return NotFound();

            await _autoRepository.DeleteAsync(auto);
            return NoContent();
        }

        // POST: api/Auto/{autoId}/AgregarChofer/{choferId}
        [HttpPost("{autoId}/AgregarChofer/{choferId}")]
        public async Task<IActionResult> AgregarChofer(Guid autoId, Guid choferId)
        {
            // 1. Buscar el auto
            var auto = await _autoRepository.GetByIdAsync(autoId);
            if (auto == null) return NotFound("Auto no encontrado");

            // 2. Buscar el chofer
            var chofer = await _choferRepository.GetByIdAsync(choferId);
            if (chofer == null) return NotFound("Chofer no encontrado");

            // 3. Verificar si ya existe la relación
            if (auto.AutoChoferes.Any(ac => ac.ChoferId == choferId))
                return BadRequest("Este chofer ya está habilitado para este auto");

            // 4. Agregar relación
            auto.AutoChoferes.Add(new AutoChofer { AutoId = autoId, ChoferId = choferId });
            await _autoRepository.UpdateAsync(auto);

            return Ok("Chofer agregado correctamente");
        }

        // DELETE: api/Auto/{autoId}/QuitarChofer/{choferId}
        [HttpDelete("{autoId}/QuitarChofer/{choferId}")]
        public async Task<IActionResult> QuitarChofer(Guid autoId, Guid choferId)
        {
            var auto = await _autoRepository.GetByIdAsync(autoId);
            if (auto == null) return NotFound("Auto no encontrado");

            var relacion = auto.AutoChoferes.FirstOrDefault(ac => ac.ChoferId == choferId);
            if (relacion == null)
                return NotFound("Ese chofer no está habilitado para este auto");

            auto.AutoChoferes.Remove(relacion);
            await _autoRepository.UpdateAsync(auto);

            return Ok("Chofer quitado correctamente");
        }

        // POST: api/Auto/{autoId}/AsignarChoferes
        [HttpPost("{autoId}/AsignarChoferes")]
        public async Task<IActionResult> AsignarChoferes(Guid autoId, [FromBody] AsignarChoferesDto dto)
        {
            var auto = await _autoRepository.GetByIdAsync(autoId);
            if (auto == null) return NotFound("Auto no encontrado");

            var agregados = new List<Guid>();
            foreach (var choferId in dto.ChoferIds)
            {
                if (!auto.AutoChoferes.Any(ac => ac.ChoferId == choferId))
                {
                    auto.AutoChoferes.Add(new AutoChofer { AutoId = autoId, ChoferId = choferId });
                    agregados.Add(choferId);
                }
            }
            await _autoRepository.UpdateAsync(auto);

            return Ok(new { agregados, mensaje = "Choferes asignados correctamente" });
        }

        // DELETE: api/Auto/{autoId}/QuitarChoferes
        [HttpDelete("{autoId}/QuitarChoferes")]
        public async Task<IActionResult> QuitarChoferes(Guid autoId, [FromBody] AsignarChoferesDto dto)
        {
            var auto = await _autoRepository.GetByIdAsync(autoId);
            if (auto == null) return NotFound("Auto no encontrado");

            var quitados = new List<Guid>();
            foreach (var choferId in dto.ChoferIds)
            {
                var relacion = auto.AutoChoferes.FirstOrDefault(ac => ac.ChoferId == choferId);
                if (relacion != null)
                {
                    auto.AutoChoferes.Remove(relacion);
                    quitados.Add(choferId);
                }
            }
            await _autoRepository.UpdateAsync(auto);

            return Ok(new { quitados, mensaje = "Choferes quitados correctamente" });
        }

    }
}
