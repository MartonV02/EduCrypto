using Microsoft.EntityFrameworkCore.Migrations;

namespace Application.Migrations
{
    public partial class testKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserFinances",
                table: "UserFinances");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CryptoCurrencies",
                table: "CryptoCurrencies");

            migrationBuilder.DropColumn(
                name: "cryptoId",
                table: "UserCryptos");

            migrationBuilder.RenameTable(
                name: "UserFinances",
                newName: "UserFinance");

            migrationBuilder.RenameTable(
                name: "CryptoCurrencies",
                newName: "CryptoCurrency");

            migrationBuilder.AlterColumn<int>(
                name: "walletNumber",
                table: "UserCryptos",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(34)",
                oldMaxLength: 34)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "cryptoCurrencyId",
                table: "UserCryptos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "userFinanceuserId",
                table: "UserCryptos",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserFinance",
                table: "UserFinance",
                column: "userId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CryptoCurrency",
                table: "CryptoCurrency",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserCryptos_cryptoCurrencyId",
                table: "UserCryptos",
                column: "cryptoCurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCryptos_userFinanceuserId",
                table: "UserCryptos",
                column: "userFinanceuserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCryptos_CryptoCurrency_cryptoCurrencyId",
                table: "UserCryptos",
                column: "cryptoCurrencyId",
                principalTable: "CryptoCurrency",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCryptos_UserFinance_userFinanceuserId",
                table: "UserCryptos",
                column: "userFinanceuserId",
                principalTable: "UserFinance",
                principalColumn: "userId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCryptos_CryptoCurrency_cryptoCurrencyId",
                table: "UserCryptos");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCryptos_UserFinance_userFinanceuserId",
                table: "UserCryptos");

            migrationBuilder.DropIndex(
                name: "IX_UserCryptos_cryptoCurrencyId",
                table: "UserCryptos");

            migrationBuilder.DropIndex(
                name: "IX_UserCryptos_userFinanceuserId",
                table: "UserCryptos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserFinance",
                table: "UserFinance");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CryptoCurrency",
                table: "CryptoCurrency");

            migrationBuilder.DropColumn(
                name: "cryptoCurrencyId",
                table: "UserCryptos");

            migrationBuilder.DropColumn(
                name: "userFinanceuserId",
                table: "UserCryptos");

            migrationBuilder.RenameTable(
                name: "UserFinance",
                newName: "UserFinances");

            migrationBuilder.RenameTable(
                name: "CryptoCurrency",
                newName: "CryptoCurrencies");

            migrationBuilder.AlterColumn<string>(
                name: "walletNumber",
                table: "UserCryptos",
                type: "varchar(34)",
                maxLength: 34,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "cryptoId",
                table: "UserCryptos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserFinances",
                table: "UserFinances",
                column: "userId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CryptoCurrencies",
                table: "CryptoCurrencies",
                column: "Id");
        }
    }
}
