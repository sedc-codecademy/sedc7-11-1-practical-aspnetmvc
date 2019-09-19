using Microsoft.EntityFrameworkCore.Migrations;

namespace SEDC.Lamazon.DataAccess.Migrations
{
    public partial class AddedUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "df9a0902-69d8-4d79-ac4b-cc525c64a7d7", "0251a7b9-b0dd-4ead-9752-3d360ad63d28", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d9f7b4bf-75ae-496a-a345-153fdbc5f813", "0a3c6f07-ac66-4c88-a980-daebed3c0fe8", "user", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "08bc3fba-cd67-40a3-bf75-143e3c775ec8", 0, "f35fde7a-2aee-41d6-bcb4-692017dc093d", "supplier@mail.com", true, null, false, null, "supplier@mail.com", "SUPPLIER", "AQAAAAEAACcQAAAAEPtu/fgls2NLmEMhlbcsQRMyhktAUZL46kV8F06VWG4AVU8B8eF7u0EEARUPqX9imQ==", null, false, "", false, "supplier" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "08bc3fba-cd67-40a3-bf75-143e3c775ec8", "df9a0902-69d8-4d79-ac4b-cc525c64a7d7" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "d9f7b4bf-75ae-496a-a345-153fdbc5f813", "0a3c6f07-ac66-4c88-a980-daebed3c0fe8" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "08bc3fba-cd67-40a3-bf75-143e3c775ec8", "df9a0902-69d8-4d79-ac4b-cc525c64a7d7" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "df9a0902-69d8-4d79-ac4b-cc525c64a7d7", "0251a7b9-b0dd-4ead-9752-3d360ad63d28" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "08bc3fba-cd67-40a3-bf75-143e3c775ec8", "f35fde7a-2aee-41d6-bcb4-692017dc093d" });
        }
    }
}
