using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackendRemis.Domain.Entities;

namespace BackendRemis.Application.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User?> BuscarPorTelefonoAsync(string telefono);
        Task<IEnumerable<User>> BuscarPorNombreAsync(string nombre);
        Task<User?> BuscarPorEmailAsync(string email);
    }
}
