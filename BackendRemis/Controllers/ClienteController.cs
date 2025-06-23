using BackendRemis.Application.DTOs;
using BackendRemis.Domain.Entities;
using BackendRemis.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackendRemis.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        // GET: api/Cliente
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClienteResponseDto>>> GetAll()
        {
            var clientes = await _clienteRepository.GetAllAsync();
            var response = clientes.Select(cliente => new ClienteResponseDto
            {
                Id = cliente.Id,
                Nombre = cliente.Nombre,
                Apellido = cliente.Apellido,
                Telefono = cliente.Telefono,
                Direccion = cliente.Direccion,
                Email = cliente.Email
            });
            return Ok(response);
        }

        // GET: api/Cliente/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteResponseDto>> GetById(Guid id)
        {
            var cliente = await _clienteRepository.GetByIdAsync(id);
            if (cliente == null) return NotFound();

            var response = new ClienteResponseDto
            {
                Id = cliente.Id,
                Nombre = cliente.Nombre,
                Apellido = cliente.Apellido,
                Telefono = cliente.Telefono,
                Direccion = cliente.Direccion,
                Email = cliente.Email
            };
            return Ok(response);
        }

        // POST: api/Cliente
        [HttpPost]
        public async Task<ActionResult<ClienteResponseDto>> Create([FromBody] ClienteCreateDto dto)
        {
            var cliente = new Cliente
            {
                Nombre = dto.Nombre,
                Apellido = dto.Apellido,
                Telefono = dto.Telefono,
                Direccion = dto.Direccion,
                Email = dto.Email,
                RegistrosDeSesion = new List<RegistroDeSesion>()
            };

            await _clienteRepository.AddAsync(cliente);

            var response = new ClienteResponseDto
            {
                Id = cliente.Id,
                Nombre = cliente.Nombre,
                Apellido = cliente.Apellido,
                Telefono = cliente.Telefono,
                Direccion = cliente.Direccion,
                Email = cliente.Email
            };

            return CreatedAtAction(nameof(GetById), new { id = cliente.Id }, response);
        }

        // PUT: api/Cliente/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] ClienteUpdateDto dto)
        {
            var cliente = await _clienteRepository.GetByIdAsync(id);
            if (cliente == null) return NotFound();

            cliente.Nombre = dto.Nombre;
            cliente.Apellido = dto.Apellido;
            cliente.Telefono = dto.Telefono;
            cliente.Direccion = dto.Direccion;
            cliente.Email = dto.Email;

            await _clienteRepository.UpdateAsync(cliente);
            return NoContent();
        }

        // DELETE: api/Cliente/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var cliente = await _clienteRepository.GetByIdAsync(id);
            if (cliente == null) return NotFound();

            await _clienteRepository.DeleteAsync(cliente);
            return NoContent();
        }

    }
}
