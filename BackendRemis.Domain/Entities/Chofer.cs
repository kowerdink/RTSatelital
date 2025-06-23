using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendRemis.Domain.Entities
{
    public class Chofer : User
    {
        public string NumeroLicencia { get; set; } = null!;
        public DateTime FechaVencimientoLicencia { get; set; }

        public List<AutoChofer> AutoChoferes { get; set; } = new();
    }

}
