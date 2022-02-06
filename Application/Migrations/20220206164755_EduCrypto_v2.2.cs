using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Application.Migrations
{
    public partial class EduCrypto_v22 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCryptos_CryptoCurrencies_cryptoCurrencyId",
                table: "UserCryptos");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCryptos_UserHandlings_userHandlingModelId",
                table: "UserCryptos");

            migrationBuilder.DropForeignKey(
                name: "FK_UserForGroups_Groups_groupModelId",
                table: "UserForGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_UserForGroups_UserHandlings_userHandlingModelId",
                table: "UserForGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTradeHistories_CryptoCurrencies_boughtCryptoCurrencyMode~",
                table: "UserTradeHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTradeHistories_CryptoCurrencies_spentCryptoCurrencyModel~",
                table: "UserTradeHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTradeHistories_UserHandlings_userHandlingModelId",
                table: "UserTradeHistories");

            migrationBuilder.AlterColumn<int>(
                name: "userHandlingModelId",
                table: "UserTradeHistories",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "spentCryptoCurrencyModelId",
                table: "UserTradeHistories",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "boughtCryptoCurrencyModelId",
                table: "UserTradeHistories",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "userHandlingModelId",
                table: "UserForGroups",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "groupWalletNumber",
                table: "UserForGroups",
                type: "varchar(34)",
                maxLength: 34,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(34)",
                oldMaxLength: 34)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "groupModelId",
                table: "UserForGroups",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "userHandlingModelId",
                table: "UserCryptos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "cryptoValue",
                table: "UserCryptos",
                type: "decimal(65,30)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double");

            migrationBuilder.AlterColumn<int>(
                name: "cryptoCurrencyId",
                table: "UserCryptos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "finishDate", "isFinished", "name", "startBudget", "startDate" },
                values: new object[] { 1, new DateTime(2022, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "test", 100m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "UserHandlings",
                columns: new[] { "Id", "PasswordHash", "birthDate", "email", "fullName", "moneyDollar", "profilePictureId", "userName", "walletNumber", "xpLevel" },
                values: new object[] { 1, "wSg08QMfZJchTyfUQy8mUXrUlBVsuI1RK9sdxLV9staSo9+iaaGbCgoqD9fWoqiF4zyDnJPCBtowoYc5KEftJw==", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "test@test.com", "Test Elek", 1000m, null, "test", null, 0 });

            migrationBuilder.InsertData(
                table: "UserHandlings",
                columns: new[] { "Id", "PasswordHash", "birthDate", "email", "fullName", "moneyDollar", "profilePictureId", "userName", "walletNumber", "xpLevel" },
                values: new object[] { 2, "eCf8a+CB6qaYDSy/BEj0sRgzVo4OWseUL/qLhw1a9hWeVX3qNK4DUis3RJif6pFYuur1t0ttU95UsJMe0eBJSg==", new DateTime(2049, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "replica@wallas.com", "Officer K", 1000m, null, "replica", null, 0 });

            migrationBuilder.InsertData(
                table: "UserForGroups",
                columns: new[] { "Id", "accesLevel", "groupModelId", "groupWalletNumber", "money", "userHandlingModelId" },
                values: new object[] { 1, "creator", 1, null, 100m, 1 });

            migrationBuilder.InsertData(
                table: "UserForGroups",
                columns: new[] { "Id", "accesLevel", "groupModelId", "groupWalletNumber", "money", "userHandlingModelId" },
                values: new object[] { 2, "member", 1, null, 100m, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_UserHandlings_email",
                table: "UserHandlings",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserHandlings_userName",
                table: "UserHandlings",
                column: "userName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserHandlings_walletNumber",
                table: "UserHandlings",
                column: "walletNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserForGroups_groupWalletNumber",
                table: "UserForGroups",
                column: "groupWalletNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Groups_name",
                table: "Groups",
                column: "name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCryptos_CryptoCurrencies_cryptoCurrencyId",
                table: "UserCryptos",
                column: "cryptoCurrencyId",
                principalTable: "CryptoCurrencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCryptos_UserHandlings_userHandlingModelId",
                table: "UserCryptos",
                column: "userHandlingModelId",
                principalTable: "UserHandlings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserForGroups_Groups_groupModelId",
                table: "UserForGroups",
                column: "groupModelId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserForGroups_UserHandlings_userHandlingModelId",
                table: "UserForGroups",
                column: "userHandlingModelId",
                principalTable: "UserHandlings",
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

            migrationBuilder.AddForeignKey(
                name: "FK_UserTradeHistories_UserHandlings_userHandlingModelId",
                table: "UserTradeHistories",
                column: "userHandlingModelId",
                principalTable: "UserHandlings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCryptos_CryptoCurrencies_cryptoCurrencyId",
                table: "UserCryptos");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCryptos_UserHandlings_userHandlingModelId",
                table: "UserCryptos");

            migrationBuilder.DropForeignKey(
                name: "FK_UserForGroups_Groups_groupModelId",
                table: "UserForGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_UserForGroups_UserHandlings_userHandlingModelId",
                table: "UserForGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTradeHistories_CryptoCurrencies_boughtCryptoCurrencyMode~",
                table: "UserTradeHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTradeHistories_CryptoCurrencies_spentCryptoCurrencyModel~",
                table: "UserTradeHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTradeHistories_UserHandlings_userHandlingModelId",
                table: "UserTradeHistories");

            migrationBuilder.DropIndex(
                name: "IX_UserHandlings_email",
                table: "UserHandlings");

            migrationBuilder.DropIndex(
                name: "IX_UserHandlings_userName",
                table: "UserHandlings");

            migrationBuilder.DropIndex(
                name: "IX_UserHandlings_walletNumber",
                table: "UserHandlings");

            migrationBuilder.DropIndex(
                name: "IX_UserForGroups_groupWalletNumber",
                table: "UserForGroups");

            migrationBuilder.DropIndex(
                name: "IX_Groups_name",
                table: "Groups");

            migrationBuilder.DeleteData(
                table: "UserForGroups",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserForGroups",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserHandlings",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserHandlings",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AlterColumn<int>(
                name: "userHandlingModelId",
                table: "UserTradeHistories",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "spentCryptoCurrencyModelId",
                table: "UserTradeHistories",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "boughtCryptoCurrencyModelId",
                table: "UserTradeHistories",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "userHandlingModelId",
                table: "UserForGroups",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "groupWalletNumber",
                table: "UserForGroups",
                type: "varchar(34)",
                maxLength: 34,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(34)",
                oldMaxLength: 34,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "groupModelId",
                table: "UserForGroups",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "userHandlingModelId",
                table: "UserCryptos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<double>(
                name: "cryptoValue",
                table: "UserCryptos",
                type: "double",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)");

            migrationBuilder.AlterColumn<int>(
                name: "cryptoCurrencyId",
                table: "UserCryptos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCryptos_CryptoCurrencies_cryptoCurrencyId",
                table: "UserCryptos",
                column: "cryptoCurrencyId",
                principalTable: "CryptoCurrencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCryptos_UserHandlings_userHandlingModelId",
                table: "UserCryptos",
                column: "userHandlingModelId",
                principalTable: "UserHandlings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserForGroups_Groups_groupModelId",
                table: "UserForGroups",
                column: "groupModelId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserForGroups_UserHandlings_userHandlingModelId",
                table: "UserForGroups",
                column: "userHandlingModelId",
                principalTable: "UserHandlings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTradeHistories_CryptoCurrencies_boughtCryptoCurrencyMode~",
                table: "UserTradeHistories",
                column: "boughtCryptoCurrencyModelId",
                principalTable: "CryptoCurrencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTradeHistories_CryptoCurrencies_spentCryptoCurrencyModel~",
                table: "UserTradeHistories",
                column: "spentCryptoCurrencyModelId",
                principalTable: "CryptoCurrencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTradeHistories_UserHandlings_userHandlingModelId",
                table: "UserTradeHistories",
                column: "userHandlingModelId",
                principalTable: "UserHandlings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
