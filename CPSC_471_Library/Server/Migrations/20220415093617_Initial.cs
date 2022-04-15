using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CPSC_471_Library.Server.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Libraries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LibraryBranch = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LibraryAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LibraryPhone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libraries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LibraryEvents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EventDuration = table.Column<int>(type: "int", nullable: false),
                    EventLibraryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibraryEvents", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Libraries",
                columns: new[] { "Id", "LibraryAddress", "LibraryBranch", "LibraryPhone" },
                values: new object[,]
                {
                    { 10101, "124 Conch St. \n Kanto OC Y7U 6R3", "Kanto", "(555)-0101" },
                    { 100100, "308 Negra Arroyo Lane \n Emerald City ZZ R4V 2A5", "Emerald", "(555)-0188" },
                    { 101010, "221B Baker St. \n Gotham NJ H9X 2D3", "Gotham", "(555)-0100" },
                    { 129129, "1640 Riverside Drive \n Bedrock TA U0F 0O1", "Bedrock", "(555)-0123" },
                    { 727272, "31 Spooner Street \n Gravity Falls OR E4B 3C2", "Gravity Falls", "(555)-0145" },
                    { 777777, "742 Evergreen Terrace \n Zion AA T9P 1A7", "Zion", "(555)-0122" }
                });

            migrationBuilder.InsertData(
                table: "LibraryEvents",
                columns: new[] { "Id", "EventDate", "EventDuration", "EventLibraryId", "EventName" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 4, 12, 17, 0, 0, 0, DateTimeKind.Unspecified), 1, 10101, "Kids Reading Day" },
                    { 2, new DateTime(2022, 4, 4, 10, 0, 0, 0, DateTimeKind.Unspecified), 9, 101010, "Book Fair" },
                    { 3, new DateTime(2022, 4, 20, 16, 0, 0, 0, DateTimeKind.Unspecified), 2, 100100, "Tutoring Day" },
                    { 4, new DateTime(2022, 4, 20, 16, 0, 0, 0, DateTimeKind.Unspecified), 2, 129129, "Tutoring Day" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Libraries");

            migrationBuilder.DropTable(
                name: "LibraryEvents");
        }
    }
}
