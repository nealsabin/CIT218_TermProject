using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TermProject.Migrations
{
    public partial class Ch11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Rides",
                newName: "Ride Name");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Rides",
                maxLength: 300,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Ride Name",
                table: "Rides",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Rides",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Rides",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Rides",
                keyColumn: "RideId",
                keyValue: 1,
                columns: new[] { "StartDate", "State" },
                values: new object[] { new DateTime(2020, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "MI" });

            migrationBuilder.UpdateData(
                table: "Rides",
                keyColumn: "RideId",
                keyValue: 2,
                columns: new[] { "StartDate", "State" },
                values: new object[] { new DateTime(2020, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "MI" });

            migrationBuilder.UpdateData(
                table: "Rides",
                keyColumn: "RideId",
                keyValue: 3,
                columns: new[] { "StartDate", "State" },
                values: new object[] { new DateTime(2018, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "MI" });

            migrationBuilder.UpdateData(
                table: "Rides",
                keyColumn: "RideId",
                keyValue: 4,
                columns: new[] { "StartDate", "State" },
                values: new object[] { new DateTime(2019, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MI" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Rides");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Rides");

            migrationBuilder.RenameColumn(
                name: "Ride Name",
                table: "Rides",
                newName: "Name");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Rides",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 300);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Rides",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);
        }
    }
}
