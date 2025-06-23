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
    public class CuentaCorrienteRepository : GenericRepository<CuentaCorriente>, ICuentaCorrienteRepository
    {
        public CuentaCorrienteRepository(AppDbContext context) : base(context) { }

        public async Task<CuentaCorriente?> ObtenerPorNumeroCuentaAsync(int numeroCuenta)
        {
            return await _dbSet.FirstOrDefaultAsync(cc => cc.NumeroCuenta == numeroCuenta);
        }

        public async Task<IEnumerable<CuentaCorriente>> BuscarPorNombreAsync(string nombre)
        {
            return await _dbSet
                .Where(cc => cc.NombreCuenta.ToLower().Contains(nombre.ToLower()))
                .ToListAsync();
        }

        public async Task<IEnumerable<CuentaCorriente>> ObtenerPorClienteIdAsync(Guid clienteId)
        {
            return await _dbSet
                .Where(cc => cc.ClienteId == clienteId)
                .ToListAsync();
        }
    }
}
