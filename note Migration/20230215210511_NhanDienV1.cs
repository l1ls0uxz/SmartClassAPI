using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartClassAPI.Migrations
{
    public partial class NhanDienV1 : Migration
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NhanDien");

            migrationBuilder.DropTable(
                name: "CanhBao");
        }
    }
}
