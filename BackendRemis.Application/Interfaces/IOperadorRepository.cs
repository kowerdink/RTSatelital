using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackendRemis.Application;
using BackendRemis.Domain.Entities;

namespace BackendRemis.Application.Interfaces
{
    public interface IOperadorRepository : IGenericRepository<Operador>
    {
        Task<Operador?> GetByNumeroDeOperadorAsync(int numeroOperador);
        Task<IEnumerable<Operador>> BuscarPorNombreAsync(string nombre);
    }
}
