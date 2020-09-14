using Microsoft.EntityFrameworkCore.Migrations;

namespace LanguageCourseAPI.Migrations
{
    public partial class userFieldsALter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Usuario",
                newName: "Usuario");

            migrationBuilder.RenameColumn(
                name: "Role",
                table: "Usuario",
                newName: "Cargo");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Usuario",
                newName: "Senha");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Usuario",
                table: "Usuario",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "Cargo",
                table: "Usuario",
                newName: "Role");

            migrationBuilder.RenameColumn(
                name: "Senha",
                table: "Usuario",
                newName: "Password");
        }
    }
}
