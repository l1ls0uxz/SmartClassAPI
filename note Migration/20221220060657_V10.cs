using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartClassAPI.Migrations
{
    public partial class V10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Devices_User_IdUser",
                table: "Devices");

            migrationBuilder.AlterColumn<int>(
                name: "IdUser",
                table: "Devices",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Devices_User_IdUser",
                table: "Devices",
                column: "IdUser",
                principalTable: "User",
                principalColumn: "IdUser",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Devices_User_IdUser",
                table: "Devices");

            migrationBuilder.AlterColumn<int>(
                name: "IdUser",
                table: "Devices",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Devices_User_IdUser",
                table: "Devices",
                column: "IdUser",
                principalTable: "User",
                principalColumn: "IdUser",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
