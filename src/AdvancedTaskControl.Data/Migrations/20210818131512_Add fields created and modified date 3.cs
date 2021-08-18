using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdvancedTaskControl.Data.Migrations
{
    public partial class Addfieldscreatedandmodifieddate3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Categories",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Categories",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -9992,
                column: "Password",
                value: "$2a$11$9UJbkOaWviHbbBaN5ptCa./YYp//Xrr8wD4FUea3LFhX7ZupxIt9O");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -9991,
                column: "Password",
                value: "$2a$11$mPmO1oCWNYwthjMlSyl07.lwyDgMdBLXU0Na5F0He6VlBtMpLBbUy");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Categories");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -9992,
                column: "Password",
                value: "$2a$11$47wB4dbnUt3tBOy8iSL3gesXFEwLrEljjrJM0NrF8gArM5BBu8PWq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -9991,
                column: "Password",
                value: "$2a$11$FTK6ifviA6BvBPdC.U5n6eYFS7oVdV4bfkZX1T74ujdFXlL8ae6UK");
        }
    }
}
