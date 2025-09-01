using System;

namespace BackendRemis.Application.DTOs
{
    public class ViajeDetailDto
    {
        public Guid Id { get; set; }

        public string? DireccionOrigen { get; set; }
        public string? EntreCalle1 { get; set; }
        public string? EntreCalle2 { get; set; }
        public string? ObservacionesDireccion { get; set; }
        public string? DireccionDestino { get; set; }

        public DateTime? FechaHoraProgramada { get; set; }
        public DateTime FechaHoraSolicitud { get; set; }
        public DateTime? FechaHoraAsignacion { get; set; }
        public DateTime? FechaHoraInicio { get; set; }
        public DateTime? FechaHoraFin { get; set; }

        public string? TelefonoContacto { get; set; }
        public string? NombreContacto { get; set; }

        public Guid? ClienteId { get; set; }
        public string? ClienteNombre { get; set; }

        public Guid? ChoferId { get; set; }
        public string? ChoferNombre { get; set; }

        public Guid? AutoId { get; set; }
        public string? AutoPatente { get; set; }

        public string Estado { get; set; } = "Pendiente";
        public string Origen { get; set; } = "Telefono";
        public int? Calificacion { get; set; }
        public string? Nota { get; set; }

        // 🔹 Campos para Google Maps (opcionales)
        public double? OrigenLat { get; set; }
        public double? OrigenLng { get; set; }
        public double? DestinoLat { get; set; }
        public double? DestinoLng { get; set; }
        public int? DistanciaMetros { get; set; }
        public int? DuracionSegundos { get; set; }
    }
}

