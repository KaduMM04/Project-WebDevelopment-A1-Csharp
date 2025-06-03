using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoDexApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VehicleInfos_Cars_VehicleId",
                table: "VehicleInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_VehicleInfos_Motorcycles_VehicleId",
                table: "VehicleInfos");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Motorcycles");

            migrationBuilder.DropColumn(
                name: "Mark",
                table: "Motorcycles");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Motorcycles");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Motorcycles");

            migrationBuilder.DropColumn(
                name: "YearManufacture",
                table: "Motorcycles");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Mark",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "YearManufacture",
                table: "Cars");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Motorcycles",
                newName: "MotorcycleId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Cars",
                newName: "CarId");

            migrationBuilder.AlterColumn<int>(
                name: "VehicleId",
                table: "VehicleInfos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Mark = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    YearManufacture = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ImageUrl = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Vehicles_CarId",
                table: "Cars",
                column: "CarId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Motorcycles_Vehicles_MotorcycleId",
                table: "Motorcycles",
                column: "MotorcycleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_Cars_Vehicles_CarId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Motorcycles_Vehicles_MotorcycleId",
                table: "Motorcycles");

            migrationBuilder.DropForeignKey(
                name: "FK_VehicleInfos_Vehicles_VehicleId",
                table: "VehicleInfos");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.RenameColumn(
                name: "MotorcycleId",
                table: "Motorcycles",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CarId",
                table: "Cars",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "VehicleId",
                table: "VehicleInfos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Motorcycles",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Mark",
                table: "Motorcycles",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Motorcycles",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Motorcycles",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "YearManufacture",
                table: "Motorcycles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Cars",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Mark",
                table: "Cars",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Cars",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Cars",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "YearManufacture",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
    }
}
