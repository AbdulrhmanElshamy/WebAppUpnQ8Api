using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppUpnQ8Api.Migrations
{
    /// <inheritdoc />
    public partial class test4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AspNetUserId",
                table: "CustomersTbls",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "CustomersTbls",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_CustomersTbls_AspNetUserId",
                table: "CustomersTbls",
                column: "AspNetUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomersTbls_AspNetUsers_AspNetUserId",
                table: "CustomersTbls",
                column: "AspNetUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomersTbls_AspNetUsers_AspNetUserId",
                table: "CustomersTbls");

            migrationBuilder.DropIndex(
                name: "IX_CustomersTbls_AspNetUserId",
                table: "CustomersTbls");

            migrationBuilder.DropColumn(
                name: "AspNetUserId",
                table: "CustomersTbls");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "CustomersTbls");
        }
    }
}
