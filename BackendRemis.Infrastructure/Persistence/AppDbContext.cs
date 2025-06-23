using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BackendRemis.Domain.Entities;

namespace BackendRemis.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        // DbSet por cada entidad principal
        public DbSet<Admin> Admins { get; set; }
        public DbSet<AdminAsignado> AdminAsignados { get; set; }
        public DbSet<Operador> Operadores { get; set; }
        public DbSet<Chofer> Choferes { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<DuenioAuto> DueniosAuto { get; set; }
        public DbSet<Auto> Autos { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Modelo> Modelos { get; set; }
        public DbSet<Viaje> Viajes { get; set; }
        public DbSet<AutoChofer> AutoChoferes { get; set; }
        public DbSet<CodigoDireccionFrecuente> CodigosDireccionFrecuente { get; set; }
        public DbSet<CuentaCorriente> CuentasCorriente { get; set; }
        public DbSet<RegistroDeSesion> RegistrosDeSesion { get; set; }
        public DbSet<AgendamientoRecurrente> AgendamientosRecurrentes { get; set; }         // <-- NUEVO
        public DbSet<PermisoOperador> PermisosOperador { get; set; }                      // <-- NUEVO


        // Opcional: configurar relaciones más adelante con Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Admin>().ToTable("Admins");
            modelBuilder.Entity<AdminAsignado>().ToTable("AdminAsignados");
            modelBuilder.Entity<Operador>().ToTable("Operadores");
            modelBuilder.Entity<Chofer>().ToTable("Choferes");
            modelBuilder.Entity<Cliente>().ToTable("Clientes");
            modelBuilder.Entity<DuenioAuto>().ToTable("DueniosAuto");

            // Relaciones muchos a muchos
            modelBuilder.Entity<AutoChofer>()
                .HasKey(ac => new { ac.AutoId, ac.ChoferId });

            modelBuilder.Entity<AutoChofer>()
                .HasOne(ac => ac.Auto)
                .WithMany(a => a.AutoChoferes)
                .HasForeignKey(ac => ac.AutoId);

            modelBuilder.Entity<AutoChofer>()
                .HasOne(ac => ac.Chofer)
                .WithMany(c => c.AutoChoferes)
                .HasForeignKey(ac => ac.ChoferId);

            modelBuilder.Entity<Marca>()
                .HasMany(m => m.Modelos)
                .WithOne(mo => mo.Marca)
                .HasForeignKey(mo => mo.MarcaId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
