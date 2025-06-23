using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackendRemis.Application.Interfaces;
using BackendRemis.Domain.Entities;
using BackendRemis.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BackendRemis.Infrastructure.Repositories
{
    public class AgendamientoRecurrenteRepository : GenericRepository<AgendamientoRecurrente>, IAgendamientoRecurrenteRepository
    {
        public AgendamientoRecurrenteRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<AgendamientoRecurrente>> GetByClienteIdAsync(Guid clienteId)
        {
            return await _dbSet
                .Where(a => a.ClienteId == clienteId)
                .ToListAsync();
        }

        public async Task<IEnumerable<AgendamientoRecurrente>> BuscarActivosEnFechaAsync(DateTime fecha)
        {
            return await _dbSet
                .Where(a => a.FechaInicio <= fecha && a.FechaFin >= fecha)
                .ToListAsync();
        }

        public async Task<IEnumerable<AgendamientoRecurrente>> BuscarPorNotaAsync(string texto)
        {
            texto = texto.ToLower();
            return await _dbSet
                .Where(a => !string.IsNullOrEmpty(a.Nota) && a.Nota.ToLower().Contains(texto))
                .ToListAsync();
        }
    }
}
