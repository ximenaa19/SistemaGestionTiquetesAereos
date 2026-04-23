// [DocHeader]
// M?dulo: General
// Capa: General
// Archivo: Migrations\20260422104120_CheckinsAdd.cs
// Responsabilidad: Agrupa l?gica espec?fica del m?dulo respetando la arquitectura por capas del proyecto.
// Flujo: Participa en el flujo general de construcci?n y ejecuci?n del sistema de gesti?n a?rea.
using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionAerolineas.Migrations
{
    /// <inheritdoc />
    public partial class CheckinsAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "checkins",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    tiquete_id = table.Column<int>(type: "int", nullable: false),
                    personal_id = table.Column<int>(type: "int", nullable: false),
                    asiento_vuelo_id = table.Column<int>(type: "int", nullable: false),
                    fecha_checkin = table.Column<DateTime>(type: "datetime", nullable: false),
                    estado_checkin_id = table.Column<int>(type: "int", nullable: false),
                    numero_tarjeta_embarque = table.Column<string>(type: "varchar(20)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    equipaje_bodega = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false),
                    peso_equipaje_kg = table.Column<decimal>(type: "decimal(5,2)", nullable: true, defaultValue: 0m)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_checkins", x => x.id);
                    table.ForeignKey(
                        name: "FK_checkins_estados_checkin_estado_checkin_id",
                        column: x => x.estado_checkin_id,
                        principalTable: "estados_checkin",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_checkins_flightseats_asiento_vuelo_id",
                        column: x => x.asiento_vuelo_id,
                        principalTable: "flightseats",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_checkins_staff_personal_id",
                        column: x => x.personal_id,
                        principalTable: "staff",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_checkins_tickets_tiquete_id",
                        column: x => x.tiquete_id,
                        principalTable: "tickets",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_checkins_asiento_vuelo_id",
                table: "checkins",
                column: "asiento_vuelo_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_checkins_estado_checkin_id",
                table: "checkins",
                column: "estado_checkin_id");

            migrationBuilder.CreateIndex(
                name: "IX_checkins_numero_tarjeta_embarque",
                table: "checkins",
                column: "numero_tarjeta_embarque",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_checkins_personal_id",
                table: "checkins",
                column: "personal_id");

            migrationBuilder.CreateIndex(
                name: "IX_checkins_tiquete_id",
                table: "checkins",
                column: "tiquete_id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "checkins");
        }
    }
}
