using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PollPulse.API.Migrations
{
    /// <inheritdoc />
    public partial class MinorChangesOnSelectedOptionsDeleteBehaviorAgain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionResponses_SurveyResponses_SurveyResponseId",
                table: "QuestionResponses");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Surveys_SurveyId",
                table: "Questions");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionResponses_SurveyResponses_SurveyResponseId",
                table: "QuestionResponses",
                column: "SurveyResponseId",
                principalTable: "SurveyResponses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Surveys_SurveyId",
                table: "Questions",
                column: "SurveyId",
                principalTable: "Surveys",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionResponses_SurveyResponses_SurveyResponseId",
                table: "QuestionResponses");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Surveys_SurveyId",
                table: "Questions");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionResponses_SurveyResponses_SurveyResponseId",
                table: "QuestionResponses",
                column: "SurveyResponseId",
                principalTable: "SurveyResponses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Surveys_SurveyId",
                table: "Questions",
                column: "SurveyId",
                principalTable: "Surveys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
