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
    public class ChoferRepository : GenericRepository<Chofer>, IChoferRepository
    {
        public ChoferRepository(AppDbContext context) : base(context) { }

        public async Task<Chofer?> BuscarPorTelefonoAsync(string telefono)
            => await _dbSet.FirstOrDefaultAsync(c => c.Telefono == telefono);

        public async Task<Chofer?> BuscarPorEmailAsync(string email)
            => await _dbSet.FirstOrDefaultAsync(c => c.Email == email);

        public async Task<IEnumerable<Chofer>> BuscarPorNombreAsync(string nombre)
            => await _dbSet
                    .Where(c => c.Nombre.ToLower().Contains(nombre.ToLower()))
                    .ToListAsync();

        public async Task<IEnumerable<Chofer>> GetChoferesConLicenciaVencidaAsync()
            => await _dbSet
                .Where(c => c.FechaVencimientoLicencia < DateTime.UtcNow)
                .ToListAsync();

        public async Task<IEnumerable<Chofer>> GetChoferesHabilitadosAsync()
            // Suponiendo que tengas una propiedad tipo "Activo" o "Habilitado" (ajustá según tu entidad)
            => await _dbSet
                .Where(c => c.FechaVencimientoLicencia >= DateTime.UtcNow /*&& c.Activo*/)
                .ToListAsync();
    }
}
