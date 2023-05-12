using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobPortal.Migrations
{
    public partial class addedjointableSkillSetsSkills : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Skills_Skills_SkillId1",
                table: "Skills");

            migrationBuilder.DropForeignKey(
                name: "FK_Skills_SkillSets_SkillSetId",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Skills_SkillId1",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Skills_SkillSetId",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "SkillId1",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "SkillSetId",
                table: "Skills");

            migrationBuilder.CreateTable(
                name: "SkillSetsSkills",
                columns: table => new
                {
                    SkillSetsSkillSetId = table.Column<int>(type: "int", nullable: false),
                    SkillsSkillId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillSetsSkills", x => new { x.SkillSetsSkillSetId, x.SkillsSkillId });
                    table.ForeignKey(
                        name: "FK_SkillSetsSkills_Skills_SkillsSkillId",
                        column: x => x.SkillsSkillId,
                        principalTable: "Skills",
                        principalColumn: "SkillId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SkillSetsSkills_SkillSets_SkillSetsSkillSetId",
                        column: x => x.SkillSetsSkillSetId,
                        principalTable: "SkillSets",
                        principalColumn: "SkillSetId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SkillSetsSkills_SkillsSkillId",
                table: "SkillSetsSkills",
                column: "SkillsSkillId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SkillSetsSkills");

            migrationBuilder.AddColumn<int>(
                name: "SkillId1",
                table: "Skills",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SkillSetId",
                table: "Skills",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Skills_SkillId1",
                table: "Skills",
                column: "SkillId1");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_SkillSetId",
                table: "Skills",
                column: "SkillSetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_Skills_SkillId1",
                table: "Skills",
                column: "SkillId1",
                principalTable: "Skills",
                principalColumn: "SkillId");

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_SkillSets_SkillSetId",
                table: "Skills",
                column: "SkillSetId",
                principalTable: "SkillSets",
                principalColumn: "SkillSetId");
        }
    }
}
