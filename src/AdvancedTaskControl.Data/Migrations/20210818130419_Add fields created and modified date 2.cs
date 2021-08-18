using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdvancedTaskControl.Data.Migrations
{
    public partial class Addfieldscreatedandmodifieddate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "UserTasks",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "UserTasks",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "UserTasks");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "UserTasks");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -9992,
                column: "Password",
                value: "$2a$11$3Ng3uPV3w/.90kNpQkwlke9uGSEmXZjPEC1gvvbFBi4zg9XD5Ul6y");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -9991,
                column: "Password",
                value: "$2a$11$/hFL2Lp11fXAX..ExleQW.t4QjGOADe3BDIJlDG95KZPa8kujGxei");
        }
    }
}
