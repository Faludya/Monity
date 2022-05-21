using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Monity.Migrations
{
    public partial class UpdateTasks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BoardId",
                table: "UserTasks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UserTasks_BoardId",
                table: "UserTasks",
                column: "BoardId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserTasks_Boards_BoardId",
                table: "UserTasks",
                column: "BoardId",
                principalTable: "Boards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserTasks_Boards_BoardId",
                table: "UserTasks");

            migrationBuilder.DropIndex(
                name: "IX_UserTasks_BoardId",
                table: "UserTasks");

            migrationBuilder.DropColumn(
                name: "BoardId",
                table: "UserTasks");
        }
    }
}
