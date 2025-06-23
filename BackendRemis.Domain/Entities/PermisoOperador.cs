using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendRemis.Domain.Entities
{
    public class PermisoOperador
    {
        public Guid Id { get; set; }
        public Guid OperadorId { get; set; }
        public Operador Operador { get; set; } = null!;

        public string NombrePermiso { get; set; } = null!;
        public bool Activo { get; set; } = true;
    }

}
