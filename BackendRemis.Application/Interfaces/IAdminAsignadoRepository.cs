using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackendRemis.Application.Interfaces;
using BackendRemis.Domain.Entities;

namespace BackendRemis.Application.Interfaces
{
    public interface IAdminAsignadoRepository : IGenericRepository<AdminAsignado>
    {
        Task<AdminAsignado?> BuscarPorNombreAsync(string nombre);
        Task<AdminAsignado?> GetByNumeroDeOperadorAsync(int numeroOperador);

    }   
}
