using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ValhallaVaultCyberAwareness.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserQuestionModel_AspNetUsers_ApplicationUserId",
                table: "ApplicationUserQuestionModel");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserQuestionModel_Questions_QuestionModelId",
                table: "ApplicationUserQuestionModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationUserQuestionModel",
                table: "ApplicationUserQuestionModel");

            migrationBuilder.RenameTable(
                name: "ApplicationUserQuestionModel",
                newName: "ApplicationUserQuestions");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationUserQuestionModel_QuestionModelId",
                table: "ApplicationUserQuestions",
                newName: "IX_ApplicationUserQuestions_QuestionModelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationUserQuestions",
                table: "ApplicationUserQuestions",
                columns: new[] { "ApplicationUserId", "QuestionModelId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserQuestions_AspNetUsers_ApplicationUserId",
                table: "ApplicationUserQuestions",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserQuestions_Questions_QuestionModelId",
                table: "ApplicationUserQuestions",
                column: "QuestionModelId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserQuestions_AspNetUsers_ApplicationUserId",
                table: "ApplicationUserQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserQuestions_Questions_QuestionModelId",
                table: "ApplicationUserQuestions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationUserQuestions",
                table: "ApplicationUserQuestions");

            migrationBuilder.RenameTable(
                name: "ApplicationUserQuestions",
                newName: "ApplicationUserQuestionModel");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationUserQuestions_QuestionModelId",
                table: "ApplicationUserQuestionModel",
                newName: "IX_ApplicationUserQuestionModel_QuestionModelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationUserQuestionModel",
                table: "ApplicationUserQuestionModel",
                columns: new[] { "ApplicationUserId", "QuestionModelId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserQuestionModel_AspNetUsers_ApplicationUserId",
                table: "ApplicationUserQuestionModel",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserQuestionModel_Questions_QuestionModelId",
                table: "ApplicationUserQuestionModel",
                column: "QuestionModelId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
