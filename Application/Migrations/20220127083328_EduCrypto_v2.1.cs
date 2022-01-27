using Microsoft.EntityFrameworkCore.Migrations;

namespace Application.Migrations
{
    public partial class EduCrypto_v21 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserHandlings_ImageModel_profilePictureIdId",
                table: "UserHandlings");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTradeHistories_Groups_groupModelId",
                table: "UserTradeHistories");

            migrationBuilder.DropIndex(
                name: "IX_UserTradeHistories_groupModelId",
                table: "UserTradeHistories");

            migrationBuilder.DropColumn(
                name: "boughtId",
                table: "UserTradeHistories");

            migrationBuilder.DropColumn(
                name: "groupId",
                table: "UserTradeHistories");

            migrationBuilder.DropColumn(
                name: "groupModelId",
                table: "UserTradeHistories");

            migrationBuilder.DropColumn(
                name: "spentId",
                table: "UserTradeHistories");

            migrationBuilder.DropColumn(
                name: "groupId",
                table: "UserForGroups");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "UserForGroups");

            migrationBuilder.DropColumn(
                name: "cryptoId",
                table: "UserCryptos");

            migrationBuilder.DropColumn(
                name: "groupWalletNumber",
                table: "UserCryptos");

            migrationBuilder.DropColumn(
                name: "userForGroupId",
                table: "UserCryptos");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "UserCryptos");

            migrationBuilder.DropColumn(
                name: "walletNumber",
                table: "UserCryptos");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "UserTradeHistories",
                newName: "userForGroupsModelId");

            migrationBuilder.RenameColumn(
                name: "profilePictureIdId",
                table: "UserHandlings",
                newName: "profilePictureId");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "UserHandlings",
                newName: "PasswordHash");

            migrationBuilder.RenameIndex(
                name: "IX_UserHandlings_profilePictureIdId",
                table: "UserHandlings",
                newName: "IX_UserHandlings_profilePictureId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTradeHistories_userForGroupsModelId",
                table: "UserTradeHistories",
                column: "userForGroupsModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserHandlings_ImageModel_profilePictureId",
                table: "UserHandlings",
                column: "profilePictureId",
                principalTable: "ImageModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTradeHistories_UserForGroups_userForGroupsModelId",
                table: "UserTradeHistories",
                column: "userForGroupsModelId",
                principalTable: "UserForGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserHandlings_ImageModel_profilePictureId",
                table: "UserHandlings");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTradeHistories_UserForGroups_userForGroupsModelId",
                table: "UserTradeHistories");

            migrationBuilder.DropIndex(
                name: "IX_UserTradeHistories_userForGroupsModelId",
                table: "UserTradeHistories");

            migrationBuilder.RenameColumn(
                name: "userForGroupsModelId",
                table: "UserTradeHistories",
                newName: "userId");

            migrationBuilder.RenameColumn(
                name: "profilePictureId",
                table: "UserHandlings",
                newName: "profilePictureIdId");

            migrationBuilder.RenameColumn(
                name: "PasswordHash",
                table: "UserHandlings",
                newName: "password");

            migrationBuilder.RenameIndex(
                name: "IX_UserHandlings_profilePictureId",
                table: "UserHandlings",
                newName: "IX_UserHandlings_profilePictureIdId");

            migrationBuilder.AddColumn<int>(
                name: "boughtId",
                table: "UserTradeHistories",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "groupId",
                table: "UserTradeHistories",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "groupModelId",
                table: "UserTradeHistories",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "spentId",
                table: "UserTradeHistories",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "groupId",
                table: "UserForGroups",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "userId",
                table: "UserForGroups",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "cryptoId",
                table: "UserCryptos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "groupWalletNumber",
                table: "UserCryptos",
                type: "varchar(34)",
                maxLength: 34,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "userForGroupId",
                table: "UserCryptos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "userId",
                table: "UserCryptos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "walletNumber",
                table: "UserCryptos",
                type: "varchar(34)",
                maxLength: 34,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_UserTradeHistories_groupModelId",
                table: "UserTradeHistories",
                column: "groupModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserHandlings_ImageModel_profilePictureIdId",
                table: "UserHandlings",
                column: "profilePictureIdId",
                principalTable: "ImageModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTradeHistories_Groups_groupModelId",
                table: "UserTradeHistories",
                column: "groupModelId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
