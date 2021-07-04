using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RewardingSystem.Migrations
{
    public partial class Sprint31 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Merchants",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.CreateTable(
                name: "VoucherRank",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoucherRank", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VoucherType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Discount = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoucherType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Voucher",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Limit = table.Column<int>(nullable: false),
                    Code = table.Column<string>(nullable: false),
                    MerchantId = table.Column<int>(nullable: false),
                    VoucherRankId = table.Column<int>(nullable: false),
                    VoucherTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voucher", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Voucher_Merchants_MerchantId",
                        column: x => x.MerchantId,
                        principalTable: "Merchants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Voucher_VoucherRank_VoucherRankId",
                        column: x => x.VoucherRankId,
                        principalTable: "VoucherRank",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Voucher_VoucherType_VoucherTypeId",
                        column: x => x.VoucherTypeId,
                        principalTable: "VoucherType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Merchants_Name",
                table: "Merchants",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Voucher_Code",
                table: "Voucher",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Voucher_MerchantId",
                table: "Voucher",
                column: "MerchantId");

            migrationBuilder.CreateIndex(
                name: "IX_Voucher_VoucherRankId",
                table: "Voucher",
                column: "VoucherRankId");

            migrationBuilder.CreateIndex(
                name: "IX_Voucher_VoucherTypeId",
                table: "Voucher",
                column: "VoucherTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_VoucherRank_Name",
                table: "VoucherRank",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VoucherType_Name",
                table: "VoucherType",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Voucher");

            migrationBuilder.DropTable(
                name: "VoucherRank");

            migrationBuilder.DropTable(
                name: "VoucherType");

            migrationBuilder.DropIndex(
                name: "IX_Merchants_Name",
                table: "Merchants");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Merchants",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
