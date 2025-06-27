using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendRemis.Application.DTOs
{
    public class DuenioAutoDetailDto
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string? Direccion { get; set; }
        public string? Email { get; set; }
        public string? DNI { get; set; }
        public string? CUIT_CUIL { get; set; }
        public List<string?>? TelefonosExtra { get; set; }
        public List<string?>? DireccionesExtra { get; set; }

        // Solo para consulta:
        public List<AutoSimpleDto>? Autos { get; set; }
    }

    public class AutoSimpleDto
    {
        public Guid Id { get; set; }
        public string? Patente { get; set; }
        public string? Marca { get; set; }
        public string? Modelo { get; set; }
    }

}
