using Microsoft.EntityFrameworkCore.Migrations;

namespace TermProject.Migrations
{
    public partial class BikeClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BikeId",
                table: "Rides",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Bike",
                columns: table => new
                {
                    BikeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BikeMake = table.Column<string>(name: "Bike Make", maxLength: 50, nullable: false),
                    Model = table.Column<string>(maxLength: 50, nullable: false),
                    WheelSize = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bike", x => x.BikeId);
                });

            migrationBuilder.InsertData(
                table: "Bike",
                columns: new[] { "BikeId", "Bike Make", "Model", "WheelSize" },
                values: new object[] { 1, "Specialized", "Sequoia", 0.0 });

            migrationBuilder.InsertData(
                table: "Bike",
                columns: new[] { "BikeId", "Bike Make", "Model", "WheelSize" },
                values: new object[] { 2, "Surly", "Pugsly", 0.0 });

            migrationBuilder.InsertData(
                table: "Bike",
                columns: new[] { "BikeId", "Bike Make", "Model", "WheelSize" },
                values: new object[] { 3, "Kona", "Unit X", 0.0 });

            migrationBuilder.UpdateData(
                table: "Rides",
                keyColumn: "RideId",
                keyValue: 1,
                column: "BikeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Rides",
                keyColumn: "RideId",
                keyValue: 2,
                column: "BikeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Rides",
                keyColumn: "RideId",
                keyValue: 3,
                column: "BikeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Rides",
                keyColumn: "RideId",
                keyValue: 4,
                column: "BikeId",
                value: 3);

            migrationBuilder.CreateIndex(
                name: "IX_Rides_BikeId",
                table: "Rides",
                column: "BikeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rides_Bike_BikeId",
                table: "Rides",
                column: "BikeId",
                principalTable: "Bike",
                principalColumn: "BikeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rides_Bike_BikeId",
                table: "Rides");

            migrationBuilder.DropTable(
                name: "Bike");

            migrationBuilder.DropIndex(
                name: "IX_Rides_BikeId",
                table: "Rides");

            migrationBuilder.DropColumn(
                name: "BikeId",
                table: "Rides");
        }
    }
}
