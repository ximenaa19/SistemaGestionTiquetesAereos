// [DocHeader]
// M?dulo: General
// Capa: General
// Archivo: Migrations\20260420221543_AircraftMigration.cs
// Responsabilidad: Agrupa l?gica espec?fica del m?dulo respetando la arquitectura por capas del proyecto.
// Flujo: Participa en el flujo general de construcci?n y ejecuci?n del sistema de gesti?n a?rea.
using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionAerolineas.Migrations
{
    /// <inheritdoc />
    public partial class AircraftMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "aircraft",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    modelo_id = table.Column<int>(type: "int", nullable: false),
                    aerolinea_id = table.Column<int>(type: "int", nullable: false),
                    matricula = table.Column<string>(type: "varchar(20)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    fecha_fabricacion = table.Column<DateTime>(type: "date", nullable: true),
                    activa = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_aircraft", x => x.id);
                    table.ForeignKey(
                        name: "FK_aircraft_aircraftmodels_modelo_id",
                        column: x => x.modelo_id,
                        principalTable: "aircraftmodels",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_aircraft_airlines_aerolinea_id",
                        column: x => x.aerolinea_id,
                        principalTable: "airlines",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_aircraft_aerolinea_id",
                table: "aircraft",
                column: "aerolinea_id");

            migrationBuilder.CreateIndex(
                name: "IX_aircraft_matricula",
                table: "aircraft",
                column: "matricula",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_aircraft_modelo_id",
                table: "aircraft",
                column: "modelo_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "aircraft");
        }
    }
}
