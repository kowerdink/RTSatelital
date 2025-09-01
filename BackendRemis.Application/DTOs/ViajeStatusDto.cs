using System;

namespace BackendRemis.Application.DTOs
{
    public class ViajeStatusDto
    {
        public Guid ViajeId { get; set; }
        public string NuevoEstado { get; set; } = "EnCurso"; // "EnCurso" | "Finalizado" | "Cancelado"
        public string? Nota { get; set; } // motivo cancelación o comentario
        public int? Calificacion { get; set; } // 1..5 al finalizar
    }
}
