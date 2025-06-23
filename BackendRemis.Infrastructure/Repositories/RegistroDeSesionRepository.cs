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
    public class RegistroDeSesionRepository : GenericRepository<RegistroDeSesion>, IRegistroDeSesionRepository
    {
        public RegistroDeSesionRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<RegistroDeSesion>> GetByUsuarioIdAsync(Guid usuarioId)
        {
            return await _dbSet
                .Where(s => s.UsuarioId == usuarioId)
                .OrderByDescending(s => s.FechaHoraIngreso)
                .ToListAsync();
        }

        public async Task<IEnumerable<RegistroDeSesion>> GetByDateRangeAsync(DateTime desde, DateTime hasta)
        {
            return await _dbSet
                .Where(s => s.FechaHoraIngreso >= desde && s.FechaHoraIngreso <= hasta)
                .ToListAsync();
        }

        public async Task<RegistroDeSesion?> GetUltimaSesionAsync(Guid usuarioId)
        {
            return await _dbSet
                .Where(s => s.UsuarioId == usuarioId)
                .OrderByDescending(s => s.FechaHoraIngreso)
                .FirstOrDefaultAsync();
        }
    }
}
