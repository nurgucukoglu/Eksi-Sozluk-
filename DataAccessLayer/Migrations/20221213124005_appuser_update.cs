using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class appuser_update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_AspNetUsers_AppUserID",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_AppUserID",
                table: "Posts");

            migrationBuilder.CreateTable(
                name: "AppUserPost",
                columns: table => new
                {
                    AppUserId = table.Column<int>(type: "int", nullable: false),
                    PostsPostID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserPost", x => new { x.AppUserId, x.PostsPostID });
                    table.ForeignKey(
                        name: "FK_AppUserPost_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppUserPost_Posts_PostsPostID",
                        column: x => x.PostsPostID,
                        principalTable: "Posts",
                        principalColumn: "PostID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppUserPost_PostsPostID",
                table: "AppUserPost",
                column: "PostsPostID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppUserPost");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_AppUserID",
                table: "Posts",
                column: "AppUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_AspNetUsers_AppUserID",
                table: "Posts",
                column: "AppUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
