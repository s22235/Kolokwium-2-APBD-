using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Musicians",
                columns: table => new
                {
                    idMusician = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    nickName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musicians", x => x.idMusician);
                });

            migrationBuilder.CreateTable(
                name: "MusicLabels",
                columns: table => new
                {
                    idMusicLabel = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicLabels", x => x.idMusicLabel);
                });

            migrationBuilder.CreateTable(
                name: "Medicaments",
                columns: table => new
                {
                    idAlbum = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    albumName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    publishDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    idMusicLabel = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicaments", x => x.idAlbum);
                    table.ForeignKey(
                        name: "FK_Medicaments_MusicLabels_idMusicLabel",
                        column: x => x.idMusicLabel,
                        principalTable: "MusicLabels",
                        principalColumn: "idMusicLabel",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tracks",
                columns: table => new
                {
                    idTrack = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    trackName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    duration = table.Column<float>(type: "real", nullable: false),
                    idMusicAlbum = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tracks", x => x.idTrack);
                    table.ForeignKey(
                        name: "FK_Tracks_Medicaments_idMusicAlbum",
                        column: x => x.idMusicAlbum,
                        principalTable: "Medicaments",
                        principalColumn: "idAlbum",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Musician_Tracks",
                columns: table => new
                {
                    idTrack = table.Column<int>(type: "int", nullable: false),
                    idMusician = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musician_Tracks", x => new { x.idMusician, x.idTrack });
                    table.ForeignKey(
                        name: "FK_Musician_Tracks_Musicians_idMusician",
                        column: x => x.idMusician,
                        principalTable: "Musicians",
                        principalColumn: "idMusician",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Musician_Tracks_Tracks_idTrack",
                        column: x => x.idTrack,
                        principalTable: "Tracks",
                        principalColumn: "idTrack",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "MusicLabels",
                columns: new[] { "idMusicLabel", "name" },
                values: new object[,]
                {
                    { 1, "Label 1" },
                    { 2, "Label 2" },
                    { 3, "Label 3" }
                });

            migrationBuilder.InsertData(
                table: "Musicians",
                columns: new[] { "idMusician", "firstName", "lastName", "nickName" },
                values: new object[,]
                {
                    { 1, "Andrzej", "Lisenkov", "Monster1" },
                    { 2, "Ryszard", "Warzocha", "Monster2" },
                    { 3, "Konrad", "Wal", "Monster3" }
                });

            migrationBuilder.InsertData(
                table: "Medicaments",
                columns: new[] { "idAlbum", "albumName", "idMusicLabel", "publishDate" },
                values: new object[] { 1, "Album 1", 1, new DateTime(2011, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Medicaments",
                columns: new[] { "idAlbum", "albumName", "idMusicLabel", "publishDate" },
                values: new object[] { 2, "Album 2", 2, new DateTime(2011, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Medicaments",
                columns: new[] { "idAlbum", "albumName", "idMusicLabel", "publishDate" },
                values: new object[] { 3, "Album 3", 3, new DateTime(2011, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Tracks",
                columns: new[] { "idTrack", "duration", "idMusicAlbum", "trackName" },
                values: new object[] { 1, 5f, 1, "track 1" });

            migrationBuilder.InsertData(
                table: "Tracks",
                columns: new[] { "idTrack", "duration", "idMusicAlbum", "trackName" },
                values: new object[] { 2, 6f, 2, "track 2" });

            migrationBuilder.InsertData(
                table: "Tracks",
                columns: new[] { "idTrack", "duration", "idMusicAlbum", "trackName" },
                values: new object[] { 3, 7f, 3, "track 3" });

            migrationBuilder.InsertData(
                table: "Musician_Tracks",
                columns: new[] { "idMusician", "idTrack" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "Musician_Tracks",
                columns: new[] { "idMusician", "idTrack" },
                values: new object[] { 2, 2 });

            migrationBuilder.InsertData(
                table: "Musician_Tracks",
                columns: new[] { "idMusician", "idTrack" },
                values: new object[] { 3, 3 });

            migrationBuilder.CreateIndex(
                name: "IX_Medicaments_idMusicLabel",
                table: "Medicaments",
                column: "idMusicLabel");

            migrationBuilder.CreateIndex(
                name: "IX_Musician_Tracks_idTrack",
                table: "Musician_Tracks",
                column: "idTrack");

            migrationBuilder.CreateIndex(
                name: "IX_Tracks_idMusicAlbum",
                table: "Tracks",
                column: "idMusicAlbum");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Musician_Tracks");

            migrationBuilder.DropTable(
                name: "Musicians");

            migrationBuilder.DropTable(
                name: "Tracks");

            migrationBuilder.DropTable(
                name: "Medicaments");

            migrationBuilder.DropTable(
                name: "MusicLabels");
        }
    }
}
