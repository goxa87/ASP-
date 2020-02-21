using Microsoft.EntityFrameworkCore.Migrations;

namespace MySite1.Migrations
{
    public partial class addBlogData_blogpost_commentblog2_ListComment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_CommentBlogs_BlogPostId",
                table: "CommentBlogs",
                column: "BlogPostId");

            migrationBuilder.AddForeignKey(
                name: "FK_CommentBlogs_BlogPosts_BlogPostId",
                table: "CommentBlogs",
                column: "BlogPostId",
                principalTable: "BlogPosts",
                principalColumn: "BlogPostId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentBlogs_BlogPosts_BlogPostId",
                table: "CommentBlogs");

            migrationBuilder.DropIndex(
                name: "IX_CommentBlogs_BlogPostId",
                table: "CommentBlogs");
        }
    }
}
