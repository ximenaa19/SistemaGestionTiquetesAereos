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
