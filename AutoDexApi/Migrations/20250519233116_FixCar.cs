using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoDexApi.Migrations
{
    /// <inheritdoc />
    public partial class FixCar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VehicleInfos_Vehicles_VehicleId",
                table: "VehicleInfos");

            migrationBuilder.DropColumn(
                name: "VehicleInfoId",
                table: "Vehicles");

            migrationBuilder.RenameColumn(
                name: "VehicleId",
                table: "VehicleInfos",
                newName: "CarId");

            migrationBuilder.RenameIndex(
                name: "IX_VehicleInfos_VehicleId",
                table: "VehicleInfos",
                newName: "IX_VehicleInfos_CarId");

            migrationBuilder.AddColumn<int>(
                name: "CarId1",
                table: "VehicleInfos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InfoId",
                table: "Motorcycles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_VehicleInfos_CarId1",
                table: "VehicleInfos",
                column: "CarId1",
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
                name: "FK_VehicleInfos_Cars_CarId",
                table: "VehicleInfos",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "CarId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleInfos_Cars_CarId1",
                table: "VehicleInfos",
                column: "CarId1",
                principalTable: "Cars",
                principalColumn: "CarId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Motorcycles_VehicleInfos_InfoId",
                table: "Motorcycles");

            migrationBuilder.DropForeignKey(
                name: "FK_VehicleInfos_Cars_CarId",
                table: "VehicleInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_VehicleInfos_Cars_CarId1",
                table: "VehicleInfos");

            migrationBuilder.DropIndex(
                name: "IX_VehicleInfos_CarId1",
                table: "VehicleInfos");

            migrationBuilder.DropIndex(
                name: "IX_Motorcycles_InfoId",
                table: "Motorcycles");

            migrationBuilder.DropColumn(
                name: "CarId1",
                table: "VehicleInfos");

            migrationBuilder.DropColumn(
                name: "InfoId",
                table: "Motorcycles");

            migrationBuilder.RenameColumn(
                name: "CarId",
                table: "VehicleInfos",
                newName: "VehicleId");

            migrationBuilder.RenameIndex(
                name: "IX_VehicleInfos_CarId",
                table: "VehicleInfos",
                newName: "IX_VehicleInfos_VehicleId");

            migrationBuilder.AddColumn<int>(
                name: "VehicleInfoId",
                table: "Vehicles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleInfos_Vehicles_VehicleId",
                table: "VehicleInfos",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
