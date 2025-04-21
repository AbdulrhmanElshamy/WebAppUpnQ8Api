using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppUpnQ8Api.Migrations
{
    /// <inheritdoc />
    public partial class test8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomersTbls_CitiesTbls_City_ID",
                table: "CustomersTbls");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomersTbls_CodeNumbersTbls_Code_Number_ID_1",
                table: "CustomersTbls");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "CustomersTbls");

            migrationBuilder.DropColumn(
                name: "IP_Address",
                table: "CustomersTbls");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "CustomersTbls");

            migrationBuilder.DropColumn(
                name: "Password_Confirm",
                table: "CustomersTbls");

            migrationBuilder.AlterColumn<string>(
                name: "Last_Name",
                table: "CustomersTbls",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "CustomersTbls",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "First_Name",
                table: "CustomersTbls",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Code_Number_ID_1",
                table: "CustomersTbls",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "City_ID",
                table: "CustomersTbls",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Address_2",
                table: "CustomersTbls",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Address_1",
                table: "CustomersTbls",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomersTbls_CitiesTbls_City_ID",
                table: "CustomersTbls",
                column: "City_ID",
                principalTable: "CitiesTbls",
                principalColumn: "City_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomersTbls_CodeNumbersTbls_Code_Number_ID_1",
                table: "CustomersTbls",
                column: "Code_Number_ID_1",
                principalTable: "CodeNumbersTbls",
                principalColumn: "Code_Number_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomersTbls_CitiesTbls_City_ID",
                table: "CustomersTbls");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomersTbls_CodeNumbersTbls_Code_Number_ID_1",
                table: "CustomersTbls");

            migrationBuilder.AlterColumn<string>(
                name: "Last_Name",
                table: "CustomersTbls",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "CustomersTbls",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "First_Name",
                table: "CustomersTbls",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Code_Number_ID_1",
                table: "CustomersTbls",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "City_ID",
                table: "CustomersTbls",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address_2",
                table: "CustomersTbls",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address_1",
                table: "CustomersTbls",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "CustomersTbls",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IP_Address",
                table: "CustomersTbls",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "CustomersTbls",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password_Confirm",
                table: "CustomersTbls",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomersTbls_CitiesTbls_City_ID",
                table: "CustomersTbls",
                column: "City_ID",
                principalTable: "CitiesTbls",
                principalColumn: "City_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomersTbls_CodeNumbersTbls_Code_Number_ID_1",
                table: "CustomersTbls",
                column: "Code_Number_ID_1",
                principalTable: "CodeNumbersTbls",
                principalColumn: "Code_Number_ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
