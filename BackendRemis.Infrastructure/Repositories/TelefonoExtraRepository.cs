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
    public class TelefonoExtraRepository : GenericRepository<TelefonoExtra>, ITelefonoExtraRepository
    {
        public TelefonoExtraRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<TelefonoExtra>> GetByUserIdAsync(Guid userId)
        {
            return await _dbSet.Where(t => t.UserId == userId).ToListAsync();
        }

        public async Task<TelefonoExtra?> GetByTelefonoAsync(string telefono)
        {
            return await _dbSet.FirstOrDefaultAsync(t => t.Telefono == telefono);
        }
    }
}
