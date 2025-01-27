using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace MapaDaForca.Data.Migrations
{
    public partial class addUserData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "150a4fe8-7313-435a-b877-ab0fb60cb587", "998e9695-2219-497d-a18b-1f53ac2c2262" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "320486cb-23e5-4b30-9a34-f522a2aa4fcb", "86ad17fe-f1c7-4420-922a-fcafdf301f9d" });

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3bc055c0-4c43-458f-97b4-699295bd52cb", "d725c4dd-e718-4f5e-8cd7-d4466fa11b67", "Administrador", "ADMINISTRADOR" },
                    { "19a1f2bd-28f2-4b6e-ae1f-859d6fc1f761", "db8a76e9-b70b-4255-affb-b90fb953fa2a", "Bombeiro", "BOMBEIRO" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DtInicio", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Nome", "NormalizedEmail", "NormalizedUserName", "NumeroMecanografico", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PostoId", "QuartelId", "SecurityStamp", "Turno", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1821ccc9-f5a2-4fcf-add0-86d75d5ad5dd", 0, "d279c4ba-1a64-4131-8d12-7c00bc681b28", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@gmail.com", true, false, null, "Admin", "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", 0, "AQAAAAEAACcQAAAAEKRRvOn4a/zVGAsKDbzKMYfXT4wZrQcfRcrkYvD+lMQTc4lvJ1/bW8d2nAW+PR+d5Q==", null, false, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), "209d27c0-b112-4267-873b-2d814afacf2a", 1, false, "admin@gmail.com" },
                    { "42025ddf-5721-4066-abc3-f813480f3c1f", 0, "e4a7638f-13b8-431f-800e-5c6693410e86", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "bombeiro@gmail.com", true, false, null, "Bombeiro0", "BOMBEIRO@GMAIL.COM", "BOMBEIRO@GMAIL.COM", 0, "AQAAAAEAACcQAAAAEPYMdnRntK5mrxTEIupg/db1aJhpjrjUAGxbLSVWBFrTxPbeNT/xL8ArQdy3K+ES/w==", null, false, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), "b7ed0c5c-3337-4f91-ae3d-0bda2722b539", 1, false, "bombeiro@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "1821ccc9-f5a2-4fcf-add0-86d75d5ad5dd", "3bc055c0-4c43-458f-97b4-699295bd52cb" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "42025ddf-5721-4066-abc3-f813480f3c1f", "19a1f2bd-28f2-4b6e-ae1f-859d6fc1f761" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "1821ccc9-f5a2-4fcf-add0-86d75d5ad5dd", "3bc055c0-4c43-458f-97b4-699295bd52cb" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "42025ddf-5721-4066-abc3-f813480f3c1f", "19a1f2bd-28f2-4b6e-ae1f-859d6fc1f761" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "19a1f2bd-28f2-4b6e-ae1f-859d6fc1f761", "db8a76e9-b70b-4255-affb-b90fb953fa2a" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "3bc055c0-4c43-458f-97b4-699295bd52cb", "d725c4dd-e718-4f5e-8cd7-d4466fa11b67" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "1821ccc9-f5a2-4fcf-add0-86d75d5ad5dd", "d279c4ba-1a64-4131-8d12-7c00bc681b28" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "42025ddf-5721-4066-abc3-f813480f3c1f", "e4a7638f-13b8-431f-800e-5c6693410e86" });

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "150a4fe8-7313-435a-b877-ab0fb60cb587", "998e9695-2219-497d-a18b-1f53ac2c2262", "Administrador", "ADMINISTRADOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "320486cb-23e5-4b30-9a34-f522a2aa4fcb", "86ad17fe-f1c7-4420-922a-fcafdf301f9d", "Bombeiro", "BOMBEIRO" });
        }
    }
}
