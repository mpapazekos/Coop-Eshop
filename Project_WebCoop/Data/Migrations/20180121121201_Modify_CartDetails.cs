using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Project_WebCoop.Data.Migrations
{
    public partial class Modify_CartDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartDetails_Products_ProductID",
                table: "CartDetails");

            migrationBuilder.DropIndex(
                name: "IX_CartDetails_ProductID",
                table: "CartDetails");

            migrationBuilder.RenameColumn(
                name: "ProductID",
                table: "CartDetails",
                newName: "SupplierProductProductID");

            migrationBuilder.AddColumn<int>(
                name: "SupplierProductID",
                table: "CartDetails",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SupplierProductUserID",
                table: "CartDetails",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_CartDetails_SupplierProductID_SupplierProductUserID_SupplierProductProductID",
                table: "CartDetails",
                columns: new[] { "SupplierProductID", "SupplierProductUserID", "SupplierProductProductID" });

            migrationBuilder.AddForeignKey(
                name: "FK_CartDetails_SupplierProducts_SupplierProductID_SupplierProductUserID_SupplierProductProductID",
                table: "CartDetails",
                columns: new[] { "SupplierProductID", "SupplierProductUserID", "SupplierProductProductID" },
                principalTable: "SupplierProducts",
                principalColumns: new[] { "SupplierProductID", "UserID", "ProductID" },
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartDetails_SupplierProducts_SupplierProductID_SupplierProductUserID_SupplierProductProductID",
                table: "CartDetails");

            migrationBuilder.DropIndex(
                name: "IX_CartDetails_SupplierProductID_SupplierProductUserID_SupplierProductProductID",
                table: "CartDetails");

            migrationBuilder.DropColumn(
                name: "SupplierProductID",
                table: "CartDetails");

            migrationBuilder.DropColumn(
                name: "SupplierProductUserID",
                table: "CartDetails");

            migrationBuilder.RenameColumn(
                name: "SupplierProductProductID",
                table: "CartDetails",
                newName: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_CartDetails_ProductID",
                table: "CartDetails",
                column: "ProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_CartDetails_Products_ProductID",
                table: "CartDetails",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
