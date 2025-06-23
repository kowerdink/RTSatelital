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
    public class DuenioAutoRepository : GenericRepository<DuenioAuto>, IDuenioAutoRepository
    {
        public DuenioAutoRepository(AppDbContext context) : base(context) { }

        public async Task<DuenioAuto?> GetByCuitAsync(string cuitCuil)
        {
            return await _dbSet.FirstOrDefaultAsync(d => d.CUIT_CUIL == cuitCuil);
        }

        public async Task<IEnumerable<DuenioAuto>> BuscarPorNombreAsync(string nombreApellido)
        {
            nombreApellido = nombreApellido.ToLower();
            return await _dbSet
                .Where(d =>
                    d.Nombre.ToLower().Contains(nombreApellido) ||
                    d.Apellido.ToLower().Contains(nombreApellido))
                .ToListAsync();
        }
    }
}
