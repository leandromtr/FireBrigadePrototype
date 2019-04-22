using Microsoft.EntityFrameworkCore.Migrations;

namespace MapaDaForca.Data.Migrations
{
    public partial class added_numeromecanografico : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumeroMecanografico",
                table: "Bombeiros",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumeroMecanografico",
                table: "Bombeiros");
        }
    }
}
