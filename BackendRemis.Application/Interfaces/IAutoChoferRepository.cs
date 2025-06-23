using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackendRemis.Domain.Entities;

namespace BackendRemis.Application.Interfaces
{
    public interface IAutoChoferRepository : IGenericRepository<AutoChofer>
    {
        Task<IEnumerable<AutoChofer>> ObtenerPorAutoIdAsync(Guid autoId);
        Task<IEnumerable<AutoChofer>> ObtenerPorChoferIdAsync(Guid choferId);
        Task<AutoChofer?> ObtenerAsignacionActualAsync(Guid autoId, Guid choferId);
        // Otros métodos personalizados si necesitás
    }
}
