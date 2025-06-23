using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackendRemis.Application.Interfaces;
using BackendRemis.Domain.Entities;

namespace BackendRemis.Application.Interfaces
{
    public interface IClienteRepository : IGenericRepository<Cliente>
    {
        Task<Cliente?> BuscarPorTelefonoAsync(string telefono);
        Task<IEnumerable<Cliente>> BuscarPorNombreAsync(string nombre);
        Task<Cliente?> BuscarPorEmailAsync(string email); // Opcional
    }
}
