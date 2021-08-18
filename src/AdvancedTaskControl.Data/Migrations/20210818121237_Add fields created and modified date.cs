using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdvancedTaskControl.Data.Migrations
{
    public partial class Addfieldscreatedandmodifieddate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Users",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -9992,
                column: "Password",
                value: "$2a$11$IF/Lu0bggDgfnZAuXnwKCutMTn6LSZmRWtFlu0dUxKuSX8w9j/4Gu");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -9991,
                column: "Password",
                value: "$2a$11$PmsJAPtBd/KuDaMPjVcKo.JtUbuGZAXDilGbpv6MVeU/aU4gAi./u");
        }
    }
}
