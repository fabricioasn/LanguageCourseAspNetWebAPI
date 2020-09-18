using Microsoft.EntityFrameworkCore.Migrations;

namespace LanguageCourseAPI.Migrations
{
    public partial class ClassNewCollums : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Modulo",
                table: "tbl_Turma",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MetodologiaDeEnsino",
                table: "tbl_Turma",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Turno",
                table: "tbl_Turma",
                maxLength: 20,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MetodologiaDeEnsino",
                table: "tbl_Turma");

            migrationBuilder.DropColumn(
                name: "Turno",
                table: "tbl_Turma");

            migrationBuilder.AlterColumn<string>(
                name: "Modulo",
                table: "tbl_Turma",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 10);
        }
    }
}
