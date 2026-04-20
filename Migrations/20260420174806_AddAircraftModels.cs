using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionAerolineas.Migrations
{
    /// <inheritdoc />
    public partial class AddAircraftModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "aircraftmodels",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    fabricante_id = table.Column<int>(type: "int", nullable: false),
                    nombre_modelo = table.Column<string>(type: "varchar(100)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    capacidad_maxima = table.Column<int>(type: "int", nullable: false),
                    peso_max_despegue_kg = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    consumo_combustible_kg_h = table.Column<decimal>(type: "decimal(8,2)", nullable: true),
                    velocidad_crucero_kmh = table.Column<int>(type: "int", nullable: true),
                    altitud_crucero_ft = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_aircraftmodels", x => x.id);
                    table.ForeignKey(
                        name: "FK_aircraftmodels_aircraftmanufacturers_fabricante_id",
                        column: x => x.fabricante_id,
                        principalTable: "aircraftmanufacturers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_aircraftmodels_fabricante_id",
                table: "aircraftmodels",
                column: "fabricante_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "aircraftmodels");
        }
    }
}
