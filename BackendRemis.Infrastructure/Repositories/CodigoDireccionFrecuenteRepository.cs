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
    public class CodigoDireccionFrecuenteRepository : GenericRepository<CodigoDireccionFrecuente>, ICodigoDireccionFrecuenteRepository
    {
        public CodigoDireccionFrecuenteRepository(AppDbContext context) : base(context) { }

        public async Task<CodigoDireccionFrecuente?> ObtenerPorCodigoAsync(string codigo)
        {
            return await _dbSet.FirstOrDefaultAsync(c => c.Codigo == codigo);
        }

        public async Task<IEnumerable<CodigoDireccionFrecuente>> BuscarPorDireccionAsync(string direccion)
        {
            return await _dbSet
                .Where(c => c.Direccion.ToLower().Contains(direccion.ToLower()))
                .ToListAsync();
        }
    }
}
