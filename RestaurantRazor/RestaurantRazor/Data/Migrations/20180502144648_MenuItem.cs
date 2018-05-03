using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RestaurantRazor.Data.Migrations
{
    public partial class MenuItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MenuItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategoryId = table.Column<int>(nullable: false),
                    CategoryTypeId = table.Column<int>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    FoodTypeId = table.Column<int>(nullable: false),
                    Imege = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    Spicyness = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuItems_CategoryTypes_CategoryTypeId",
                        column: x => x.CategoryTypeId,
                        principalTable: "CategoryTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MenuItems_FoodType_FoodTypeId",
                        column: x => x.FoodTypeId,
                        principalTable: "FoodType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MenuItems_CategoryTypeId",
                table: "MenuItems",
                column: "CategoryTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItems_FoodTypeId",
                table: "MenuItems",
                column: "FoodTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MenuItems");
        }
    }
}
