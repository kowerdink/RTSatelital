using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackendRemis.Application.Interfaces;
using BackendRemis.Domain.Entities;

namespace BackendRemis.Application.Interfaces
{
    public interface IChoferRepository : IGenericRepository<Chofer>
    {
        Task<Chofer?> BuscarPorTelefonoAsync(string telefono);
        Task<Chofer?> BuscarPorEmailAsync(string email);
        Task<IEnumerable<Chofer>> BuscarPorNombreAsync(string nombre);
        Task<IEnumerable<Chofer>> GetChoferesConLicenciaVencidaAsync();
        Task<IEnumerable<Chofer>> GetChoferesHabilitadosAsync();
    }
}
