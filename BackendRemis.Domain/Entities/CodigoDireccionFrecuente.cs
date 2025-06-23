using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendRemis.Domain.Entities
{
    public class CodigoDireccionFrecuente
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Codigo { get; set; } = null!; // Ejemplo: "500.1", "CENTRAL", "MERCADO"
        public string Direccion { get; set; } required
        public string? NombreReferencia { get; set; } // "Central", "Mercado", "Kiosco Susi"
        public string? MensajeDefault { get; set; } // Opcional: “Señora con bolsos”
        public string? Observaciones { get; set; } // Por si querés guardar una nota fija

        public ICollection<Viaje> ViajesAsociados { get; set; } = new List<Viaje>();

    }
}
