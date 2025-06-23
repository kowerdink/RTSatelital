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
    public class AdminRepository : GenericRepository<Admin>, IAdminRepository
    {
        public AdminRepository(AppDbContext context) : base(context) { }

        public async Task<Admin?> BuscarPorNombreAsync(string nombre)
        {
            return await _dbSet.FirstOrDefaultAsync(a => a.Nombre.ToLower() == nombre.ToLower());
        }

        public async Task<Admin?> GetByNumeroDeOperadorAsync(int numeroOperador)
        {
            return await _dbSet.FirstOrDefaultAsync(a => a.NumeroDeOperador == numeroOperador);
        }
    }
}
