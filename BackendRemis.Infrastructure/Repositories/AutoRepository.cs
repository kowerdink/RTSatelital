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
    public class AutoRepository : GenericRepository<Auto>, IAutoRepository
    {
        public AutoRepository(AppDbContext context) : base(context) { }

        public async Task<Auto?> GetByPatenteAsync(string patente)
        {
            return await _dbSet
                .Include(a => a.Marca)
                .Include(a => a.Modelo)
                .FirstOrDefaultAsync(a => a.Patente == patente);
        }

        public async Task<IEnumerable<Auto>> BuscarPorMarcaModeloAsync(string busqueda)
        {
            busqueda = busqueda.ToLower();

            return await _dbSet
                .Include(a => a.Marca)
                .Include(a => a.Modelo)
                .Where(a =>
                    a.Marca.Nombre.ToLower().Contains(busqueda) ||
                    a.Modelo.Nombre.ToLower().Contains(busqueda)
                )
                .ToListAsync();
        }

        public async Task<IEnumerable<Auto>> GetByEstadoAsync(EstadoAuto estado)
        {
            return await _dbSet
                .Where(a => a.Estado == estado)
                .Include(a => a.Marca)
                .Include(a => a.Modelo)
                .ToListAsync();
        }

        public async Task<IEnumerable<Auto>> GetByAnioAsync(int anio)
        {
            return await _dbSet
                .Include(a => a.Marca)
                .Include(a => a.Modelo)
                .Where(a => a.Anio == anio)
                .ToListAsync();
        }
    }
}
