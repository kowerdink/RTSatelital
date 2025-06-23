using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public int Anio { get; set; } required
        public string Patente { get; set; } required
        public string Color { get; set; } required
        public int NumeroMovil { get; set; } required

        public string Seguro { get; set; }
        required
        public DateTime FechaVencimientoSeguro { get; set; }
        required
        public DateTime FechaVencimientoVTV { get; set; }
        required

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
