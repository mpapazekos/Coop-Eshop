using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Project_WebCoop.Data.Migrations
{
    public partial class Added_BaseSalePrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_AspNetUsers_ClientId",
                table: "Carts");

            migrationBuilder.DropIndex(
                name: "IX_Carts_ClientId",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "BasePrice",
                table: "SupplierProducts");

            migrationBuilder.DropColumn(
                name: "SalePrice",
                table: "SupplierProducts");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Carts");

            migrationBuilder.AddColumn<int>(
                name: "CartID",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BasePrices",
                columns: table => new
                {
                    BasePriceID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BaseUnitPrice = table.Column<decimal>(nullable: false),
                    FromDate = table.Column<DateTime>(nullable: false),
                    ProductID = table.Column<int>(nullable: false),
                    ProductSupplierProductID = table.Column<int>(nullable: false),
                    ProductUserID = table.Column<string>(nullable: false),
                    ThroughDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasePrices", x => x.BasePriceID);
                    table.ForeignKey(
                        name: "FK_BasePrices_SupplierProducts_ProductSupplierProductID_ProductUserID_ProductID",
                        columns: x => new { x.ProductSupplierProductID, x.ProductUserID, x.ProductID },
                        principalTable: "SupplierProducts",
                        principalColumns: new[] { "SupplierProductID", "UserID", "ProductID" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalePrices",
                columns: table => new
                {
                    SalePriceID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FromDate = table.Column<DateTime>(nullable: false),
                    ProductID = table.Column<int>(nullable: false),
                    ProductSupplierProductID = table.Column<int>(nullable: false),
                    ProductUserID = table.Column<string>(nullable: false),
                    SaleUnitPrice = table.Column<decimal>(nullable: false),
                    ThroughDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalePrices", x => x.SalePriceID);
                    table.ForeignKey(
                        name: "FK_SalePrices_SupplierProducts_ProductSupplierProductID_ProductUserID_ProductID",
                        columns: x => new { x.ProductSupplierProductID, x.ProductUserID, x.ProductID },
                        principalTable: "SupplierProducts",
                        principalColumns: new[] { "SupplierProductID", "UserID", "ProductID" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CartID",
                table: "AspNetUsers",
                column: "CartID",
                unique: true,
                filter: "[CartID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BasePrices_ProductSupplierProductID_ProductUserID_ProductID",
                table: "BasePrices",
                columns: new[] { "ProductSupplierProductID", "ProductUserID", "ProductID" });

            migrationBuilder.CreateIndex(
                name: "IX_SalePrices_ProductSupplierProductID_ProductUserID_ProductID",
                table: "SalePrices",
                columns: new[] { "ProductSupplierProductID", "ProductUserID", "ProductID" });

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Carts_CartID",
                table: "AspNetUsers",
                column: "CartID",
                principalTable: "Carts",
                principalColumn: "CartID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Carts_CartID",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "BasePrices");

            migrationBuilder.DropTable(
                name: "SalePrices");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CartID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CartID",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<decimal>(
                name: "BasePrice",
                table: "SupplierProducts",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "SalePrice",
                table: "SupplierProducts",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "ClientId",
                table: "Carts",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_ClientId",
                table: "Carts",
                column: "ClientId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_AspNetUsers_ClientId",
                table: "Carts",
                column: "ClientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
