using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobPortal.Migrations
{
    public partial class UserModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Employers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Candidates",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Something",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Employers_ApplicationUserId",
                table: "Employers",
                column: "ApplicationUserId",
                unique: true,
                filter: "[ApplicationUserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Candidates_ApplicationUserId",
                table: "Candidates",
                column: "ApplicationUserId",
                unique: true,
                filter: "[ApplicationUserId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Candidates_AspNetUsers_ApplicationUserId",
                table: "Candidates",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employers_AspNetUsers_ApplicationUserId",
                table: "Employers",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Candidates_AspNetUsers_ApplicationUserId",
                table: "Candidates");

            migrationBuilder.DropForeignKey(
                name: "FK_Employers_AspNetUsers_ApplicationUserId",
                table: "Employers");

            migrationBuilder.DropIndex(
                name: "IX_Employers_ApplicationUserId",
                table: "Employers");

            migrationBuilder.DropIndex(
                name: "IX_Candidates_ApplicationUserId",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Employers");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "Something",
                table: "AspNetUsers");
        }
    }
}
