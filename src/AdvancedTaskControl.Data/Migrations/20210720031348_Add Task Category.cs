using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AdvancedTaskControl.Data.Migrations
{
    public partial class AddTaskCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "UserTasks",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CategoryDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryDescription" },
                values: new object[,]
                {
                    { 1, "Categoria 1" },
                    { 2, "Categoria 2" },
                    { 3, "Categoria 3" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserTasks_CategoryId",
                table: "UserTasks",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserTasks_Categories_CategoryId",
                table: "UserTasks",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserTasks_Categories_CategoryId",
                table: "UserTasks");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_UserTasks_CategoryId",
                table: "UserTasks");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "UserTasks");
        }
    }
}
