using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogWeb.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_comments_Post_postId",
                table: "comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_comments",
                table: "comments");

            migrationBuilder.DropIndex(
                name: "IX_comments_postId",
                table: "comments");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "comments");

            migrationBuilder.AlterColumn<int>(
                name: "postId",
                table: "comments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "comments",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)")
                .OldAnnotation("Relational:ColumnOrder", 2);

            migrationBuilder.AddPrimaryKey(
                name: "PK_comments",
                table: "comments",
                columns: new[] { "postId", "ApplicationUserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_comments_Post_postId",
                table: "comments",
                column: "postId",
                principalTable: "Post",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_comments_Post_postId",
                table: "comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_comments",
                table: "comments");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "comments",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)")
                .Annotation("Relational:ColumnOrder", 2);

            migrationBuilder.AlterColumn<int>(
                name: "postId",
                table: "comments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "comments",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("Relational:ColumnOrder", 1);

            migrationBuilder.AddPrimaryKey(
                name: "PK_comments",
                table: "comments",
                columns: new[] { "Id", "ApplicationUserId" });

            migrationBuilder.CreateIndex(
                name: "IX_comments_postId",
                table: "comments",
                column: "postId");

            migrationBuilder.AddForeignKey(
                name: "FK_comments_Post_postId",
                table: "comments",
                column: "postId",
                principalTable: "Post",
                principalColumn: "Id");
        }
    }
}
