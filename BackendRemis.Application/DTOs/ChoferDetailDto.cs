using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendRemis.Application.DTOs
{
    public class ChoferDetailDto
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public string Email { get; set; } 
        public string DNI { get; set; } = null!;
        public string CUIT_CUIL { get; set; } = null!;
        public string NumeroLicencia { get; set; } = null!;
        public DateTime FechaVencimientoLicencia { get; set; }
        public List<string> TelefonosExtra { get; set; } = new();
        public List<string> DireccionesExtra { get; set; } = new();
    }
}

