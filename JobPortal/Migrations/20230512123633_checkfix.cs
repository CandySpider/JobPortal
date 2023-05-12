using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobPortal.Migrations
{
    public partial class checkfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SkillSetsSkills_Skills_SkillsSkillId",
                table: "SkillSetsSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_SkillSetsSkills_SkillSets_SkillSetsSkillSetId",
                table: "SkillSetsSkills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SkillSetsSkills",
                table: "SkillSetsSkills");

            migrationBuilder.RenameTable(
                name: "SkillSetsSkills",
                newName: "SkillSkillSet");

            migrationBuilder.RenameIndex(
                name: "IX_SkillSetsSkills_SkillsSkillId",
                table: "SkillSkillSet",
                newName: "IX_SkillSkillSet_SkillsSkillId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SkillSkillSet",
                table: "SkillSkillSet",
                columns: new[] { "SkillSetsSkillSetId", "SkillsSkillId" });

            migrationBuilder.AddForeignKey(
                name: "FK_SkillSkillSet_Skills_SkillsSkillId",
                table: "SkillSkillSet",
                column: "SkillsSkillId",
                principalTable: "Skills",
                principalColumn: "SkillId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SkillSkillSet_SkillSets_SkillSetsSkillSetId",
                table: "SkillSkillSet",
                column: "SkillSetsSkillSetId",
                principalTable: "SkillSets",
                principalColumn: "SkillSetId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SkillSkillSet_Skills_SkillsSkillId",
                table: "SkillSkillSet");

            migrationBuilder.DropForeignKey(
                name: "FK_SkillSkillSet_SkillSets_SkillSetsSkillSetId",
                table: "SkillSkillSet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SkillSkillSet",
                table: "SkillSkillSet");

            migrationBuilder.RenameTable(
                name: "SkillSkillSet",
                newName: "SkillSetsSkills");

            migrationBuilder.RenameIndex(
                name: "IX_SkillSkillSet_SkillsSkillId",
                table: "SkillSetsSkills",
                newName: "IX_SkillSetsSkills_SkillsSkillId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SkillSetsSkills",
                table: "SkillSetsSkills",
                columns: new[] { "SkillSetsSkillSetId", "SkillsSkillId" });

            migrationBuilder.AddForeignKey(
                name: "FK_SkillSetsSkills_Skills_SkillsSkillId",
                table: "SkillSetsSkills",
                column: "SkillsSkillId",
                principalTable: "Skills",
                principalColumn: "SkillId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SkillSetsSkills_SkillSets_SkillSetsSkillSetId",
                table: "SkillSetsSkills",
                column: "SkillSetsSkillSetId",
                principalTable: "SkillSets",
                principalColumn: "SkillSetId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
