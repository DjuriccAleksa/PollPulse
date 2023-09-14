using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PollPulse.API.Migrations
{
    /// <inheritdoc />
    public partial class MinorChangesOnSelectedOptionsDeleteBehavior : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SelectedOptions_ClosedQuestionOptions_SurveyId_QuestionId_ClosedQuestionOptionId",
                table: "SelectedOptions");

            migrationBuilder.DropForeignKey(
                name: "FK_SelectedOptions_QuestionResponses_SurveyId_QuestionId_SurveyResponseId",
                table: "SelectedOptions");

            migrationBuilder.AddForeignKey(
                name: "FK_SelectedOptions_ClosedQuestionOptions_SurveyId_QuestionId_ClosedQuestionOptionId",
                table: "SelectedOptions",
                columns: new[] { "SurveyId", "QuestionId", "ClosedQuestionOptionId" },
                principalTable: "ClosedQuestionOptions",
                principalColumns: new[] { "SurveyId", "QuestionId", "Id" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SelectedOptions_QuestionResponses_SurveyId_QuestionId_SurveyResponseId",
                table: "SelectedOptions",
                columns: new[] { "SurveyId", "QuestionId", "SurveyResponseId" },
                principalTable: "QuestionResponses",
                principalColumns: new[] { "SurveyId", "QuestionId", "SurveyResponseId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SelectedOptions_ClosedQuestionOptions_SurveyId_QuestionId_ClosedQuestionOptionId",
                table: "SelectedOptions");

            migrationBuilder.DropForeignKey(
                name: "FK_SelectedOptions_QuestionResponses_SurveyId_QuestionId_SurveyResponseId",
                table: "SelectedOptions");

            migrationBuilder.AddForeignKey(
                name: "FK_SelectedOptions_ClosedQuestionOptions_SurveyId_QuestionId_ClosedQuestionOptionId",
                table: "SelectedOptions",
                columns: new[] { "SurveyId", "QuestionId", "ClosedQuestionOptionId" },
                principalTable: "ClosedQuestionOptions",
                principalColumns: new[] { "SurveyId", "QuestionId", "Id" });

            migrationBuilder.AddForeignKey(
                name: "FK_SelectedOptions_QuestionResponses_SurveyId_QuestionId_SurveyResponseId",
                table: "SelectedOptions",
                columns: new[] { "SurveyId", "QuestionId", "SurveyResponseId" },
                principalTable: "QuestionResponses",
                principalColumns: new[] { "SurveyId", "QuestionId", "SurveyResponseId" },
                onDelete: ReferentialAction.Cascade);
        }
    }
}
