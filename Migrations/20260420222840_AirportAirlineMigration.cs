// [DocHeader]
// M?dulo: General
// Capa: General
// Archivo: Migrations\20260420222840_AirportAirlineMigration.cs
// Responsabilidad: Agrupa l?gica espec?fica del m?dulo respetando la arquitectura por capas del proyecto.
// Flujo: Participa en el flujo general de construcci?n y ejecuci?n del sistema de gesti?n a?rea.
using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionAerolineas.Migrations
{
    /// <inheritdoc />
    public partial class AirportAirlineMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "airportairline",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    aeropuerto_id = table.Column<int>(type: "int", nullable: false),
                    aerolinea_id = table.Column<int>(type: "int", nullable: false),
                    terminal = table.Column<string>(type: "varchar(20)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    fecha_inicio = table.Column<DateTime>(type: "date", nullable: false),
                    fecha_fin = table.Column<DateTime>(type: "date", nullable: true),
                    activa = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_airportairline", x => x.id);
                    table.ForeignKey(
                        name: "FK_airportairline_airlines_aerolinea_id",
                        column: x => x.aerolinea_id,
                        principalTable: "airlines",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_airportairline_airports_aeropuerto_id",
                        column: x => x.aeropuerto_id,
                        principalTable: "airports",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_airportairline_aerolinea_id",
                table: "airportairline",
                column: "aerolinea_id");

            migrationBuilder.CreateIndex(
                name: "IX_airportairline_aeropuerto_id_aerolinea_id",
                table: "airportairline",
                columns: new[] { "aeropuerto_id", "aerolinea_id" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "airportairline");
        }
    }
}
