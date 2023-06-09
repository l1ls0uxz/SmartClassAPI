using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartClassAPI.Migrations
{
    public partial class AddLoaiUserV : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_LoaiUser_IdLoai",
                table: "User");

            migrationBuilder.AlterColumn<int>(
                name: "IdLoai",
                table: "User",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

            migrationBuilder.AlterColumn<int>(
                name: "IdLoai",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_User_LoaiUser_IdLoai",
                table: "User",
                column: "IdLoai",
                principalTable: "LoaiUser",
                principalColumn: "IdLoai",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
