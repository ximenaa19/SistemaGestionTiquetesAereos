using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionAerolineas.Migrations
{
    /// <inheritdoc />
    public partial class AddFlightStatusTransitions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "flightstatustransitions",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    estado_origen_id = table.Column<int>(type: "int", nullable: false),
                    estado_destino_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_flightstatustransitions", x => x.id);
                    table.ForeignKey(
                        name: "FK_flightstatustransitions_estados_vuelo_estado_destino_id",
                        column: x => x.estado_destino_id,
                        principalTable: "estados_vuelo",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_flightstatustransitions_estados_vuelo_estado_origen_id",
                        column: x => x.estado_origen_id,
                        principalTable: "estados_vuelo",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_flightstatustransitions_estado_destino_id",
                table: "flightstatustransitions",
                column: "estado_destino_id");

            migrationBuilder.CreateIndex(
                name: "IX_flightstatustransitions_estado_origen_id_estado_destino_id",
                table: "flightstatustransitions",
                columns: new[] { "estado_origen_id", "estado_destino_id" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "flightstatustransitions");
        }
    }
}
