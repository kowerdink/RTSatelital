using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendRemis.Domain.Entities
{
    public class RegistroDeSesion
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        // Usuario relacionado (puede ser operador, chofer, admin, etc.)
        public Guid UsuarioId { get; set; }
        public User Usuario { get; set; } = null!;

        public DateTime FechaHoraIngreso { get; set; }  // Al hacer login/marcar entrada
        public DateTime? FechaHoraEgreso { get; set; }  // Al hacer logout/marcar salida

        public string? IpAcceso { get; set; }           // Opcional: registrar desde dónde
        public string? Dispositivo { get; set; }        // Ej: "App Chofer", "Panel Operador"
    }
}
