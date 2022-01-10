using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Libraries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Publisher = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libraries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permisos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permisos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PermisosRols",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdRole = table.Column<int>(type: "int", nullable: false),
                    IdPermiso = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermisosRols", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PermisosRols_Permisos_IdPermiso",
                        column: x => x.IdPermiso,
                        principalTable: "Permisos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PermisosRols_Roles_IdRole",
                        column: x => x.IdRole,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsersRols",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUser = table.Column<int>(type: "int", nullable: false),
                    IdRole = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersRols", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsersRols_Roles_IdRole",
                        column: x => x.IdRole,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersRols_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Libraries",
                columns: new[] { "Id", "Author", "FechaCreacion", "FechaModificacion", "Genre", "Price", "Publisher", "Title" },
                values: new object[,]
                {
                    { 1, "Robin Sharma", new DateTime(2022, 1, 9, 18, 27, 37, 873, DateTimeKind.Local).AddTicks(132), new DateTime(2022, 1, 9, 18, 27, 37, 873, DateTimeKind.Local).AddTicks(149), "Fiction", 141m, "Jaiko Publishing House", "The Monk Who Sold His Ferrari" },
                    { 2, "Stephen W Hawking", new DateTime(2022, 1, 9, 18, 27, 37, 873, DateTimeKind.Local).AddTicks(164), new DateTime(2022, 1, 9, 18, 27, 37, 873, DateTimeKind.Local).AddTicks(165), "Engineering & Technology", 149m, "Jaiko Publishing House", "The Theory Of Everything" },
                    { 3, "Robert T. Kiyosaki", new DateTime(2022, 1, 9, 18, 27, 37, 873, DateTimeKind.Local).AddTicks(168), new DateTime(2022, 1, 9, 18, 27, 37, 873, DateTimeKind.Local).AddTicks(169), "Personal Finance", 288m, "Plata Publishing", "Rich Dad Poor Dad" }
                });

            migrationBuilder.InsertData(
                table: "Permisos",
                columns: new[] { "Id", "Descripcion", "FechaCreacion", "FechaModificacion", "Nombre" },
                values: new object[,]
                {
                    { 1, "Permiso para guardar libros", new DateTime(2022, 1, 9, 18, 27, 37, 882, DateTimeKind.Local).AddTicks(2451), new DateTime(2022, 1, 9, 18, 27, 37, 882, DateTimeKind.Local).AddTicks(2452), "GuardarLibro" },
                    { 2, "Permiso para Buscar Libros", new DateTime(2022, 1, 9, 18, 27, 37, 882, DateTimeKind.Local).AddTicks(2460), new DateTime(2022, 1, 9, 18, 27, 37, 882, DateTimeKind.Local).AddTicks(2461), "BuscarLibro" },
                    { 3, "Permiso para Actualizar Libros", new DateTime(2022, 1, 9, 18, 27, 37, 882, DateTimeKind.Local).AddTicks(2463), new DateTime(2022, 1, 9, 18, 27, 37, 882, DateTimeKind.Local).AddTicks(2464), "ActualizarLibro" },
                    { 4, "Permiso para Eliminar Libros", new DateTime(2022, 1, 9, 18, 27, 37, 882, DateTimeKind.Local).AddTicks(2467), new DateTime(2022, 1, 9, 18, 27, 37, 882, DateTimeKind.Local).AddTicks(2468), "EliminarLibro" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Descripcion", "FechaCreacion", "FechaModificacion", "Nombre" },
                values: new object[] { 1, "Rol con privilegios", new DateTime(2022, 1, 9, 18, 27, 37, 882, DateTimeKind.Local).AddTicks(2272), new DateTime(2022, 1, 9, 18, 27, 37, 882, DateTimeKind.Local).AddTicks(2286), "Administrador" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Apellidos", "Correo", "FechaCreacion", "FechaModificacion", "Hash", "Nombres" },
                values: new object[] { 1, "Vega", "Admin@gmail.com", new DateTime(2022, 1, 9, 18, 27, 37, 873, DateTimeKind.Local).AddTicks(215), new DateTime(2022, 1, 9, 18, 27, 37, 873, DateTimeKind.Local).AddTicks(216), "$MYHASH$V1$10000$B1i0fXTXROH0Prv3+53pRytaCz/kVaZkpdV/ZmU+HmJ4Kwzo", "Fernando" });

            migrationBuilder.InsertData(
                table: "PermisosRols",
                columns: new[] { "Id", "FechaCreacion", "FechaModificacion", "IdPermiso", "IdRole" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 1, 9, 18, 27, 37, 882, DateTimeKind.Local).AddTicks(2505), new DateTime(2022, 1, 9, 18, 27, 37, 882, DateTimeKind.Local).AddTicks(2506), 1, 1 },
                    { 2, new DateTime(2022, 1, 9, 18, 27, 37, 882, DateTimeKind.Local).AddTicks(2511), new DateTime(2022, 1, 9, 18, 27, 37, 882, DateTimeKind.Local).AddTicks(2512), 2, 1 },
                    { 3, new DateTime(2022, 1, 9, 18, 27, 37, 882, DateTimeKind.Local).AddTicks(2514), new DateTime(2022, 1, 9, 18, 27, 37, 882, DateTimeKind.Local).AddTicks(2515), 3, 1 },
                    { 4, new DateTime(2022, 1, 9, 18, 27, 37, 882, DateTimeKind.Local).AddTicks(2517), new DateTime(2022, 1, 9, 18, 27, 37, 882, DateTimeKind.Local).AddTicks(2518), 4, 1 }
                });

            migrationBuilder.InsertData(
                table: "UsersRols",
                columns: new[] { "Id", "FechaCreacion", "FechaModificacion", "IdRole", "IdUser" },
                values: new object[] { 1, new DateTime(2022, 1, 9, 18, 27, 37, 882, DateTimeKind.Local).AddTicks(2559), new DateTime(2022, 1, 9, 18, 27, 37, 882, DateTimeKind.Local).AddTicks(2560), 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_PermisosRols_IdPermiso",
                table: "PermisosRols",
                column: "IdPermiso");

            migrationBuilder.CreateIndex(
                name: "IX_PermisosRols_IdRole",
                table: "PermisosRols",
                column: "IdRole");

            migrationBuilder.CreateIndex(
                name: "IX_UsersRols_IdRole",
                table: "UsersRols",
                column: "IdRole");

            migrationBuilder.CreateIndex(
                name: "IX_UsersRols_IdUser",
                table: "UsersRols",
                column: "IdUser");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Libraries");

            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropTable(
                name: "PermisosRols");

            migrationBuilder.DropTable(
                name: "UsersRols");

            migrationBuilder.DropTable(
                name: "Permisos");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
