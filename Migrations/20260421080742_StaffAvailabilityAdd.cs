using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionAerolineas.Migrations
{
    /// <inheritdoc />
    public partial class StaffAvailabilityAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "staffavailability",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    personal_id = table.Column<int>(type: "int", nullable: false),
                    estado_disponibilidad_id = table.Column<int>(type: "int", nullable: false),
                    fecha_inicio = table.Column<DateTime>(type: "datetime", nullable: false),
                    fecha_fin = table.Column<DateTime>(type: "datetime", nullable: false),
                    observacion = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_staffavailability", x => x.id);
                    table.ForeignKey(
                        name: "FK_staffavailability_estados_disponibilidad_estado_disponibilid~",
                        column: x => x.estado_disponibilidad_id,
                        principalTable: "estados_disponibilidad",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_staffavailability_staff_personal_id",
                        column: x => x.personal_id,
                        principalTable: "staff",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_staffavailability_estado_disponibilidad_id",
                table: "staffavailability",
                column: "estado_disponibilidad_id");

            migrationBuilder.CreateIndex(
                name: "IX_staffavailability_personal_id",
                table: "staffavailability",
                column: "personal_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "staffavailability");
        }
    }
}
