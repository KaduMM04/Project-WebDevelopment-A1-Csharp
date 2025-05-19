using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoDexApi.Migrations
{
    /// <inheritdoc />
    public partial class FixTPCWithFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VehicleInfos_Cars_CarId",
                table: "VehicleInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_VehicleInfos_Motorcycles_MotorcycleId",
                table: "VehicleInfos");

            migrationBuilder.DropIndex(
                name: "IX_VehicleInfos_CarId",
                table: "VehicleInfos");

            migrationBuilder.DropColumn(
                name: "CarId",
                table: "VehicleInfos");

            migrationBuilder.RenameColumn(
                name: "MotorcycleId",
                table: "VehicleInfos",
                newName: "VehicleId");

            migrationBuilder.RenameIndex(
                name: "IX_VehicleInfos_MotorcycleId",
                table: "VehicleInfos",
                newName: "IX_VehicleInfos_VehicleId");

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleInfos_Cars_VehicleId",
                table: "VehicleInfos",
                column: "VehicleId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleInfos_Motorcycles_VehicleId",
                table: "VehicleInfos",
                column: "VehicleId",
                principalTable: "Motorcycles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VehicleInfos_Cars_VehicleId",
                table: "VehicleInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_VehicleInfos_Motorcycles_VehicleId",
                table: "VehicleInfos");

            migrationBuilder.RenameColumn(
                name: "VehicleId",
                table: "VehicleInfos",
                newName: "MotorcycleId");

            migrationBuilder.RenameIndex(
                name: "IX_VehicleInfos_VehicleId",
                table: "VehicleInfos",
                newName: "IX_VehicleInfos_MotorcycleId");

            migrationBuilder.AddColumn<int>(
                name: "CarId",
                table: "VehicleInfos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_VehicleInfos_CarId",
                table: "VehicleInfos",
                column: "CarId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleInfos_Cars_CarId",
                table: "VehicleInfos",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleInfos_Motorcycles_MotorcycleId",
                table: "VehicleInfos",
                column: "MotorcycleId",
                principalTable: "Motorcycles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
