using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendRemis.Domain.Entities
{
    public class Cliente : User
    {
        public ICollection<Viaje>? Viajes { get; set; }
    }

}
