using Microsoft.EntityFrameworkCore.Migrations;

namespace OwnRestAPI.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Points = table.Column<int>(type: "int", nullable: false),
                    Wins = table.Column<int>(type: "int", nullable: false),
                    TeamChampionships = table.Column<int>(type: "int", nullable: false),
                    CarName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TeamName = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Points = table.Column<int>(type: "int", nullable: false),
                    Wins = table.Column<int>(type: "int", nullable: false),
                    Podiums = table.Column<int>(type: "int", nullable: false),
                    Titles = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.Name);
                    table.ForeignKey(
                        name: "FK_Drivers_Teams_TeamName",
                        column: x => x.TeamName,
                        principalTable: "Teams",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Name", "CarName", "Points", "TeamChampionships", "Wins" },
                values: new object[] { "Ferrari", "SF1000", 64, 10, 5 });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Name", "CarName", "Points", "TeamChampionships", "Wins" },
                values: new object[] { "Aston Martin", "AM21", 75, 0, 3 });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Name", "CarName", "Points", "TeamChampionships", "Wins" },
                values: new object[] { "Haas", "Beast", 1, 0, 0 });

            migrationBuilder.InsertData(
                table: "Drivers",
                columns: new[] { "Name", "Podiums", "Points", "TeamName", "Titles", "Wins" },
                values: new object[,]
                {
                    { "David Goliáš", 4, 52, "Ferrari", 0, 4 },
                    { "Sebastian Vettel", 5, 48, "Aston Martin", 4, 3 },
                    { "Adam Alkaz", 1, 27, "Aston Martin", 0, 0 },
                    { "Mick Schumacher", 0, 1, "Haas", 0, 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_TeamName",
                table: "Drivers",
                column: "TeamName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Drivers");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
