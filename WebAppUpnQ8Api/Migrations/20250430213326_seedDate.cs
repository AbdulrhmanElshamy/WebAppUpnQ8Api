using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebAppUpnQ8Api.Migrations
{
    /// <inheritdoc />
    public partial class seedDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0191a4b6-c4fc-752e-9d95-40b5e4e68054", "0191a4b6-c4fc-752e-9d95-40b631d1866d", "Admin", "ADMIN" },
                    { "0191a4b6-c4fc-752e-9d95-40b7a5cb88f0", "0191a4b6-c4fc-752e-9d95-40b85cf3fd22", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "CityId", "CodeNumberId", "ConcurrencyStamp", "CountryId", "Email", "EmailConfirmed", "FirstAddress", "FirstName", "Gender", "Image", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RegisterDate", "SecondAddress", "SecondPhoneNumber", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "0191a4b6-c4fc-752e-9d95-40b30fa7a9b6", 0, null, null, null, "0191a4b6-c4fc-752e-9d95-40b42a925b8e", null, "admin@UpnQ8.com", true, null, "UpnQ8A", false, null, "Admin", false, null, "ADMIN@UPNQ8.COM", "ADMIN@UPNQ8.COM", "AQAAAAIAAYagAAAAEKNBpPV7qI3TPxuNFJth5cCA3sNdI7bs07Sh+Wu9vUrr+13Ls03V1e8EFNMZEYo8Mg==", null, false, new DateTime(2025, 4, 30, 21, 33, 24, 641, DateTimeKind.Utc).AddTicks(4008), null, null, "55BF92C9EF0249CDA210D85D1A851BC9", false, "admin@UpnQ8.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "0191a4b6-c4fc-752e-9d95-40b5e4e68054", "0191a4b6-c4fc-752e-9d95-40b30fa7a9b6" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0191a4b6-c4fc-752e-9d95-40b7a5cb88f0");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0191a4b6-c4fc-752e-9d95-40b5e4e68054", "0191a4b6-c4fc-752e-9d95-40b30fa7a9b6" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0191a4b6-c4fc-752e-9d95-40b5e4e68054");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0191a4b6-c4fc-752e-9d95-40b30fa7a9b6");
        }
    }
}
