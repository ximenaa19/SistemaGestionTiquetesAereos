// [DocHeader]
// M?dulo: General
// Capa: General
// Archivo: Migrations\20260420223721_RoutesMigration.cs
// Responsabilidad: Agrupa l?gica espec?fica del m?dulo respetando la arquitectura por capas del proyecto.
// Flujo: Participa en el flujo general de construcci?n y ejecuci?n del sistema de gesti?n a?rea.
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionAerolineas.Migrations
{
    /// <inheritdoc />
    public partial class RoutesMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "routes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    aeropuerto_origen_id = table.Column<int>(type: "int", nullable: false),
                    aeropuerto_destino_id = table.Column<int>(type: "int", nullable: false),
                    distancia_km = table.Column<int>(type: "int", nullable: true),
                    duracion_estimada_min = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_routes", x => x.id);
                    table.ForeignKey(
                        name: "FK_routes_airports_aeropuerto_destino_id",
                        column: x => x.aeropuerto_destino_id,
                        principalTable: "airports",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_routes_airports_aeropuerto_origen_id",
                        column: x => x.aeropuerto_origen_id,
                        principalTable: "airports",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_routes_aeropuerto_destino_id",
                table: "routes",
                column: "aeropuerto_destino_id");

            migrationBuilder.CreateIndex(
                name: "IX_routes_aeropuerto_origen_id_aeropuerto_destino_id",
                table: "routes",
                columns: new[] { "aeropuerto_origen_id", "aeropuerto_destino_id" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "routes");
        }
    }
}
