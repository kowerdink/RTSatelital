using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackendRemis.Application.Interfaces;
using BackendRemis.Domain.Entities;

namespace BackendRemis.Application.Interfaces
{
    public interface ICuentaCorrienteRepository : IGenericRepository<CuentaCorriente>
    {
        Task<CuentaCorriente?> ObtenerPorNumeroCuentaAsync(int numeroCuenta);
        Task<IEnumerable<CuentaCorriente>> BuscarPorNombreAsync(string nombre);
        Task<IEnumerable<CuentaCorriente>> ObtenerPorClienteIdAsync(Guid clienteId);
        
    }
}
