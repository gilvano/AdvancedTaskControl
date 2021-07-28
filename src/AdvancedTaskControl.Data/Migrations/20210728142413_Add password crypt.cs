using Microsoft.EntityFrameworkCore.Migrations;

namespace AdvancedTaskControl.Data.Migrations
{
    public partial class Addpasswordcrypt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -9992,
                column: "Password",
                value: "123");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -9991,
                column: "Password",
                value: "123");
        }
    }
}
