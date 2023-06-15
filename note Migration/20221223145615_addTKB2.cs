using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartClassAPI.Migrations
{
    public partial class addTKB2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ThoiKhoaBieu_User_IdUser",
                table: "ThoiKhoaBieu");

            migrationBuilder.AlterColumn<int>(
                name: "TinhTrang",
                table: "ThoiKhoaBieu",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Thu",
                table: "ThoiKhoaBieu",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "IdUser",
                table: "ThoiKhoaBieu",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ThoiKhoaBieu_User_IdUser",
                table: "ThoiKhoaBieu",
                column: "IdUser",
                principalTable: "User",
                principalColumn: "IdUser",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ThoiKhoaBieu_User_IdUser",
                table: "ThoiKhoaBieu");

            migrationBuilder.AlterColumn<int>(
                name: "TinhTrang",
                table: "ThoiKhoaBieu",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Thu",
                table: "ThoiKhoaBieu",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IdUser",
                table: "ThoiKhoaBieu",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ThoiKhoaBieu_User_IdUser",
                table: "ThoiKhoaBieu",
                column: "IdUser",
                principalTable: "User",
                principalColumn: "IdUser",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
