using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class Tablas_News : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Curso",
                columns: table => new
                {
                    CursoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Curso", x => x.CursoId);
                });

            migrationBuilder.CreateTable(
                name: "Docente",
                columns: table => new
                {
                    DocenteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombres = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Docente", x => x.DocenteId);
                });

            migrationBuilder.CreateTable(
                name: "Asignacions",
                columns: table => new
                {
                    AsignacionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstudianteId = table.Column<int>(type: "int", nullable: false),
                    CursoId = table.Column<int>(type: "int", nullable: false),
                    DocenteId = table.Column<int>(type: "int", nullable: false),
                    Estudiantes = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asignacions", x => x.AsignacionId);
                    table.ForeignKey(
                        name: "FK_Asignacions_Curso_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Curso",
                        principalColumn: "CursoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Asignacions_Docente_DocenteId",
                        column: x => x.DocenteId,
                        principalTable: "Docente",
                        principalColumn: "DocenteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Asignacions_Estudiante_Estudiantes",
                        column: x => x.Estudiantes,
                        principalTable: "Estudiante",
                        principalColumn: "EstudianteId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Asignacions_CursoId",
                table: "Asignacions",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_Asignacions_DocenteId",
                table: "Asignacions",
                column: "DocenteId");

            migrationBuilder.CreateIndex(
                name: "IX_Asignacions_Estudiantes",
                table: "Asignacions",
                column: "Estudiantes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Asignacions");

            migrationBuilder.DropTable(
                name: "Curso");

            migrationBuilder.DropTable(
                name: "Docente");
        }
    }
}
