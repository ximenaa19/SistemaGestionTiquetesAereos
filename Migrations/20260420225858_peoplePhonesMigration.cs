using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionAerolineas.Migrations
{
    /// <inheritdoc />
    public partial class peoplePhonesMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "personphones",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    persona_id = table.Column<int>(type: "int", nullable: false),
                    codigo_telefono_id = table.Column<int>(type: "int", nullable: false),
                    numero_telefono = table.Column<string>(type: "varchar(20)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    es_principal = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_personphones", x => x.id);
                    table.ForeignKey(
                        name: "FK_personphones_people_persona_id",
                        column: x => x.persona_id,
                        principalTable: "people",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_personphones_phonecodes_codigo_telefono_id",
                        column: x => x.codigo_telefono_id,
                        principalTable: "phonecodes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_personphones_codigo_telefono_id",
                table: "personphones",
                column: "codigo_telefono_id");

            migrationBuilder.CreateIndex(
                name: "IX_personphones_persona_id",
                table: "personphones",
                column: "persona_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "personphones");
        }
    }
}
