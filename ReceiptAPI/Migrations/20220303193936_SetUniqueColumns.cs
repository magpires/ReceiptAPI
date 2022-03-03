using Microsoft.EntityFrameworkCore.Migrations;

namespace ReceiptAPI.Migrations
{
    public partial class SetUniqueColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_users_email",
                table: "users",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_customers_email_phone_number",
                table: "customers",
                columns: new[] { "email", "phone_number" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_users_email",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_customers_email_phone_number",
                table: "customers");
        }
    }
}
