using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BackendRemis.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CodigosDireccionFrecuente",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Codigo = table.Column<string>(type: "text", nullable: false),
                    Direccion = table.Column<string>(type: "text", nullable: false),
                    NombreReferencia = table.Column<string>(type: "text", nullable: true),
                    MensajeDefault = table.Column<string>(type: "text", nullable: true),
                    Observaciones = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CodigosDireccionFrecuente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Apellido = table.Column<string>(type: "text", nullable: false),
                    Telefono = table.Column<string>(type: "text", nullable: false),
                    Direccion = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    DNI = table.Column<string>(type: "text", nullable: true),
                    CUIT_CUIL = table.Column<string>(type: "text", nullable: true),
                    Discriminator = table.Column<string>(type: "character varying(13)", maxLength: 13, nullable: false),
                    AdminId = table.Column<Guid>(type: "uuid", nullable: true),
                    NumeroLicencia = table.Column<string>(type: "text", nullable: true),
                    FechaVencimientoLicencia = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    NumeroDeOperador = table.Column<int>(type: "integer", nullable: true),
                    AdminAsignadoId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_User_AdminAsignadoId",
                        column: x => x.AdminAsignadoId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_User_AdminId",
                        column: x => x.AdminId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AgendamientosRecurrentes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ClienteId = table.Column<Guid>(type: "uuid", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DiasPermitidos = table.Column<int[]>(type: "integer[]", nullable: false),
                    FechasExcluidas = table.Column<List<DateTime>>(type: "timestamp with time zone[]", nullable: false),
                    Nota = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgendamientosRecurrentes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AgendamientosRecurrentes_User_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Autos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Marca = table.Column<string>(type: "text", nullable: false),
                    Modelo = table.Column<string>(type: "text", nullable: false),
                    Patente = table.Column<string>(type: "text", nullable: false),
                    Color = table.Column<string>(type: "text", nullable: false),
                    NumeroMovil = table.Column<string>(type: "text", nullable: false),
                    Seguro = table.Column<string>(type: "text", nullable: false),
                    FechaVencimientoSeguro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FechaVencimientoVTV = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ChoferId = table.Column<Guid>(type: "uuid", nullable: true),
                    Estado = table.Column<int>(type: "integer", nullable: false),
                    DuenioAutoId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Autos_User_ChoferId",
                        column: x => x.ChoferId,
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Autos_User_DuenioAutoId",
                        column: x => x.DuenioAutoId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CuentasCorriente",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    NumeroCuenta = table.Column<int>(type: "integer", nullable: false),
                    NombreCuenta = table.Column<string>(type: "text", nullable: false),
                    Responsable = table.Column<string>(type: "text", nullable: true),
                    TelefonoResponsable = table.Column<string>(type: "text", nullable: true),
                    EmailResponsable = table.Column<string>(type: "text", nullable: true),
                    ClienteId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CuentasCorriente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CuentasCorriente_User_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DireccionExtra",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Direccion = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DireccionExtra", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DireccionExtra_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PermisosOperador",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OperadorId = table.Column<Guid>(type: "uuid", nullable: false),
                    NombrePermiso = table.Column<string>(type: "text", nullable: false),
                    Activo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermisosOperador", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PermisosOperador_User_OperadorId",
                        column: x => x.OperadorId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RegistrosDeSesion",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uuid", nullable: false),
                    FechaHoraIngreso = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FechaHoraEgreso = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IpAcceso = table.Column<string>(type: "text", nullable: true),
                    Dispositivo = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistrosDeSesion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RegistrosDeSesion_User_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TelefonoExtra",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Telefono = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TelefonoExtra", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TelefonoExtra_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AutoChoferes",
                columns: table => new
                {
                    AutoId = table.Column<Guid>(type: "uuid", nullable: false),
                    ChoferId = table.Column<Guid>(type: "uuid", nullable: false),
                    FechaAsignacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EstaHabilitado = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutoChoferes", x => new { x.AutoId, x.ChoferId });
                    table.ForeignKey(
                        name: "FK_AutoChoferes_Autos_AutoId",
                        column: x => x.AutoId,
                        principalTable: "Autos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AutoChoferes_User_ChoferId",
                        column: x => x.ChoferId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Viajes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DireccionOrigen = table.Column<string>(type: "text", nullable: true),
                    EntreCalle1 = table.Column<string>(type: "text", nullable: true),
                    EntreCalle2 = table.Column<string>(type: "text", nullable: true),
                    ObservacionesDireccion = table.Column<string>(type: "text", nullable: true),
                    DireccionDestino = table.Column<string>(type: "text", nullable: true),
                    FechaHoraProgramada = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    FechaHoraSolicitud = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FechaHoraAsignacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    FechaHoraInicio = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    FechaHoraFin = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    TelefonoContacto = table.Column<string>(type: "text", nullable: true),
                    NombreContacto = table.Column<string>(type: "text", nullable: true),
                    CodigoDireccionFrecuenteId = table.Column<Guid>(type: "uuid", nullable: true),
                    ClienteId = table.Column<Guid>(type: "uuid", nullable: true),
                    Calificacion = table.Column<int>(type: "integer", nullable: true),
                    Nota = table.Column<string>(type: "text", nullable: true),
                    NumeroOperador = table.Column<int>(type: "integer", nullable: true),
                    ChoferId = table.Column<Guid>(type: "uuid", nullable: true),
                    AutoId = table.Column<Guid>(type: "uuid", nullable: true),
                    Estado = table.Column<int>(type: "integer", nullable: false),
                    Origen = table.Column<int>(type: "integer", nullable: false),
                    CuentaCorrienteId = table.Column<Guid>(type: "uuid", nullable: true),
                    AgendamientoRecurrenteId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Viajes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Viajes_AgendamientosRecurrentes_AgendamientoRecurrenteId",
                        column: x => x.AgendamientoRecurrenteId,
                        principalTable: "AgendamientosRecurrentes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Viajes_Autos_AutoId",
                        column: x => x.AutoId,
                        principalTable: "Autos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Viajes_CodigosDireccionFrecuente_CodigoDireccionFrecuenteId",
                        column: x => x.CodigoDireccionFrecuenteId,
                        principalTable: "CodigosDireccionFrecuente",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Viajes_CuentasCorriente_CuentaCorrienteId",
                        column: x => x.CuentaCorrienteId,
                        principalTable: "CuentasCorriente",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Viajes_User_ChoferId",
                        column: x => x.ChoferId,
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Viajes_User_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AgendamientosRecurrentes_ClienteId",
                table: "AgendamientosRecurrentes",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_AutoChoferes_ChoferId",
                table: "AutoChoferes",
                column: "ChoferId");

            migrationBuilder.CreateIndex(
                name: "IX_Autos_ChoferId",
                table: "Autos",
                column: "ChoferId");

            migrationBuilder.CreateIndex(
                name: "IX_Autos_DuenioAutoId",
                table: "Autos",
                column: "DuenioAutoId");

            migrationBuilder.CreateIndex(
                name: "IX_CuentasCorriente_ClienteId",
                table: "CuentasCorriente",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_DireccionExtra_UserId",
                table: "DireccionExtra",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PermisosOperador_OperadorId",
                table: "PermisosOperador",
                column: "OperadorId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistrosDeSesion_UsuarioId",
                table: "RegistrosDeSesion",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_TelefonoExtra_UserId",
                table: "TelefonoExtra",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_User_AdminAsignadoId",
                table: "User",
                column: "AdminAsignadoId");

            migrationBuilder.CreateIndex(
                name: "IX_User_AdminId",
                table: "User",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_Viajes_AgendamientoRecurrenteId",
                table: "Viajes",
                column: "AgendamientoRecurrenteId");

            migrationBuilder.CreateIndex(
                name: "IX_Viajes_AutoId",
                table: "Viajes",
                column: "AutoId");

            migrationBuilder.CreateIndex(
                name: "IX_Viajes_ChoferId",
                table: "Viajes",
                column: "ChoferId");

            migrationBuilder.CreateIndex(
                name: "IX_Viajes_ClienteId",
                table: "Viajes",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Viajes_CodigoDireccionFrecuenteId",
                table: "Viajes",
                column: "CodigoDireccionFrecuenteId");

            migrationBuilder.CreateIndex(
                name: "IX_Viajes_CuentaCorrienteId",
                table: "Viajes",
                column: "CuentaCorrienteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AutoChoferes");

            migrationBuilder.DropTable(
                name: "DireccionExtra");

            migrationBuilder.DropTable(
                name: "PermisosOperador");

            migrationBuilder.DropTable(
                name: "RegistrosDeSesion");

            migrationBuilder.DropTable(
                name: "TelefonoExtra");

            migrationBuilder.DropTable(
                name: "Viajes");

            migrationBuilder.DropTable(
                name: "AgendamientosRecurrentes");

            migrationBuilder.DropTable(
                name: "Autos");

            migrationBuilder.DropTable(
                name: "CodigosDireccionFrecuente");

            migrationBuilder.DropTable(
                name: "CuentasCorriente");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
