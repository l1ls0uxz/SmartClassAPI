using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartClassAPI.Migrations
{
    public partial class V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CanhBao",
                columns: table => new
                {
                    IdCanhBao = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenCanhBao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CanhBao", x => x.IdCanhBao);
                });

            migrationBuilder.CreateTable(
                name: "LoaiUser",
                columns: table => new
                {
                    IdLoai = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLoai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MotaLoai = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiUser", x => x.IdLoai);
                });

            migrationBuilder.CreateTable(
                name: "LopHoc",
                columns: table => new
                {
                    IdLopHoc = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaLopHoc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NgayBatDau = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LopHoc", x => x.IdLopHoc);
                });

            migrationBuilder.CreateTable(
                name: "PhongHoc",
                columns: table => new
                {
                    IdPhongHoc = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenPhongHoc = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhongHoc", x => x.IdPhongHoc);
                });

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
                name: "TinhTrangMonHoc",
                columns: table => new
                {
                    IdTinhTrang = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenTinhTrang = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TinhTrangMonHoc", x => x.IdTinhTrang);
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
                    IdLoai = table.Column<int>(type: "int", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DienThoai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdHocSinh = table.Column<int>(type: "int", nullable: true),
                    IdLopHoc = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.IdUser);
                    table.ForeignKey(
                        name: "FK_User_LoaiUser_IdLoai",
                        column: x => x.IdLoai,
                        principalTable: "LoaiUser",
                        principalColumn: "IdLoai",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_LopHoc_IdLopHoc",
                        column: x => x.IdLopHoc,
                        principalTable: "LopHoc",
                        principalColumn: "IdLopHoc",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Devices",
                columns: table => new
                {
                    IdDevice = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeviceName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MieuTaCongDung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviceTpye = table.Column<int>(type: "int", nullable: false),
                    IdPhongHoc = table.Column<int>(type: "int", nullable: true),
                    IdUser = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devices", x => x.IdDevice);
                    table.ForeignKey(
                        name: "FK_Devices_PhongHoc_IdPhongHoc",
                        column: x => x.IdPhongHoc,
                        principalTable: "PhongHoc",
                        principalColumn: "IdPhongHoc",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Devices_User_IdUser",
                        column: x => x.IdUser,
                        principalTable: "User",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Restrict);
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
                    IdUser = table.Column<int>(type: "int", nullable: true),
                    IdPhongHoc = table.Column<int>(type: "int", nullable: true),
                    IdTinhTrang = table.Column<int>(type: "int", nullable: true)
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
                    table.ForeignKey(
                        name: "FK_MonHoc_PhongHoc_IdPhongHoc",
                        column: x => x.IdPhongHoc,
                        principalTable: "PhongHoc",
                        principalColumn: "IdPhongHoc",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MonHoc_TinhTrangMonHoc_IdTinhTrang",
                        column: x => x.IdTinhTrang,
                        principalTable: "TinhTrangMonHoc",
                        principalColumn: "IdTinhTrang",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MonHoc_User_IdUser",
                        column: x => x.IdUser,
                        principalTable: "User",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Notification",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUser = table.Column<int>(type: "int", nullable: true),
                    HoTen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TranType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notification_User_IdUser",
                        column: x => x.IdUser,
                        principalTable: "User",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Restrict);
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
                    IdUser = table.Column<int>(type: "int", nullable: false),
                    NgayHoc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Buoi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdTinhTrang = table.Column<int>(type: "int", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuanLyBuoiHoc_User_IdUser",
                        column: x => x.IdUser,
                        principalTable: "User",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
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
                    IdUser = table.Column<int>(type: "int", nullable: true)
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

            migrationBuilder.CreateTable(
                name: "ThoiKhoaBieu",
                columns: table => new
                {
                    IdLopHoc = table.Column<int>(type: "int", nullable: false),
                    IdMonHoc = table.Column<int>(type: "int", nullable: false),
                    IdPhongHoc = table.Column<int>(type: "int", nullable: false),
                    IdUser = table.Column<int>(type: "int", nullable: true),
                    Thu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayThan = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SangChieu = table.Column<int>(type: "int", nullable: false),
                    TinhTrang = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThoiKhoaBieu", x => new { x.IdLopHoc, x.IdPhongHoc, x.IdMonHoc });
                    table.ForeignKey(
                        name: "FK_ThoiKhoaBieu_User_IdUser",
                        column: x => x.IdUser,
                        principalTable: "User",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tkb_LopHoc",
                        column: x => x.IdLopHoc,
                        principalTable: "LopHoc",
                        principalColumn: "IdLopHoc",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tkb_MonHoc",
                        column: x => x.IdMonHoc,
                        principalTable: "MonHoc",
                        principalColumn: "IdMonHoc",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tkb_PhongHoc",
                        column: x => x.IdPhongHoc,
                        principalTable: "PhongHoc",
                        principalColumn: "IdPhongHoc",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NhanDien",
                columns: table => new
                {
                    IdNhanDien = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdBuoiHoc = table.Column<int>(type: "int", nullable: false),
                    IdUser = table.Column<int>(type: "int", nullable: true),
                    Connect = table.Column<int>(type: "int", nullable: false),
                    NhanDien = table.Column<string>(type: "Text", nullable: false),
                    IdCanhBao = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanDien", x => x.IdNhanDien);
                    table.ForeignKey(
                        name: "FK_NhanDien_CanhBao_IdCanhBao",
                        column: x => x.IdCanhBao,
                        principalTable: "CanhBao",
                        principalColumn: "IdCanhBao",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NhanDien_QuanLyBuoiHoc_IdBuoiHoc",
                        column: x => x.IdBuoiHoc,
                        principalTable: "QuanLyBuoiHoc",
                        principalColumn: "IdBuoiHoc",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NhanDien_User_IdUser",
                        column: x => x.IdUser,
                        principalTable: "User",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Devices_IdPhongHoc",
                table: "Devices",
                column: "IdPhongHoc");

            migrationBuilder.CreateIndex(
                name: "IX_Devices_IdUser",
                table: "Devices",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_MonHoc_IdLopHoc",
                table: "MonHoc",
                column: "IdLopHoc");

            migrationBuilder.CreateIndex(
                name: "IX_MonHoc_IdPhongHoc",
                table: "MonHoc",
                column: "IdPhongHoc");

            migrationBuilder.CreateIndex(
                name: "IX_MonHoc_IdTinhTrang",
                table: "MonHoc",
                column: "IdTinhTrang");

            migrationBuilder.CreateIndex(
                name: "IX_MonHoc_IdUser",
                table: "MonHoc",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_NhanDien_IdBuoiHoc",
                table: "NhanDien",
                column: "IdBuoiHoc");

            migrationBuilder.CreateIndex(
                name: "IX_NhanDien_IdCanhBao",
                table: "NhanDien",
                column: "IdCanhBao");

            migrationBuilder.CreateIndex(
                name: "IX_NhanDien_IdUser",
                table: "NhanDien",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_IdUser",
                table: "Notification",
                column: "IdUser");

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

            migrationBuilder.CreateIndex(
                name: "IX_QuanLyBuoiHoc_IdUser",
                table: "QuanLyBuoiHoc",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_TaiLieuHocTap_IdMonHoc",
                table: "TaiLieuHocTap",
                column: "IdMonHoc");

            migrationBuilder.CreateIndex(
                name: "IX_TaiLieuHocTap_IdUser",
                table: "TaiLieuHocTap",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_ThoiKhoaBieu_IdMonHoc",
                table: "ThoiKhoaBieu",
                column: "IdMonHoc");

            migrationBuilder.CreateIndex(
                name: "IX_ThoiKhoaBieu_IdPhongHoc",
                table: "ThoiKhoaBieu",
                column: "IdPhongHoc");

            migrationBuilder.CreateIndex(
                name: "IX_ThoiKhoaBieu_IdUser",
                table: "ThoiKhoaBieu",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_User_IdLoai",
                table: "User",
                column: "IdLoai");

            migrationBuilder.CreateIndex(
                name: "IX_User_IdLopHoc",
                table: "User",
                column: "IdLopHoc");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Devices");

            migrationBuilder.DropTable(
                name: "NhanDien");

            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DropTable(
                name: "TaiLieuHocTap");

            migrationBuilder.DropTable(
                name: "ThoiKhoaBieu");

            migrationBuilder.DropTable(
                name: "CanhBao");

            migrationBuilder.DropTable(
                name: "QuanLyBuoiHoc");

            migrationBuilder.DropTable(
                name: "MonHoc");

            migrationBuilder.DropTable(
                name: "TinhTrangBuoiHoc");

            migrationBuilder.DropTable(
                name: "PhongHoc");

            migrationBuilder.DropTable(
                name: "TinhTrangMonHoc");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "LoaiUser");

            migrationBuilder.DropTable(
                name: "LopHoc");
        }
    }
}
