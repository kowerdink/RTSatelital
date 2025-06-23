using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackendRemis.Application.Interfaces;
using BackendRemis.Domain.Entities;

namespace BackendRemis.Application.Interfaces
{
    public interface IAgendamientoRecurrenteRepository : IGenericRepository<AgendamientoRecurrente>
    {
        // Obtener los agendamientos de un cliente
        Task<IEnumerable<AgendamientoRecurrente>> GetByClienteIdAsync(Guid clienteId);

        // Buscar agendamientos activos en una fecha determinada
        Task<IEnumerable<AgendamientoRecurrente>> BuscarActivosEnFechaAsync(DateTime fecha);

        // Buscar por nota o texto
        Task<IEnumerable<AgendamientoRecurrente>> BuscarPorNotaAsync(string texto);
    }
}
