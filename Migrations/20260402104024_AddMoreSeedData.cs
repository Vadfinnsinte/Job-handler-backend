using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JobHandlerAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddMoreSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "u1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "9859207d-9062-4022-a1fe-bf38de9b8888", "0334c1a6-afb3-4f2d-b8cd-352667da8222" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Created", "Email", "EmailConfirmed", "EmploymentStatus", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "u2", 0, "9859207d-9062-4022-a1fe-bf38de9b0000", new DateTime(2024, 4, 2, 14, 30, 0, 0, DateTimeKind.Unspecified), "user1@test.com", true, false, false, null, "User One", "USER1@TEST.COM", "USER1@TEST.COM", "AQAAAAIAAYagAAAAEC7G//5lR9tL3LqUr/GKrFYgxc6L5GKz87BvdCzb07dQLNkCgtwkGbHefQGihmQD5w==", null, false, "0334c1a6-afb3-4f2d-b8cd-352667da8000", false, "user1@test.com" },
                    { "u3", 0, "9859207d-9062-4022-a1fe-bf38de9b0195", new DateTime(2024, 4, 2, 14, 30, 0, 0, DateTimeKind.Unspecified), "user2@test.com", true, false, false, null, "User Two", "USER2@TEST.COM", "USER2@TEST.COM", "AQAAAAIAAYagAAAAEC7G//5lR9tL3LqUr/GKrFYgxc6L5GKz87BvdCzb07dQLNkCgtwkGbHefQGihmQD5w==", null, false, "0334c1a6-afb3-4f2d-b8cd-352667da8221", false, "user2@test.com" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "AdText", "ApplicationDate", "CompanyName", "Created", "Link", "Status", "Title", "Updated", "UserId" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111112"), "Another job ad", new DateTime(2024, 4, 2, 14, 30, 0, 0, DateTimeKind.Unspecified), "Company B", new DateTime(2024, 4, 2, 14, 30, 0, 0, DateTimeKind.Unspecified), "https://example.com/job2", "Pending", "Fullstack Developer", new DateTime(2024, 4, 2, 14, 30, 0, 0, DateTimeKind.Unspecified), "u1" },
                    { new Guid("22222222-2222-2222-2222-222222222221"), "Frontend job", new DateTime(2024, 4, 2, 14, 30, 0, 0, DateTimeKind.Unspecified), "Company C", new DateTime(2024, 4, 2, 14, 30, 0, 0, DateTimeKind.Unspecified), "https://example.com/job3", "Applied", "Frontend Developer", new DateTime(2024, 4, 2, 14, 30, 0, 0, DateTimeKind.Unspecified), "u2" },
                    { new Guid("22222222-2222-2222-2222-222222222222"), "React job", new DateTime(2024, 4, 2, 14, 30, 0, 0, DateTimeKind.Unspecified), "Company D", new DateTime(2024, 4, 2, 14, 30, 0, 0, DateTimeKind.Unspecified), "https://example.com/job4", "Rejected", "React Developer", new DateTime(2024, 4, 2, 14, 30, 0, 0, DateTimeKind.Unspecified), "u2" },
                    { new Guid("33333333-3333-3333-3333-333333333331"), "DevOps job", new DateTime(2024, 4, 2, 14, 30, 0, 0, DateTimeKind.Unspecified), "Company E", new DateTime(2024, 4, 2, 14, 30, 0, 0, DateTimeKind.Unspecified), "https://example.com/job5", "Pending", "DevOps Engineer", new DateTime(2024, 4, 2, 14, 30, 0, 0, DateTimeKind.Unspecified), "u3" },
                    { new Guid("33333333-3333-3333-3333-333333333332"), "Cloud job", new DateTime(2024, 4, 2, 14, 30, 0, 0, DateTimeKind.Unspecified), "Company F", new DateTime(2024, 4, 2, 14, 30, 0, 0, DateTimeKind.Unspecified), "https://example.com/job6", "Applied", "Cloud Engineer", new DateTime(2024, 4, 2, 14, 30, 0, 0, DateTimeKind.Unspecified), "u3" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "2", "u2" },
                    { "2", "u3" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2", "u2" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2", "u3" });

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111112"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222221"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333331"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333332"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "u2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "u3");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "u1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "9859207d-9062-4022-a1fe-bf38de9b0228", "0334c1a6-afb3-4f2d-b8cd-352667da8f32" });
        }
    }
}
