using BackendRemis.Domain.Entities;

namespace BackendRemis.Application.Interfaces
{
    public interface IMarcaRepository : IGenericRepository<Marca>
    {
        // Agregar métodos específicos 
        // Task<Marca?> GetByNombreAsync(string nombre);
    }
}
