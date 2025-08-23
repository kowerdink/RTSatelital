using BackendRemis.Domain.Enums;

namespace BackendRemis.Domain.Entities
{
    public class Auto
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid MarcaId { get; set; }
        public Marca Marca { get; set; } = null!;

        public Guid ModeloId { get; set; }
        public Modelo Modelo { get; set; } = null!;

        // En C# 11, "required" va antes del tipo/propiedad
        public required int Anio { get; set; }
        public required string Patente { get; set; }
        public required string Color { get; set; }
        public required int NumeroMovil { get; set; }

        public required string Seguro { get; set; }
        public required DateTime FechaVencimientoSeguro { get; set; }
        public required DateTime FechaVencimientoVTV { get; set; }

        public Guid? ChoferId { get; set; }
        public Chofer? Chofer { get; set; }

        public EstadoAuto Estado { get; set; } = EstadoAuto.FueraDeServicio;

        // Dueño
        public Guid DuenioAutoId { get; set; }
        public DuenioAuto DuenioAuto { get; set; } = null!;

        // Relación muchos a muchos con Choferes
        public List<AutoChofer> AutoChoferes { get; set; } = new();
    }
}
