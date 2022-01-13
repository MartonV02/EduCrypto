using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Application.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CryptoCurrencies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    contraction = table.Column<string>(type: "varchar(5)", maxLength: 5, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    price = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    dayPercent = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    weekPercent = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    marketCap = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    volume = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    circulatingSupply = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CryptoCurrencies", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    startBudget = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    startDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    finishDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    isFinished = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

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
                name: "UserHandlings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    userName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    password = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    fullNme = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    birthDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    xpLevel = table.Column<int>(type: "int", nullable: false),
                    profilePictureIdId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserHandlings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserHandlings_Image_profilePictureIdId",
                        column: x => x.profilePictureIdId,
                        principalTable: "Image",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserFinances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    userHandlingId = table.Column<int>(type: "int", nullable: true),
                    userId = table.Column<int>(type: "int", nullable: true),
                    walletNumber = table.Column<string>(type: "varchar(34)", maxLength: 34, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    moneyDollar = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "UserForGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    userHandlingId = table.Column<int>(type: "int", nullable: true),
                    userId = table.Column<int>(type: "int", nullable: true),
                    groupId = table.Column<int>(type: "int", nullable: false),
                    accesLevel = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    groupWalletNumber = table.Column<string>(type: "varchar(34)", maxLength: 34, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    money = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserForGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserForGroups_Groups_groupId",
                        column: x => x.groupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserForGroups_UserHandlings_userHandlingId",
                        column: x => x.userHandlingId,
                        principalTable: "UserHandlings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserTradeHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    userHandlingId = table.Column<int>(type: "int", nullable: true),
                    userId = table.Column<int>(type: "int", nullable: true),
                    tradeDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    spentCryptoCurrencyId = table.Column<int>(type: "int", nullable: true),
                    spentId = table.Column<int>(type: "int", nullable: true),
                    spentValue = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    boughtCryptoCurrencyId = table.Column<int>(type: "int", nullable: true),
                    boughtId = table.Column<int>(type: "int", nullable: true),
                    boughtValue = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    groupId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTradeHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserTradeHistories_CryptoCurrencies_boughtCryptoCurrencyId",
                        column: x => x.boughtCryptoCurrencyId,
                        principalTable: "CryptoCurrencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserTradeHistories_CryptoCurrencies_spentCryptoCurrencyId",
                        column: x => x.spentCryptoCurrencyId,
                        principalTable: "CryptoCurrencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserTradeHistories_Groups_groupId",
                        column: x => x.groupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserTradeHistories_UserHandlings_userHandlingId",
                        column: x => x.userHandlingId,
                        principalTable: "UserHandlings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserCryptos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    userFinanceId = table.Column<int>(type: "int", nullable: true),
                    walletNumber = table.Column<string>(type: "varchar(34)", maxLength: 34, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    cryptoCurrencyId = table.Column<int>(type: "int", nullable: true),
                    cryptoValue = table.Column<double>(type: "double", nullable: false),
                    userForGroupsId = table.Column<int>(type: "int", nullable: true),
                    groupWalletNumber = table.Column<string>(type: "varchar(34)", maxLength: 34, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    isFavourite = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCryptos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserCryptos_CryptoCurrencies_cryptoCurrencyId",
                        column: x => x.cryptoCurrencyId,
                        principalTable: "CryptoCurrencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserCryptos_UserFinances_userFinanceId",
                        column: x => x.userFinanceId,
                        principalTable: "UserFinances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserCryptos_UserForGroups_userForGroupsId",
                        column: x => x.userForGroupsId,
                        principalTable: "UserForGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_UserCryptos_cryptoCurrencyId",
                table: "UserCryptos",
                column: "cryptoCurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCryptos_userFinanceId",
                table: "UserCryptos",
                column: "userFinanceId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCryptos_userForGroupsId",
                table: "UserCryptos",
                column: "userForGroupsId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFinances_userHandlingId",
                table: "UserFinances",
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
                name: "IX_UserHandlings_profilePictureIdId",
                table: "UserHandlings",
                column: "profilePictureIdId");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserCryptos");

            migrationBuilder.DropTable(
                name: "UserTradeHistories");

            migrationBuilder.DropTable(
                name: "UserFinances");

            migrationBuilder.DropTable(
                name: "UserForGroups");

            migrationBuilder.DropTable(
                name: "CryptoCurrencies");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "UserHandlings");

            migrationBuilder.DropTable(
                name: "Image");
        }
    }
}
