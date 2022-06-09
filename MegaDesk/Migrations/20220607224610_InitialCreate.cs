﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MegaDesk.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeliveryType",
                columns: table => new
                {
                    DeliveryTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeliveryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PriceUnder1000 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PriceBetween1000And2000 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PriceOver1000 = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryType", x => x.DeliveryTypeId);
                });

            migrationBuilder.CreateTable(
                name: "DesktopMaterial",
                columns: table => new
                {
                    DesktopMaterialId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DesktopMaterialName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DesktopMaterial", x => x.DesktopMaterialId);
                });

            migrationBuilder.CreateTable(
                name: "Desk",
                columns: table => new
                {
                    DeskId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Width = table.Column<int>(type: "int", nullable: false),
                    Depth = table.Column<int>(type: "int", nullable: false),
                    NumDrawers = table.Column<int>(type: "int", nullable: false),
                    DesktopMaterialId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Desk", x => x.DeskId);
                    table.ForeignKey(
                        name: "FK_Desk_DesktopMaterial_DesktopMaterialId",
                        column: x => x.DesktopMaterialId,
                        principalTable: "DesktopMaterial",
                        principalColumn: "DesktopMaterialId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeskQuote",
                columns: table => new
                {
                    DeskQuoteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuoteDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    QuotePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DeskId = table.Column<int>(type: "int", nullable: false),
                    DeliveryTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeskQuote", x => x.DeskQuoteId);
                    table.ForeignKey(
                        name: "FK_DeskQuote_DeliveryType_DeliveryTypeId",
                        column: x => x.DeliveryTypeId,
                        principalTable: "DeliveryType",
                        principalColumn: "DeliveryTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeskQuote_Desk_DeskId",
                        column: x => x.DeskId,
                        principalTable: "Desk",
                        principalColumn: "DeskId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Desk_DesktopMaterialId",
                table: "Desk",
                column: "DesktopMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_DeskQuote_DeliveryTypeId",
                table: "DeskQuote",
                column: "DeliveryTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DeskQuote_DeskId",
                table: "DeskQuote",
                column: "DeskId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeskQuote");

            migrationBuilder.DropTable(
                name: "DeliveryType");

            migrationBuilder.DropTable(
                name: "Desk");

            migrationBuilder.DropTable(
                name: "DesktopMaterial");
        }
    }
}
