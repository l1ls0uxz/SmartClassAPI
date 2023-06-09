using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartClassAPI.Migrations
{
    public partial class AddLoaiUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdLoai",
                table: "User",
                type: "int",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_User_IdLoai",
                table: "User",
                column: "IdLoai");

            migrationBuilder.AddForeignKey(
                name: "FK_User_LoaiUser_IdLoai",
                table: "User",
                column: "IdLoai",
                principalTable: "LoaiUser",
                principalColumn: "IdLoai",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_LoaiUser_IdLoai",
                table: "User");

            migrationBuilder.DropTable(
                name: "LoaiUser");

            migrationBuilder.DropIndex(
                name: "IX_User_IdLoai",
                table: "User");

            migrationBuilder.DropColumn(
                name: "IdLoai",
                table: "User");
        }
    }
}
