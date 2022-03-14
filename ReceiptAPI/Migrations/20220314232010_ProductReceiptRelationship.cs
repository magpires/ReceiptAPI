using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ReceiptAPI.Migrations
{
    public partial class ProductReceiptRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReceiptId",
                table: "product",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "receipt",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    customer_id = table.Column<int>(type: "int", nullable: false),
                    payment_method = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_receipt", x => x.id);
                    table.ForeignKey(
                        name: "FK_receipt_customers_customer_id",
                        column: x => x.customer_id,
                        principalTable: "customers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "product_receipt",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    product_id = table.Column<int>(type: "int", nullable: false),
                    receipt_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_receipt", x => x.id);
                    table.ForeignKey(
                        name: "FK_product_receipt_product_product_id",
                        column: x => x.product_id,
                        principalTable: "product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_product_receipt_receipt_receipt_id",
                        column: x => x.receipt_id,
                        principalTable: "receipt",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_product_ReceiptId",
                table: "product",
                column: "ReceiptId");

            migrationBuilder.CreateIndex(
                name: "IX_product_receipt_product_id",
                table: "product_receipt",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_product_receipt_receipt_id",
                table: "product_receipt",
                column: "receipt_id");

            migrationBuilder.CreateIndex(
                name: "IX_receipt_customer_id",
                table: "receipt",
                column: "customer_id");

            migrationBuilder.AddForeignKey(
                name: "FK_product_receipt_ReceiptId",
                table: "product",
                column: "ReceiptId",
                principalTable: "receipt",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_product_receipt_ReceiptId",
                table: "product");

            migrationBuilder.DropTable(
                name: "product_receipt");

            migrationBuilder.DropTable(
                name: "receipt");

            migrationBuilder.DropIndex(
                name: "IX_product_ReceiptId",
                table: "product");

            migrationBuilder.DropColumn(
                name: "ReceiptId",
                table: "product");
        }
    }
}
