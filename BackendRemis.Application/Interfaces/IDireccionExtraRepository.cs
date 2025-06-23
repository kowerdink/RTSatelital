using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackendRemis.Domain.Entities;

namespace BackendRemis.Application.Interfaces
{
    public interface IDireccionExtraRepository : IGenericRepository<DireccionExtra>
    {
        Task<IEnumerable<DireccionExtra>> GetByUserIdAsync(Guid userId);
        Task<DireccionExtra?> GetByDireccionAsync(string direccion);
    }
}
