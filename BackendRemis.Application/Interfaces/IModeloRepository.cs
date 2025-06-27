using BackendRemis.Domain.Entities;

namespace BackendRemis.Application.Interfaces
{
    public interface IModeloRepository : IGenericRepository<Modelo>
    {
        
        // Task<Modelo?> GetByNombreAsync(string nombre);
    }
}
