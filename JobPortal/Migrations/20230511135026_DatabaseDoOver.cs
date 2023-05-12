using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobPortal.Migrations
{
    public partial class DatabaseDoOver : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Resumes");

            migrationBuilder.DropColumn(
                name: "ApplicantEmail",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "ApplicantName",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "ResumeFileName",
                table: "Applications");

            migrationBuilder.AddColumn<int>(
                name: "EmployerId",
                table: "Jobs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SkillSetId",
                table: "Jobs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CandidateId",
                table: "Applications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Candidates",
                columns: table => new
                {
                    CandidateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidates", x => x.CandidateId);
                });

            migrationBuilder.CreateTable(
                name: "Employers",
                columns: table => new
                {
                    EmployerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employers", x => x.EmployerId);
                });

            migrationBuilder.CreateTable(
                name: "SkillSets",
                columns: table => new
                {
                    SkillSetId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillSets", x => x.SkillSetId);
                });

            migrationBuilder.CreateTable(
                name: "CandidateProfiles",
                columns: table => new
                {
                    CandidateProfileId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CandidateId = table.Column<int>(type: "int", nullable: false),
                    CandidateName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfilePhotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResumeFileUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateProfiles", x => x.CandidateProfileId);
                    table.ForeignKey(
                        name: "FK_CandidateProfiles_Candidates_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidates",
                        principalColumn: "CandidateId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompanyProfiles",
                columns: table => new
                {
                    CompanyProfileId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyProfiles", x => x.CompanyProfileId);
                    table.ForeignKey(
                        name: "FK_CompanyProfiles_Employers_EmployerId",
                        column: x => x.EmployerId,
                        principalTable: "Employers",
                        principalColumn: "EmployerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    SkillId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SkillName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SkillId1 = table.Column<int>(type: "int", nullable: true),
                    SkillSetId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.SkillId);
                    table.ForeignKey(
                        name: "FK_Skills_Skills_SkillId1",
                        column: x => x.SkillId1,
                        principalTable: "Skills",
                        principalColumn: "SkillId");
                    table.ForeignKey(
                        name: "FK_Skills_SkillSets_SkillSetId",
                        column: x => x.SkillSetId,
                        principalTable: "SkillSets",
                        principalColumn: "SkillSetId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_EmployerId",
                table: "Jobs",
                column: "EmployerId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_SkillSetId",
                table: "Jobs",
                column: "SkillSetId");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_CandidateId",
                table: "Applications",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_JobId",
                table: "Applications",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateProfiles_CandidateId",
                table: "CandidateProfiles",
                column: "CandidateId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CompanyProfiles_EmployerId",
                table: "CompanyProfiles",
                column: "EmployerId");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_SkillId1",
                table: "Skills",
                column: "SkillId1");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_SkillSetId",
                table: "Skills",
                column: "SkillSetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Candidates_CandidateId",
                table: "Applications",
                column: "CandidateId",
                principalTable: "Candidates",
                principalColumn: "CandidateId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Jobs_JobId",
                table: "Applications",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "JobId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Employers_EmployerId",
                table: "Jobs",
                column: "EmployerId",
                principalTable: "Employers",
                principalColumn: "EmployerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_SkillSets_SkillSetId",
                table: "Jobs",
                column: "SkillSetId",
                principalTable: "SkillSets",
                principalColumn: "SkillSetId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Candidates_CandidateId",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Jobs_JobId",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Employers_EmployerId",
                table: "Jobs");

            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_SkillSets_SkillSetId",
                table: "Jobs");

            migrationBuilder.DropTable(
                name: "CandidateProfiles");

            migrationBuilder.DropTable(
                name: "CompanyProfiles");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Candidates");

            migrationBuilder.DropTable(
                name: "Employers");

            migrationBuilder.DropTable(
                name: "SkillSets");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_EmployerId",
                table: "Jobs");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_SkillSetId",
                table: "Jobs");

            migrationBuilder.DropIndex(
                name: "IX_Applications_CandidateId",
                table: "Applications");

            migrationBuilder.DropIndex(
                name: "IX_Applications_JobId",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "EmployerId",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "SkillSetId",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "CandidateId",
                table: "Applications");

            migrationBuilder.AddColumn<string>(
                name: "ApplicantEmail",
                table: "Applications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ApplicantName",
                table: "Applications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ResumeFileName",
                table: "Applications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Resumes",
                columns: table => new
                {
                    ResumeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicantName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResumeFileName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resumes", x => x.ResumeId);
                });
        }
    }
}
