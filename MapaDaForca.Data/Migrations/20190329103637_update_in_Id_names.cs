using Microsoft.EntityFrameworkCore.Migrations;

namespace MapaDaForca.Data.Migrations
{
    public partial class update_in_Id_names : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdTipoViatura",
                table: "Viaturas",
                newName: "TipoViaturaId");

            migrationBuilder.RenameColumn(
                name: "IdTipoViatura",
                table: "TipoViaturaFuncoes",
                newName: "TipoViaturaId");

            migrationBuilder.RenameColumn(
                name: "IdFuncao",
                table: "TipoViaturaFuncoes",
                newName: "FuncaoId");

            migrationBuilder.RenameColumn(
                name: "IdDetalheTipo",
                table: "TipoEscalas",
                newName: "DetalheTipoId");

            migrationBuilder.RenameColumn(
                name: "IdViatura",
                table: "QuartelViaturas",
                newName: "ViaturaId");

            migrationBuilder.RenameColumn(
                name: "IdQuartel",
                table: "QuartelViaturas",
                newName: "QuartelId");

            migrationBuilder.RenameColumn(
                name: "IdViatura",
                table: "QuartelViaturaCondicoes",
                newName: "ViaturaId");

            migrationBuilder.RenameColumn(
                name: "IdQuartelViatura",
                table: "QuartelViaturaCondicoes",
                newName: "QuartelViaturaId");

            migrationBuilder.RenameColumn(
                name: "IdCompanhia",
                table: "Quarteis",
                newName: "CompanhiaId");

            migrationBuilder.RenameColumn(
                name: "IdBatalhao",
                table: "Logs",
                newName: "BatalhaoId");

            migrationBuilder.RenameColumn(
                name: "IdTipoEscala",
                table: "Escalas",
                newName: "TipoEscalaId");

            migrationBuilder.RenameColumn(
                name: "IdQuartel",
                table: "Escalas",
                newName: "QuartelId");

            migrationBuilder.RenameColumn(
                name: "IdFuncao",
                table: "Escalas",
                newName: "FuncaoId");

            migrationBuilder.RenameColumn(
                name: "IdBombeiro",
                table: "Escalas",
                newName: "BombeiroId");

            migrationBuilder.RenameColumn(
                name: "IdBatalhao",
                table: "Companhias",
                newName: "BatalhaoId");

            migrationBuilder.RenameColumn(
                name: "IdQuartel",
                table: "Bombeiros",
                newName: "QuartelId");

            migrationBuilder.RenameColumn(
                name: "IdPosto",
                table: "Bombeiros",
                newName: "PostoId");

            migrationBuilder.RenameColumn(
                name: "IdFuncao",
                table: "BombeiroFuncoes",
                newName: "FuncaoId");

            migrationBuilder.RenameColumn(
                name: "IdBombeiro",
                table: "BombeiroFuncoes",
                newName: "BombeiroId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TipoViaturaId",
                table: "Viaturas",
                newName: "IdTipoViatura");

            migrationBuilder.RenameColumn(
                name: "TipoViaturaId",
                table: "TipoViaturaFuncoes",
                newName: "IdTipoViatura");

            migrationBuilder.RenameColumn(
                name: "FuncaoId",
                table: "TipoViaturaFuncoes",
                newName: "IdFuncao");

            migrationBuilder.RenameColumn(
                name: "DetalheTipoId",
                table: "TipoEscalas",
                newName: "IdDetalheTipo");

            migrationBuilder.RenameColumn(
                name: "ViaturaId",
                table: "QuartelViaturas",
                newName: "IdViatura");

            migrationBuilder.RenameColumn(
                name: "QuartelId",
                table: "QuartelViaturas",
                newName: "IdQuartel");

            migrationBuilder.RenameColumn(
                name: "ViaturaId",
                table: "QuartelViaturaCondicoes",
                newName: "IdViatura");

            migrationBuilder.RenameColumn(
                name: "QuartelViaturaId",
                table: "QuartelViaturaCondicoes",
                newName: "IdQuartelViatura");

            migrationBuilder.RenameColumn(
                name: "CompanhiaId",
                table: "Quarteis",
                newName: "IdCompanhia");

            migrationBuilder.RenameColumn(
                name: "BatalhaoId",
                table: "Logs",
                newName: "IdBatalhao");

            migrationBuilder.RenameColumn(
                name: "TipoEscalaId",
                table: "Escalas",
                newName: "IdTipoEscala");

            migrationBuilder.RenameColumn(
                name: "QuartelId",
                table: "Escalas",
                newName: "IdQuartel");

            migrationBuilder.RenameColumn(
                name: "FuncaoId",
                table: "Escalas",
                newName: "IdFuncao");

            migrationBuilder.RenameColumn(
                name: "BombeiroId",
                table: "Escalas",
                newName: "IdBombeiro");

            migrationBuilder.RenameColumn(
                name: "BatalhaoId",
                table: "Companhias",
                newName: "IdBatalhao");

            migrationBuilder.RenameColumn(
                name: "QuartelId",
                table: "Bombeiros",
                newName: "IdQuartel");

            migrationBuilder.RenameColumn(
                name: "PostoId",
                table: "Bombeiros",
                newName: "IdPosto");

            migrationBuilder.RenameColumn(
                name: "FuncaoId",
                table: "BombeiroFuncoes",
                newName: "IdFuncao");

            migrationBuilder.RenameColumn(
                name: "BombeiroId",
                table: "BombeiroFuncoes",
                newName: "IdBombeiro");
        }
    }
}
