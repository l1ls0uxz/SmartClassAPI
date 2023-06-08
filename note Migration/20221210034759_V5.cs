using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartClassAPI.Migrations
{
    public partial class V5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_MonHoc_MonHocIdMonHoc",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_MonHocIdMonHoc",
                table: "User");

            migrationBuilder.DropColumn(
                name: "MonHocIdMonHoc",
                table: "User");

            migrationBuilder.DropColumn(
                name: "HoTen",
                table: "TaiLieuHocTap");

            migrationBuilder.DropColumn(
                name: "MaMonHoc",
                table: "TaiLieuHocTap");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MonHocIdMonHoc",
                table: "User",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HoTen",
                table: "TaiLieuHocTap",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaMonHoc",
                table: "TaiLieuHocTap",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_MonHocIdMonHoc",
                table: "User",
                column: "MonHocIdMonHoc");

            migrationBuilder.AddForeignKey(
                name: "FK_User_MonHoc_MonHocIdMonHoc",
                table: "User",
                column: "MonHocIdMonHoc",
                principalTable: "MonHoc",
                principalColumn: "IdMonHoc",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
