using Microsoft.EntityFrameworkCore.Migrations;

namespace MapaDaForca.Data.Migrations
{
    public partial class reanamed_periodo_of_Escalaturno : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Periodo1",
                table: "EscalaTurnos",
                newName: "PeriodoDiurno");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PeriodoDiurno",
                table: "EscalaTurnos",
                newName: "Periodo1");
        }
    }
}
