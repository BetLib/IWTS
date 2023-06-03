using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    public partial class AddDefaultValues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PassingScore_AdmissionInformations_AdmissionInformationId",
                schema: "public",
                table: "PassingScore");

            migrationBuilder.DropForeignKey(
                name: "FK_PassingScore_Subjects_SubjectId",
                schema: "public",
                table: "PassingScore");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PassingScore",
                schema: "public",
                table: "PassingScore");

            migrationBuilder.RenameTable(
                name: "PassingScore",
                schema: "public",
                newName: "PassingScores",
                newSchema: "public");

            migrationBuilder.RenameIndex(
                name: "IX_PassingScore_SubjectId",
                schema: "public",
                table: "PassingScores",
                newName: "IX_PassingScores_SubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_PassingScore_AdmissionInformationId",
                schema: "public",
                table: "PassingScores",
                newName: "IX_PassingScores_AdmissionInformationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PassingScores",
                schema: "public",
                table: "PassingScores",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PassingScores_AdmissionInformations_AdmissionInformationId",
                schema: "public",
                table: "PassingScores",
                column: "AdmissionInformationId",
                principalSchema: "public",
                principalTable: "AdmissionInformations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PassingScores_Subjects_SubjectId",
                schema: "public",
                table: "PassingScores",
                column: "SubjectId",
                principalSchema: "public",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PassingScores_AdmissionInformations_AdmissionInformationId",
                schema: "public",
                table: "PassingScores");

            migrationBuilder.DropForeignKey(
                name: "FK_PassingScores_Subjects_SubjectId",
                schema: "public",
                table: "PassingScores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PassingScores",
                schema: "public",
                table: "PassingScores");

            migrationBuilder.RenameTable(
                name: "PassingScores",
                schema: "public",
                newName: "PassingScore",
                newSchema: "public");

            migrationBuilder.RenameIndex(
                name: "IX_PassingScores_SubjectId",
                schema: "public",
                table: "PassingScore",
                newName: "IX_PassingScore_SubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_PassingScores_AdmissionInformationId",
                schema: "public",
                table: "PassingScore",
                newName: "IX_PassingScore_AdmissionInformationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PassingScore",
                schema: "public",
                table: "PassingScore",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PassingScore_AdmissionInformations_AdmissionInformationId",
                schema: "public",
                table: "PassingScore",
                column: "AdmissionInformationId",
                principalSchema: "public",
                principalTable: "AdmissionInformations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PassingScore_Subjects_SubjectId",
                schema: "public",
                table: "PassingScore",
                column: "SubjectId",
                principalSchema: "public",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
