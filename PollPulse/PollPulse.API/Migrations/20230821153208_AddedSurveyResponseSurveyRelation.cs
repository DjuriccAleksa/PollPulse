using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PollPulse.API.Migrations
{
    /// <inheritdoc />
    public partial class AddedSurveyResponseSurveyRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionResponses_SurveyResponses_SurveyResponseId",
                table: "QuestionResponses");

            migrationBuilder.AddColumn<long>(
                name: "SurveyId",
                table: "SurveyResponses",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_SurveyResponses_SurveyId",
                table: "SurveyResponses",
                column: "SurveyId");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionResponses_SurveyResponses_SurveyResponseId",
                table: "QuestionResponses",
                column: "SurveyResponseId",
                principalTable: "SurveyResponses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SurveyResponses_Surveys_SurveyId",
                table: "SurveyResponses",
                column: "SurveyId",
                principalTable: "Surveys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionResponses_SurveyResponses_SurveyResponseId",
                table: "QuestionResponses");

            migrationBuilder.DropForeignKey(
                name: "FK_SurveyResponses_Surveys_SurveyId",
                table: "SurveyResponses");

            migrationBuilder.DropIndex(
                name: "IX_SurveyResponses_SurveyId",
                table: "SurveyResponses");

            migrationBuilder.DropColumn(
                name: "SurveyId",
                table: "SurveyResponses");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionResponses_SurveyResponses_SurveyResponseId",
                table: "QuestionResponses",
                column: "SurveyResponseId",
                principalTable: "SurveyResponses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
