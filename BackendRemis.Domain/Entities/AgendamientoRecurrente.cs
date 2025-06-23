using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendRemis.Domain.Entities
{
    public class AgendamientoRecurrente
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid ClienteId { get; set; }
        public Cliente Cliente { get; set; } = null!;
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public List<DayOfWeek> DiasPermitidos { get; set; } = null!; // Lunes a Viernes, por ejemplo
        public List<DateTime> FechasExcluidas { get; set; } = null!;// Feriados, días no válidos
        public string? Nota { get; set; }

        // Relación: todos los viajes generados por este patrón
        public ICollection<Viaje> ViajesGenerados { get; set; } = new List<Viaje>();
    }
}
