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
    public class DireccionExtraRepository : GenericRepository<DireccionExtra>, IDireccionExtraRepository
    {
        public DireccionExtraRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<DireccionExtra>> GetByUserIdAsync(Guid userId)
        {
            return await _dbSet.Where(d => d.UserId == userId).ToListAsync();
        }

        public async Task<DireccionExtra?> GetByDireccionAsync(string direccion)
        {
            return await _dbSet.FirstOrDefaultAsync(d => d.Direccion == direccion);
        }
    }
}
