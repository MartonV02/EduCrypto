using Microsoft.EntityFrameworkCore.Migrations;

namespace Application.Migrations
{
    public partial class EduCrypto_v41 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "actualPrice",
                table: "UserTradeHistories",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "actualPrice",
                table: "UserTradeHistories");
        }
    }
}
