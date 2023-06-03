using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartClassAPI.Migrations
{
    public partial class V9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Devices_PhongHoc_IdPhongHoc",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "DeviceType",
                table: "Devices");

            migrationBuilder.AlterColumn<int>(
                name: "IdPhongHoc",
                table: "Devices",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "DeviceTpye",
                table: "Devices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Devices_PhongHoc_IdPhongHoc",
                table: "Devices",
                column: "IdPhongHoc",
                principalTable: "PhongHoc",
                principalColumn: "IdPhongHoc",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Devices_PhongHoc_IdPhongHoc",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "DeviceTpye",
                table: "Devices");

            migrationBuilder.AlterColumn<int>(
                name: "IdPhongHoc",
                table: "Devices",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeviceType",
                table: "Devices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Devices_PhongHoc_IdPhongHoc",
                table: "Devices",
                column: "IdPhongHoc",
                principalTable: "PhongHoc",
                principalColumn: "IdPhongHoc",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
