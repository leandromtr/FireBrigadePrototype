using Microsoft.EntityFrameworkCore.Migrations;

namespace MapaDaForca.Data.Migrations
{
    public partial class added_codigorsb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nome",
                table: "BombeiroFuncoes");

            migrationBuilder.AddColumn<string>(
                name: "CodigoRSB",
                table: "Viaturas",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CodigoRSB",
                table: "Viaturas");

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "BombeiroFuncoes",
                nullable: true);
        }
    }
}
