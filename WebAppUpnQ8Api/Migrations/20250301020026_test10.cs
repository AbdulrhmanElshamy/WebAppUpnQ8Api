using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppUpnQ8Api.Migrations
{
    /// <inheritdoc />
    public partial class test10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RefreshTokenCustom",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "RefreshTokenTbls",
                columns: table => new
                {
                    Token = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsUsed = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokenTbls", x => x.Token);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RefreshTokenTbls");

            migrationBuilder.AddColumn<string>(
                name: "RefreshTokenCustom",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
