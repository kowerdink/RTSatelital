using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendRemis.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NuevaMigracionMarcaModelo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Marca",
                table: "Autos");

            migrationBuilder.DropColumn(
                name: "Modelo",
                table: "Autos");

            migrationBuilder.AlterColumn<string>(
                name: "Telefono",
                table: "TelefonoExtra",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Direccion",
                table: "DireccionExtra",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.Sql(
                "ALTER TABLE \"Autos\" ALTER COLUMN \"NumeroMovil\" TYPE integer USING \"NumeroMovil\"::integer;");


            migrationBuilder.AddColumn<int>(
                name: "Anio",
                table: "Autos",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "MarcaId",
                table: "Autos",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ModeloId",
                table: "Autos",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Marcas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nombre = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marcas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Modelos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    MarcaId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modelos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Modelos_Marcas_MarcaId",
                        column: x => x.MarcaId,
                        principalTable: "Marcas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Autos_MarcaId",
                table: "Autos",
                column: "MarcaId");

            migrationBuilder.CreateIndex(
                name: "IX_Autos_ModeloId",
                table: "Autos",
                column: "ModeloId");

            migrationBuilder.CreateIndex(
                name: "IX_Modelos_MarcaId",
                table: "Modelos",
                column: "MarcaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Autos_Marcas_MarcaId",
                table: "Autos",
                column: "MarcaId",
                principalTable: "Marcas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Autos_Modelos_ModeloId",
                table: "Autos",
                column: "ModeloId",
                principalTable: "Modelos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Autos_Marcas_MarcaId",
                table: "Autos");

            migrationBuilder.DropForeignKey(
                name: "FK_Autos_Modelos_ModeloId",
                table: "Autos");

            migrationBuilder.DropTable(
                name: "Modelos");

            migrationBuilder.DropTable(
                name: "Marcas");

            migrationBuilder.DropIndex(
                name: "IX_Autos_MarcaId",
                table: "Autos");

            migrationBuilder.DropIndex(
                name: "IX_Autos_ModeloId",
                table: "Autos");

            migrationBuilder.DropColumn(
                name: "Anio",
                table: "Autos");

            migrationBuilder.DropColumn(
                name: "MarcaId",
                table: "Autos");

            migrationBuilder.DropColumn(
                name: "ModeloId",
                table: "Autos");

            migrationBuilder.AlterColumn<string>(
                name: "Telefono",
                table: "TelefonoExtra",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Direccion",
                table: "DireccionExtra",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NumeroMovil",
                table: "Autos",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<string>(
                name: "Marca",
                table: "Autos",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Modelo",
                table: "Autos",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
