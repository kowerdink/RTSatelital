using BackendRemis.Application.Interfaces;
using BackendRemis.Domain.Entities;
using BackendRemis.Infrastructure.Persistence;

namespace BackendRemis.Infrastructure.Repositories
{
    public class ModeloRepository : GenericRepository<Modelo>, IModeloRepository
    {
        public ModeloRepository(AppDbContext context) : base(context)
        {
        }

        // Ejemplo de método específico:
        // public async Task<Modelo?> GetByNombreAsync(string nombre)
        // {
        //     return await _dbSet.FirstOrDefaultAsync(m => m.Nombre == nombre);
        // }
    }
}
