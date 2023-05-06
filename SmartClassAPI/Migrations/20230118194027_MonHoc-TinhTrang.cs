using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartClassAPI.Migrations
{
    public partial class MonHocTinhTrang : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdTinhTrang",
                table: "MonHoc",
                type: "int",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_MonHoc_IdTinhTrang",
                table: "MonHoc",
                column: "IdTinhTrang");

            migrationBuilder.AddForeignKey(
                name: "FK_MonHoc_TinhTrangMonHoc_IdTinhTrang",
                table: "MonHoc",
                column: "IdTinhTrang",
                principalTable: "TinhTrangMonHoc",
                principalColumn: "IdTinhTrang",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MonHoc_TinhTrangMonHoc_IdTinhTrang",
                table: "MonHoc");

            migrationBuilder.DropTable(
                name: "TinhTrangMonHoc");

            migrationBuilder.DropIndex(
                name: "IX_MonHoc_IdTinhTrang",
                table: "MonHoc");

            migrationBuilder.DropColumn(
                name: "IdTinhTrang",
                table: "MonHoc");
        }
    }
}
