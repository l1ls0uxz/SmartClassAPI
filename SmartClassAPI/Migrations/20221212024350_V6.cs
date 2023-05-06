using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartClassAPI.Migrations
{
    public partial class V6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdPhongHoc",
                table: "MonHoc",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PhongHoc",
                columns: table => new
                {
                    IdPhongHoc = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenPhongHoc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdMonHoc = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhongHoc", x => x.IdPhongHoc);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MonHoc_IdPhongHoc",
                table: "MonHoc",
                column: "IdPhongHoc");

            migrationBuilder.AddForeignKey(
                name: "FK_MonHoc_PhongHoc_IdPhongHoc",
                table: "MonHoc",
                column: "IdPhongHoc",
                principalTable: "PhongHoc",
                principalColumn: "IdPhongHoc",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MonHoc_PhongHoc_IdPhongHoc",
                table: "MonHoc");

            migrationBuilder.DropTable(
                name: "PhongHoc");

            migrationBuilder.DropIndex(
                name: "IX_MonHoc_IdPhongHoc",
                table: "MonHoc");

            migrationBuilder.DropColumn(
                name: "IdPhongHoc",
                table: "MonHoc");
        }
    }
}
