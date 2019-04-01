using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MapaDaForca.Data.Migrations
{
    public partial class renamed_classes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetalheTipos");

            migrationBuilder.DropTable(
                name: "TipoEscalas");

            migrationBuilder.DropTable(
                name: "TipoViaturaFuncoes");

            migrationBuilder.DropTable(
                name: "TipoViaturas");

            migrationBuilder.RenameColumn(
                name: "TipoEscalaId",
                table: "Escalas",
                newName: "EscalaTipoId");

            migrationBuilder.CreateTable(
                name: "EscalaTipoDetalhes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EscalaTipoDetalhes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EscalaTipos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    EscalaTipoDetalheId = table.Column<Guid>(nullable: false),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EscalaTipos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ViaturaTipoFuncoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ViaturaTipoId = table.Column<Guid>(nullable: false),
                    FuncaoId = table.Column<Guid>(nullable: false),
                    Quantidade = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ViaturaTipoFuncoes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ViaturaTipos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Sigla = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ViaturaTipos", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EscalaTipoDetalhes");

            migrationBuilder.DropTable(
                name: "EscalaTipos");

            migrationBuilder.DropTable(
                name: "ViaturaTipoFuncoes");

            migrationBuilder.DropTable(
                name: "ViaturaTipos");

            migrationBuilder.RenameColumn(
                name: "EscalaTipoId",
                table: "Escalas",
                newName: "TipoEscalaId");

            migrationBuilder.CreateTable(
                name: "DetalheTipos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalheTipos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoEscalas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Descricao = table.Column<string>(nullable: true),
                    DetalheTipoId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoEscalas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoViaturaFuncoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FuncaoId = table.Column<Guid>(nullable: false),
                    Quantidade = table.Column<int>(nullable: false),
                    TipoViaturaId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoViaturaFuncoes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoViaturas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Descricao = table.Column<string>(nullable: true),
                    Sigla = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoViaturas", x => x.Id);
                });
        }
    }
}
