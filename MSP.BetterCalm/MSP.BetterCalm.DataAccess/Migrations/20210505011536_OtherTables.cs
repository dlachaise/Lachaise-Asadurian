using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MSP.BetterCalm.DataAccess.Migrations
{
    public partial class OtherTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Audios_Category_CategoryId",
                table: "Audios");

            migrationBuilder.DropForeignKey(
                name: "FK_Audios_Playlists_PlaylistId",
                table: "Audios");

            migrationBuilder.DropIndex(
                name: "IX_Audios_CategoryId",
                table: "Audios");

            migrationBuilder.DropIndex(
                name: "IX_Audios_PlaylistId",
                table: "Audios");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Audios");

            migrationBuilder.DropColumn(
                name: "PlaylistId",
                table: "Audios");

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Psychologist",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "AudioCategory",
                columns: table => new
                {
                    AudiosId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    audioCategoriesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AudioCategory", x => new { x.AudiosId, x.audioCategoriesId });
                    table.ForeignKey(
                        name: "FK_AudioCategory_Audios_AudiosId",
                        column: x => x.AudiosId,
                        principalTable: "Audios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AudioCategory_Category_audioCategoriesId",
                        column: x => x.audioCategoriesId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AudioPlaylist",
                columns: table => new
                {
                    AudiosId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    audioPlaylistId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AudioPlaylist", x => new { x.AudiosId, x.audioPlaylistId });
                    table.ForeignKey(
                        name: "FK_AudioPlaylist_Audios_AudiosId",
                        column: x => x.AudiosId,
                        principalTable: "Audios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AudioPlaylist_Playlists_audioPlaylistId",
                        column: x => x.audioPlaylistId,
                        principalTable: "Playlists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AudioCategory_audioCategoriesId",
                table: "AudioCategory",
                column: "audioCategoriesId");

            migrationBuilder.CreateIndex(
                name: "IX_AudioPlaylist_audioPlaylistId",
                table: "AudioPlaylist",
                column: "audioPlaylistId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AudioCategory");

            migrationBuilder.DropTable(
                name: "AudioPlaylist");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Psychologist");

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId",
                table: "Audios",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PlaylistId",
                table: "Audios",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Audios_CategoryId",
                table: "Audios",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Audios_PlaylistId",
                table: "Audios",
                column: "PlaylistId");

            migrationBuilder.AddForeignKey(
                name: "FK_Audios_Category_CategoryId",
                table: "Audios",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Audios_Playlists_PlaylistId",
                table: "Audios",
                column: "PlaylistId",
                principalTable: "Playlists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
