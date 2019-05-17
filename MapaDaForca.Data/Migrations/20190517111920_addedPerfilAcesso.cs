using Microsoft.EntityFrameworkCore.Migrations;

namespace MapaDaForca.Data.Migrations
{
    public partial class addedPerfilAcesso : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "150a4fe8-7313-435a-b877-ab0fb60cb587", "998e9695-2219-497d-a18b-1f53ac2c2262", "Administrador", "ADMINISTRADOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "320486cb-23e5-4b30-9a34-f522a2aa4fcb", "86ad17fe-f1c7-4420-922a-fcafdf301f9d", "Bombeiro", "BOMBEIRO" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "150a4fe8-7313-435a-b877-ab0fb60cb587", "998e9695-2219-497d-a18b-1f53ac2c2262" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "320486cb-23e5-4b30-9a34-f522a2aa4fcb", "86ad17fe-f1c7-4420-922a-fcafdf301f9d" });
        }
    }
}
