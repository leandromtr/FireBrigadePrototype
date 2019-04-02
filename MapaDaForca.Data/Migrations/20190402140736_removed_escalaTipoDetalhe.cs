using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MapaDaForca.Data.Migrations
{
    public partial class removed_escalaTipoDetalhe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EscalaTipoDetalhes");

            migrationBuilder.DropColumn(
                name: "EscalaTipoDetalheId",
                table: "EscalaTipos");

            migrationBuilder.AddColumn<int>(
                name: "EscalaTipoDetalhe",
                table: "EscalaTipos",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EscalaTipoDetalhe",
                table: "EscalaTipos");

            migrationBuilder.AddColumn<Guid>(
                name: "EscalaTipoDetalheId",
                table: "EscalaTipos",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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
        }
    }
}
