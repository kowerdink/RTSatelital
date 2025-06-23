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
    public class OperadorRepository : GenericRepository<Operador>, IOperadorRepository
    {
        public OperadorRepository(AppDbContext context) : base(context) { }

        public async Task<Operador?> GetByNumeroDeOperadorAsync(int numeroOperador)
        {
            return await _dbSet.FirstOrDefaultAsync(o => o.NumeroDeOperador == numeroOperador);
        }

        public async Task<IEnumerable<Operador>> BuscarPorNombreAsync(string nombre)
        {
            return await _dbSet
                .Where(o => o.Nombre.ToLower().Contains(nombre.ToLower()))
                .ToListAsync();
        }
    }
}
