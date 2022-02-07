using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Application.Migrations
{
    public partial class EduCrypto_v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCryptos_UserFinances_userFinanceId",
                table: "UserCryptos");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCryptos_UserForGroups_userForGroupsId",
                table: "UserCryptos");

            migrationBuilder.DropForeignKey(
                name: "FK_UserForGroups_Groups_groupId",
                table: "UserForGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_UserForGroups_UserHandlings_userHandlingId",
                table: "UserForGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_UserHandlings_Image_profilePictureIdId",
                table: "UserHandlings");

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

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropTable(
                name: "UserFinances");

            migrationBuilder.DropIndex(
                name: "IX_UserTradeHistories_groupId",
                table: "UserTradeHistories");

            migrationBuilder.DropIndex(
                name: "IX_UserForGroups_groupId",
                table: "UserForGroups");

            migrationBuilder.DropIndex(
                name: "IX_UserCryptos_userForGroupsId",
                table: "UserCryptos");

            migrationBuilder.RenameColumn(
                name: "userHandlingId",
                table: "UserTradeHistories",
                newName: "userHandlingModelId");

            migrationBuilder.RenameColumn(
                name: "spentCryptoCurrencyId",
                table: "UserTradeHistories",
                newName: "spentCryptoCurrencyModelId");

            migrationBuilder.RenameColumn(
                name: "boughtCryptoCurrencyId",
                table: "UserTradeHistories",
                newName: "groupModelId");

            migrationBuilder.RenameIndex(
                name: "IX_UserTradeHistories_userHandlingId",
                table: "UserTradeHistories",
                newName: "IX_UserTradeHistories_userHandlingModelId");

            migrationBuilder.RenameIndex(
                name: "IX_UserTradeHistories_spentCryptoCurrencyId",
                table: "UserTradeHistories",
                newName: "IX_UserTradeHistories_spentCryptoCurrencyModelId");

            migrationBuilder.RenameIndex(
                name: "IX_UserTradeHistories_boughtCryptoCurrencyId",
                table: "UserTradeHistories",
                newName: "IX_UserTradeHistories_groupModelId");

            migrationBuilder.RenameColumn(
                name: "fullNme",
                table: "UserHandlings",
                newName: "fullName");

            migrationBuilder.RenameColumn(
                name: "userHandlingId",
                table: "UserForGroups",
                newName: "userHandlingModelId");

            migrationBuilder.RenameIndex(
                name: "IX_UserForGroups_userHandlingId",
                table: "UserForGroups",
                newName: "IX_UserForGroups_userHandlingModelId");

            migrationBuilder.RenameColumn(
                name: "userForGroupsId",
                table: "UserCryptos",
                newName: "userId");

            migrationBuilder.RenameColumn(
                name: "userFinanceId",
                table: "UserCryptos",
                newName: "userHandlingModelId");

            migrationBuilder.RenameIndex(
                name: "IX_UserCryptos_userFinanceId",
                table: "UserCryptos",
                newName: "IX_UserCryptos_userHandlingModelId");

            migrationBuilder.AddColumn<int>(
                name: "boughtCryptoCurrencyModelId",
                table: "UserTradeHistories",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "moneyDollar",
                table: "UserHandlings",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "walletNumber",
                table: "UserHandlings",
                type: "varchar(34)",
                maxLength: 34,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "groupId",
                table: "UserForGroups",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "groupModelId",
                table: "UserForGroups",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "cryptoId",
                table: "UserCryptos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "userForGroupId",
                table: "UserCryptos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "userForGroupsModelId",
                table: "UserCryptos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ImageModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IamageTitle = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ImageData = table.Column<byte[]>(type: "longblob", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageModel", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_UserTradeHistories_boughtCryptoCurrencyModelId",
                table: "UserTradeHistories",
                column: "boughtCryptoCurrencyModelId");

            migrationBuilder.CreateIndex(
                name: "IX_UserForGroups_groupModelId",
                table: "UserForGroups",
                column: "groupModelId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCryptos_userForGroupsModelId",
                table: "UserCryptos",
                column: "userForGroupsModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCryptos_UserForGroups_userForGroupsModelId",
                table: "UserCryptos",
                column: "userForGroupsModelId",
                principalTable: "UserForGroups",
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
                name: "FK_UserHandlings_ImageModel_profilePictureIdId",
                table: "UserHandlings",
                column: "profilePictureIdId",
                principalTable: "ImageModel",
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
                name: "FK_UserTradeHistories_Groups_groupModelId",
                table: "UserTradeHistories",
                column: "groupModelId",
                principalTable: "Groups",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCryptos_UserForGroups_userForGroupsModelId",
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
                name: "FK_UserHandlings_ImageModel_profilePictureIdId",
                table: "UserHandlings");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTradeHistories_CryptoCurrencies_boughtCryptoCurrencyMode~",
                table: "UserTradeHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTradeHistories_CryptoCurrencies_spentCryptoCurrencyModel~",
                table: "UserTradeHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTradeHistories_Groups_groupModelId",
                table: "UserTradeHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTradeHistories_UserHandlings_userHandlingModelId",
                table: "UserTradeHistories");

            migrationBuilder.DropTable(
                name: "ImageModel");

            migrationBuilder.DropIndex(
                name: "IX_UserTradeHistories_boughtCryptoCurrencyModelId",
                table: "UserTradeHistories");

            migrationBuilder.DropIndex(
                name: "IX_UserForGroups_groupModelId",
                table: "UserForGroups");

            migrationBuilder.DropIndex(
                name: "IX_UserCryptos_userForGroupsModelId",
                table: "UserCryptos");

            migrationBuilder.DropColumn(
                name: "boughtCryptoCurrencyModelId",
                table: "UserTradeHistories");

            migrationBuilder.DropColumn(
                name: "moneyDollar",
                table: "UserHandlings");

            migrationBuilder.DropColumn(
                name: "walletNumber",
                table: "UserHandlings");

            migrationBuilder.DropColumn(
                name: "groupModelId",
                table: "UserForGroups");

            migrationBuilder.DropColumn(
                name: "cryptoId",
                table: "UserCryptos");

            migrationBuilder.DropColumn(
                name: "userForGroupId",
                table: "UserCryptos");

            migrationBuilder.DropColumn(
                name: "userForGroupsModelId",
                table: "UserCryptos");

            migrationBuilder.RenameColumn(
                name: "userHandlingModelId",
                table: "UserTradeHistories",
                newName: "userHandlingId");

            migrationBuilder.RenameColumn(
                name: "spentCryptoCurrencyModelId",
                table: "UserTradeHistories",
                newName: "spentCryptoCurrencyId");

            migrationBuilder.RenameColumn(
                name: "groupModelId",
                table: "UserTradeHistories",
                newName: "boughtCryptoCurrencyId");

            migrationBuilder.RenameIndex(
                name: "IX_UserTradeHistories_userHandlingModelId",
                table: "UserTradeHistories",
                newName: "IX_UserTradeHistories_userHandlingId");

            migrationBuilder.RenameIndex(
                name: "IX_UserTradeHistories_spentCryptoCurrencyModelId",
                table: "UserTradeHistories",
                newName: "IX_UserTradeHistories_spentCryptoCurrencyId");

            migrationBuilder.RenameIndex(
                name: "IX_UserTradeHistories_groupModelId",
                table: "UserTradeHistories",
                newName: "IX_UserTradeHistories_boughtCryptoCurrencyId");

            migrationBuilder.RenameColumn(
                name: "fullName",
                table: "UserHandlings",
                newName: "fullNme");

            migrationBuilder.RenameColumn(
                name: "userHandlingModelId",
                table: "UserForGroups",
                newName: "userHandlingId");

            migrationBuilder.RenameIndex(
                name: "IX_UserForGroups_userHandlingModelId",
                table: "UserForGroups",
                newName: "IX_UserForGroups_userHandlingId");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "UserCryptos",
                newName: "userForGroupsId");

            migrationBuilder.RenameColumn(
                name: "userHandlingModelId",
                table: "UserCryptos",
                newName: "userFinanceId");

            migrationBuilder.RenameIndex(
                name: "IX_UserCryptos_userHandlingModelId",
                table: "UserCryptos",
                newName: "IX_UserCryptos_userFinanceId");

            migrationBuilder.AlterColumn<int>(
                name: "groupId",
                table: "UserForGroups",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IamageTitle = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ImageData = table.Column<byte[]>(type: "longblob", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserFinances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    moneyDollar = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    userHandlingId = table.Column<int>(type: "int", nullable: true),
                    userId = table.Column<int>(type: "int", nullable: true),
                    walletNumber = table.Column<string>(type: "varchar(34)", maxLength: 34, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFinances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserFinances_UserHandlings_userHandlingId",
                        column: x => x.userHandlingId,
                        principalTable: "UserHandlings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_UserTradeHistories_groupId",
                table: "UserTradeHistories",
                column: "groupId");

            migrationBuilder.CreateIndex(
                name: "IX_UserForGroups_groupId",
                table: "UserForGroups",
                column: "groupId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCryptos_userForGroupsId",
                table: "UserCryptos",
                column: "userForGroupsId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFinances_userHandlingId",
                table: "UserFinances",
                column: "userHandlingId");

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
                name: "FK_UserHandlings_Image_profilePictureIdId",
                table: "UserHandlings",
                column: "profilePictureIdId",
                principalTable: "Image",
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
    }
}
