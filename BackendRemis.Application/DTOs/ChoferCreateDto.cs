namespace BackendRemis.Application.DTOs
{
    public class ChoferCreateDto
    {
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public string Email { get; set; }
        public string DNI { get; set; } = null!;
        public string CUIT_CUIL { get; set; } = null!;
        public string NumeroLicencia { get; set; } = null!;
        public DateTime FechaVencimientoLicencia { get; set; }
        public List<string>? TelefonosExtra { get; set; }
        public List<string>? DireccionesExtra { get; set; }
    }
}

