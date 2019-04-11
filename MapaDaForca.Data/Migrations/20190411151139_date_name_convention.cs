using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MapaDaForca.Data.Migrations
{
    public partial class date_name_convention : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Data",
                table: "EscalaTurnos",
                newName: "DtEscalaTurno");

            migrationBuilder.RenameColumn(
                name: "Data",
                table: "Escalas",
                newName: "DtEscala");

            migrationBuilder.AddColumn<DateTime>(
                name: "DtLog",
                table: "Logs",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DtLog",
                table: "Logs");

            migrationBuilder.RenameColumn(
                name: "DtEscalaTurno",
                table: "EscalaTurnos",
                newName: "Data");

            migrationBuilder.RenameColumn(
                name: "DtEscala",
                table: "Escalas",
                newName: "Data");
        }
    }
}
