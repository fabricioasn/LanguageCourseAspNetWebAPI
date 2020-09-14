using Microsoft.EntityFrameworkCore.Migrations;

namespace LanguageCourseAPI.Migrations
{
    public partial class UserEnrollmentAddition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Matricula",
                table: "tbl_Aluno",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Aluno_Matricula",
                table: "tbl_Aluno",
                column: "Matricula",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_tbl_Aluno_Matricula",
                table: "tbl_Aluno");

            migrationBuilder.DropColumn(
                name: "Matricula",
                table: "tbl_Aluno");
        }
    }
}
