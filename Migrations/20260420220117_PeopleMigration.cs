using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionAerolineas.Migrations
{
    /// <inheritdoc />
    public partial class PeopleMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "people",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    tipo_documento_id = table.Column<int>(type: "int", nullable: false),
                    numero_documento = table.Column<string>(type: "varchar(30)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    nombres = table.Column<string>(type: "varchar(100)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    apellidos = table.Column<string>(type: "varchar(100)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    fecha_nacimiento = table.Column<DateTime>(type: "date", nullable: true),
                    genero = table.Column<string>(type: "char(1)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    direccion_id = table.Column<int>(type: "int", nullable: true),
                    creado_en = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP"),
                    actualizado_en = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP")
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_people", x => x.id);
                    table.ForeignKey(
                        name: "FK_people_DocumentTypes_tipo_documento_id",
                        column: x => x.tipo_documento_id,
                        principalTable: "DocumentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_people_addresses_direccion_id",
                        column: x => x.direccion_id,
                        principalTable: "addresses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_people_direccion_id",
                table: "people",
                column: "direccion_id");

            migrationBuilder.CreateIndex(
                name: "IX_people_tipo_documento_id_numero_documento",
                table: "people",
                columns: new[] { "tipo_documento_id", "numero_documento" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "people");
        }
    }
}
