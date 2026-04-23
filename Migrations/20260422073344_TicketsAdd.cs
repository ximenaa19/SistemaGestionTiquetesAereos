// [DocHeader]
// M?dulo: General
// Capa: General
// Archivo: Migrations\20260422073344_TicketsAdd.cs
// Responsabilidad: Agrupa l?gica espec?fica del m?dulo respetando la arquitectura por capas del proyecto.
// Flujo: Participa en el flujo general de construcci?n y ejecuci?n del sistema de gesti?n a?rea.
using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionAerolineas.Migrations
{
    /// <inheritdoc />
    public partial class TicketsAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tickets",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    reserva_pasajero_id = table.Column<int>(type: "int", nullable: false),
                    codigo_tiquete = table.Column<string>(type: "varchar(30)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    fecha_emision = table.Column<DateTime>(type: "datetime", nullable: false),
                    estado_tiquete_id = table.Column<int>(type: "int", nullable: false),
                    creado_en = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP"),
                    actualizado_en = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP")
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tickets", x => x.id);
                    table.ForeignKey(
                        name: "FK_tickets_estados_tiquete_estado_tiquete_id",
                        column: x => x.estado_tiquete_id,
                        principalTable: "estados_tiquete",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tickets_reservationpassengers_reserva_pasajero_id",
                        column: x => x.reserva_pasajero_id,
                        principalTable: "reservationpassengers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_tickets_codigo_tiquete",
                table: "tickets",
                column: "codigo_tiquete",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tickets_estado_tiquete_id",
                table: "tickets",
                column: "estado_tiquete_id");

            migrationBuilder.CreateIndex(
                name: "IX_tickets_reserva_pasajero_id",
                table: "tickets",
                column: "reserva_pasajero_id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tickets");
        }
    }
}
