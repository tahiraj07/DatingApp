using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace datingapp.API.Migrations
{
    public partial class neetasks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedById = table.Column<int>(nullable: true),
                    TaskDetail = table.Column<string>(nullable: true),
                    TaskName = table.Column<string>(nullable: true),
                    DueTo = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Assigned = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Notify = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    ToDo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_CreatedById",
                table: "Tasks",
                column: "CreatedById");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");
        }
    }
}
