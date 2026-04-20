using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionAerolineas.Migrations
{
    /// <inheritdoc />
    public partial class AddRegions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_regions_countries_Country_id",
                table: "regions");

            migrationBuilder.RenameColumn(
                name: "type",
                table: "regions",
                newName: "tipo");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "regions",
                newName: "nombre");

            migrationBuilder.RenameColumn(
                name: "Country_id",
                table: "regions",
                newName: "pais_id");

            migrationBuilder.RenameIndex(
                name: "IX_regions_Country_id",
                table: "regions",
                newName: "IX_regions_pais_id");

            migrationBuilder.AddForeignKey(
                name: "FK_regions_countries_pais_id",
                table: "regions",
                column: "pais_id",
                principalTable: "countries",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_regions_countries_pais_id",
                table: "regions");

            migrationBuilder.RenameColumn(
                name: "tipo",
                table: "regions",
                newName: "type");

            migrationBuilder.RenameColumn(
                name: "pais_id",
                table: "regions",
                newName: "Country_id");

            migrationBuilder.RenameColumn(
                name: "nombre",
                table: "regions",
                newName: "name");

            migrationBuilder.RenameIndex(
                name: "IX_regions_pais_id",
                table: "regions",
                newName: "IX_regions_Country_id");

            migrationBuilder.AddForeignKey(
                name: "FK_regions_countries_Country_id",
                table: "regions",
                column: "Country_id",
                principalTable: "countries",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
