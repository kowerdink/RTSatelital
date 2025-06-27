using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendRemis.Application.DTOs
{
    public class DuenioAutoDto
    {
        // Propiedades heredadas de User
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string? Direccion { get; set; }
        public string? Email { get; set; }
        public string? DNI { get; set; }
        public string? CUIT_CUIL { get; set; }

        public List<string>? TelefonosExtra { get; set; }
        public List<string>? DireccionesExtra { get; set; }

        
    }
}
