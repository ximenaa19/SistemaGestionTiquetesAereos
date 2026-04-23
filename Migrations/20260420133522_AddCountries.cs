// [DocHeader]
// M?dulo: General
// Capa: General
// Archivo: Migrations\20260420133522_AddCountries.cs
// Responsabilidad: Agrupa l?gica espec?fica del m?dulo respetando la arquitectura por capas del proyecto.
// Flujo: Participa en el flujo general de construcci?n y ejecuci?n del sistema de gesti?n a?rea.
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionAerolineas.Migrations
{
    /// <inheritdoc />
    public partial class AddCountries : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_countries_continents_continent_id",
                table: "countries");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "countries",
                newName: "nombre");

            migrationBuilder.RenameColumn(
                name: "continent_id",
                table: "countries",
                newName: "continente_id");

            migrationBuilder.RenameColumn(
                name: "code_iso",
                table: "countries",
                newName: "codigo_iso");

            migrationBuilder.RenameIndex(
                name: "IX_countries_continent_id",
                table: "countries",
                newName: "IX_countries_continente_id");

            migrationBuilder.CreateIndex(
                name: "IX_countries_codigo_iso",
                table: "countries",
                column: "codigo_iso",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_countries_continents_continente_id",
                table: "countries",
                column: "continente_id",
                principalTable: "continents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_countries_continents_continente_id",
                table: "countries");

            migrationBuilder.DropIndex(
                name: "IX_countries_codigo_iso",
                table: "countries");

            migrationBuilder.RenameColumn(
                name: "nombre",
                table: "countries",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "continente_id",
                table: "countries",
                newName: "continent_id");

            migrationBuilder.RenameColumn(
                name: "codigo_iso",
                table: "countries",
                newName: "code_iso");

            migrationBuilder.RenameIndex(
                name: "IX_countries_continente_id",
                table: "countries",
                newName: "IX_countries_continent_id");

            migrationBuilder.AddForeignKey(
                name: "FK_countries_continents_continent_id",
                table: "countries",
                column: "continent_id",
                principalTable: "continents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
