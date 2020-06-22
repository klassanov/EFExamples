using Microsoft.EntityFrameworkCore.Migrations;

namespace EFExamples.Data.Migrations
{
    public partial class AddPersonNickname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nickname",
                table: "People",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nickname",
                table: "People");
        }
    }
}
