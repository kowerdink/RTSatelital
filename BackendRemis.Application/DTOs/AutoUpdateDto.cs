using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendRemis.Application.DTOs
{
    public class AutoUpdateDto
    {
        public Guid Id { get; set; }
        public Guid MarcaId { get; set; }
        public Guid ModeloId { get; set; }
        public int Anio { get; set; }
        public string Patente { get; set; }
        public string Color { get; set; }
        public int NumeroMovil { get; set; }
        public string Seguro { get; set; }
        public DateTime FechaVencimientoSeguro { get; set; }
        public DateTime FechaVencimientoVTV { get; set; }
        public Guid DuenioAutoId { get; set; }
        public Guid? ChoferId { get; set; }
    }

}
