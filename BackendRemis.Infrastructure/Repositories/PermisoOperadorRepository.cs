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
    public class PermisoOperadorRepository : GenericRepository<PermisoOperador>, IPermisoOperadorRepository
    {
        public PermisoOperadorRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<PermisoOperador>> GetByOperadorIdAsync(Guid operadorId)
        {
            return await _dbSet
                .Where(p => p.OperadorId == operadorId)
                .ToListAsync();
        }

        public async Task<IEnumerable<PermisoOperador>> GetPermisosActivosAsync(Guid operadorId)
        {
            return await _dbSet
                .Where(p => p.OperadorId == operadorId && p.Activo)
                .ToListAsync();
        }

        public async Task<PermisoOperador?> GetByNombreAsync(Guid operadorId, string nombrePermiso)
        {
            return await _dbSet
                .FirstOrDefaultAsync(p => p.OperadorId == operadorId && p.NombrePermiso == nombrePermiso);
        }
    }
}
