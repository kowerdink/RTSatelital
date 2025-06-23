using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackendRemis.Application.Interfaces;
using BackendRemis.Domain.Entities;
using BackendRemis.Domain.Enums;

namespace BackendRemis.Application.Interfaces
{
    public interface IViajeRepository : IGenericRepository<Viaje>
    {
        Task<IEnumerable<Viaje>> GetViajesPorEstadoAsync(EstadoViaje estado);
        Task<IEnumerable<Viaje>> BuscarViajesPorTelefonoAsync(string telefono);
        Task<IEnumerable<Viaje>> GetViajesPorFechaAsync(DateTime fecha);
        Task<IEnumerable<Viaje>> GetViajesPorClienteAsync(Guid clienteId);
        // Otros métodos personalizados para Viajes, si los vas a usar
    }
}
