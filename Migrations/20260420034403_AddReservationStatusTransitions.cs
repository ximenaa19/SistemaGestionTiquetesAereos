using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionAerolineas.Migrations
{
    /// <inheritdoc />
    public partial class AddReservationStatusTransitions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "transiciones_estado_reserva",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    estado_origen_id = table.Column<int>(type: "int", nullable: false),
                    estado_destino_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transiciones_estado_reserva", x => x.id);
                    table.ForeignKey(
                        name: "FK_transiciones_estado_reserva_reservationstatus_estado_destino~",
                        column: x => x.estado_destino_id,
                        principalTable: "reservationstatus",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_transiciones_estado_reserva_reservationstatus_estado_origen_~",
                        column: x => x.estado_origen_id,
                        principalTable: "reservationstatus",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_transiciones_estado_reserva_estado_destino_id",
                table: "transiciones_estado_reserva",
                column: "estado_destino_id");

            migrationBuilder.CreateIndex(
                name: "IX_transiciones_estado_reserva_estado_origen_id_estado_destino_~",
                table: "transiciones_estado_reserva",
                columns: new[] { "estado_origen_id", "estado_destino_id" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "transiciones_estado_reserva");
        }
    }
}
