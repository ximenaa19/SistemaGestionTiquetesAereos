// [DocHeader]
// M?dulo: General
// Capa: General
// Archivo: Migrations\20260420100009_AddPaymentMethods.cs
// Responsabilidad: Agrupa l?gica espec?fica del m?dulo respetando la arquitectura por capas del proyecto.
// Flujo: Participa en el flujo general de construcci?n y ejecuci?n del sistema de gesti?n a?rea.
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionAerolineas.Migrations
{
    /// <inheritdoc />
    public partial class AddPaymentMethods : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "paymentmethods",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    tipo_medio_pago_id = table.Column<int>(type: "int", nullable: false),
                    tipo_tarjeta_id = table.Column<int>(type: "int", nullable: true),
                    emisor_tarjeta_id = table.Column<int>(type: "int", nullable: true),
                    nombre_comercial = table.Column<string>(type: "varchar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_paymentmethods", x => x.id);
                    table.ForeignKey(
                        name: "FK_paymentmethods_card_issuers_emisor_tarjeta_id",
                        column: x => x.emisor_tarjeta_id,
                        principalTable: "card_issuers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_paymentmethods_payment_method_types_tipo_medio_pago_id",
                        column: x => x.tipo_medio_pago_id,
                        principalTable: "payment_method_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_paymentmethods_tipos_tarjeta_tipo_tarjeta_id",
                        column: x => x.tipo_tarjeta_id,
                        principalTable: "tipos_tarjeta",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_paymentmethods_emisor_tarjeta_id",
                table: "paymentmethods",
                column: "emisor_tarjeta_id");

            migrationBuilder.CreateIndex(
                name: "IX_paymentmethods_nombre_comercial",
                table: "paymentmethods",
                column: "nombre_comercial",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_paymentmethods_tipo_medio_pago_id",
                table: "paymentmethods",
                column: "tipo_medio_pago_id");

            migrationBuilder.CreateIndex(
                name: "IX_paymentmethods_tipo_tarjeta_id",
                table: "paymentmethods",
                column: "tipo_tarjeta_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "paymentmethods");
        }
    }
}
