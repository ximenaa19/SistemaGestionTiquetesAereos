using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionAerolineas.Migrations
{
    /// <inheritdoc />
    public partial class paopleEmailMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "personemails",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    persona_id = table.Column<int>(type: "int", nullable: false),
                    usuario_email = table.Column<string>(type: "varchar(100)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    dominio_email_id = table.Column<int>(type: "int", nullable: false),
                    es_principal = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_personemails", x => x.id);
                    table.ForeignKey(
                        name: "FK_personemails_emaildomains_dominio_email_id",
                        column: x => x.dominio_email_id,
                        principalTable: "emaildomains",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_personemails_people_persona_id",
                        column: x => x.persona_id,
                        principalTable: "people",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_personemails_dominio_email_id",
                table: "personemails",
                column: "dominio_email_id");

            migrationBuilder.CreateIndex(
                name: "IX_personemails_persona_id",
                table: "personemails",
                column: "persona_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "personemails");
        }
    }
}
