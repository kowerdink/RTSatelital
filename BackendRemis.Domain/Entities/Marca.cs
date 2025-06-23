using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BackendRemis.Domain.Entities
{
    public class Marca
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Nombre { get; set; } = null!;
        public ICollection<Modelo> Modelos { get; set; } = new List<Modelo>();
    }
}
