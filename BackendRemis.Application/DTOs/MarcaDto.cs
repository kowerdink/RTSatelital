using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendRemis.Application.DTOs
{
    public class MarcaDto
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; } = null!;
    }
}

