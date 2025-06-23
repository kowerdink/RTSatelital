using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendRemis.Domain.Entities
{
    public class Admin : User
    {
        public bool EsPrincipal => true;

        public List<AdminAsignado> AdminAsignados { get; set; } = new();
    }
}
