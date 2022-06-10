using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MegaDesk.Migrations
{
    public partial class Changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeskQuote_DeliveryType_DeliveryTypeId",
                table: "DeskQuote");

            migrationBuilder.DropForeignKey(
                name: "FK_DeskQuote_Desk_DeskId",
                table: "DeskQuote");

            migrationBuilder.DropIndex(
                name: "IX_DeskQuote_DeskId",
                table: "DeskQuote");

            migrationBuilder.AlterColumn<string>(
                name: "DesktopMaterialName",
                table: "DesktopMaterial",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<decimal>(
                name: "QuotePrice",
                table: "DeskQuote",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "QuoteDate",
                table: "DeskQuote",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "DeskId",
                table: "DeskQuote",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DeliveryTypeId",
                table: "DeskQuote",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_DeskQuote_DeskId",
                table: "DeskQuote",
                column: "DeskId",
                unique: true,
                filter: "[DeskId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_DeskQuote_DeliveryType_DeliveryTypeId",
                table: "DeskQuote",
                column: "DeliveryTypeId",
                principalTable: "DeliveryType",
                principalColumn: "DeliveryTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_DeskQuote_Desk_DeskId",
                table: "DeskQuote",
                column: "DeskId",
                principalTable: "Desk",
                principalColumn: "DeskId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeskQuote_DeliveryType_DeliveryTypeId",
                table: "DeskQuote");

            migrationBuilder.DropForeignKey(
                name: "FK_DeskQuote_Desk_DeskId",
                table: "DeskQuote");

            migrationBuilder.DropIndex(
                name: "IX_DeskQuote_DeskId",
                table: "DeskQuote");

            migrationBuilder.AlterColumn<string>(
                name: "DesktopMaterialName",
                table: "DesktopMaterial",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "QuotePrice",
                table: "DeskQuote",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "QuoteDate",
                table: "DeskQuote",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DeskId",
                table: "DeskQuote",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DeliveryTypeId",
                table: "DeskQuote",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DeskQuote_DeskId",
                table: "DeskQuote",
                column: "DeskId");

            migrationBuilder.AddForeignKey(
                name: "FK_DeskQuote_DeliveryType_DeliveryTypeId",
                table: "DeskQuote",
                column: "DeliveryTypeId",
                principalTable: "DeliveryType",
                principalColumn: "DeliveryTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DeskQuote_Desk_DeskId",
                table: "DeskQuote",
                column: "DeskId",
                principalTable: "Desk",
                principalColumn: "DeskId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
