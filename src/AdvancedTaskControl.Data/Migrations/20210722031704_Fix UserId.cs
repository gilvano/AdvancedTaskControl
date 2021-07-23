﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace AdvancedTaskControl.Data.Migrations
{
    public partial class FixUserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserTasks_Users_userId",
                table: "UserTasks");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "UserTasks",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserTasks_userId",
                table: "UserTasks",
                newName: "IX_UserTasks_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserTasks_Users_UserId",
                table: "UserTasks",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserTasks_Users_UserId",
                table: "UserTasks");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "UserTasks",
                newName: "userId");

            migrationBuilder.RenameIndex(
                name: "IX_UserTasks_UserId",
                table: "UserTasks",
                newName: "IX_UserTasks_userId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserTasks_Users_userId",
                table: "UserTasks",
                column: "userId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}