// [DocHeader]
// M?dulo: General
// Capa: General
// Archivo: Migrations\20260421013453_cabinConfigurationAdd.cs
// Responsabilidad: Agrupa l?gica espec?fica del m?dulo respetando la arquitectura por capas del proyecto.
// Flujo: Participa en el flujo general de construcci?n y ejecuci?n del sistema de gesti?n a?rea.
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionAerolineas.Migrations
{
    /// <inheritdoc />
    public partial class cabinConfigurationAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cabinconfiguration",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    aeronave_id = table.Column<int>(type: "int", nullable: false),
                    tipo_cabina_id = table.Column<int>(type: "int", nullable: false),
                    fila_inicio = table.Column<int>(type: "int", nullable: false),
                    fila_fin = table.Column<int>(type: "int", nullable: false),
                    asientos_por_fila = table.Column<int>(type: "int", nullable: false),
                    letras_asientos = table.Column<string>(type: "varchar(10)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cabinconfiguration", x => x.id);
                    table.ForeignKey(
                        name: "FK_cabinconfiguration_CabinTypes_tipo_cabina_id",
                        column: x => x.tipo_cabina_id,
                        principalTable: "CabinTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_cabinconfiguration_aircraft_aeronave_id",
                        column: x => x.aeronave_id,
                        principalTable: "aircraft",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_cabinconfiguration_aeronave_id_tipo_cabina_id",
                table: "cabinconfiguration",
                columns: new[] { "aeronave_id", "tipo_cabina_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_cabinconfiguration_tipo_cabina_id",
                table: "cabinconfiguration",
                column: "tipo_cabina_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cabinconfiguration");
        }
    }
}
