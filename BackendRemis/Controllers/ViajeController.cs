using Microsoft.AspNetCore.Mvc;
using BackendRemis.Application.Interfaces;
using BackendRemis.Application.DTOs;
using BackendRemis.Domain.Entities;
using BackendRemis.Domain.Enums;

namespace BackendRemis.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ViajeController : ControllerBase
    {
        private readonly IViajeRepository _viajes;
        private readonly IAutoRepository _autos;
        private readonly IChoferRepository _choferes;
        private readonly IClienteRepository _clientes;

        public ViajeController(
            IViajeRepository viajes,
            IAutoRepository autos,
            IChoferRepository choferes,
            IClienteRepository clientes)
        {
            _viajes = viajes;
            _autos = autos;
            _choferes = choferes;
            _clientes = clientes;
        }

        // POST /api/viaje
        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] ViajeCreateDto dto)
        {
            // Validaciones mínimas (podés sumar más)
            if (string.IsNullOrWhiteSpace(dto.DireccionOrigen) && dto.CodigoDireccionFrecuenteId == null)
                return BadRequest("Debe indicar una dirección de origen o un código frecuente.");

            var origen = OrigenSolicitudViaje.Telefono;
            if (!string.IsNullOrWhiteSpace(dto.Origen) &&
                Enum.TryParse<OrigenSolicitudViaje>(dto.Origen, true, out var o))
                origen = o;

            var v = new Viaje
            {
                DireccionOrigen = dto.DireccionOrigen,
                EntreCalle1 = dto.EntreCalle1,
                EntreCalle2 = dto.EntreCalle2,
                ObservacionesDireccion = dto.ObservacionesDireccion,
                DireccionDestino = dto.DireccionDestino,
                FechaHoraProgramada = dto.FechaHoraProgramada,
                FechaHoraSolicitud = DateTime.UtcNow,
                TelefonoContacto = dto.TelefonoContacto,
                NombreContacto = dto.NombreContacto,
                CodigoDireccionFrecuenteId = dto.CodigoDireccionFrecuenteId,
                ClienteId = dto.ClienteId,
                NumeroOperador = dto.NumeroOperador,
                Origen = origen,
                Estado = EstadoViaje.Pendiente,
                CuentaCorrienteId = dto.CuentaCorrienteId,
                OrigenLat = dto.OrigenLat,
                OrigenLng = dto.OrigenLng,
                DestinoLat = dto.DestinoLat,
                DestinoLng = dto.DestinoLng,
                DistanciaMetros = dto.DistanciaMetros,
                DuracionSegundos = dto.DuracionSegundos
            };

            await _viajes.AddAsync(v);
            return CreatedAtAction(nameof(Obtener), new { id = v.Id }, new { id = v.Id });
        }

        // GET /api/viaje/{id}
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Obtener(Guid id)
        {
            var v = await _viajes.GetByIdAsync(id);
            if (v == null) return NotFound();

            return Ok(MapDetail(v));
        }

        // GET /api/viaje?skip=0&take=50
        [HttpGet]
        public async Task<IActionResult> Listar([FromQuery] int skip = 0, [FromQuery] int take = 50)
        {
            var all = await _viajes.GetAllAsync();
            var list = all
                .OrderByDescending(x => x.FechaHoraSolicitud)
                .Skip(skip).Take(take)
                .Select(MapDetail)
                .ToList();

            return Ok(list);
        }

        // POST /api/viaje/asignar
        [HttpPost("asignar")]
        public async Task<IActionResult> Asignar([FromBody] ViajeAssignDto dto)
        {
            var v = await _viajes.GetByIdAsync(dto.ViajeId);
            if (v == null) return NotFound("Viaje no encontrado.");

            var auto = await _autos.GetByIdAsync(dto.AutoId);
            if (auto == null) return NotFound("Auto no encontrado.");

            var chofer = await _choferes.GetByIdAsync(dto.ChoferId);
            if (chofer == null) return NotFound("Chofer no encontrado.");

            if (auto.Estado == EstadoAuto.FueraDeServicio)
                return BadRequest("El auto está fuera de servicio.");

            v.AutoId = auto.Id;
            v.ChoferId = chofer.Id;
            v.FechaHoraAsignacion = DateTime.UtcNow;
            // Estado sigue Pendiente hasta que se inicie
            await _viajes.UpdateAsync(v);

            return NoContent();
        }

        // POST /api/viaje/estado
        [HttpPost("estado")]
        public async Task<IActionResult> CambiarEstado([FromBody] ViajeStatusDto dto)
        {
            var v = await _viajes.GetByIdAsync(dto.ViajeId);
            if (v == null) return NotFound("Viaje no encontrado.");

            if (!Enum.TryParse<EstadoViaje>(dto.NuevoEstado, true, out var nuevo))
                return BadRequest("Estado inválido.");

            switch (nuevo)
            {
                case EstadoViaje.EnCurso:
                    v.FechaHoraInicio = DateTime.UtcNow;
                    break;
                case EstadoViaje.Finalizado:
                    v.FechaHoraFin = DateTime.UtcNow;
                    v.Calificacion = dto.Calificacion;
                    v.Nota = dto.Nota;
                    break;
                case EstadoViaje.Cancelado:
                    v.Nota = string.IsNullOrWhiteSpace(dto.Nota) ? "Cancelado" : dto.Nota;
                    break;
            }

            v.Estado = nuevo;
            await _viajes.UpdateAsync(v);
            return NoContent();
        }

        // ----- helpers locales (mapeo manual) -----
        private static ViajeDetailDto MapDetail(Viaje v) => new ViajeDetailDto
        {
            Id = v.Id,
            DireccionOrigen = v.DireccionOrigen,
            EntreCalle1 = v.EntreCalle1,
            EntreCalle2 = v.EntreCalle2,
            ObservacionesDireccion = v.ObservacionesDireccion,
            DireccionDestino = v.DireccionDestino,
            FechaHoraProgramada = v.FechaHoraProgramada,
            FechaHoraSolicitud = v.FechaHoraSolicitud,
            FechaHoraAsignacion = v.FechaHoraAsignacion,
            FechaHoraInicio = v.FechaHoraInicio,
            FechaHoraFin = v.FechaHoraFin,
            TelefonoContacto = v.TelefonoContacto,
            NombreContacto = v.NombreContacto,
            ClienteId = v.ClienteId,
            ClienteNombre = v.Cliente != null ? $"{v.Cliente.Nombre} {v.Cliente.Apellido}" : null,
            ChoferId = v.ChoferId,
            ChoferNombre = v.Chofer != null ? $"{v.Chofer.Nombre} {v.Chofer.Apellido}" : null,
            AutoId = v.AutoId,
            AutoPatente = v.Auto?.Patente,
            Estado = v.Estado.ToString(),
            Origen = v.Origen.ToString(),
            Calificacion = v.Calificacion,
            Nota = v.Nota
        };
    }
}
