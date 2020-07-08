using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MediaDatabase.Migrations
{
    public partial class InitialCommit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Salt = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MediaEntries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: false),
                    Size = table.Column<double>(nullable: false),
                    SizeType = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MediaEntries_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Password", "Salt" },
                values: new object[,]
                {
                    { 1, "xavier.long4@outlook.com", "P@$$w0rd1234!@#$", null },
                    { 2, "tsijiang@hotmail.com", "qwer1234QWER!@#$", null },
                    { 3, "longx@my.erau.edu", "Pa$$w0rd11!!", null },
                    { 4, "tsijiang@gmail.com", "P4$$w0rd", null },
                    { 5, "tsijiang@yahoo.com", "wh4tPa$$w0rd", null },
                    { 6, "tsijiang@aol.com", "password", null }
                });

            migrationBuilder.InsertData(
                table: "MediaEntries",
                columns: new[] { "Id", "LastModified", "Name", "Size", "SizeType", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2018, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "My First Manga Vol 1", 30.0, "PG", 1 },
                    { 2, new DateTime(2018, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "My First Manga Vol 2", 45.0, "PG", 1 },
                    { 5, new DateTime(2020, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Game B", 0.0, null, 1 },
                    { 11, new DateTime(2020, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Game B Guidebook", 117.0, "PG", 1 },
                    { 4, new DateTime(2019, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Game A", 0.0, null, 2 },
                    { 10, new DateTime(2020, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Game A Guidebook", 256.0, "PG", 2 },
                    { 3, new DateTime(2018, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "My First Manga Vol 5", 55.0, "PG", 3 },
                    { 6, new DateTime(2020, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Game C", 0.0, null, 3 },
                    { 12, new DateTime(2020, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Game C Guidebook", 400.0, "PG", 3 },
                    { 7, new DateTime(2015, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Game D", 0.0, null, 4 },
                    { 8, new DateTime(2016, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Game E", 0.0, null, 4 },
                    { 9, new DateTime(2017, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Game F", 0.0, null, 4 },
                    { 13, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Time Life Music Collection", 7.0, "TR", 4 },
                    { 14, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Greatest Hits: Volume 12", 9.0, "TR", 4 },
                    { 15, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Now Thats What I Call Music", 10.0, "TR", 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MediaEntries_UserId",
                table: "MediaEntries",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MediaEntries");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
