// [DocHeader]
// M?dulo: General
// Capa: General
// Archivo: Migrations\20260421094909_ReservationsAdd.cs
// Responsabilidad: Agrupa l?gica espec?fica del m?dulo respetando la arquitectura por capas del proyecto.
// Flujo: Participa en el flujo general de construcci?n y ejecuci?n del sistema de gesti?n a?rea.
using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionAerolineas.Migrations
{
    /// <inheritdoc />
    public partial class ReservationsAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "reservations",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    codigo_reserva = table.Column<string>(type: "varchar(30)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    cliente_id = table.Column<int>(type: "int", nullable: false),
                    fecha_reserva = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    estado_reserva_id = table.Column<int>(type: "int", nullable: false),
                    valor_total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    vence_en = table.Column<DateTime>(type: "datetime", nullable: true),
                    creado_en = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP"),
                    actualizado_en = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP")
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reservations", x => x.id);
                    table.ForeignKey(
                        name: "FK_reservations_clients_cliente_id",
                        column: x => x.cliente_id,
                        principalTable: "clients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_reservations_reservationstatus_estado_reserva_id",
                        column: x => x.estado_reserva_id,
                        principalTable: "reservationstatus",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "reservationflights",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    reserva_id = table.Column<int>(type: "int", nullable: false),
                    vuelo_id = table.Column<int>(type: "int", nullable: false),
                    valor_parcial = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reservationflights", x => x.id);
                    table.ForeignKey(
                        name: "FK_reservationflights_flights_vuelo_id",
                        column: x => x.vuelo_id,
                        principalTable: "flights",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_reservationflights_reservations_reserva_id",
                        column: x => x.reserva_id,
                        principalTable: "reservations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "reservationpassengers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    reserva_vuelo_id = table.Column<int>(type: "int", nullable: false),
                    pasajero_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reservationpassengers", x => x.id);
                    table.ForeignKey(
                        name: "FK_reservationpassengers_passengers_pasajero_id",
                        column: x => x.pasajero_id,
                        principalTable: "passengers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_reservationpassengers_reservationflights_reserva_vuelo_id",
                        column: x => x.reserva_vuelo_id,
                        principalTable: "reservationflights",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_reservationflights_reserva_id_vuelo_id",
                table: "reservationflights",
                columns: new[] { "reserva_id", "vuelo_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_reservationflights_vuelo_id",
                table: "reservationflights",
                column: "vuelo_id");

            migrationBuilder.CreateIndex(
                name: "IX_reservationpassengers_pasajero_id",
                table: "reservationpassengers",
                column: "pasajero_id");

            migrationBuilder.CreateIndex(
                name: "IX_reservationpassengers_reserva_vuelo_id_pasajero_id",
                table: "reservationpassengers",
                columns: new[] { "reserva_vuelo_id", "pasajero_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_reservations_cliente_id",
                table: "reservations",
                column: "cliente_id");

            migrationBuilder.CreateIndex(
                name: "IX_reservations_codigo_reserva",
                table: "reservations",
                column: "codigo_reserva",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_reservations_estado_reserva_id",
                table: "reservations",
                column: "estado_reserva_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "reservationpassengers");

            migrationBuilder.DropTable(
                name: "reservationflights");

            migrationBuilder.DropTable(
                name: "reservations");
        }
    }
}
