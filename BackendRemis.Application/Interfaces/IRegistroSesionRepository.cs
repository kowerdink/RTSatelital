using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackendRemis.Application.Interfaces;
using BackendRemis.Domain.Entities;

namespace BackendRemis.Application.Interfaces
{
    public interface IRegistroDeSesionRepository : IGenericRepository<RegistroDeSesion>
    {
        // Obtener sesiones por usuario
        Task<IEnumerable<RegistroDeSesion>> GetByUsuarioIdAsync(Guid usuarioId);

        // Obtener sesiones en un rango de fechas
        Task<IEnumerable<RegistroDeSesion>> GetByDateRangeAsync(DateTime desde, DateTime hasta);

        // Obtener la última sesión de un usuario
        Task<RegistroDeSesion?> GetUltimaSesionAsync(Guid usuarioId);
    }
}
