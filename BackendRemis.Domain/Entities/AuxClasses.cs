using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendRemis.Domain.Entities
{
    public class TelefonoExtra
    {
        public int Id { get; set; }
        public string? Telefono { get; set; }
        public Guid UserId { get; set; }
    }

    public class DireccionExtra
    {
        public int Id { get; set; }
        public string? Direccion { get; set; }
        public Guid UserId { get; set; }
    }
}

