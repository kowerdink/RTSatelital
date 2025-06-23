using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendRemis.Domain.Entities
{
    public class AdminAsignado : User
    {
        public bool EsPrincipal => false;

        public List<Operador> Operadores { get; set; } = new();
    }

}
