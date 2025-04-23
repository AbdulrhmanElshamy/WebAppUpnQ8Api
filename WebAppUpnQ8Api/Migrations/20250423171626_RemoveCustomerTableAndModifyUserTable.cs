using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppUpnQ8Api.Migrations
{
    /// <inheritdoc />
    public partial class RemoveCustomerTableAndModifyUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaintinanceRequestsTbls_CustomersTbls_Customer_ID",
                table: "MaintinanceRequestsTbls");

            migrationBuilder.DropForeignKey(
                name: "FK_PlanSubscripesTbls_CustomersTbls_Customer_ID",
                table: "PlanSubscripesTbls");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceRequestsTbls_CustomersTbls_Customer_ID",
                table: "ServiceRequestsTbls");

            migrationBuilder.DropForeignKey(
                name: "FK_SpecialRequestsTbls_CustomersTbls_Customer_ID",
                table: "SpecialRequestsTbls");

            migrationBuilder.DropForeignKey(
                name: "FK_SubscriptionsTbls_CustomersTbls_Customer_ID",
                table: "SubscriptionsTbls");

            migrationBuilder.DropForeignKey(
                name: "FK_TestmonialsTbls_CustomersTbls_Customer_ID",
                table: "TestmonialsTbls");

            migrationBuilder.DropTable(
                name: "CustomersTbls");

            migrationBuilder.RenameColumn(
                name: "ActivationCode",
                table: "AspNetUsers",
                newName: "SecondPhoneNumber");

            migrationBuilder.AlterColumn<string>(
                name: "Customer_ID",
                table: "TestmonialsTbls",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Customer_ID",
                table: "SubscriptionsTbls",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Customer_ID",
                table: "SpecialRequestsTbls",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Customer_ID",
                table: "ServiceRequestsTbls",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Customer_ID",
                table: "PlanSubscripesTbls",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Customer_ID",
                table: "MaintinanceRequestsTbls",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CodeNumberId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstAddress",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Gender",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RegisterDate",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "SecondAddress",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CityId",
                table: "AspNetUsers",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CodeNumberId",
                table: "AspNetUsers",
                column: "CodeNumberId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_CitiesTbls_CityId",
                table: "AspNetUsers",
                column: "CityId",
                principalTable: "CitiesTbls",
                principalColumn: "City_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_CodeNumbersTbls_CodeNumberId",
                table: "AspNetUsers",
                column: "CodeNumberId",
                principalTable: "CodeNumbersTbls",
                principalColumn: "Code_Number_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_MaintinanceRequestsTbls_AspNetUsers_Customer_ID",
                table: "MaintinanceRequestsTbls",
                column: "Customer_ID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlanSubscripesTbls_AspNetUsers_Customer_ID",
                table: "PlanSubscripesTbls",
                column: "Customer_ID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceRequestsTbls_AspNetUsers_Customer_ID",
                table: "ServiceRequestsTbls",
                column: "Customer_ID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SpecialRequestsTbls_AspNetUsers_Customer_ID",
                table: "SpecialRequestsTbls",
                column: "Customer_ID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubscriptionsTbls_AspNetUsers_Customer_ID",
                table: "SubscriptionsTbls",
                column: "Customer_ID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TestmonialsTbls_AspNetUsers_Customer_ID",
                table: "TestmonialsTbls",
                column: "Customer_ID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_CitiesTbls_CityId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_CodeNumbersTbls_CodeNumberId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_MaintinanceRequestsTbls_AspNetUsers_Customer_ID",
                table: "MaintinanceRequestsTbls");

            migrationBuilder.DropForeignKey(
                name: "FK_PlanSubscripesTbls_AspNetUsers_Customer_ID",
                table: "PlanSubscripesTbls");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceRequestsTbls_AspNetUsers_Customer_ID",
                table: "ServiceRequestsTbls");

            migrationBuilder.DropForeignKey(
                name: "FK_SpecialRequestsTbls_AspNetUsers_Customer_ID",
                table: "SpecialRequestsTbls");

            migrationBuilder.DropForeignKey(
                name: "FK_SubscriptionsTbls_AspNetUsers_Customer_ID",
                table: "SubscriptionsTbls");

            migrationBuilder.DropForeignKey(
                name: "FK_TestmonialsTbls_AspNetUsers_Customer_ID",
                table: "TestmonialsTbls");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CityId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CodeNumberId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CodeNumberId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstAddress",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RegisterDate",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SecondAddress",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "SecondPhoneNumber",
                table: "AspNetUsers",
                newName: "ActivationCode");

            migrationBuilder.AlterColumn<int>(
                name: "Customer_ID",
                table: "TestmonialsTbls",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "Customer_ID",
                table: "SubscriptionsTbls",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "Customer_ID",
                table: "SpecialRequestsTbls",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "Customer_ID",
                table: "ServiceRequestsTbls",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "Customer_ID",
                table: "PlanSubscripesTbls",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "Customer_ID",
                table: "MaintinanceRequestsTbls",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateTable(
                name: "CustomersTbls",
                columns: table => new
                {
                    Customer_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City_ID = table.Column<int>(type: "int", nullable: true),
                    Code_Number_ID_1 = table.Column<int>(type: "int", nullable: true),
                    Address_1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address_2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Birth_Day_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Country_ID = table.Column<int>(type: "int", nullable: true),
                    First_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<bool>(type: "bit", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Last_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone_Number_1 = table.Column<long>(type: "bigint", nullable: true),
                    Phone_Number_2 = table.Column<long>(type: "bigint", nullable: true),
                    Register_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    User_ID = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomersTbls", x => x.Customer_ID);
                    table.ForeignKey(
                        name: "FK_CustomersTbls_CitiesTbls_City_ID",
                        column: x => x.City_ID,
                        principalTable: "CitiesTbls",
                        principalColumn: "City_ID");
                    table.ForeignKey(
                        name: "FK_CustomersTbls_CodeNumbersTbls_Code_Number_ID_1",
                        column: x => x.Code_Number_ID_1,
                        principalTable: "CodeNumbersTbls",
                        principalColumn: "Code_Number_ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomersTbls_City_ID",
                table: "CustomersTbls",
                column: "City_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomersTbls_Code_Number_ID_1",
                table: "CustomersTbls",
                column: "Code_Number_ID_1");

            migrationBuilder.AddForeignKey(
                name: "FK_MaintinanceRequestsTbls_CustomersTbls_Customer_ID",
                table: "MaintinanceRequestsTbls",
                column: "Customer_ID",
                principalTable: "CustomersTbls",
                principalColumn: "Customer_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlanSubscripesTbls_CustomersTbls_Customer_ID",
                table: "PlanSubscripesTbls",
                column: "Customer_ID",
                principalTable: "CustomersTbls",
                principalColumn: "Customer_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceRequestsTbls_CustomersTbls_Customer_ID",
                table: "ServiceRequestsTbls",
                column: "Customer_ID",
                principalTable: "CustomersTbls",
                principalColumn: "Customer_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SpecialRequestsTbls_CustomersTbls_Customer_ID",
                table: "SpecialRequestsTbls",
                column: "Customer_ID",
                principalTable: "CustomersTbls",
                principalColumn: "Customer_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubscriptionsTbls_CustomersTbls_Customer_ID",
                table: "SubscriptionsTbls",
                column: "Customer_ID",
                principalTable: "CustomersTbls",
                principalColumn: "Customer_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TestmonialsTbls_CustomersTbls_Customer_ID",
                table: "TestmonialsTbls",
                column: "Customer_ID",
                principalTable: "CustomersTbls",
                principalColumn: "Customer_ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
