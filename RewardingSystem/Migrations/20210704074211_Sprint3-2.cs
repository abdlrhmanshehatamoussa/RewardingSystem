using Microsoft.EntityFrameworkCore.Migrations;

namespace RewardingSystem.Migrations
{
    public partial class Sprint32 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Points",
                table: "VoucherRank",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Points",
                table: "VoucherRank");
        }
    }
}
