using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RestaurantRazor.Data.Migrations
{
    public partial class MenuItemCorrectID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuItems_CategoryTypes_CategoryTypeId",
                table: "MenuItems");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "MenuItems");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryTypeId",
                table: "MenuItems",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItems_CategoryTypes_CategoryTypeId",
                table: "MenuItems",
                column: "CategoryTypeId",
                principalTable: "CategoryTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuItems_CategoryTypes_CategoryTypeId",
                table: "MenuItems");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryTypeId",
                table: "MenuItems",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "MenuItems",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItems_CategoryTypes_CategoryTypeId",
                table: "MenuItems",
                column: "CategoryTypeId",
                principalTable: "CategoryTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
