using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogWeb.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_comments_AspNetUsers_ApplicationUserId",
                table: "comments");

            migrationBuilder.DropForeignKey(
                name: "FK_comments_Post_postId",
                table: "comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_comments",
                table: "comments");

            migrationBuilder.RenameTable(
                name: "comments",
                newName: "comment");

            migrationBuilder.RenameIndex(
                name: "IX_comments_ApplicationUserId",
                table: "comment",
                newName: "IX_comment_ApplicationUserId");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "comment",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "postId",
                table: "comment",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "comment",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_comment",
                table: "comment",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_comment_postId",
                table: "comment",
                column: "postId");

            migrationBuilder.AddForeignKey(
                name: "FK_comment_AspNetUsers_ApplicationUserId",
                table: "comment",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_comment_Post_postId",
                table: "comment",
                column: "postId",
                principalTable: "Post",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_comment_AspNetUsers_ApplicationUserId",
                table: "comment");

            migrationBuilder.DropForeignKey(
                name: "FK_comment_Post_postId",
                table: "comment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_comment",
                table: "comment");

            migrationBuilder.DropIndex(
                name: "IX_comment_postId",
                table: "comment");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "comment");

            migrationBuilder.RenameTable(
                name: "comment",
                newName: "comments");

            migrationBuilder.RenameIndex(
                name: "IX_comment_ApplicationUserId",
                table: "comments",
                newName: "IX_comments_ApplicationUserId");

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
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_comments",
                table: "comments",
                columns: new[] { "postId", "ApplicationUserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_comments_AspNetUsers_ApplicationUserId",
                table: "comments",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_comments_Post_postId",
                table: "comments",
                column: "postId",
                principalTable: "Post",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
