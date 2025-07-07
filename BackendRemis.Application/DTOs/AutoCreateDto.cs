
namespace BackendRemis.Application.DTOs
{
    public class AutoCreateDto
    {
        public Guid MarcaId { get; set; }
        public Guid ModeloId { get; set; }
        public int Anio { get; set; }
        public string Patente { get; set; } = null!;
        public string Color { get; set; } = null!;
        public int NumeroMovil { get; set; }
        public string Seguro { get; set; } = null!;
        public DateTime FechaVencimientoSeguro { get; set; }
        public DateTime FechaVencimientoVTV { get; set; }
        public Guid DuenioAutoId { get; set; }
        public Guid? ChoferId { get; set; } // null si no lo asignás
        // El estado lo pone el backend o un endpoint especial (opcional aquí)
    }
}

