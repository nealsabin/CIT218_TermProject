using Microsoft.EntityFrameworkCore.Migrations;

namespace TermProject.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rides",
                columns: table => new
                {
                    RideId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Days = table.Column<int>(nullable: false),
                    Miles = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rides", x => x.RideId);
                });

            migrationBuilder.InsertData(
                table: "Rides",
                columns: new[] { "RideId", "Days", "Description", "Miles", "Name" },
                values: new object[,]
                {
                    { 1, 16, "This bikepacking trip takes your around the largest lake by surface in the world.", 1200, "Around Superior" },
                    { 2, 3, "A trip around the scenic Leelanau Peninsula.", 180, "Leelanau Peninsula" },
                    { 3, 4, "A rugged, remote trip awaits with this route around the Huron Mountains, in the Upper Peninsula of Michigan.", 210, "Huron Mountains" },
                    { 4, 5, "You will encounter some of the most beautiful coastline Michigan has to offer in this trip.", 220, "Keweenaw Peninsula" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rides");
        }
    }
}
