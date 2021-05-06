using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MSP.BetterCalm.DataAccess.Migrations
{
    public partial class OtherTables2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Playlists_Category_CategoryId",
                table: "Playlists");

            migrationBuilder.DropIndex(
                name: "IX_Playlists_CategoryId",
                table: "Playlists");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Playlists");

            migrationBuilder.CreateTable(
                name: "CategoryPlaylist",
                columns: table => new
                {
                    CategoriesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlaylistsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryPlaylist", x => new { x.CategoriesId, x.PlaylistsId });
                    table.ForeignKey(
                        name: "FK_CategoryPlaylist_Category_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryPlaylist_Playlists_PlaylistsId",
                        column: x => x.PlaylistsId,
                        principalTable: "Playlists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryPlaylist_PlaylistsId",
                table: "CategoryPlaylist",
                column: "PlaylistsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryPlaylist");

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId",
                table: "Playlists",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Playlists_CategoryId",
                table: "Playlists",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Playlists_Category_CategoryId",
                table: "Playlists",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
