using Microsoft.EntityFrameworkCore.Migrations;

namespace RewardingSystem.Migrations
{
    public partial class Sprint42 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Purchases_UserId",
                table: "Purchases");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_UserId_VoucherId",
                table: "Purchases",
                columns: new[] { "UserId", "VoucherId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Purchases_UserId_VoucherId",
                table: "Purchases");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_UserId",
                table: "Purchases",
                column: "UserId");
        }
    }
}
