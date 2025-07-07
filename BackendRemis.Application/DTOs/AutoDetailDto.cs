namespace BackendRemis.Application.DTOs
{
    public class AutoDetailDto
    {
        public Guid Id { get; set; }
        public string Patente { get; set; } = null!;
        public string Color { get; set; } = null!;
        public int Anio { get; set; }
        public int NumeroMovil { get; set; }
        public string Seguro { get; set; } = null!;
        public DateTime FechaVencimientoSeguro { get; set; }
        public DateTime FechaVencimientoVTV { get; set; }
        public string Marca { get; set; } = null!;
        public string Modelo { get; set; } = null!;
        public string Estado { get; set; } = null!;
        public Guid DuenioAutoId { get; set; }
        public string DuenioNombre { get; set; } = null!;
        public Guid? ChoferId { get; set; }
        public string? ChoferNombre { get; set; }

        public List<ChoferSimpleDto> ChoferesAsignados { get; set; } = new();

    }
}
