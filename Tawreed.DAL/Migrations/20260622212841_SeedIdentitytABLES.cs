using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Tawreed.DAL.Migrations
{
    /// <inheritdoc />
    public partial class SeedIdentitytABLES : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AspNetRoles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "IsDeleted", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("3cfc4e5b-70f7-4437-a09e-799859a119c8"), "a0fa979b-5117-49ef-86e4-db00aff6ed39", false, "Admin", "ADMIN" },
                    { new Guid("5dc9280f-e17a-4c3c-b2f1-b7be3256c7c7"), "d0463275-a8fc-4468-ab4e-e2a10e9fa47f", false, "Supplier", "SUPPLIER" },
                    { new Guid("a18591e5-7617-4bbd-b83b-cad4fa3572bb"), "106c609a-d895-43cc-bcd7-3976c49b38aa", false, "Buyer", "BUYER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AvatarUrl", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FullName", "IsDeleted", "LastLoginAt", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PreferredLang", "SecurityStamp", "Status", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[] { new Guid("51fa1d98-0573-4c2f-a9c3-8c0f93cf91b6"), 0, null, "712e8e30-2da9-4603-913d-652c07919cab", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "admin@tawreed.com", true, "Admin", false, null, false, null, "ADMIN@TAWREED.COM", "ADMIN@TAWREED.COM", "AQAAAAIAAYagAAAAEPQRee3V73RVPNYD8BALbNHBr4xqPMVG+4GumW3asmZR8abwWUd7AJG8PQ1mnQs/uw==", null, false, "en", "C7EDC5BC-70A0-47C6-8F6D-5D0C9C57124C", "Active", false, null, "admin@tawreed.com" });

            migrationBuilder.InsertData(
                table: "AspNetRoleClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "RoleId" },
                values: new object[,]
                {
                    { 1, "permissions", "users:read", new Guid("3cfc4e5b-70f7-4437-a09e-799859a119c8") },
                    { 2, "permissions", "users:suspend", new Guid("3cfc4e5b-70f7-4437-a09e-799859a119c8") },
                    { 3, "permissions", "users:reactivate", new Guid("3cfc4e5b-70f7-4437-a09e-799859a119c8") },
                    { 4, "permissions", "users:reset-password", new Guid("3cfc4e5b-70f7-4437-a09e-799859a119c8") },
                    { 5, "permissions", "suppliers:read", new Guid("3cfc4e5b-70f7-4437-a09e-799859a119c8") },
                    { 6, "permissions", "suppliers:approve", new Guid("3cfc4e5b-70f7-4437-a09e-799859a119c8") },
                    { 7, "permissions", "suppliers:reject", new Guid("3cfc4e5b-70f7-4437-a09e-799859a119c8") },
                    { 8, "permissions", "suppliers:suspend", new Guid("3cfc4e5b-70f7-4437-a09e-799859a119c8") },
                    { 9, "permissions", "suppliers:reactivate", new Guid("3cfc4e5b-70f7-4437-a09e-799859a119c8") },
                    { 10, "permissions", "orders:read", new Guid("3cfc4e5b-70f7-4437-a09e-799859a119c8") },
                    { 11, "permissions", "orders:create", new Guid("3cfc4e5b-70f7-4437-a09e-799859a119c8") },
                    { 12, "permissions", "orders:update", new Guid("3cfc4e5b-70f7-4437-a09e-799859a119c8") },
                    { 13, "permissions", "orders:force-close", new Guid("3cfc4e5b-70f7-4437-a09e-799859a119c8") },
                    { 14, "permissions", "orders:join", new Guid("3cfc4e5b-70f7-4437-a09e-799859a119c8") },
                    { 15, "permissions", "orders:leave", new Guid("3cfc4e5b-70f7-4437-a09e-799859a119c8") },
                    { 16, "permissions", "orders:accept", new Guid("3cfc4e5b-70f7-4437-a09e-799859a119c8") },
                    { 17, "permissions", "orders:decline", new Guid("3cfc4e5b-70f7-4437-a09e-799859a119c8") },
                    { 18, "permissions", "categories:read", new Guid("3cfc4e5b-70f7-4437-a09e-799859a119c8") },
                    { 19, "permissions", "categories:create", new Guid("3cfc4e5b-70f7-4437-a09e-799859a119c8") },
                    { 20, "permissions", "categories:update", new Guid("3cfc4e5b-70f7-4437-a09e-799859a119c8") },
                    { 21, "permissions", "categories:activate", new Guid("3cfc4e5b-70f7-4437-a09e-799859a119c8") },
                    { 22, "permissions", "categories:deactivate", new Guid("3cfc4e5b-70f7-4437-a09e-799859a119c8") },
                    { 23, "permissions", "categories:delete", new Guid("3cfc4e5b-70f7-4437-a09e-799859a119c8") },
                    { 24, "permissions", "regions:read", new Guid("3cfc4e5b-70f7-4437-a09e-799859a119c8") },
                    { 25, "permissions", "regions:create", new Guid("3cfc4e5b-70f7-4437-a09e-799859a119c8") },
                    { 26, "permissions", "regions:update", new Guid("3cfc4e5b-70f7-4437-a09e-799859a119c8") },
                    { 27, "permissions", "regions:delete", new Guid("3cfc4e5b-70f7-4437-a09e-799859a119c8") },
                    { 28, "permissions", "regions:toggle", new Guid("3cfc4e5b-70f7-4437-a09e-799859a119c8") },
                    { 29, "permissions", "products:read", new Guid("3cfc4e5b-70f7-4437-a09e-799859a119c8") },
                    { 30, "permissions", "products:create", new Guid("3cfc4e5b-70f7-4437-a09e-799859a119c8") },
                    { 31, "permissions", "products:update", new Guid("3cfc4e5b-70f7-4437-a09e-799859a119c8") },
                    { 32, "permissions", "products:delete", new Guid("3cfc4e5b-70f7-4437-a09e-799859a119c8") },
                    { 33, "permissions", "products:manage-tiers", new Guid("3cfc4e5b-70f7-4437-a09e-799859a119c8") },
                    { 34, "permissions", "deliveries:read", new Guid("3cfc4e5b-70f7-4437-a09e-799859a119c8") },
                    { 35, "permissions", "deliveries:update-status", new Guid("3cfc4e5b-70f7-4437-a09e-799859a119c8") },
                    { 36, "permissions", "group-orders:read", new Guid("3cfc4e5b-70f7-4437-a09e-799859a119c8") },
                    { 37, "permissions", "group-orders:create", new Guid("3cfc4e5b-70f7-4437-a09e-799859a119c8") },
                    { 38, "permissions", "group-orders:update-status", new Guid("3cfc4e5b-70f7-4437-a09e-799859a119c8") },
                    { 39, "permissions", "group-orders:delete", new Guid("3cfc4e5b-70f7-4437-a09e-799859a119c8") },
                    { 40, "permissions", "dashboard:admin", new Guid("3cfc4e5b-70f7-4437-a09e-799859a119c8") },
                    { 41, "permissions", "dashboard:buyer", new Guid("3cfc4e5b-70f7-4437-a09e-799859a119c8") },
                    { 42, "permissions", "dashboard:supplier", new Guid("3cfc4e5b-70f7-4437-a09e-799859a119c8") }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("3cfc4e5b-70f7-4437-a09e-799859a119c8"), new Guid("51fa1d98-0573-4c2f-a9c3-8c0f93cf91b6") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5dc9280f-e17a-4c3c-b2f1-b7be3256c7c7"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a18591e5-7617-4bbd-b83b-cad4fa3572bb"));

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("3cfc4e5b-70f7-4437-a09e-799859a119c8"), new Guid("51fa1d98-0573-4c2f-a9c3-8c0f93cf91b6") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("3cfc4e5b-70f7-4437-a09e-799859a119c8"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("51fa1d98-0573-4c2f-a9c3-8c0f93cf91b6"));

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AspNetRoles");
        }
    }
}
