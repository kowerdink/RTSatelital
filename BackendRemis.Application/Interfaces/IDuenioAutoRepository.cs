using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackendRemis.Application.Interfaces;
using BackendRemis.Domain.Entities;

namespace BackendRemis.Application.Interfaces
{
    public interface IDuenioAutoRepository : IGenericRepository<DuenioAuto>
    {
        // Buscar dueño por CUIT/CUIL
        Task<DuenioAuto?> GetByCuitAsync(string cuitCuil);

        // Buscar por nombre/apellido
        Task<IEnumerable<DuenioAuto>> BuscarPorNombreAsync(string nombreApellido);
    }
}
