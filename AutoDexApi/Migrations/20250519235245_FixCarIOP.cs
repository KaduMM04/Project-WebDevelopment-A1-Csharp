using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoDexApi.Migrations
{
    /// <inheritdoc />
    public partial class FixCarIOP : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Motorcycles_VehicleInfos_InfoId",
                table: "Motorcycles");

            migrationBuilder.DropForeignKey(
                name: "FK_VehicleInfos_Cars_VehicleId",
                table: "VehicleInfos");

            migrationBuilder.DropIndex(
                name: "IX_VehicleInfos_VehicleId",
                table: "VehicleInfos");

            migrationBuilder.DropIndex(
                name: "IX_Motorcycles_InfoId",
                table: "Motorcycles");

            migrationBuilder.DropColumn(
                name: "InfoId",
                table: "Motorcycles");

            migrationBuilder.DropColumn(
                name: "TypeSteering",
                table: "Cars");

            migrationBuilder.AddColumn<string>(
                name: "Engine",
                table: "Vehicles",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "FuelType",
                table: "Vehicles",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "MaximumSpeed",
                table: "Vehicles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Power",
                table: "Vehicles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Transmission",
                table: "Vehicles",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleInfos_VehicleId",
                table: "VehicleInfos",
                column: "VehicleId");

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleInfos_Vehicles_VehicleId",
                table: "VehicleInfos",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VehicleInfos_Vehicles_VehicleId",
                table: "VehicleInfos");

            migrationBuilder.DropIndex(
                name: "IX_VehicleInfos_VehicleId",
                table: "VehicleInfos");

            migrationBuilder.DropColumn(
                name: "Engine",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "FuelType",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "MaximumSpeed",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "Power",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "Transmission",
                table: "Vehicles");

            migrationBuilder.AddColumn<int>(
                name: "InfoId",
                table: "Motorcycles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TypeSteering",
                table: "Cars",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleInfos_VehicleId",
                table: "VehicleInfos",
                column: "VehicleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Motorcycles_InfoId",
                table: "Motorcycles",
                column: "InfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Motorcycles_VehicleInfos_InfoId",
                table: "Motorcycles",
                column: "InfoId",
                principalTable: "VehicleInfos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleInfos_Cars_VehicleId",
                table: "VehicleInfos",
                column: "VehicleId",
                principalTable: "Cars",
                principalColumn: "CarId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
