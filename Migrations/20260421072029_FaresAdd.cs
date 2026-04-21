using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionAerolineas.Migrations
{
    /// <inheritdoc />
    public partial class FaresAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "fares",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ruta_id = table.Column<int>(type: "int", nullable: false),
                    tipo_cabina_id = table.Column<int>(type: "int", nullable: false),
                    tipo_pasajero_id = table.Column<int>(type: "int", nullable: false),
                    temporada_id = table.Column<int>(type: "int", nullable: false),
                    precio_base = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    vigencia_desde = table.Column<DateTime>(type: "date", nullable: true),
                    vigencia_hasta = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fares", x => x.id);
                    table.ForeignKey(
                        name: "FK_fares_CabinTypes_tipo_cabina_id",
                        column: x => x.tipo_cabina_id,
                        principalTable: "CabinTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_fares_routes_ruta_id",
                        column: x => x.ruta_id,
                        principalTable: "routes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_fares_temporadas_temporada_id",
                        column: x => x.temporada_id,
                        principalTable: "temporadas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_fares_tipos_pasajero_tipo_pasajero_id",
                        column: x => x.tipo_pasajero_id,
                        principalTable: "tipos_pasajero",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_fares_ruta_id_tipo_cabina_id_tipo_pasajero_id_temporada_id",
                table: "fares",
                columns: new[] { "ruta_id", "tipo_cabina_id", "tipo_pasajero_id", "temporada_id" });

            migrationBuilder.CreateIndex(
                name: "IX_fares_temporada_id",
                table: "fares",
                column: "temporada_id");

            migrationBuilder.CreateIndex(
                name: "IX_fares_tipo_cabina_id",
                table: "fares",
                column: "tipo_cabina_id");

            migrationBuilder.CreateIndex(
                name: "IX_fares_tipo_pasajero_id",
                table: "fares",
                column: "tipo_pasajero_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "fares");
        }
    }
}
