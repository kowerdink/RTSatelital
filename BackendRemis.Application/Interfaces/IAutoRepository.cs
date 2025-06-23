using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackendRemis.Application.Interfaces;
using BackendRemis.Domain.Entities;
using BackendRemis.Domain.Enums;

namespace BackendRemis.Application.Interfaces
{
    public interface IAutoRepository : IGenericRepository<Auto>
    {
        Task<Auto?> GetByPatenteAsync(string patente);
        Task<IEnumerable<Auto>> BuscarPorMarcaModeloAsync(string busqueda);
        Task<IEnumerable<Auto>> GetByEstadoAsync(EstadoAuto estado);
        Task<IEnumerable<Auto>> GetByAnioAsync(int anio);
    }
}
