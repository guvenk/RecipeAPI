using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class manytomany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "posts",
                columns: table => new
                {
                    postId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    content = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_posts", x => x.postId);
                });

            migrationBuilder.CreateTable(
                name: "tags",
                columns: table => new
                {
                    tagId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tags", x => x.tagId);
                });

            migrationBuilder.CreateTable(
                name: "postTag",
                columns: table => new
                {
                    postsPostId = table.Column<int>(type: "int", nullable: false),
                    tagsTagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_postTag", x => new { x.postsPostId, x.tagsTagId });
                    table.ForeignKey(
                        name: "FK_postTag_posts_postsPostId",
                        column: x => x.postsPostId,
                        principalTable: "posts",
                        principalColumn: "postId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_postTag_tags_tagsTagId",
                        column: x => x.tagsTagId,
                        principalTable: "tags",
                        principalColumn: "tagId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_postTag_tagsTagId",
                table: "postTag",
                column: "tagsTagId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "postTag");

            migrationBuilder.DropTable(
                name: "posts");

            migrationBuilder.DropTable(
                name: "tags");
        }
    }
}
