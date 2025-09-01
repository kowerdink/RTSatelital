using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendRemis.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddViajeMapsColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "DestinoLat",
                table: "Viajes",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "DestinoLng",
                table: "Viajes",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DistanciaMetros",
                table: "Viajes",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DuracionSegundos",
                table: "Viajes",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "OrigenLat",
                table: "Viajes",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "OrigenLng",
                table: "Viajes",
                type: "double precision",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DestinoLat",
                table: "Viajes");

            migrationBuilder.DropColumn(
                name: "DestinoLng",
                table: "Viajes");

            migrationBuilder.DropColumn(
                name: "DistanciaMetros",
                table: "Viajes");

            migrationBuilder.DropColumn(
                name: "DuracionSegundos",
                table: "Viajes");

            migrationBuilder.DropColumn(
                name: "OrigenLat",
                table: "Viajes");

            migrationBuilder.DropColumn(
                name: "OrigenLng",
                table: "Viajes");
        }
    }
}
