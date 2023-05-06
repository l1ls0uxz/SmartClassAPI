using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartClassAPI.Migrations
{
    public partial class V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LopHoc",
                columns: table => new
                {
                    IdLopHoc = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaLopHoc = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LopHoc", x => x.IdLopHoc);
                });

            migrationBuilder.CreateTable(
                name: "MonHoc",
                columns: table => new
                {
                    IdMonHoc = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenMonHoc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayBatDau = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SoTiet = table.Column<int>(type: "int", nullable: false),
                    IdLopHoc = table.Column<int>(type: "int", nullable: true),
                    MaLopHoc = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonHoc", x => x.IdMonHoc);
                    table.ForeignKey(
                        name: "FK_MonHoc_LopHoc_IdLopHoc",
                        column: x => x.IdLopHoc,
                        principalTable: "LopHoc",
                        principalColumn: "IdLopHoc",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    IdUser = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoTen = table.Column<string>(type: "Nvarchar(200)", maxLength: 200, nullable: false),
                    UserName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    MatKhau = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoaiUser = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DienThoai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdHocSinh = table.Column<int>(type: "int", nullable: false),
                    IdLopHoc = table.Column<int>(type: "int", nullable: true),
                    MonHocIdMonHoc = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.IdUser);
                    table.ForeignKey(
                        name: "FK_User_LopHoc_IdLopHoc",
                        column: x => x.IdLopHoc,
                        principalTable: "LopHoc",
                        principalColumn: "IdLopHoc",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_MonHoc_MonHocIdMonHoc",
                        column: x => x.MonHocIdMonHoc,
                        principalTable: "MonHoc",
                        principalColumn: "IdMonHoc",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TaiLieuHocTap",
                columns: table => new
                {
                    IdTaiLieu = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenTaiLieu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UrlTaiLieu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdMonHoc = table.Column<int>(type: "int", nullable: true),
                    MaMonHoc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdUser = table.Column<int>(type: "int", nullable: true),
                    HoTen = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaiLieuHocTap", x => x.IdTaiLieu);
                    table.ForeignKey(
                        name: "FK_TaiLieuHocTap_MonHoc_IdMonHoc",
                        column: x => x.IdMonHoc,
                        principalTable: "MonHoc",
                        principalColumn: "IdMonHoc",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TaiLieuHocTap_User_IdUser",
                        column: x => x.IdUser,
                        principalTable: "User",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MonHoc_IdLopHoc",
                table: "MonHoc",
                column: "IdLopHoc");

            migrationBuilder.CreateIndex(
                name: "IX_TaiLieuHocTap_IdMonHoc",
                table: "TaiLieuHocTap",
                column: "IdMonHoc");

            migrationBuilder.CreateIndex(
                name: "IX_TaiLieuHocTap_IdUser",
                table: "TaiLieuHocTap",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_User_IdLopHoc",
                table: "User",
                column: "IdLopHoc");

            migrationBuilder.CreateIndex(
                name: "IX_User_MonHocIdMonHoc",
                table: "User",
                column: "MonHocIdMonHoc");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaiLieuHocTap");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "MonHoc");

            migrationBuilder.DropTable(
                name: "LopHoc");
        }
    }
}
