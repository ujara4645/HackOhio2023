using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HackOhio2023.Data.Migrations
{
    public partial class jdlfglkjsdfhglk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserEvents_AspNetUsers_ApplicationUserId1",
                table: "ApplicationUserEvents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationUserEvents",
                table: "ApplicationUserEvents");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "ApplicationUserEvents");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "ApplicationUserEvents",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationUserEvents",
                table: "ApplicationUserEvents",
                columns: new[] { "ApplicationUserId", "EventId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserEvents_AspNetUsers_ApplicationUserId",
                table: "ApplicationUserEvents",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserEvents_AspNetUsers_ApplicationUserId",
                table: "ApplicationUserEvents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationUserEvents",
                table: "ApplicationUserEvents");

            migrationBuilder.AlterColumn<int>(
                name: "ApplicationUserId",
                table: "ApplicationUserEvents",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "ApplicationUserEvents",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationUserEvents",
                table: "ApplicationUserEvents",
                columns: new[] { "ApplicationUserId1", "EventId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserEvents_AspNetUsers_ApplicationUserId1",
                table: "ApplicationUserEvents",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
