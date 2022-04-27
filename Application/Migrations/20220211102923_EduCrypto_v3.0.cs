using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Application.Migrations
{
    public partial class EduCrypto_v30 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCryptos_CryptoCurrencies_cryptoCurrencyId",
                table: "UserCryptos");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTradeHistories_CryptoCurrencies_boughtCryptoCurrencyMode~",
                table: "UserTradeHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTradeHistories_CryptoCurrencies_spentCryptoCurrencyModel~",
                table: "UserTradeHistories");

            migrationBuilder.DropTable(
                name: "CryptoCurrencies");

            migrationBuilder.DropIndex(
                name: "IX_UserTradeHistories_boughtCryptoCurrencyModelId",
                table: "UserTradeHistories");

            migrationBuilder.DropIndex(
                name: "IX_UserTradeHistories_spentCryptoCurrencyModelId",
                table: "UserTradeHistories");

            migrationBuilder.DropIndex(
                name: "IX_UserCryptos_cryptoCurrencyId",
                table: "UserCryptos");

            migrationBuilder.DropColumn(
                name: "boughtCryptoCurrencyModelId",
                table: "UserTradeHistories");

            migrationBuilder.DropColumn(
                name: "spentCryptoCurrencyModelId",
                table: "UserTradeHistories");

            migrationBuilder.DropColumn(
                name: "cryptoCurrencyId",
                table: "UserCryptos");

            migrationBuilder.AddColumn<string>(
                name: "boughtCryptoSymbol",
                table: "UserTradeHistories",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "spentCryptoSymbol",
                table: "UserTradeHistories",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "cryptoSymbol",
                table: "UserCryptos",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "boughtCryptoSymbol",
                table: "UserTradeHistories");

            migrationBuilder.DropColumn(
                name: "spentCryptoSymbol",
                table: "UserTradeHistories");

            migrationBuilder.DropColumn(
                name: "cryptoSymbol",
                table: "UserCryptos");

            migrationBuilder.AddColumn<int>(
                name: "boughtCryptoCurrencyModelId",
                table: "UserTradeHistories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "spentCryptoCurrencyModelId",
                table: "UserTradeHistories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "cryptoCurrencyId",
                table: "UserCryptos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CryptoCurrencies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    circulatingSupply = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    contraction = table.Column<string>(type: "varchar(5)", maxLength: 5, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    dayPercent = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    marketCap = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    name = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    price = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    volume = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    weekPercent = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CryptoCurrencies", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_UserTradeHistories_boughtCryptoCurrencyModelId",
                table: "UserTradeHistories",
                column: "boughtCryptoCurrencyModelId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTradeHistories_spentCryptoCurrencyModelId",
                table: "UserTradeHistories",
                column: "spentCryptoCurrencyModelId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCryptos_cryptoCurrencyId",
                table: "UserCryptos",
                column: "cryptoCurrencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCryptos_CryptoCurrencies_cryptoCurrencyId",
                table: "UserCryptos",
                column: "cryptoCurrencyId",
                principalTable: "CryptoCurrencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTradeHistories_CryptoCurrencies_boughtCryptoCurrencyMode~",
                table: "UserTradeHistories",
                column: "boughtCryptoCurrencyModelId",
                principalTable: "CryptoCurrencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTradeHistories_CryptoCurrencies_spentCryptoCurrencyModel~",
                table: "UserTradeHistories",
                column: "spentCryptoCurrencyModelId",
                principalTable: "CryptoCurrencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
