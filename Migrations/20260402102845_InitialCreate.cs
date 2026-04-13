using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobHandlerAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Created", "Email", "EmailConfirmed", "EmploymentStatus", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "u1", 0, "9859207d-9062-4022-a1fe-bf38de9b0228", new DateTime(2024, 4, 2, 14, 30, 0, 0, DateTimeKind.Utc), "admin@test.com", true, true, false, null, "Admin User", "ADMIN@TEST.COM", "ADMIN@TEST.COM", "AQAAAAIAAYagAAAAEC7G//5lR9tL3LqUr/GKrFYgxc6L5GKz87BvdCzb07dQLNkCgtwkGbHefQGihmQD5w==", null, false, "0334c1a6-afb3-4f2d-b8cd-352667da8f32", false, "admin@test.com" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "AdText", "ApplicationDate", "CompanyName", "Created", "Link", "Status", "Title", "Updated", "UserId" },
                values: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), "Job ad text here", new DateTime(2024, 4, 2, 14, 30, 0, 0, DateTimeKind.Utc), "Company A", new DateTime(2024, 4, 2, 14, 30, 0, 0, DateTimeKind.Utc), "https://example.com/job1", "Applied", "Backend Developer", new DateTime(2024, 4, 2, 14, 30, 0, 0, DateTimeKind.Utc), "u1" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1", "u1" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "u1" });

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "u1");
        }
    }
}
