using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendRemis.Domain.Entities
{
    public class CuentaCorriente
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public int NumeroCuenta { get; set; } // Ej: 50
        public string NombreCuenta { get; set; } = null!; // Ej: Hospital
        public string? Responsable { get; set; } // Nombre del responsable
        public string? TelefonoResponsable { get; set; }
        public string? EmailResponsable { get; set; }

        public Guid? ClienteId { get; set; } // Si es para un cliente específico
        public Cliente? Cliente { get; set; }
        public ICollection<Viaje> ViajesAsociados { get; set; } = new List<Viaje>();
    }

}
