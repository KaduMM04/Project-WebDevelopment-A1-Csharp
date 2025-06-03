using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoDexApi.Migrations
{
    /// <inheritdoc />
    public partial class FixCarI : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VehicleInfos_Cars_CarId",
                table: "VehicleInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_VehicleInfos_Cars_CarId1",
                table: "VehicleInfos");

            migrationBuilder.DropIndex(
                name: "IX_VehicleInfos_CarId1",
                table: "VehicleInfos");

            migrationBuilder.DropColumn(
                name: "CarId1",
                table: "VehicleInfos");

            migrationBuilder.RenameColumn(
                name: "CarId",
                table: "VehicleInfos",
                newName: "VehicleId");

            migrationBuilder.RenameIndex(
                name: "IX_VehicleInfos_CarId",
                table: "VehicleInfos",
                newName: "IX_VehicleInfos_VehicleId");

            migrationBuilder.AddColumn<int>(
                name: "infoId",
                table: "Cars",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cars_infoId",
                table: "Cars",
                column: "infoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_VehicleInfos_infoId",
                table: "Cars",
                column: "infoId",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_VehicleInfos_infoId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_VehicleInfos_Cars_VehicleId",
                table: "VehicleInfos");

            migrationBuilder.DropIndex(
                name: "IX_Cars_infoId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "infoId",
                table: "Cars");

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

            migrationBuilder.CreateIndex(
                name: "IX_VehicleInfos_CarId1",
                table: "VehicleInfos",
                column: "CarId1",
                unique: true);

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
    }
}
