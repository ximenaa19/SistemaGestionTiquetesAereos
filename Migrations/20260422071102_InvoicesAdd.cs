using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionAerolineas.Migrations
{
    /// <inheritdoc />
    public partial class InvoicesAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "invoices",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    reserva_id = table.Column<int>(type: "int", nullable: false),
                    numero_factura = table.Column<string>(type: "varchar(30)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    fecha_emision = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    subtotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    impuestos = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    total = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    creado_en = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_invoices", x => x.id);
                    table.ForeignKey(
                        name: "FK_invoices_reservations_reserva_id",
                        column: x => x.reserva_id,
                        principalTable: "reservations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "invoiceitems",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    factura_id = table.Column<int>(type: "int", nullable: false),
                    tipo_item_id = table.Column<int>(type: "int", nullable: false),
                    descripcion = table.Column<string>(type: "varchar(200)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    cantidad = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    precio_unitario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    subtotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    reserva_pasajero_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_invoiceitems", x => x.id);
                    table.ForeignKey(
                        name: "FK_invoiceitems_invoices_factura_id",
                        column: x => x.factura_id,
                        principalTable: "invoices",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_invoiceitems_reservationpassengers_reserva_pasajero_id",
                        column: x => x.reserva_pasajero_id,
                        principalTable: "reservationpassengers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_invoiceitems_tipos_item_factura_tipo_item_id",
                        column: x => x.tipo_item_id,
                        principalTable: "tipos_item_factura",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_invoiceitems_factura_id",
                table: "invoiceitems",
                column: "factura_id");

            migrationBuilder.CreateIndex(
                name: "IX_invoiceitems_reserva_pasajero_id",
                table: "invoiceitems",
                column: "reserva_pasajero_id");

            migrationBuilder.CreateIndex(
                name: "IX_invoiceitems_tipo_item_id",
                table: "invoiceitems",
                column: "tipo_item_id");

            migrationBuilder.CreateIndex(
                name: "IX_invoices_numero_factura",
                table: "invoices",
                column: "numero_factura",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_invoices_reserva_id",
                table: "invoices",
                column: "reserva_id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "invoiceitems");

            migrationBuilder.DropTable(
                name: "invoices");
        }
    }
}
