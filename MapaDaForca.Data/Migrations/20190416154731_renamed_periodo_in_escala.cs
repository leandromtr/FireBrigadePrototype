using Microsoft.EntityFrameworkCore.Migrations;

namespace MapaDaForca.Data.Migrations
{
    public partial class renamed_periodo_in_escala : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Periodo1",
                table: "Escalas",
                newName: "PeriodoDiurno");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PeriodoDiurno",
                table: "Escalas",
                newName: "Periodo1");
        }
    }
}
