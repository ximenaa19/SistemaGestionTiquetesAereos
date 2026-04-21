using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionAerolineas.Migrations
{
    /// <inheritdoc />
    public partial class FlightSeatsAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "flightseats",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    vuelo_id = table.Column<int>(type: "int", nullable: false),
                    codigo_asiento = table.Column<string>(type: "varchar(5)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tipo_cabina_id = table.Column<int>(type: "int", nullable: false),
                    tipo_ubicacion_id = table.Column<int>(type: "int", nullable: false),
                    esta_ocupado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_flightseats", x => x.id);
                    table.ForeignKey(
                        name: "FK_flightseats_CabinTypes_tipo_cabina_id",
                        column: x => x.tipo_cabina_id,
                        principalTable: "CabinTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_flightseats_flights_vuelo_id",
                        column: x => x.vuelo_id,
                        principalTable: "flights",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_flightseats_tipos_ubicacion_asiento_tipo_ubicacion_id",
                        column: x => x.tipo_ubicacion_id,
                        principalTable: "tipos_ubicacion_asiento",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_flightseats_tipo_cabina_id",
                table: "flightseats",
                column: "tipo_cabina_id");

            migrationBuilder.CreateIndex(
                name: "IX_flightseats_tipo_ubicacion_id",
                table: "flightseats",
                column: "tipo_ubicacion_id");

            migrationBuilder.CreateIndex(
                name: "IX_flightseats_vuelo_id_codigo_asiento",
                table: "flightseats",
                columns: new[] { "vuelo_id", "codigo_asiento" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "flightseats");
        }
    }
}
