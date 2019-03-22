using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MapaDaForca.Data.Migrations
{
    public partial class FirstCommit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Batalhoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Batalhoes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BombeiroFuncoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdBombeiro = table.Column<Guid>(nullable: false),
                    IdFuncao = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    FuncaoPrincipal = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BombeiroFuncoes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bombeiros",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    DtInicio = table.Column<DateTime>(nullable: false),
                    IdPosto = table.Column<Guid>(nullable: false),
                    IdQuartel = table.Column<Guid>(nullable: false),
                    Turno = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bombeiros", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Companhias",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdBatalhao = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companhias", x => x.Id);
                });

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
                name: "Escalas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdBombeiro = table.Column<Guid>(nullable: false),
                    IdFuncao = table.Column<Guid>(nullable: false),
                    IdQuartel = table.Column<Guid>(nullable: false),
                    IdTipoEscala = table.Column<Guid>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false),
                    Periodo1 = table.Column<bool>(nullable: false),
                    PrioridadeFerias = table.Column<int>(nullable: false),
                    AprovadoPor = table.Column<Guid>(nullable: false),
                    AprovadoEm = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Escalas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EscalaTurnos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Turno = table.Column<int>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false),
                    Periodo1 = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EscalaTurnos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Funcoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcoes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    IdBatalhao = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Postos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Postos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Quarteis",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdCompanhia = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Portao = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quarteis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QuartelViaturaCondicoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdQuartelViatura = table.Column<Guid>(nullable: false),
                    IdViatura = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuartelViaturaCondicoes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QuartelViaturas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdQuartel = table.Column<Guid>(nullable: false),
                    IdViatura = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuartelViaturas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoEscalas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdDetalheTipo = table.Column<Guid>(nullable: false),
                    Descricao = table.Column<string>(nullable: true)
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
                    IdTipoViatura = table.Column<Guid>(nullable: false),
                    IdFuncao = table.Column<Guid>(nullable: false),
                    Quantidade = table.Column<int>(nullable: false)
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
                    Sigla = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoViaturas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Viaturas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdTipoViatura = table.Column<Guid>(nullable: false),
                    Operacional = table.Column<bool>(nullable: false),
                    Matricula = table.Column<string>(nullable: true),
                    Ano = table.Column<int>(nullable: false),
                    DataInicioUso = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Viaturas", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Batalhoes");

            migrationBuilder.DropTable(
                name: "BombeiroFuncoes");

            migrationBuilder.DropTable(
                name: "Bombeiros");

            migrationBuilder.DropTable(
                name: "Companhias");

            migrationBuilder.DropTable(
                name: "DetalheTipos");

            migrationBuilder.DropTable(
                name: "Escalas");

            migrationBuilder.DropTable(
                name: "EscalaTurnos");

            migrationBuilder.DropTable(
                name: "Funcoes");

            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropTable(
                name: "Postos");

            migrationBuilder.DropTable(
                name: "Quarteis");

            migrationBuilder.DropTable(
                name: "QuartelViaturaCondicoes");

            migrationBuilder.DropTable(
                name: "QuartelViaturas");

            migrationBuilder.DropTable(
                name: "TipoEscalas");

            migrationBuilder.DropTable(
                name: "TipoViaturaFuncoes");

            migrationBuilder.DropTable(
                name: "TipoViaturas");

            migrationBuilder.DropTable(
                name: "Viaturas");
        }
    }
}
