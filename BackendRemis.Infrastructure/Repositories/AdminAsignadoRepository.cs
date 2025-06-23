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
    public class AdminAsignadoRepository : GenericRepository<AdminAsignado>, IAdminAsignadoRepository
    {
        public AdminAsignadoRepository(AppDbContext context) : base(context) { }

        public async Task<AdminAsignado?> BuscarPorNombreAsync(string nombre)
        {
            return await _dbSet.FirstOrDefaultAsync(a => a.Nombre.ToLower() == nombre.ToLower());
        }

        public async Task<AdminAsignado?> GetByNumeroDeOperadorAsync(int numeroOperador)
        {
            // Chequea que NumeroDeOperador NO sea null
            return await _dbSet.FirstOrDefaultAsync(a => a.NumeroDeOperador == numeroOperador);
        }
    }

}
