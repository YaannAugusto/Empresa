using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Loja.Migrations
{
    public partial class CreateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Funcionario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "VARCHAR(80)", maxLength: 80, nullable: false),
                    CPF = table.Column<string>(type: "VARCHAR(80)", maxLength: 80, nullable: false),
                    Function = table.Column<string>(type: "VARCHAR(80)", maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Responsabilidade",
                columns: table => new
                {
                    RespId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "VARCHAR(80)", maxLength: 80, nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responsabilidade", x => x.RespId);
                });

            migrationBuilder.CreateTable(
                name: "Empres",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CEP = table.Column<string>(type: "VARCHAR(80)", maxLength: 80, nullable: false),
                    Company = table.Column<string>(type: "VARCHAR(80)", maxLength: 80, nullable: false),
                    FuncionariosId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empres", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Empresa_Funcionario",
                        column: x => x.FuncionariosId,
                        principalTable: "Funcionario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FuncionarioResponsabilidade",
                columns: table => new
                {
                    FuncionarioId = table.Column<int>(type: "int", nullable: false),
                    RespId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuncionarioResponsabilidade", x => new { x.FuncionarioId, x.RespId });
                    table.ForeignKey(
                        name: "FK_FuncionarioTag_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Responsabilidade_RespId",
                        column: x => x.RespId,
                        principalTable: "Responsabilidade",
                        principalColumn: "RespId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Empres_FuncionariosId",
                table: "Empres",
                column: "FuncionariosId");

            migrationBuilder.CreateIndex(
                name: "IX_FuncionarioResponsabilidade_RespId",
                table: "FuncionarioResponsabilidade",
                column: "RespId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Empres");

            migrationBuilder.DropTable(
                name: "FuncionarioResponsabilidade");

            migrationBuilder.DropTable(
                name: "Funcionario");

            migrationBuilder.DropTable(
                name: "Responsabilidade");
        }
    }
}
