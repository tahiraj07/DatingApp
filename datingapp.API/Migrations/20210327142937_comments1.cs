using Microsoft.EntityFrameworkCore.Migrations;

namespace datingapp.API.Migrations
{
    public partial class comments1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TaskId",
                table: "Comments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "tasksIdId",
                table: "Comments",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_tasksIdId",
                table: "Comments",
                column: "tasksIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Tasks_tasksIdId",
                table: "Comments",
                column: "tasksIdId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Tasks_tasksIdId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_tasksIdId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "TaskId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "tasksIdId",
                table: "Comments");
        }
    }
}
