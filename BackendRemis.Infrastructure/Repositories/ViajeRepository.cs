using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackendRemis.Application.Interfaces;
using BackendRemis.Domain.Entities;
using BackendRemis.Domain.Enums;
using BackendRemis.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BackendRemis.Infrastructure.Repositories
{
    public class ViajeRepository : GenericRepository<Viaje>, IViajeRepository
    {
        public ViajeRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<Viaje>> GetViajesPorEstadoAsync(EstadoViaje estado)
        {
            return await _dbSet.Where(v => v.Estado == estado).ToListAsync();
        }

        public async Task<IEnumerable<Viaje>> BuscarViajesPorTelefonoAsync(string telefono)
        {
            return await _dbSet.Where(v => v.TelefonoContacto == telefono).ToListAsync();
        }

        public async Task<IEnumerable<Viaje>> GetViajesPorFechaAsync(DateTime fecha)
        {
            // Filtra por día, ignorando la hora
            return await _dbSet
                .Where(v => v.FechaHoraSolicitud.Date == fecha.Date)
                .ToListAsync();
        }

        public async Task<IEnumerable<Viaje>> GetViajesPorClienteAsync(Guid clienteId)
        {
            return await _dbSet.Where(v => v.ClienteId == clienteId).ToListAsync();
        }

        
    }
}
