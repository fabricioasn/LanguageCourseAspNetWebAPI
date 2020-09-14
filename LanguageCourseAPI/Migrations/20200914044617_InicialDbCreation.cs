using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LanguageCourseAPI.Migrations
{
    public partial class InicialDbCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_Turma",
                columns: table => new
                {
                    turma_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Idioma = table.Column<string>(maxLength: 60, nullable: false),
                    Modulo = table.Column<string>(maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Turma", x => x.turma_ID);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    User_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(maxLength: 20, nullable: false),
                    Password = table.Column<string>(maxLength: 20, nullable: false),
                    Role = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.User_ID);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Aluno",
                columns: table => new
                {
                    estudante_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome_Completo = table.Column<string>(maxLength: 100, nullable: false),
                    Endereco = table.Column<string>(maxLength: 100, nullable: true),
                    Data_Nascimento = table.Column<DateTime>(nullable: false),
                    Telefone = table.Column<string>(nullable: true),
                    Identidade = table.Column<string>(nullable: true),
                    CPF = table.Column<string>(nullable: false),
                    ClassRoomID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Aluno", x => x.estudante_ID);
                    table.ForeignKey(
                        name: "FK_tbl_Aluno_tbl_Turma_ClassRoomID",
                        column: x => x.ClassRoomID,
                        principalTable: "tbl_Turma",
                        principalColumn: "turma_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Aluno_ClassRoomID",
                table: "tbl_Aluno",
                column: "ClassRoomID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_Aluno");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "tbl_Turma");
        }
    }
}
