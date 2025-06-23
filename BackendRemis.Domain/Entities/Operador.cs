using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendRemis.Domain.Entities
{
    public class Operador : User
    {
        // Admin que lo creó
        public Guid AdminAsignadoId { get; set; }
        public AdminAsignado AdminAsignado { get; set; } = null!;
    }
}
