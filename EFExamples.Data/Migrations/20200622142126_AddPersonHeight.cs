using Microsoft.EntityFrameworkCore.Migrations;

namespace EFExamples.Data.Migrations
{
    public partial class AddPersonHeight : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Height",
                table: "People",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Height",
                table: "People");
        }
    }
}
