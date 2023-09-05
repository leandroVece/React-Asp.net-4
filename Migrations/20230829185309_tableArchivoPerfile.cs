using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cadeteria.Migrations
{
    public partial class tableArchivoPerfile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_archivo_articulo_ForeiKey",
                table: "archivo");

            migrationBuilder.RenameColumn(
                name: "ForeiKey",
                table: "archivo",
                newName: "articulolForeiKey");

            migrationBuilder.RenameIndex(
                name: "IX_archivo_ForeiKey",
                table: "archivo",
                newName: "IX_archivo_articulolForeiKey");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "archivo",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Foto",
                table: "archivo",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "archivoPerfil",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    perfilForeiKey = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Foto = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_archivoPerfil", x => x.Id);
                    table.ForeignKey(
                        name: "FK_archivoPerfil_perfil_perfilForeiKey",
                        column: x => x.perfilForeiKey,
                        principalTable: "perfil",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "usuario",
                keyColumn: "Id",
                keyValue: new Guid("07899a8d-bc7f-46d4-8d23-b174203f8bb0"),
                column: "password",
                value: "$2a$11$YmyXY1F4gh2174PholhDVu1069/n5u0HDWzwgh9ozmYt.138psCdu");

            migrationBuilder.UpdateData(
                table: "usuario",
                keyColumn: "Id",
                keyValue: new Guid("19ccc667-10c5-47b7-abd0-bae699c1cd3e"),
                column: "password",
                value: "$2a$11$8.Ib.2sBFqSdTRrNOqRkbOQxPVS0pp5HDsKHcfXQgPC5uILWxSr/6");

            migrationBuilder.UpdateData(
                table: "usuario",
                keyColumn: "Id",
                keyValue: new Guid("2d58f017-e038-4efa-acc1-f5f9e2d08668"),
                column: "password",
                value: "$2a$11$hlqqrNAUYg.Eu7N.3V9z5u1q.PO1MjDT2fJ44mL9SXQdnOFTSRyGG");

            migrationBuilder.UpdateData(
                table: "usuario",
                keyColumn: "Id",
                keyValue: new Guid("36126fee-fee7-4d62-a22e-959feb2dd013"),
                column: "password",
                value: "$2a$11$3mHKnLATEEr1FtF6qUEAeevei/DyUnKgKKz5oap5gECol8YBZDAla");

            migrationBuilder.UpdateData(
                table: "usuario",
                keyColumn: "Id",
                keyValue: new Guid("afaa31d8-013f-4dee-b21a-f9d03278d26a"),
                column: "password",
                value: "$2a$11$lBBdyChOPoJNhZS.Icc8/eX9.J/41U1LP/Drcjj41Qi5RwZe.IP3m");

            migrationBuilder.UpdateData(
                table: "usuario",
                keyColumn: "Id",
                keyValue: new Guid("c036633e-2b76-498b-9b82-cfbb4f6a95a8"),
                column: "password",
                value: "$2a$11$AdC3TV.5sTx84zEdPZ54l.XEwNcu9.xrxtMLP3De.uCkrhRXJiIFe");

            migrationBuilder.UpdateData(
                table: "usuario",
                keyColumn: "Id",
                keyValue: new Guid("c9d6ff8f-82ac-4eef-80df-de4999c4bb45"),
                column: "password",
                value: "$2a$11$VMZQIB/46P0p3YDtjwwfau1wAOg1NIXTv5GA0Rw.r9IhUNBYE8Wb.");

            migrationBuilder.UpdateData(
                table: "usuario",
                keyColumn: "Id",
                keyValue: new Guid("df0efb73-de14-4140-bbd0-c357148d89d1"),
                column: "password",
                value: "$2a$11$Hs/JCq/2cYw.9u/ke/ggYexEWWV4sllSG8LkZoaHRHU00raCodsAW");

            migrationBuilder.UpdateData(
                table: "usuario",
                keyColumn: "Id",
                keyValue: new Guid("e0bd0d60-7ff8-43a6-b78b-8dc67780c8c9"),
                column: "password",
                value: "$2a$11$4b2zA5n2t6Kw/zc9fogvouz.lTdX.PeVC23SSoOgiIUkG8RwiFWfa");

            migrationBuilder.UpdateData(
                table: "usuario",
                keyColumn: "Id",
                keyValue: new Guid("e2a4980f-7c50-45b0-aba5-6a46d79cf328"),
                column: "password",
                value: "$2a$11$y7soHPETFsMMOPlU1xPlWuci5eoqeEFGDS/tBuU5alPjcxhyxibnC");

            migrationBuilder.CreateIndex(
                name: "IX_archivoPerfil_perfilForeiKey",
                table: "archivoPerfil",
                column: "perfilForeiKey",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_archivo_articulo_articulolForeiKey",
                table: "archivo",
                column: "articulolForeiKey",
                principalTable: "articulo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_archivo_articulo_articulolForeiKey",
                table: "archivo");

            migrationBuilder.DropTable(
                name: "archivoPerfil");

            migrationBuilder.RenameColumn(
                name: "articulolForeiKey",
                table: "archivo",
                newName: "ForeiKey");

            migrationBuilder.RenameIndex(
                name: "IX_archivo_articulolForeiKey",
                table: "archivo",
                newName: "IX_archivo_ForeiKey");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "archivo",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Foto",
                table: "archivo",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.UpdateData(
                table: "usuario",
                keyColumn: "Id",
                keyValue: new Guid("07899a8d-bc7f-46d4-8d23-b174203f8bb0"),
                column: "password",
                value: "$2a$11$Nt0rMpNwEhyE2Ovhz2Q4BOSCotvFL4MmU4Zv/7WXchs0uoqyb7dKe");

            migrationBuilder.UpdateData(
                table: "usuario",
                keyColumn: "Id",
                keyValue: new Guid("19ccc667-10c5-47b7-abd0-bae699c1cd3e"),
                column: "password",
                value: "$2a$11$80EpBt84L4.ck0AC2zKQoOTKlOHlreI3UaAJ.atsimM3TAl7fX6Ku");

            migrationBuilder.UpdateData(
                table: "usuario",
                keyColumn: "Id",
                keyValue: new Guid("2d58f017-e038-4efa-acc1-f5f9e2d08668"),
                column: "password",
                value: "$2a$11$OB38ljzEt.d.fL5aYJVfCOzJ/FwQe0hMJC6bcfCyQz3wUo3DPo6j6");

            migrationBuilder.UpdateData(
                table: "usuario",
                keyColumn: "Id",
                keyValue: new Guid("36126fee-fee7-4d62-a22e-959feb2dd013"),
                column: "password",
                value: "$2a$11$LaRyYTHakjHt3.eK5TaTHOltMXx4jJ67QpOJb/WV0PimBDA5TBc2m");

            migrationBuilder.UpdateData(
                table: "usuario",
                keyColumn: "Id",
                keyValue: new Guid("afaa31d8-013f-4dee-b21a-f9d03278d26a"),
                column: "password",
                value: "$2a$11$FYZq4o5dZu9MolojmXSUgemH3f83SENMUgLdq.gNPAMayYFkRi9hS");

            migrationBuilder.UpdateData(
                table: "usuario",
                keyColumn: "Id",
                keyValue: new Guid("c036633e-2b76-498b-9b82-cfbb4f6a95a8"),
                column: "password",
                value: "$2a$11$75HuOfCuc1vy2XMDbQHxMeZXN8mxjzXkQg5a2vAPMSJdJXhVYhKkS");

            migrationBuilder.UpdateData(
                table: "usuario",
                keyColumn: "Id",
                keyValue: new Guid("c9d6ff8f-82ac-4eef-80df-de4999c4bb45"),
                column: "password",
                value: "$2a$11$61xNVK.jGfHK0fRn7UeinucGnfiVH.JMmPsosyvYMDthVS5RUK7pC");

            migrationBuilder.UpdateData(
                table: "usuario",
                keyColumn: "Id",
                keyValue: new Guid("df0efb73-de14-4140-bbd0-c357148d89d1"),
                column: "password",
                value: "$2a$11$WbbTh8ek2NGuzoOlHKnSHOrTCmoujKs3lyKz.ajWxeN5SQDQG34rm");

            migrationBuilder.UpdateData(
                table: "usuario",
                keyColumn: "Id",
                keyValue: new Guid("e0bd0d60-7ff8-43a6-b78b-8dc67780c8c9"),
                column: "password",
                value: "$2a$11$OF0tfeD9db3xSTIMBNAESehiMGmWIsp6/ST2OZ0YOM1WR0O5GmiAO");

            migrationBuilder.UpdateData(
                table: "usuario",
                keyColumn: "Id",
                keyValue: new Guid("e2a4980f-7c50-45b0-aba5-6a46d79cf328"),
                column: "password",
                value: "$2a$11$2.jxDaixFu2nYdZiO4saqOMhQ85YXj6WP8fxVMfk4EA4u/h.FjC3i");

            migrationBuilder.AddForeignKey(
                name: "FK_archivo_articulo_ForeiKey",
                table: "archivo",
                column: "ForeiKey",
                principalTable: "articulo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
