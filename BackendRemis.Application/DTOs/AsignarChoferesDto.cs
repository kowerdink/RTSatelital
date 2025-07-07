using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendRemis.Application.DTOs
{
    public class AsignarChoferesDto
    {
        public List<Guid> ChoferIds { get; set; } = new();
    }
}
