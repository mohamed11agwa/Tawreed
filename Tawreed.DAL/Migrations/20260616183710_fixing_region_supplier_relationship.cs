using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tawreed.DAL.Migrations
{
    /// <inheritdoc />
    public partial class fixing_region_supplier_relationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Suppliers_Regions_RegionId",
                table: "Suppliers");

            migrationBuilder.DropIndex(
                name: "IX_Suppliers_RegionId",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "RegionId",
                table: "Suppliers");

            migrationBuilder.CreateTable(
                name: "RegionSupplier",
                columns: table => new
                {
                    RegionsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SuppliersUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegionSupplier", x => new { x.RegionsId, x.SuppliersUserId });
                    table.ForeignKey(
                        name: "FK_RegionSupplier_Regions_RegionsId",
                        column: x => x.RegionsId,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RegionSupplier_Suppliers_SuppliersUserId",
                        column: x => x.SuppliersUserId,
                        principalTable: "Suppliers",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RegionSupplier_SuppliersUserId",
                table: "RegionSupplier",
                column: "SuppliersUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RegionSupplier");

            migrationBuilder.AddColumn<Guid>(
                name: "RegionId",
                table: "Suppliers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_RegionId",
                table: "Suppliers",
                column: "RegionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Suppliers_Regions_RegionId",
                table: "Suppliers",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
