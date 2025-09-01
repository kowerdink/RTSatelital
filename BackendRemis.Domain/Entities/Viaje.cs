using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackendRemis.Domain.Enums;

namespace BackendRemis.Domain.Entities
{
    public class Viaje
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string? DireccionOrigen { get; set; }
        public string? EntreCalle1 { get; set; }               
        public string? EntreCalle2 { get; set; }               
        public string? ObservacionesDireccion { get; set; }
        public string? DireccionDestino { get; set; }
        public DateTime? FechaHoraProgramada { get; set; } // Si es un viaje programado
        public DateTime FechaHoraSolicitud { get; set; } = DateTime.UtcNow; // Cuando se solicita el viaje
        public DateTime? FechaHoraAsignacion { get; set; } // Cuando se asigna el chofer/auto
        public DateTime? FechaHoraInicio { get; set; }     // Cuando el chofer inicia el viaje
        public DateTime? FechaHoraFin { get; set; }        // Cuando termina el viaje

        public TimeSpan? Duracion =>
            (FechaHoraInicio.HasValue && FechaHoraFin.HasValue)
                ? FechaHoraFin - FechaHoraInicio
                : null;
        public string? TelefonoContacto { get; set; }
        public string? NombreContacto { get; set; }

        public Guid? CodigoDireccionFrecuenteId { get; set; }
        public CodigoDireccionFrecuente? CodigoDireccionFrecuente { get; set; }

        public Guid? ClienteId { get; set; }
        public Cliente? Cliente { get; set; }

        public int? Calificacion { get; set; } // Entre 1 y 5
        public string? Nota { get; set; }

        public int? NumeroOperador { get; set; } // Si es cargado por operador

        public Guid? ChoferId { get; set; }
        public Chofer? Chofer { get; set; }

        public Guid? AutoId { get; set; }
        public Auto? Auto { get; set; }

        public EstadoViaje Estado { get; set; } = EstadoViaje.Pendiente;
        public OrigenSolicitudViaje Origen { get; set; }
        public Guid? CuentaCorrienteId { get; set; }
        public CuentaCorriente? CuentaCorriente { get; set; }

        // 🔹 NUEVO: Preparado para Google Maps
        public double? OrigenLat { get; set; }
        public double? OrigenLng { get; set; }
        public double? DestinoLat { get; set; }
        public double? DestinoLng { get; set; }
        public int? DistanciaMetros { get; set; }
        public int? DuracionSegundos { get; set; }

    }


}
