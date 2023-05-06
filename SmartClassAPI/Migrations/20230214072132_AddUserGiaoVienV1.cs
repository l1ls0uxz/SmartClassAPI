using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartClassAPI.Migrations
{
    public partial class AddUserGiaoVienV1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_QuanLyBuoiHoc_IdUser",
                table: "QuanLyBuoiHoc",
                column: "IdUser");

            migrationBuilder.AddForeignKey(
                name: "FK_QuanLyBuoiHoc_User_IdUser",
                table: "QuanLyBuoiHoc",
                column: "IdUser",
                principalTable: "User",
                principalColumn: "IdUser",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuanLyBuoiHoc_User_IdUser",
                table: "QuanLyBuoiHoc");

            migrationBuilder.DropIndex(
                name: "IX_QuanLyBuoiHoc_IdUser",
                table: "QuanLyBuoiHoc");
        }
    }
}
