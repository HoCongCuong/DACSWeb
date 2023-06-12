using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogWeb.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "published",
                table: "Post",
                type: "bit",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "published",
                table: "Post");
        }
    }
}
