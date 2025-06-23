using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendRemis.Domain.Entities
{
    public class Modelo
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Nombre { get; set; } = null!;
        public Guid MarcaId { get; set; }
        public Marca Marca { get; set; } = null!;
        public ICollection<Auto> Autos { get; set; } = new List<Auto>();
    }
}
