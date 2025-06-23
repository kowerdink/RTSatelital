using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackendRemis.Domain.Entities;

namespace BackendRemis.Application.Interfaces
{
    public interface ITelefonoExtraRepository : IGenericRepository<TelefonoExtra>
    {
        Task<IEnumerable<TelefonoExtra>> GetByUserIdAsync(Guid userId);
        Task<TelefonoExtra?> GetByTelefonoAsync(string telefono);
    }
}
