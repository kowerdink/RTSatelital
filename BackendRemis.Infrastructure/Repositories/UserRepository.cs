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
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context) { }

        public async Task<User?> BuscarPorTelefonoAsync(string telefono)
        {
            return await _dbSet.FirstOrDefaultAsync(u => u.Telefono == telefono);
        }

        public async Task<IEnumerable<User>> BuscarPorNombreAsync(string nombre)
        {
            return await _dbSet
                .Where(u => u.Nombre.ToLower().Contains(nombre.ToLower()))
                .ToListAsync();
        }

        public async Task<User?> BuscarPorEmailAsync(string email)
        {
            return await _dbSet.FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
