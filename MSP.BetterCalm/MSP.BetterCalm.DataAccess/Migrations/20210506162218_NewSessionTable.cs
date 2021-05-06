using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MSP.BetterCalm.DataAccess.Migrations
{
    public partial class NewSessionTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AudioCategory_Category_audioCategoriesId",
                table: "AudioCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_AudioPlaylist_Playlists_audioPlaylistId",
                table: "AudioPlaylist");

            migrationBuilder.RenameColumn(
                name: "MeetingLink",
                table: "Consultations",
                newName: "MeetingAdress");

            migrationBuilder.RenameColumn(
                name: "audioPlaylistId",
                table: "AudioPlaylist",
                newName: "PlaylistsId");

            migrationBuilder.RenameIndex(
                name: "IX_AudioPlaylist_audioPlaylistId",
                table: "AudioPlaylist",
                newName: "IX_AudioPlaylist_PlaylistsId");

            migrationBuilder.RenameColumn(
                name: "audioCategoriesId",
                table: "AudioCategory",
                newName: "CategoriesId");

            migrationBuilder.RenameIndex(
                name: "IX_AudioCategory_audioCategoriesId",
                table: "AudioCategory",
                newName: "IX_AudioCategory_CategoriesId");

            migrationBuilder.AlterColumn<int>(
                name: "MeetingType",
                table: "Psychologist",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    Token = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AdministratorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.Token);
                    table.ForeignKey(
                        name: "FK_Sessions_Administrators_AdministratorId",
                        column: x => x.AdministratorId,
                        principalTable: "Administrators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_AdministratorId",
                table: "Sessions",
                column: "AdministratorId");

            migrationBuilder.AddForeignKey(
                name: "FK_AudioCategory_Category_CategoriesId",
                table: "AudioCategory",
                column: "CategoriesId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AudioPlaylist_Playlists_PlaylistsId",
                table: "AudioPlaylist",
                column: "PlaylistsId",
                principalTable: "Playlists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AudioCategory_Category_CategoriesId",
                table: "AudioCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_AudioPlaylist_Playlists_PlaylistsId",
                table: "AudioPlaylist");

            migrationBuilder.DropTable(
                name: "Sessions");

            migrationBuilder.RenameColumn(
                name: "MeetingAdress",
                table: "Consultations",
                newName: "MeetingLink");

            migrationBuilder.RenameColumn(
                name: "PlaylistsId",
                table: "AudioPlaylist",
                newName: "audioPlaylistId");

            migrationBuilder.RenameIndex(
                name: "IX_AudioPlaylist_PlaylistsId",
                table: "AudioPlaylist",
                newName: "IX_AudioPlaylist_audioPlaylistId");

            migrationBuilder.RenameColumn(
                name: "CategoriesId",
                table: "AudioCategory",
                newName: "audioCategoriesId");

            migrationBuilder.RenameIndex(
                name: "IX_AudioCategory_CategoriesId",
                table: "AudioCategory",
                newName: "IX_AudioCategory_audioCategoriesId");

            migrationBuilder.AlterColumn<string>(
                name: "MeetingType",
                table: "Psychologist",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_AudioCategory_Category_audioCategoriesId",
                table: "AudioCategory",
                column: "audioCategoriesId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AudioPlaylist_Playlists_audioPlaylistId",
                table: "AudioPlaylist",
                column: "audioPlaylistId",
                principalTable: "Playlists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
