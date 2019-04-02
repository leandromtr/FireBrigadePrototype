using Microsoft.EntityFrameworkCore.Migrations;

namespace MapaDaForca.Data.Migrations
{
    public partial class viaturaTipo_field_renamed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TipoViaturaId",
                table: "Viaturas",
                newName: "ViaturaTipoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ViaturaTipoId",
                table: "Viaturas",
                newName: "TipoViaturaId");
        }
    }
}
