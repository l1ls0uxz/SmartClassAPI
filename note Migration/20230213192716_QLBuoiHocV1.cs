using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartClassAPI.Migrations
{
    public partial class QLBuoiHocV1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TinhTrangBuoiHoc",
                columns: table => new
                {
                    IdTinhTrang = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenTinhTrang = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TinhTrangBuoiHoc", x => x.IdTinhTrang);
                });

            migrationBuilder.CreateTable(
                name: "QuanLyBuoiHoc",
                columns: table => new
                {
                    IdBuoiHoc = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdMonHoc = table.Column<int>(type: "int", nullable: false),
                    IdLopHoc = table.Column<int>(type: "int", nullable: false),
                    IdPhongHoc = table.Column<int>(type: "int", nullable: false),
                    NgayHoc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Buoi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdTinhTrang = table.Column<int>(type: "int", nullable: false),
                    //TinhTrangBuoiHocIdTinhTrang = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuanLyBuoiHoc", x => x.IdBuoiHoc);
                    table.ForeignKey(
                        name: "FK_QuanLyBuoiHoc_LopHoc_IdLopHoc",
                        column: x => x.IdLopHoc,
                        principalTable: "LopHoc",
                        principalColumn: "IdLopHoc",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuanLyBuoiHoc_MonHoc_IdMonHoc",
                        column: x => x.IdMonHoc,
                        principalTable: "MonHoc",
                        principalColumn: "IdMonHoc",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuanLyBuoiHoc_PhongHoc_IdPhongHoc",
                        column: x => x.IdPhongHoc,
                        principalTable: "PhongHoc",
                        principalColumn: "IdPhongHoc",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuanLyBuoiHoc_TinhTrangBuoiHoc_IdTinhTrang",
                        column: x => x.IdTinhTrang,
                        principalTable: "TinhTrangBuoiHoc",
                        principalColumn: "IdTinhTrang",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuanLyBuoiHoc_IdLopHoc",
                table: "QuanLyBuoiHoc",
                column: "IdLopHoc");

            migrationBuilder.CreateIndex(
                name: "IX_QuanLyBuoiHoc_IdMonHoc",
                table: "QuanLyBuoiHoc",
                column: "IdMonHoc");

            migrationBuilder.CreateIndex(
                name: "IX_QuanLyBuoiHoc_IdPhongHoc",
                table: "QuanLyBuoiHoc",
                column: "IdPhongHoc");

            migrationBuilder.CreateIndex(
                name: "IX_QuanLyBuoiHoc_IdTinhTrang",
                table: "QuanLyBuoiHoc",
                column: "IdTinhTrang");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuanLyBuoiHoc");

            migrationBuilder.DropTable(
                name: "TinhTrangBuoiHoc");
        }
    }
}
