using Microsoft.EntityFrameworkCore.Migrations;

namespace TermProject.Migrations
{
    public partial class Difficulty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DifficultyId",
                table: "Rides",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Difficulties",
                columns: table => new
                {
                    DifficultyId = table.Column<string>(nullable: false),
                    Rating = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Difficulties", x => x.DifficultyId);
                });

            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "DifficultyId", "Rating" },
                values: new object[] { "1", "Easy" });

            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "DifficultyId", "Rating" },
                values: new object[] { "2", "Medium" });

            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "DifficultyId", "Rating" },
                values: new object[] { "3", "Hard" });

            migrationBuilder.UpdateData(
                table: "Rides",
                keyColumn: "RideId",
                keyValue: 1,
                column: "DifficultyId",
                value: "3");

            migrationBuilder.UpdateData(
                table: "Rides",
                keyColumn: "RideId",
                keyValue: 2,
                column: "DifficultyId",
                value: "1");

            migrationBuilder.UpdateData(
                table: "Rides",
                keyColumn: "RideId",
                keyValue: 3,
                column: "DifficultyId",
                value: "2");

            migrationBuilder.UpdateData(
                table: "Rides",
                keyColumn: "RideId",
                keyValue: 4,
                column: "DifficultyId",
                value: "2");

            migrationBuilder.CreateIndex(
                name: "IX_Rides_DifficultyId",
                table: "Rides",
                column: "DifficultyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rides_Difficulties_DifficultyId",
                table: "Rides",
                column: "DifficultyId",
                principalTable: "Difficulties",
                principalColumn: "DifficultyId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rides_Difficulties_DifficultyId",
                table: "Rides");

            migrationBuilder.DropTable(
                name: "Difficulties");

            migrationBuilder.DropIndex(
                name: "IX_Rides_DifficultyId",
                table: "Rides");

            migrationBuilder.DropColumn(
                name: "DifficultyId",
                table: "Rides");
        }
    }
}
