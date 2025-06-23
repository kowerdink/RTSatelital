using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackendRemis.Application.Interfaces;
using BackendRemis.Domain.Entities;

namespace BackendRemis.Application.Interfaces
{
    public interface IAdminRepository : IGenericRepository<Admin>
    {
        Task<Admin?> BuscarPorNombreAsync(string nombre);
        Task<Admin?> GetByNumeroDeOperadorAsync(int numeroOperador);
    }
}
