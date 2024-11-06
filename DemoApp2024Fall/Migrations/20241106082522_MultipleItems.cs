using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoApp2024Fall.Migrations
{
    /// <inheritdoc />
    public partial class MultipleItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_People_Items_ItemId",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_People_ItemId",
                table: "People");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "People");

            migrationBuilder.AddColumn<Guid>(
                name: "PersonId",
                table: "Items",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Items_PersonId",
                table: "Items",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_People_PersonId",
                table: "Items",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_People_PersonId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_PersonId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "Items");

            migrationBuilder.AddColumn<Guid>(
                name: "ItemId",
                table: "People",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_People_ItemId",
                table: "People",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_People_Items_ItemId",
                table: "People",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id");
        }
    }
}
