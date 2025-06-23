using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackendRemis.Domain.Entities;

namespace BackendRemis.Application.Interfaces
{
    public interface IPermisoOperadorRepository : IGenericRepository<PermisoOperador>
    {
        // Obtener permisos por Operador
        Task<IEnumerable<PermisoOperador>> GetByOperadorIdAsync(Guid operadorId);

        // Obtener todos los permisos activos para un operador
        Task<IEnumerable<PermisoOperador>> GetPermisosActivosAsync(Guid operadorId);

        // Buscar permiso por nombre
        Task<PermisoOperador?> GetByNombreAsync(Guid operadorId, string nombrePermiso);
    }
}
