using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace SmartClassAPI.Migrations
{
    public partial class addTKB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ThoiKhoaBieu",
                columns: table => new
                {
                    IdLopHoc = table.Column<int>(type: "int", nullable: false),
                    IdMonHoc = table.Column<int>(type: "int", nullable: false),
                    IdPhongHoc = table.Column<int>(type: "int", nullable: false),
                    IdUser = table.Column<int>(type: "int", nullable: false),
                    Thu = table.Column<int>(type: "int", nullable: false),
                    NgayThan = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SangChieu = table.Column<int>(type: "int", nullable: false),
                    TinhTrang = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThoiKhoaBieu", x => new { x.IdLopHoc, x.IdPhongHoc, x.IdMonHoc });
                    table.ForeignKey(
                        name: "FK_ThoiKhoaBieu_User_IdUser",
                        column: x => x.IdUser,
                        principalTable: "User",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ThoiKhoaBieu");
        }
    }
}
