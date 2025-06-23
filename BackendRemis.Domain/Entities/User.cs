using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendRemis.Domain.Entities
{
    public abstract class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string? Direccion { get; set; }
        public string? Email { get; set; }
        public string? DNI { get; set; }
        public string? CUIT_CUIL { get; set; }

        public int? NumeroDeOperador { get; set; }
        // <----Sólo aplica para Admins, AdminAsignados y Operadores. En clientes y otros roles, debe ser null.
        public ICollection<TelefonoExtra>? TelefonosExtra { get; set; }
        public ICollection<DireccionExtra>? DireccionesExtra { get; set; }
        public ICollection<RegistroDeSesion> RegistrosDeSesion { get; set; } = null!;

    }

}
