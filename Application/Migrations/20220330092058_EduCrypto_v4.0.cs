using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Application.Migrations
{
    public partial class EduCrypto_v40 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserHandlings_ImageModel_profilePictureId",
                table: "UserHandlings");

            migrationBuilder.DropTable(
                name: "ImageModel");

            migrationBuilder.DropIndex(
                name: "IX_UserHandlings_profilePictureId",
                table: "UserHandlings");

            migrationBuilder.DropColumn(
                name: "profilePictureId",
                table: "UserHandlings");

            migrationBuilder.AddColumn<string>(
                name: "profilePictureUrl",
                table: "UserHandlings",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "profilePictureUrl",
                table: "UserHandlings");

            migrationBuilder.AddColumn<int>(
                name: "profilePictureId",
                table: "UserHandlings",
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
                name: "IX_UserHandlings_profilePictureId",
                table: "UserHandlings",
                column: "profilePictureId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserHandlings_ImageModel_profilePictureId",
                table: "UserHandlings",
                column: "profilePictureId",
                principalTable: "ImageModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
