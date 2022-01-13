using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Application.Migrations
{
    public partial class testKeys_v4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_UserCryptos_CryptoCurrenc_cryptoCurrencyId",
            //    table: "UserCryptos");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCryptos_UserFinance_userFinanceuserId",
                table: "UserCryptos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserFinance",
                table: "UserFinance");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CryptoCurrency",
                table: "CryptoCurrency");

            migrationBuilder.RenameTable(
                name: "UserFinance",
                newName: "UserFinances");

            migrationBuilder.RenameTable(
                name: "CryptoCurrency",
                newName: "CryptoCurrencies");

            migrationBuilder.RenameColumn(
                name: "userFinanceuserId",
                table: "UserCryptos",
                newName: "userForGroupsId");

            migrationBuilder.RenameIndex(
                name: "IX_UserCryptos_userFinanceuserId",
                table: "UserCryptos",
                newName: "IX_UserCryptos_userForGroupsId");

            migrationBuilder.AlterColumn<int>(
                name: "userId",
                table: "UserTradeHistories",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "spentId",
                table: "UserTradeHistories",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "boughtId",
                table: "UserTradeHistories",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "boughtCryptoCurrencyId",
                table: "UserTradeHistories",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "spentCryptoCurrencyId",
                table: "UserTradeHistories",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "userHandlingId",
                table: "UserTradeHistories",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "userId",
                table: "UserForGroups",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "userHandlingId",
                table: "UserForGroups",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "walletNumber",
                table: "UserCryptos",
                type: "varchar(34)",
                maxLength: 34,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "groupWalletNumber",
                table: "UserCryptos",
                type: "varchar(34)",
                maxLength: 34,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(34)",
                oldMaxLength: 34)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "userFinanceId",
                table: "UserCryptos",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "UserFinances",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<int>(
                name: "userId",
                table: "UserFinances",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "userHandlingId",
                table: "UserFinances",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserFinances",
                table: "UserFinances",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CryptoCurrencies",
                table: "CryptoCurrencies",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserTradeHistories_boughtCryptoCurrencyId",
                table: "UserTradeHistories",
                column: "boughtCryptoCurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTradeHistories_groupId",
                table: "UserTradeHistories",
                column: "groupId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTradeHistories_spentCryptoCurrencyId",
                table: "UserTradeHistories",
                column: "spentCryptoCurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTradeHistories_userHandlingId",
                table: "UserTradeHistories",
                column: "userHandlingId");

            migrationBuilder.CreateIndex(
                name: "IX_UserForGroups_groupId",
                table: "UserForGroups",
                column: "groupId");

            migrationBuilder.CreateIndex(
                name: "IX_UserForGroups_userHandlingId",
                table: "UserForGroups",
                column: "userHandlingId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCryptos_userFinanceId",
                table: "UserCryptos",
                column: "userFinanceId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFinances_userHandlingId",
                table: "UserFinances",
                column: "userHandlingId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCryptos_CryptoCurrencies_cryptoCurrencyId",
                table: "UserCryptos",
                column: "cryptoCurrencyId",
                principalTable: "CryptoCurrencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCryptos_UserFinances_userFinanceId",
                table: "UserCryptos",
                column: "userFinanceId",
                principalTable: "UserFinances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCryptos_UserForGroups_userForGroupsId",
                table: "UserCryptos",
                column: "userForGroupsId",
                principalTable: "UserForGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFinances_UserHandlings_userHandlingId",
                table: "UserFinances",
                column: "userHandlingId",
                principalTable: "UserHandlings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserForGroups_Groups_groupId",
                table: "UserForGroups",
                column: "groupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserForGroups_UserHandlings_userHandlingId",
                table: "UserForGroups",
                column: "userHandlingId",
                principalTable: "UserHandlings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTradeHistories_CryptoCurrencies_boughtCryptoCurrencyId",
                table: "UserTradeHistories",
                column: "boughtCryptoCurrencyId",
                principalTable: "CryptoCurrencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTradeHistories_CryptoCurrencies_spentCryptoCurrencyId",
                table: "UserTradeHistories",
                column: "spentCryptoCurrencyId",
                principalTable: "CryptoCurrencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTradeHistories_Groups_groupId",
                table: "UserTradeHistories",
                column: "groupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTradeHistories_UserHandlings_userHandlingId",
                table: "UserTradeHistories",
                column: "userHandlingId",
                principalTable: "UserHandlings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCryptos_CryptoCurrencies_cryptoCurrencyId",
                table: "UserCryptos");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCryptos_UserFinances_userFinanceId",
                table: "UserCryptos");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCryptos_UserForGroups_userForGroupsId",
                table: "UserCryptos");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFinances_UserHandlings_userHandlingId",
                table: "UserFinances");

            migrationBuilder.DropForeignKey(
                name: "FK_UserForGroups_Groups_groupId",
                table: "UserForGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_UserForGroups_UserHandlings_userHandlingId",
                table: "UserForGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTradeHistories_CryptoCurrencies_boughtCryptoCurrencyId",
                table: "UserTradeHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTradeHistories_CryptoCurrencies_spentCryptoCurrencyId",
                table: "UserTradeHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTradeHistories_Groups_groupId",
                table: "UserTradeHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTradeHistories_UserHandlings_userHandlingId",
                table: "UserTradeHistories");

            migrationBuilder.DropIndex(
                name: "IX_UserTradeHistories_boughtCryptoCurrencyId",
                table: "UserTradeHistories");

            migrationBuilder.DropIndex(
                name: "IX_UserTradeHistories_groupId",
                table: "UserTradeHistories");

            migrationBuilder.DropIndex(
                name: "IX_UserTradeHistories_spentCryptoCurrencyId",
                table: "UserTradeHistories");

            migrationBuilder.DropIndex(
                name: "IX_UserTradeHistories_userHandlingId",
                table: "UserTradeHistories");

            migrationBuilder.DropIndex(
                name: "IX_UserForGroups_groupId",
                table: "UserForGroups");

            migrationBuilder.DropIndex(
                name: "IX_UserForGroups_userHandlingId",
                table: "UserForGroups");

            migrationBuilder.DropIndex(
                name: "IX_UserCryptos_userFinanceId",
                table: "UserCryptos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserFinances",
                table: "UserFinances");

            migrationBuilder.DropIndex(
                name: "IX_UserFinances_userHandlingId",
                table: "UserFinances");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CryptoCurrencies",
                table: "CryptoCurrencies");

            migrationBuilder.DropColumn(
                name: "boughtCryptoCurrencyId",
                table: "UserTradeHistories");

            migrationBuilder.DropColumn(
                name: "spentCryptoCurrencyId",
                table: "UserTradeHistories");

            migrationBuilder.DropColumn(
                name: "userHandlingId",
                table: "UserTradeHistories");

            migrationBuilder.DropColumn(
                name: "userHandlingId",
                table: "UserForGroups");

            migrationBuilder.DropColumn(
                name: "userFinanceId",
                table: "UserCryptos");

            migrationBuilder.DropColumn(
                name: "userHandlingId",
                table: "UserFinances");

            migrationBuilder.RenameTable(
                name: "UserFinances",
                newName: "UserFinance");

            migrationBuilder.RenameTable(
                name: "CryptoCurrencies",
                newName: "CryptoCurrency");

            migrationBuilder.RenameColumn(
                name: "userForGroupsId",
                table: "UserCryptos",
                newName: "userFinanceuserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserCryptos_userForGroupsId",
                table: "UserCryptos",
                newName: "IX_UserCryptos_userFinanceuserId");

            migrationBuilder.AlterColumn<int>(
                name: "userId",
                table: "UserTradeHistories",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "spentId",
                table: "UserTradeHistories",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "boughtId",
                table: "UserTradeHistories",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "userId",
                table: "UserForGroups",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "walletNumber",
                table: "UserCryptos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "varchar(34)",
                oldMaxLength: 34,
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "groupWalletNumber",
                table: "UserCryptos",
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
                name: "userId",
                table: "UserFinance",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "UserFinance",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserFinance",
                table: "UserFinance",
                column: "userId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CryptoCurrency",
                table: "CryptoCurrency",
                column: "Id");

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
    }
}
