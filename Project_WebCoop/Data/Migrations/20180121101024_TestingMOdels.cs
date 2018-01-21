using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Project_WebCoop.Data.Migrations
{
    public partial class TestingMOdels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasePrices_SupplierProducts_ProductSupplierProductID_ProductUserID_ProductID",
                table: "BasePrices");

            migrationBuilder.DropForeignKey(
                name: "FK_SalePrices_SupplierProducts_ProductSupplierProductID_ProductUserID_ProductID",
                table: "SalePrices");

            migrationBuilder.DropIndex(
                name: "IX_SalePrices_ProductSupplierProductID_ProductUserID_ProductID",
                table: "SalePrices");

            migrationBuilder.DropIndex(
                name: "IX_BasePrices_ProductSupplierProductID_ProductUserID_ProductID",
                table: "BasePrices");

            migrationBuilder.RenameColumn(
                name: "ProductUserID",
                table: "SalePrices",
                newName: "SupplierProductUserID");

            migrationBuilder.RenameColumn(
                name: "ProductSupplierProductID",
                table: "SalePrices",
                newName: "SupplierProductProductID");

            migrationBuilder.RenameColumn(
                name: "ProductID",
                table: "SalePrices",
                newName: "SupplierProductID");

            migrationBuilder.RenameColumn(
                name: "ProductUserID",
                table: "BasePrices",
                newName: "SupplierProductUserID");

            migrationBuilder.RenameColumn(
                name: "ProductSupplierProductID",
                table: "BasePrices",
                newName: "SupplierProductProductID");

            migrationBuilder.RenameColumn(
                name: "ProductID",
                table: "BasePrices",
                newName: "SupplierProductID");

            migrationBuilder.AddColumn<decimal>(
                name: "TotalCost",
                table: "Orders",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_SalePrices_SupplierProductID_SupplierProductUserID_SupplierProductProductID",
                table: "SalePrices",
                columns: new[] { "SupplierProductID", "SupplierProductUserID", "SupplierProductProductID" });

            migrationBuilder.CreateIndex(
                name: "IX_BasePrices_SupplierProductID_SupplierProductUserID_SupplierProductProductID",
                table: "BasePrices",
                columns: new[] { "SupplierProductID", "SupplierProductUserID", "SupplierProductProductID" });

            migrationBuilder.AddForeignKey(
                name: "FK_BasePrices_SupplierProducts_SupplierProductID_SupplierProductUserID_SupplierProductProductID",
                table: "BasePrices",
                columns: new[] { "SupplierProductID", "SupplierProductUserID", "SupplierProductProductID" },
                principalTable: "SupplierProducts",
                principalColumns: new[] { "SupplierProductID", "UserID", "ProductID" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SalePrices_SupplierProducts_SupplierProductID_SupplierProductUserID_SupplierProductProductID",
                table: "SalePrices",
                columns: new[] { "SupplierProductID", "SupplierProductUserID", "SupplierProductProductID" },
                principalTable: "SupplierProducts",
                principalColumns: new[] { "SupplierProductID", "UserID", "ProductID" },
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasePrices_SupplierProducts_SupplierProductID_SupplierProductUserID_SupplierProductProductID",
                table: "BasePrices");

            migrationBuilder.DropForeignKey(
                name: "FK_SalePrices_SupplierProducts_SupplierProductID_SupplierProductUserID_SupplierProductProductID",
                table: "SalePrices");

            migrationBuilder.DropIndex(
                name: "IX_SalePrices_SupplierProductID_SupplierProductUserID_SupplierProductProductID",
                table: "SalePrices");

            migrationBuilder.DropIndex(
                name: "IX_BasePrices_SupplierProductID_SupplierProductUserID_SupplierProductProductID",
                table: "BasePrices");

            migrationBuilder.DropColumn(
                name: "TotalCost",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "SupplierProductUserID",
                table: "SalePrices",
                newName: "ProductUserID");

            migrationBuilder.RenameColumn(
                name: "SupplierProductProductID",
                table: "SalePrices",
                newName: "ProductSupplierProductID");

            migrationBuilder.RenameColumn(
                name: "SupplierProductID",
                table: "SalePrices",
                newName: "ProductID");

            migrationBuilder.RenameColumn(
                name: "SupplierProductUserID",
                table: "BasePrices",
                newName: "ProductUserID");

            migrationBuilder.RenameColumn(
                name: "SupplierProductProductID",
                table: "BasePrices",
                newName: "ProductSupplierProductID");

            migrationBuilder.RenameColumn(
                name: "SupplierProductID",
                table: "BasePrices",
                newName: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_SalePrices_ProductSupplierProductID_ProductUserID_ProductID",
                table: "SalePrices",
                columns: new[] { "ProductSupplierProductID", "ProductUserID", "ProductID" });

            migrationBuilder.CreateIndex(
                name: "IX_BasePrices_ProductSupplierProductID_ProductUserID_ProductID",
                table: "BasePrices",
                columns: new[] { "ProductSupplierProductID", "ProductUserID", "ProductID" });

            migrationBuilder.AddForeignKey(
                name: "FK_BasePrices_SupplierProducts_ProductSupplierProductID_ProductUserID_ProductID",
                table: "BasePrices",
                columns: new[] { "ProductSupplierProductID", "ProductUserID", "ProductID" },
                principalTable: "SupplierProducts",
                principalColumns: new[] { "SupplierProductID", "UserID", "ProductID" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SalePrices_SupplierProducts_ProductSupplierProductID_ProductUserID_ProductID",
                table: "SalePrices",
                columns: new[] { "ProductSupplierProductID", "ProductUserID", "ProductID" },
                principalTable: "SupplierProducts",
                principalColumns: new[] { "SupplierProductID", "UserID", "ProductID" },
                onDelete: ReferentialAction.Cascade);
        }
    }
}
