// [DocHeader]
// M?dulo: General
// Capa: General
// Archivo: Migrations\20260421090724_FlightAssignmentsAdd.cs
// Responsabilidad: Agrupa l?gica espec?fica del m?dulo respetando la arquitectura por capas del proyecto.
// Flujo: Participa en el flujo general de construcci?n y ejecuci?n del sistema de gesti?n a?rea.
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionAerolineas.Migrations
{
    /// <inheritdoc />
    public partial class FlightAssignmentsAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "flightassignments",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    vuelo_id = table.Column<int>(type: "int", nullable: false),
                    personal_id = table.Column<int>(type: "int", nullable: false),
                    rol_vuelo_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_flightassignments", x => x.id);
                    table.ForeignKey(
                        name: "FK_flightassignments_flights_vuelo_id",
                        column: x => x.vuelo_id,
                        principalTable: "flights",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_flightassignments_fligthroles_rol_vuelo_id",
                        column: x => x.rol_vuelo_id,
                        principalTable: "fligthroles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_flightassignments_staff_personal_id",
                        column: x => x.personal_id,
                        principalTable: "staff",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_flightassignments_personal_id",
                table: "flightassignments",
                column: "personal_id");

            migrationBuilder.CreateIndex(
                name: "IX_flightassignments_rol_vuelo_id",
                table: "flightassignments",
                column: "rol_vuelo_id");

            migrationBuilder.CreateIndex(
                name: "IX_flightassignments_vuelo_id_personal_id",
                table: "flightassignments",
                columns: new[] { "vuelo_id", "personal_id" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "flightassignments");
        }
    }
}
