using System;
using Microsoft.EntityFrameworkCore.Migrations;

public partial class InitialCreate : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        // Tabela Filiais
        migrationBuilder.CreateTable(
            name: "Filiais",
            columns: table => new
            {
                Id = table.Column<int>(nullable: false)
                      .Annotation("Sqlite:Autoincrement", true),
                Nome = table.Column<string>(nullable: false),
                Endereco = table.Column<string>(nullable: false),
                CustoOperacional = table.Column<decimal>(nullable: false),
                Faturamento = table.Column<decimal>(nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Filiais", x => x.Id);
            });

        // Tabela Setores
        migrationBuilder.CreateTable(
            name: "Setores",
            columns: table => new
            {
                Id = table.Column<int>(nullable: false)
                      .Annotation("Sqlite:Autoincrement", true),
                Nome = table.Column<string>(nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Setores", x => x.Id);
            });

        // Tabela Funcionarios
        migrationBuilder.CreateTable(
            name: "Funcionarios",
            columns: table => new
            {
                Id = table.Column<int>(nullable: false)
                      .Annotation("Sqlite:Autoincrement", true),
                Nome = table.Column<string>(nullable: false),
                Sexo = table.Column<string>(nullable: false),
                UsuarioId = table.Column<string>(nullable: false),
                DataAniversario = table.Column<DateTime>(nullable: false),
                Salario = table.Column<decimal>(nullable: false),
                DiasTrabalhados = table.Column<int>(nullable: false),
                FaltasNaoJustificadas = table.Column<int>(nullable: false),
                NivelAcesso = table.Column<string>(nullable: false),
                FilialId = table.Column<int>(nullable: false),
                SetorId = table.Column<int>(nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Funcionarios", x => x.Id);
                table.ForeignKey(
                    name: "FK_Funcionarios_Filiais_FilialId",
                    column: x => x.FilialId,
                    principalTable: "Filiais",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_Funcionarios_Setores_SetorId",
                    column: x => x.SetorId,
                    principalTable: "Setores",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        // Índices para as chaves estrangeiras
        migrationBuilder.CreateIndex(
            name: "IX_Funcionarios_FilialId",
            table: "Funcionarios",
            column: "FilialId");

        migrationBuilder.CreateIndex(
            name: "IX_Funcionarios_SetorId",
            table: "Funcionarios",
            column: "SetorId");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(name: "Funcionarios");
        migrationBuilder.DropTable(name: "Filiais");
        migrationBuilder.DropTable(name: "Setores");
    }
}
