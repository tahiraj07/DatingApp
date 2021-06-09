using Microsoft.EntityFrameworkCore.Migrations;

namespace datingapp.API.Migrations
{
    public partial class updatetask : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserWhoCreate",
                table: "Tasks",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserWhoCreate",
                table: "Tasks");
        }
    }
}
