using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartClassAPI.Migrations
{
    public partial class BuoiHocTinhTrang : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_QuanLyBuoiHoc_TinhTrangBuoiHoc_TinhTrangBuoiHocIdTinhTrang",
            //    table: "QuanLyBuoiHoc");

            //migrationBuilder.DropIndex(
            //    name: "IX_QuanLyBuoiHoc_TinhTrangBuoiHocIdTinhTrang",
            //    table: "QuanLyBuoiHoc");

            //migrationBuilder.DropColumn(
            //    name: "TinhTrangBuoiHocIdTinhTrang",
            //    table: "QuanLyBuoiHoc");

            //migrationBuilder.CreateIndex(
            //    name: "IX_QuanLyBuoiHoc_IdTinhTrang",
            //    table: "QuanLyBuoiHoc",
            //    column: "IdTinhTrang");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_QuanLyBuoiHoc_TinhTrangBuoiHoc_IdTinhTrang",
            //    table: "QuanLyBuoiHoc",
            //    column: "IdTinhTrang",
            //    principalTable: "TinhTrangBuoiHoc",
            //    principalColumn: "IdTinhTrang",
            //    onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuanLyBuoiHoc_IdTinhTrang",
                table: "QuanLyBuoiHoc");

            migrationBuilder.DropIndex(
                name: "IX_QuanLyBuoiHoc_IdTinhTrang",
                table: "QuanLyBuoiHoc");

            migrationBuilder.AddColumn<int>(
                name: "IdTinhTrang",
                table: "QuanLyBuoiHoc",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_QuanLyBuoiHoc_IdTinhTrang",
                table: "QuanLyBuoiHoc",
                column: "IdTinhTrang");

            migrationBuilder.AddForeignKey(
                name: "FK_QuanLyBuoiHoc_IdTinhTrang",
                table: "QuanLyBuoiHoc",
                column: "IdTinhTrang",
                principalTable: "TinhTrangBuoiHoc",
                principalColumn: "IdTinhTrang",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
