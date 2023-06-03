using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartClassAPI.Migrations
{
    public partial class V3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HoTen",
                table: "MonHoc",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdUser",
                table: "MonHoc",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaLopHoc",
                table: "MonHoc",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MonHoc_IdUser",
                table: "MonHoc",
                column: "IdUser");

            migrationBuilder.AddForeignKey(
                name: "FK_MonHoc_User_IdUser",
                table: "MonHoc",
                column: "IdUser",
                principalTable: "User",
                principalColumn: "IdUser",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MonHoc_User_IdUser",
                table: "MonHoc");

            migrationBuilder.DropIndex(
                name: "IX_MonHoc_IdUser",
                table: "MonHoc");

            migrationBuilder.DropColumn(
                name: "HoTen",
                table: "MonHoc");

            migrationBuilder.DropColumn(
                name: "IdUser",
                table: "MonHoc");

            migrationBuilder.DropColumn(
                name: "MaLopHoc",
                table: "MonHoc");
        }
    }
}
