using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cadeteria.Migrations
{
    public partial class Initialparte4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "articulo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    stock = table.Column<int>(type: "int", nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_articulo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "categoria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categoria", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "historial",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    userForeingKey = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    profileForeingKey = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_historial", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "rol",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    rolName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rol", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "archivo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ForeiKey = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Foto = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_archivo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_archivo_articulo_ForeiKey",
                        column: x => x.ForeiKey,
                        principalTable: "articulo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "articuloCategoria",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    categoriaForeiKey = table.Column<int>(type: "int", nullable: false),
                    articuloForeiKey = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_articuloCategoria", x => x.Id);
                    table.ForeignKey(
                        name: "FK_articuloCategoria_articulo_articuloForeiKey",
                        column: x => x.articuloForeiKey,
                        principalTable: "articulo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_articuloCategoria_categoria_categoriaForeiKey",
                        column: x => x.categoriaForeiKey,
                        principalTable: "categoria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "usuario",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    rolForeikey = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    userName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    password = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_usuario_rol_rolForeikey",
                        column: x => x.rolForeikey,
                        principalTable: "rol",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "califiacacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userForeiKey = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    valor = table.Column<int>(type: "int", nullable: true, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_califiacacion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_califiacacion_usuario_userForeiKey",
                        column: x => x.userForeiKey,
                        principalTable: "usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "perfil",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    userForeiKey = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Referencia = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_perfil", x => x.id);
                    table.ForeignKey(
                        name: "FK_perfil_usuario_userForeiKey",
                        column: x => x.userForeiKey,
                        principalTable: "usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pedido",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClienteForeingKey = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Obs = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pedido", x => x.id);
                    table.ForeignKey(
                        name: "FK_pedido_perfil_ClienteForeingKey",
                        column: x => x.ClienteForeingKey,
                        principalTable: "perfil",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cadetePedido",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    userForeingKey = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    pedidoForeingKey = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cadetePedido", x => x.id);
                    table.ForeignKey(
                        name: "FK_cadetePedido_pedido_pedidoForeingKey",
                        column: x => x.pedidoForeingKey,
                        principalTable: "pedido",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_cadetePedido_usuario_userForeingKey",
                        column: x => x.userForeingKey,
                        principalTable: "usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "articulo",
                columns: new[] { "Id", "Name", "Price", "descripcion", "stock" },
                values: new object[,]
                {
                    { new Guid("0ac4774e-1616-464d-b827-99862f55ae7e"), "Micro razen 3200", 500m, null, 3 },
                    { new Guid("302eec33-3ec7-4664-9da4-32e98b3ee027"), "Celular Motorola", 1500m, null, 3 },
                    { new Guid("44de84e5-5a5a-4b07-a083-606c46a358ca"), "Monitor 25", 200m, null, 3 },
                    { new Guid("51d30e27-6782-473b-bf06-f0dff24d145f"), "Micro intel i3 9100", 500m, null, 3 },
                    { new Guid("646bec53-9328-40cf-9936-7ad0fd5c5983"), "Celular Sangsung", 2500m, null, 3 },
                    { new Guid("ae679e76-b7e3-45bc-8b97-d6dd8ef16200"), "Celular Shiaomi", 1200m, null, 3 },
                    { new Guid("bb55f434-2698-4d1f-98f8-2fccaa36bc21"), "Iphon", 1000m, null, 3 },
                    { new Guid("cf9ee397-bba1-4522-adb7-cb9ff5842499"), "Pc intel i3 9100 16GB ddr4", 1000m, null, 3 }
                });

            migrationBuilder.InsertData(
                table: "categoria",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Informatica" },
                    { 2, "Celular" }
                });

            migrationBuilder.InsertData(
                table: "rol",
                columns: new[] { "Id", "rolName" },
                values: new object[,]
                {
                    { new Guid("7a86db69-1474-4d92-a18e-91899d876c92"), "cadete" },
                    { new Guid("7aafd6fb-612e-42c7-99db-cbec0fdad96f"), "admin" },
                    { new Guid("c434c64a-5699-431e-8a88-a3ede659ba3d"), "provedor" },
                    { new Guid("f0601b48-a878-4fb5-a767-3f1340b8c0d8"), "cliente" }
                });

            migrationBuilder.InsertData(
                table: "articuloCategoria",
                columns: new[] { "Id", "articuloForeiKey", "categoriaForeiKey" },
                values: new object[,]
                {
                    { new Guid("2d4532c3-4282-4190-9817-80fc6b543652"), new Guid("cf9ee397-bba1-4522-adb7-cb9ff5842499"), 1 },
                    { new Guid("4e6eadcf-f982-43db-b8a4-641e426d564f"), new Guid("bb55f434-2698-4d1f-98f8-2fccaa36bc21"), 2 },
                    { new Guid("55d553ae-0e7f-4f65-aefd-86fbb6ba0c70"), new Guid("51d30e27-6782-473b-bf06-f0dff24d145f"), 1 },
                    { new Guid("94db418a-7c53-433a-b135-46b670ddc372"), new Guid("302eec33-3ec7-4664-9da4-32e98b3ee027"), 2 },
                    { new Guid("ba8a92c4-8a41-4b60-867e-c586ede13fde"), new Guid("44de84e5-5a5a-4b07-a083-606c46a358ca"), 1 },
                    { new Guid("daf9fde7-9e3e-4b61-ad3b-f342fa712e4c"), new Guid("646bec53-9328-40cf-9936-7ad0fd5c5983"), 2 },
                    { new Guid("f126372b-6855-4e24-bead-0843f5ce67a7"), new Guid("ae679e76-b7e3-45bc-8b97-d6dd8ef16200"), 2 },
                    { new Guid("fcb24de5-3374-4339-a7e3-64a155835da7"), new Guid("0ac4774e-1616-464d-b827-99862f55ae7e"), 1 }
                });

            migrationBuilder.InsertData(
                table: "usuario",
                columns: new[] { "Id", "password", "rolForeikey", "userName" },
                values: new object[,]
                {
                    { new Guid("07899a8d-bc7f-46d4-8d23-b174203f8bb0"), "$2a$11$Nt0rMpNwEhyE2Ovhz2Q4BOSCotvFL4MmU4Zv/7WXchs0uoqyb7dKe", new Guid("f0601b48-a878-4fb5-a767-3f1340b8c0d8"), "cliente02" },
                    { new Guid("19ccc667-10c5-47b7-abd0-bae699c1cd3e"), "$2a$11$80EpBt84L4.ck0AC2zKQoOTKlOHlreI3UaAJ.atsimM3TAl7fX6Ku", new Guid("f0601b48-a878-4fb5-a767-3f1340b8c0d8"), "cliente01" },
                    { new Guid("2d58f017-e038-4efa-acc1-f5f9e2d08668"), "$2a$11$OB38ljzEt.d.fL5aYJVfCOzJ/FwQe0hMJC6bcfCyQz3wUo3DPo6j6", new Guid("f0601b48-a878-4fb5-a767-3f1340b8c0d8"), "cliente03" },
                    { new Guid("36126fee-fee7-4d62-a22e-959feb2dd013"), "$2a$11$LaRyYTHakjHt3.eK5TaTHOltMXx4jJ67QpOJb/WV0PimBDA5TBc2m", new Guid("f0601b48-a878-4fb5-a767-3f1340b8c0d8"), "cliente" },
                    { new Guid("afaa31d8-013f-4dee-b21a-f9d03278d26a"), "$2a$11$FYZq4o5dZu9MolojmXSUgemH3f83SENMUgLdq.gNPAMayYFkRi9hS", new Guid("f0601b48-a878-4fb5-a767-3f1340b8c0d8"), "cliente2" },
                    { new Guid("c036633e-2b76-498b-9b82-cfbb4f6a95a8"), "$2a$11$75HuOfCuc1vy2XMDbQHxMeZXN8mxjzXkQg5a2vAPMSJdJXhVYhKkS", new Guid("c434c64a-5699-431e-8a88-a3ede659ba3d"), "proveedor" },
                    { new Guid("c9d6ff8f-82ac-4eef-80df-de4999c4bb45"), "$2a$11$61xNVK.jGfHK0fRn7UeinucGnfiVH.JMmPsosyvYMDthVS5RUK7pC", new Guid("f0601b48-a878-4fb5-a767-3f1340b8c0d8"), "cliente3" },
                    { new Guid("df0efb73-de14-4140-bbd0-c357148d89d1"), "$2a$11$WbbTh8ek2NGuzoOlHKnSHOrTCmoujKs3lyKz.ajWxeN5SQDQG34rm", new Guid("7a86db69-1474-4d92-a18e-91899d876c92"), "cadete" },
                    { new Guid("e0bd0d60-7ff8-43a6-b78b-8dc67780c8c9"), "$2a$11$OF0tfeD9db3xSTIMBNAESehiMGmWIsp6/ST2OZ0YOM1WR0O5GmiAO", new Guid("f0601b48-a878-4fb5-a767-3f1340b8c0d8"), "cadete2" },
                    { new Guid("e2a4980f-7c50-45b0-aba5-6a46d79cf328"), "$2a$11$2.jxDaixFu2nYdZiO4saqOMhQ85YXj6WP8fxVMfk4EA4u/h.FjC3i", new Guid("7aafd6fb-612e-42c7-99db-cbec0fdad96f"), "admin" }
                });

            migrationBuilder.InsertData(
                table: "perfil",
                columns: new[] { "id", "Direccion", "Nombre", "Referencia", "Telefono", "userForeiKey" },
                values: new object[,]
                {
                    { new Guid("0a9fa564-0604-4dfa-88df-3636fe395651"), "independencia", "Ana Hume", null, "231321231", new Guid("2d58f017-e038-4efa-acc1-f5f9e2d08668") },
                    { new Guid("0a9fa564-0604-4dfa-88df-3636fe395678"), "independencia", "Fer Hume", null, "654321", new Guid("07899a8d-bc7f-46d4-8d23-b174203f8bb0") },
                    { new Guid("2544db67-7dd3-4a16-99ec-7f1451c00558"), "independencia", "Fer Nanda", null, "654321", new Guid("c9d6ff8f-82ac-4eef-80df-de4999c4bb45") },
                    { new Guid("4978a844-a5d3-4d32-86e9-7046eefddea2"), "Entre rios", "Jaun Antonio", null, "231321231", new Guid("19ccc667-10c5-47b7-abd0-bae699c1cd3e") },
                    { new Guid("7b5e9399-8e95-4ae8-8745-9542a01e2cc0"), "Entre rios", "Jaun Castellanos", null, "231321231", new Guid("e0bd0d60-7ff8-43a6-b78b-8dc67780c8c9") },
                    { new Guid("910381a0-3a65-4ab9-9929-44faca09b567"), "cordoba", "Chichu Han", null, "654321", new Guid("df0efb73-de14-4140-bbd0-c357148d89d1") },
                    { new Guid("a8bc0306-f0d1-46bb-b2b4-44104bb0e017"), "independencia y alem", "Tu unico Proveedor", null, "3812342", new Guid("c036633e-2b76-498b-9b82-cfbb4f6a95a8") },
                    { new Guid("b140ee23-f61b-45a7-8ef0-177d5c76a317"), "italia", "Jessy Jade", null, "654321", new Guid("e2a4980f-7c50-45b0-aba5-6a46d79cf328") },
                    { new Guid("e04a530d-f4bb-4ff1-898f-b3c00160dc28"), "corrientes", "Pancho Estrada", null, "654321", new Guid("36126fee-fee7-4d62-a22e-959feb2dd013") },
                    { new Guid("e41d99f0-2afd-4c25-b677-514bcf897f6b"), "independencia", "Ana Pradera", null, "231321231", new Guid("afaa31d8-013f-4dee-b21a-f9d03278d26a") }
                });

            migrationBuilder.InsertData(
                table: "pedido",
                columns: new[] { "id", "ClienteForeingKey", "Estado", "Obs" },
                values: new object[] { new Guid("adc4aba6-b2b6-4ca6-a715-e563987fd02e"), new Guid("0a9fa564-0604-4dfa-88df-3636fe395678"), "Pendiente", "Coca" });

            migrationBuilder.CreateIndex(
                name: "IX_archivo_ForeiKey",
                table: "archivo",
                column: "ForeiKey");

            migrationBuilder.CreateIndex(
                name: "IX_articuloCategoria_articuloForeiKey",
                table: "articuloCategoria",
                column: "articuloForeiKey");

            migrationBuilder.CreateIndex(
                name: "IX_articuloCategoria_categoriaForeiKey",
                table: "articuloCategoria",
                column: "categoriaForeiKey");

            migrationBuilder.CreateIndex(
                name: "IX_cadetePedido_pedidoForeingKey",
                table: "cadetePedido",
                column: "pedidoForeingKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_cadetePedido_userForeingKey",
                table: "cadetePedido",
                column: "userForeingKey");

            migrationBuilder.CreateIndex(
                name: "IX_califiacacion_userForeiKey",
                table: "califiacacion",
                column: "userForeiKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_categoria_Name",
                table: "categoria",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_pedido_ClienteForeingKey",
                table: "pedido",
                column: "ClienteForeingKey");

            migrationBuilder.CreateIndex(
                name: "IX_perfil_userForeiKey",
                table: "perfil",
                column: "userForeiKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_usuario_rolForeikey",
                table: "usuario",
                column: "rolForeikey");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "archivo");

            migrationBuilder.DropTable(
                name: "articuloCategoria");

            migrationBuilder.DropTable(
                name: "cadetePedido");

            migrationBuilder.DropTable(
                name: "califiacacion");

            migrationBuilder.DropTable(
                name: "historial");

            migrationBuilder.DropTable(
                name: "articulo");

            migrationBuilder.DropTable(
                name: "categoria");

            migrationBuilder.DropTable(
                name: "pedido");

            migrationBuilder.DropTable(
                name: "perfil");

            migrationBuilder.DropTable(
                name: "usuario");

            migrationBuilder.DropTable(
                name: "rol");
        }
    }
}
