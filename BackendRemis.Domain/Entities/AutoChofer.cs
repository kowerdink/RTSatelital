using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendRemis.Domain.Entities
{
    public class AutoChofer
    {
        public Guid AutoId { get; set; }
        public Auto Auto { get; set; } = null!;

        public Guid ChoferId { get; set; }
        public Chofer Chofer { get; set; } = null!;

        public DateTime FechaAsignacion { get; set; } = DateTime.UtcNow;
        public bool EstaHabilitado { get; set; } = true;
    }

}
