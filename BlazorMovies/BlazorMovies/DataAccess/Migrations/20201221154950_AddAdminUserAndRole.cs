using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorMovies.DataAccess.Migrations
{
    public partial class AddAdminUserAndRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1", "0d520cb5-7fbe-4f59-8585-9c88870ab05a", "Admin", "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "6af3decf-7e66-40ea-9c87-67a88a89f368", 0, "c565a1d0-5b07-4d78-9db7-c09593d7fcaf", "admin@admin.com", true, false, null, "admin@admin.com", "admin@admin.com", "AQAAAAEAACcQAAAAEBrmGYcOhlKe0JQzlzAywQaMJW1En3RyyMgWc7COQdHXh/FMJS12L5bwamyxSJmeAg==", null, false, "0711f2eb-504a-48ce-a784-91f1fa75002b", false, "admin@admin.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[] { 1, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "Admin", "6af3decf-7e66-40ea-9c87-67a88a89f368" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6af3decf-7e66-40ea-9c87-67a88a89f368");
        }
    }
}
