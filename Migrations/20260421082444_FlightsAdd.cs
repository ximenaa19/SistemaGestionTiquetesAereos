using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionAerolineas.Migrations
{
    /// <inheritdoc />
    public partial class FlightsAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "flights",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    codigo_vuelo = table.Column<string>(type: "varchar(10)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    aerolinea_id = table.Column<int>(type: "int", nullable: false),
                    ruta_id = table.Column<int>(type: "int", nullable: false),
                    aeronave_id = table.Column<int>(type: "int", nullable: false),
                    fecha_salida = table.Column<DateTime>(type: "datetime", nullable: false),
                    fecha_llegada_estimada = table.Column<DateTime>(type: "datetime", nullable: false),
                    capacidad_total = table.Column<int>(type: "int", nullable: false),
                    asientos_disponibles = table.Column<int>(type: "int", nullable: false),
                    estado_vuelo_id = table.Column<int>(type: "int", nullable: false),
                    reprogramado_en = table.Column<DateTime>(type: "datetime", nullable: true),
                    creado_en = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP"),
                    actualizado_en = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP")
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_flights", x => x.id);
                    table.ForeignKey(
                        name: "FK_flights_aircraft_aeronave_id",
                        column: x => x.aeronave_id,
                        principalTable: "aircraft",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_flights_airlines_aerolinea_id",
                        column: x => x.aerolinea_id,
                        principalTable: "airlines",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_flights_estados_vuelo_estado_vuelo_id",
                        column: x => x.estado_vuelo_id,
                        principalTable: "estados_vuelo",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_flights_routes_ruta_id",
                        column: x => x.ruta_id,
                        principalTable: "routes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_flights_aerolinea_id",
                table: "flights",
                column: "aerolinea_id");

            migrationBuilder.CreateIndex(
                name: "IX_flights_aeronave_id",
                table: "flights",
                column: "aeronave_id");

            migrationBuilder.CreateIndex(
                name: "IX_flights_codigo_vuelo",
                table: "flights",
                column: "codigo_vuelo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_flights_estado_vuelo_id",
                table: "flights",
                column: "estado_vuelo_id");

            migrationBuilder.CreateIndex(
                name: "IX_flights_ruta_id",
                table: "flights",
                column: "ruta_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "flights");
        }
    }
}
