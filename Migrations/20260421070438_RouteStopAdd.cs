using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionAerolineas.Migrations
{
    /// <inheritdoc />
    public partial class RouteStopAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "routestops",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ruta_id = table.Column<int>(type: "int", nullable: false),
                    aeropuerto_escala_id = table.Column<int>(type: "int", nullable: false),
                    orden = table.Column<int>(type: "int", nullable: false),
                    duracion_escala_min = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_routestops", x => x.id);
                    table.ForeignKey(
                        name: "FK_routestops_airports_aeropuerto_escala_id",
                        column: x => x.aeropuerto_escala_id,
                        principalTable: "airports",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_routestops_routes_ruta_id",
                        column: x => x.ruta_id,
                        principalTable: "routes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_routestops_aeropuerto_escala_id",
                table: "routestops",
                column: "aeropuerto_escala_id");

            migrationBuilder.CreateIndex(
                name: "IX_routestops_ruta_id_orden",
                table: "routestops",
                columns: new[] { "ruta_id", "orden" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "routestops");
        }
    }
}
