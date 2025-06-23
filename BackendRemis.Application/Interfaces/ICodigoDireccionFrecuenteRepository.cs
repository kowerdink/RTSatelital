using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackendRemis.Application.Interfaces;
using BackendRemis.Domain.Entities;

namespace BackendRemis.Application.Interfaces
{
    public interface ICodigoDireccionFrecuenteRepository : IGenericRepository<CodigoDireccionFrecuente>
    {
        Task<CodigoDireccionFrecuente?> ObtenerPorCodigoAsync(string codigo);
        Task<IEnumerable<CodigoDireccionFrecuente>> BuscarPorDireccionAsync(string direccion);
        
    }
}
