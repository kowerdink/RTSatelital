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
    public class ClienteRepository : GenericRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(AppDbContext context) : base(context) { }

        // Buscar por teléfono (exacto)
        public async Task<Cliente?> BuscarPorTelefonoAsync(string telefono)
        {
            return await _dbSet.FirstOrDefaultAsync(c => c.Telefono == telefono);
        }

        // Buscar clientes por nombre (puede traer varios, ej: Juan)
        public async Task<IEnumerable<Cliente>> BuscarPorNombreAsync(string nombre)
        {
            return await _dbSet
                .Where(c => c.Nombre.ToLower().Contains(nombre.ToLower()))
                .ToListAsync();
        }

        // Buscar por email (opcional)
        public async Task<Cliente?> BuscarPorEmailAsync(string email)
        {
            return await _dbSet.FirstOrDefaultAsync(c => c.Email == email);
        }
    }

}
