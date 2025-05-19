using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoDexApi.Migrations
{
    /// <inheritdoc />
    public partial class AddTPCWithFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VehicleInfos_Cars_Id",
                table: "VehicleInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_VehicleInfos_Motorcycles_Id",
                table: "VehicleInfos");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "VehicleInfos",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "CarId",
                table: "VehicleInfos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MotorcycleId",
                table: "VehicleInfos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_VehicleInfos_CarId",
                table: "VehicleInfos",
                column: "CarId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VehicleInfos_MotorcycleId",
                table: "VehicleInfos",
                column: "MotorcycleId",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropIndex(
                name: "IX_VehicleInfos_MotorcycleId",
                table: "VehicleInfos");

            migrationBuilder.DropColumn(
                name: "CarId",
                table: "VehicleInfos");

            migrationBuilder.DropColumn(
                name: "MotorcycleId",
                table: "VehicleInfos");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "VehicleInfos",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleInfos_Cars_Id",
                table: "VehicleInfos",
                column: "Id",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleInfos_Motorcycles_Id",
                table: "VehicleInfos",
                column: "Id",
                principalTable: "Motorcycles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
