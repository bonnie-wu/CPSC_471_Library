using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CPSC_471_Library.Server.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            /*migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Copies = table.Column<int>(type: "int", nullable: false),
                    Publisher = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Distribution = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Holds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Card_number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hold_date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Holds", x => x.Id);
                });

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

            /*migrationBuilder.CreateTable(
                name: "LibraryCards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Card_number = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibraryCards", x => x.Id);
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

            /*migrationBuilder.CreateTable(
                name: "Loans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Card_number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Curr_date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Due_date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loans", x => x.Id);
                });*/

            /*migrationBuilder.CreateTable(
                name: "Staffs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Staff_num = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phone_num = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Branch_id = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staffs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactForms",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactFirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactMessage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactLibraryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactForms", x => x.id);
                    table.ForeignKey(
                        name: "FK_ContactForms_Libraries_ContactLibraryId",
                        column: x => x.ContactLibraryId,
                        principalTable: "Libraries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                });*/

            migrationBuilder.CreateIndex(
                name: "IX_ContactForms_ContactLibraryId",
                table: "ContactForms",
                column: "ContactLibraryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "ContactForms");

            migrationBuilder.DropTable(
                name: "Holds");

            migrationBuilder.DropTable(
                name: "LibraryCards");

            migrationBuilder.DropTable(
                name: "LibraryEvents");

            migrationBuilder.DropTable(
                name: "Loans");

            migrationBuilder.DropTable(
                name: "Staffs");

            migrationBuilder.DropTable(
                name: "Libraries");
        }
    }
}
