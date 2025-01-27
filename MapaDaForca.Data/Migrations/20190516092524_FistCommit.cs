using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace MapaDaForca.Data.Migrations
{
    public partial class FistCommit : Migration
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
                    BombeiroId = table.Column<Guid>(nullable: false),
                    FuncaoId = table.Column<Guid>(nullable: false),
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
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    NumeroMecanografico = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    DtInicio = table.Column<DateTime>(nullable: false),
                    PostoId = table.Column<Guid>(nullable: false),
                    QuartelId = table.Column<Guid>(nullable: false),
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
                    BatalhaoId = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companhias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Escalas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    BombeiroId = table.Column<Guid>(nullable: false),
                    FuncaoId = table.Column<Guid>(nullable: false),
                    QuartelId = table.Column<Guid>(nullable: false),
                    EscalaTipoId = table.Column<Guid>(nullable: false),
                    DtEscala = table.Column<DateTime>(nullable: false),
                    PeriodoDiurno = table.Column<bool>(nullable: false),
                    PrioridadeFerias = table.Column<int>(nullable: false),
                    AprovadoPor = table.Column<Guid>(nullable: false),
                    AprovadoEm = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Escalas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EscalaTipos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    EscalaTipoDetalhe = table.Column<int>(nullable: false),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EscalaTipos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EscalaTurnos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Turno = table.Column<int>(nullable: false),
                    DtEscalaTurno = table.Column<DateTime>(nullable: false),
                    PeriodoDiurno = table.Column<bool>(nullable: false)
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
                    BatalhaoId = table.Column<Guid>(nullable: false),
                    DtLog = table.Column<DateTime>(nullable: false)
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
                    CompanhiaId = table.Column<Guid>(nullable: false),
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
                    QuartelViaturaId = table.Column<Guid>(nullable: false),
                    ViaturaId = table.Column<Guid>(nullable: false)
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
                    QuartelId = table.Column<Guid>(nullable: false),
                    ViaturaId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuartelViaturas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Viaturas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ViaturaTipoId = table.Column<Guid>(nullable: false),
                    CodigoRSB = table.Column<string>(nullable: true),
                    Operacional = table.Column<bool>(nullable: false),
                    Matricula = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Viaturas", x => x.Id);
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
                name: "Batalhoes");

            migrationBuilder.DropTable(
                name: "BombeiroFuncoes");

            migrationBuilder.DropTable(
                name: "Bombeiros");

            migrationBuilder.DropTable(
                name: "Companhias");

            migrationBuilder.DropTable(
                name: "Escalas");

            migrationBuilder.DropTable(
                name: "EscalaTipos");

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
                name: "Viaturas");

            migrationBuilder.DropTable(
                name: "ViaturaTipoFuncoes");

            migrationBuilder.DropTable(
                name: "ViaturaTipos");
        }
    }
}
