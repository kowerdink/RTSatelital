using System;

namespace BackendRemis.Application.DTOs
{
    public class ViajeCreateDto
    {
        public string? DireccionOrigen { get; set; }
        public string? EntreCalle1 { get; set; }
        public string? EntreCalle2 { get; set; }
        public string? ObservacionesDireccion { get; set; }
        public string? DireccionDestino { get; set; }

        public DateTime? FechaHoraProgramada { get; set; } // null => inmediato

        public string? TelefonoContacto { get; set; }
        public string? NombreContacto { get; set; }

        public Guid? CodigoDireccionFrecuenteId { get; set; }
        public Guid? ClienteId { get; set; }
        public Guid? CuentaCorrienteId { get; set; } // si va por cuenta corriente

        public int? NumeroOperador { get; set; } // si lo cargó un operador
        public string Origen { get; set; } = "Telefono"; // "App" | "Telefono" | "WhatsApp"

        // 🔹 Campos para Google Maps (opcionales)
        public double? OrigenLat { get; set; }
        public double? OrigenLng { get; set; }
        public double? DestinoLat { get; set; }
        public double? DestinoLng { get; set; }
        public int? DistanciaMetros { get; set; }
        public int? DuracionSegundos { get; set; }
    }
}

