using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Project_WebCoop.Data.Migrations
{
    public partial class ManyToManyID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategory_Categories_CategoryID",
                table: "ProductCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategory_Products_ProductID",
                table: "ProductCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_SupplierProduct_Products_ProductID",
                table: "SupplierProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_SupplierProduct_AspNetUsers_UserID",
                table: "SupplierProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SupplierProduct",
                table: "SupplierProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductCategory",
                table: "ProductCategory");

            migrationBuilder.RenameTable(
                name: "SupplierProduct",
                newName: "SupplierProducts");

            migrationBuilder.RenameTable(
                name: "ProductCategory",
                newName: "ProductCategories");

            migrationBuilder.RenameIndex(
                name: "IX_SupplierProduct_ProductID",
                table: "SupplierProducts",
                newName: "IX_SupplierProducts_ProductID");

            migrationBuilder.RenameIndex(
                name: "IX_ProductCategory_CategoryID",
                table: "ProductCategories",
                newName: "IX_ProductCategories_CategoryID");

            migrationBuilder.AddColumn<int>(
                name: "SupplierProductID",
                table: "SupplierProducts",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "ProductCategoryID",
                table: "ProductCategories",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SupplierProducts",
                table: "SupplierProducts",
                columns: new[] { "SupplierProductID", "UserID", "ProductID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductCategories",
                table: "ProductCategories",
                columns: new[] { "ProductCategoryID", "ProductID", "CategoryID" });

            migrationBuilder.CreateIndex(
                name: "IX_SupplierProducts_UserID",
                table: "SupplierProducts",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_ProductID",
                table: "ProductCategories",
                column: "ProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategories_Categories_CategoryID",
                table: "ProductCategories",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategories_Products_ProductID",
                table: "ProductCategories",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SupplierProducts_Products_ProductID",
                table: "SupplierProducts",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SupplierProducts_AspNetUsers_UserID",
                table: "SupplierProducts",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategories_Categories_CategoryID",
                table: "ProductCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategories_Products_ProductID",
                table: "ProductCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_SupplierProducts_Products_ProductID",
                table: "SupplierProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_SupplierProducts_AspNetUsers_UserID",
                table: "SupplierProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SupplierProducts",
                table: "SupplierProducts");

            migrationBuilder.DropIndex(
                name: "IX_SupplierProducts_UserID",
                table: "SupplierProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductCategories",
                table: "ProductCategories");

            migrationBuilder.DropIndex(
                name: "IX_ProductCategories_ProductID",
                table: "ProductCategories");

            migrationBuilder.DropColumn(
                name: "SupplierProductID",
                table: "SupplierProducts");

            migrationBuilder.DropColumn(
                name: "ProductCategoryID",
                table: "ProductCategories");

            migrationBuilder.RenameTable(
                name: "SupplierProducts",
                newName: "SupplierProduct");

            migrationBuilder.RenameTable(
                name: "ProductCategories",
                newName: "ProductCategory");

            migrationBuilder.RenameIndex(
                name: "IX_SupplierProducts_ProductID",
                table: "SupplierProduct",
                newName: "IX_SupplierProduct_ProductID");

            migrationBuilder.RenameIndex(
                name: "IX_ProductCategories_CategoryID",
                table: "ProductCategory",
                newName: "IX_ProductCategory_CategoryID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SupplierProduct",
                table: "SupplierProduct",
                columns: new[] { "UserID", "ProductID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductCategory",
                table: "ProductCategory",
                columns: new[] { "ProductID", "CategoryID" });

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategory_Categories_CategoryID",
                table: "ProductCategory",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategory_Products_ProductID",
                table: "ProductCategory",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SupplierProduct_Products_ProductID",
                table: "SupplierProduct",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SupplierProduct_AspNetUsers_UserID",
                table: "SupplierProduct",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
