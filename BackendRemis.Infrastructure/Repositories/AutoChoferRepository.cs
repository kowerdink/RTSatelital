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
    public class AutoChoferRepository : GenericRepository<AutoChofer>, IAutoChoferRepository
    {
        public AutoChoferRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<AutoChofer>> ObtenerPorAutoIdAsync(Guid autoId)
        {
            return await _dbSet.Where(ac => ac.AutoId == autoId).ToListAsync();
        }

        public async Task<IEnumerable<AutoChofer>> ObtenerPorChoferIdAsync(Guid choferId)
        {
            return await _dbSet.Where(ac => ac.ChoferId == choferId).ToListAsync();
        }

        public async Task<AutoChofer?> ObtenerAsignacionActualAsync(Guid autoId, Guid choferId)
        {
            return await _dbSet.FirstOrDefaultAsync(ac =>
                ac.AutoId == autoId && ac.ChoferId == choferId && ac.EstaHabilitado);
        }
    }
}
