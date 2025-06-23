using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendRemis.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MigracionTPT : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AgendamientosRecurrentes_User_ClienteId",
                table: "AgendamientosRecurrentes");

            migrationBuilder.DropForeignKey(
                name: "FK_AutoChoferes_User_ChoferId",
                table: "AutoChoferes");

            migrationBuilder.DropForeignKey(
                name: "FK_Autos_User_ChoferId",
                table: "Autos");

            migrationBuilder.DropForeignKey(
                name: "FK_Autos_User_DuenioAutoId",
                table: "Autos");

            migrationBuilder.DropForeignKey(
                name: "FK_CuentasCorriente_User_ClienteId",
                table: "CuentasCorriente");

            migrationBuilder.DropForeignKey(
                name: "FK_PermisosOperador_User_OperadorId",
                table: "PermisosOperador");

            migrationBuilder.DropForeignKey(
                name: "FK_User_User_AdminAsignadoId",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_User_AdminId",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_Viajes_User_ChoferId",
                table: "Viajes");

            migrationBuilder.DropForeignKey(
                name: "FK_Viajes_User_ClienteId",
                table: "Viajes");

            migrationBuilder.DropIndex(
                name: "IX_User_AdminAsignadoId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_AdminId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "AdminAsignadoId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "AdminId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "User");

            migrationBuilder.DropColumn(
                name: "FechaVencimientoLicencia",
                table: "User");

            migrationBuilder.DropColumn(
                name: "NumeroLicencia",
                table: "User");

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Admins_User_Id",
                        column: x => x.Id,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Choferes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    NumeroLicencia = table.Column<string>(type: "text", nullable: false),
                    FechaVencimientoLicencia = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Choferes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Choferes_User_Id",
                        column: x => x.Id,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clientes_User_Id",
                        column: x => x.Id,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DueniosAuto",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DueniosAuto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DueniosAuto_User_Id",
                        column: x => x.Id,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AdminAsignados",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AdminId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminAsignados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdminAsignados_Admins_AdminId",
                        column: x => x.AdminId,
                        principalTable: "Admins",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AdminAsignados_User_Id",
                        column: x => x.Id,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Operadores",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AdminAsignadoId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operadores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Operadores_AdminAsignados_AdminAsignadoId",
                        column: x => x.AdminAsignadoId,
                        principalTable: "AdminAsignados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Operadores_User_Id",
                        column: x => x.Id,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdminAsignados_AdminId",
                table: "AdminAsignados",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_Operadores_AdminAsignadoId",
                table: "Operadores",
                column: "AdminAsignadoId");

            migrationBuilder.AddForeignKey(
                name: "FK_AgendamientosRecurrentes_Clientes_ClienteId",
                table: "AgendamientosRecurrentes",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AutoChoferes_Choferes_ChoferId",
                table: "AutoChoferes",
                column: "ChoferId",
                principalTable: "Choferes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Autos_Choferes_ChoferId",
                table: "Autos",
                column: "ChoferId",
                principalTable: "Choferes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Autos_DueniosAuto_DuenioAutoId",
                table: "Autos",
                column: "DuenioAutoId",
                principalTable: "DueniosAuto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CuentasCorriente_Clientes_ClienteId",
                table: "CuentasCorriente",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PermisosOperador_Operadores_OperadorId",
                table: "PermisosOperador",
                column: "OperadorId",
                principalTable: "Operadores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Viajes_Choferes_ChoferId",
                table: "Viajes",
                column: "ChoferId",
                principalTable: "Choferes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Viajes_Clientes_ClienteId",
                table: "Viajes",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AgendamientosRecurrentes_Clientes_ClienteId",
                table: "AgendamientosRecurrentes");

            migrationBuilder.DropForeignKey(
                name: "FK_AutoChoferes_Choferes_ChoferId",
                table: "AutoChoferes");

            migrationBuilder.DropForeignKey(
                name: "FK_Autos_Choferes_ChoferId",
                table: "Autos");

            migrationBuilder.DropForeignKey(
                name: "FK_Autos_DueniosAuto_DuenioAutoId",
                table: "Autos");

            migrationBuilder.DropForeignKey(
                name: "FK_CuentasCorriente_Clientes_ClienteId",
                table: "CuentasCorriente");

            migrationBuilder.DropForeignKey(
                name: "FK_PermisosOperador_Operadores_OperadorId",
                table: "PermisosOperador");

            migrationBuilder.DropForeignKey(
                name: "FK_Viajes_Choferes_ChoferId",
                table: "Viajes");

            migrationBuilder.DropForeignKey(
                name: "FK_Viajes_Clientes_ClienteId",
                table: "Viajes");

            migrationBuilder.DropTable(
                name: "Choferes");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "DueniosAuto");

            migrationBuilder.DropTable(
                name: "Operadores");

            migrationBuilder.DropTable(
                name: "AdminAsignados");

            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.AddColumn<Guid>(
                name: "AdminAsignadoId",
                table: "User",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "AdminId",
                table: "User",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "User",
                type: "character varying(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaVencimientoLicencia",
                table: "User",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NumeroLicencia",
                table: "User",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_AdminAsignadoId",
                table: "User",
                column: "AdminAsignadoId");

            migrationBuilder.CreateIndex(
                name: "IX_User_AdminId",
                table: "User",
                column: "AdminId");

            migrationBuilder.AddForeignKey(
                name: "FK_AgendamientosRecurrentes_User_ClienteId",
                table: "AgendamientosRecurrentes",
                column: "ClienteId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AutoChoferes_User_ChoferId",
                table: "AutoChoferes",
                column: "ChoferId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Autos_User_ChoferId",
                table: "Autos",
                column: "ChoferId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Autos_User_DuenioAutoId",
                table: "Autos",
                column: "DuenioAutoId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CuentasCorriente_User_ClienteId",
                table: "CuentasCorriente",
                column: "ClienteId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PermisosOperador_User_OperadorId",
                table: "PermisosOperador",
                column: "OperadorId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_User_AdminAsignadoId",
                table: "User",
                column: "AdminAsignadoId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_User_AdminId",
                table: "User",
                column: "AdminId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Viajes_User_ChoferId",
                table: "Viajes",
                column: "ChoferId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Viajes_User_ClienteId",
                table: "Viajes",
                column: "ClienteId",
                principalTable: "User",
                principalColumn: "Id");
        }
    }
}
