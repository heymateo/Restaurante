using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class JMIGRACION1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Administrador",
                columns: table => new
                {
                    Id_Administrador = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contrasena = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrador", x => x.Id_Administrador);
                });

            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    Id_Categoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.Id_Categoria);
                });

            migrationBuilder.CreateTable(
                name: "Chef",
                columns: table => new
                {
                    Id_Chef = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contrasena = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chef", x => x.Id_Chef);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id_Cliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id_Cliente);
                });

            migrationBuilder.CreateTable(
                name: "Empleado",
                columns: table => new
                {
                    Id_Empleado = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contrasena = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleado", x => x.Id_Empleado);
                });

            migrationBuilder.CreateTable(
                name: "Mesa",
                columns: table => new
                {
                    Id_Mesa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero_Mesa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Disponible = table.Column<bool>(type: "bit", nullable: false),
                    Activa = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mesa", x => x.Id_Mesa);
                });

            migrationBuilder.CreateTable(
                name: "Bebida",
                columns: table => new
                {
                    Id_Bebida = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Precio = table.Column<int>(type: "int", precision: 7, scale: 2, nullable: false),
                    Id_Categoria = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bebida", x => x.Id_Bebida);
                    table.ForeignKey(
                        name: "FK_Bebida_Categoria_Id_Categoria",
                        column: x => x.Id_Categoria,
                        principalTable: "Categoria",
                        principalColumn: "Id_Categoria");
                });

            migrationBuilder.CreateTable(
                name: "Platillo",
                columns: table => new
                {
                    Id_Platillo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Precio = table.Column<int>(type: "int", precision: 7, scale: 2, nullable: false),
                    Id_Categoria = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Platillo", x => x.Id_Platillo);
                    table.ForeignKey(
                        name: "FK_Platillo_Categoria_Id_Categoria",
                        column: x => x.Id_Categoria,
                        principalTable: "Categoria",
                        principalColumn: "Id_Categoria");
                });

            migrationBuilder.CreateTable(
                name: "Orden",
                columns: table => new
                {
                    Id_Orden = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Hora = table.Column<TimeSpan>(type: "time", nullable: false),
                    Numero_Orden = table.Column<int>(type: "int", nullable: false),
                    Cantidad_Personas = table.Column<int>(type: "int", nullable: false),
                    Cancelado = table.Column<bool>(type: "bit", nullable: false),
                    Id_Detalle_Orden = table.Column<int>(type: "int", nullable: false),
                    Id_Empleado = table.Column<int>(type: "int", nullable: false),
                    Id_Cliente = table.Column<int>(type: "int", nullable: false),
                    Id_Mesa = table.Column<int>(type: "int", nullable: false),
                    Id_Chef = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orden", x => x.Id_Orden);
                    table.ForeignKey(
                        name: "FK_Orden_Chef_Id_Chef",
                        column: x => x.Id_Chef,
                        principalTable: "Chef",
                        principalColumn: "Id_Chef",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orden_Cliente_Id_Cliente",
                        column: x => x.Id_Cliente,
                        principalTable: "Cliente",
                        principalColumn: "Id_Cliente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orden_Empleado_Id_Empleado",
                        column: x => x.Id_Empleado,
                        principalTable: "Empleado",
                        principalColumn: "Id_Empleado",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orden_Mesa_Id_Mesa",
                        column: x => x.Id_Mesa,
                        principalTable: "Mesa",
                        principalColumn: "Id_Mesa",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cuenta",
                columns: table => new
                {
                    Id_Cuenta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_Cliente = table.Column<int>(type: "int", nullable: false),
                    Id_Orden = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Cancelado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuenta", x => x.Id_Cuenta);
                    table.ForeignKey(
                        name: "FK_Cuenta_Orden_Id_Orden",
                        column: x => x.Id_Orden,
                        principalTable: "Orden",
                        principalColumn: "Id_Orden",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetalleOrden",
                columns: table => new
                {
                    Id_Detalle_Orden = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_Orden = table.Column<int>(type: "int", nullable: false),
                    Cantidad_Platillo = table.Column<int>(type: "int", nullable: false),
                    Cantidad_Bebida = table.Column<int>(type: "int", nullable: false),
                    Id_Bebida = table.Column<int>(type: "int", nullable: true),
                    Id_Platillo = table.Column<int>(type: "int", nullable: true),
                    Precio = table.Column<decimal>(type: "decimal(7,2)", precision: 7, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleOrden", x => x.Id_Detalle_Orden);
                    table.ForeignKey(
                        name: "FK_DetalleOrden_Orden",
                        column: x => x.Id_Orden,
                        principalTable: "Orden",
                        principalColumn: "Id_Orden",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetalleOrdenBebida",
                columns: table => new
                {
                    Id_Bebida = table.Column<int>(type: "int", nullable: false),
                    Id_Detalle_Orden = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleOrdenBebida", x => new { x.Id_Bebida, x.Id_Detalle_Orden });
                    table.ForeignKey(
                        name: "FK_DetalleOrdenBebida_Bebida_Id_Bebida",
                        column: x => x.Id_Bebida,
                        principalTable: "Bebida",
                        principalColumn: "Id_Bebida",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetalleOrdenBebida_DetalleOrden_Id_Detalle_Orden",
                        column: x => x.Id_Detalle_Orden,
                        principalTable: "DetalleOrden",
                        principalColumn: "Id_Detalle_Orden",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetalleOrdenPlatillo",
                columns: table => new
                {
                    Id_Detalle_Orden = table.Column<int>(type: "int", nullable: false),
                    Id_Platillo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleOrdenPlatillo", x => new { x.Id_Detalle_Orden, x.Id_Platillo });
                    table.ForeignKey(
                        name: "FK_DetalleOrdenPlatillo_DetalleOrden_Id_Detalle_Orden",
                        column: x => x.Id_Detalle_Orden,
                        principalTable: "DetalleOrden",
                        principalColumn: "Id_Detalle_Orden",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetalleOrdenPlatillo_Platillo_Id_Platillo",
                        column: x => x.Id_Platillo,
                        principalTable: "Platillo",
                        principalColumn: "Id_Platillo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Administrador",
                columns: new[] { "Id_Administrador", "Activo", "Contrasena", "Correo", "Nombre" },
                values: new object[] { 1, true, "root", "admin@gmail.com", "admin" });

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "Id_Categoria", "Nombre" },
                values: new object[,]
                {
                    { 1, "Entradas" },
                    { 2, "Platos principales" },
                    { 3, "Postres" },
                    { 4, "Bebidas frías" },
                    { 5, "Bebidas calientes" },
                    { 6, "Ensaladas" },
                    { 7, "Sopas" },
                    { 8, "Aperitivos" },
                    { 9, "Sandwiches" },
                    { 10, "Mariscos" }
                });

            migrationBuilder.InsertData(
                table: "Chef",
                columns: new[] { "Id_Chef", "Activo", "Contrasena", "Correo", "Nombre" },
                values: new object[,]
                {
                    { 1, true, "root", "ana.rodriguez@gmail.com", "Ana Rodríguez" },
                    { 2, true, "root", "pedro.gomez@gmail.com", "Pedro Gómez" },
                    { 3, true, "root", "lucia.fernandez@gmail.com", "Lucía Fernández" },
                    { 4, true, "root", "jorge.ramirez@gmail.com", "Jorge Ramírez" },
                    { 5, true, "root", "elena.sanchez@gmail.com", "Elena Sánchez" }
                });

            migrationBuilder.InsertData(
                table: "Cliente",
                columns: new[] { "Id_Cliente", "Apellido", "Nombre" },
                values: new object[,]
                {
                    { 1, "Martínez", "Ana" },
                    { 2, "Gómez", "Pedro" },
                    { 3, "López", "María" },
                    { 4, "Pérez", "Juan" },
                    { 5, "Sánchez", "Laura" },
                    { 6, "García", "Carlos" },
                    { 7, "Fernández", "Sofía" },
                    { 8, "Ramírez", "Diego" },
                    { 9, "Hernández", "Valentina" },
                    { 10, "Torres", "Luis" },
                    { 11, "Díaz", "Carmen" },
                    { 12, "Moreno", "Pablo" },
                    { 13, "Ortega", "Adriana" },
                    { 14, "Ruiz", "Martín" },
                    { 15, "González", "Julia" },
                    { 16, "Navarro", "Elena" },
                    { 17, "Jiménez", "Miguel" },
                    { 18, "Silva", "Sara" },
                    { 19, "López", "Andrés" },
                    { 20, "Martí", "Lucía" }
                });

            migrationBuilder.InsertData(
                table: "Empleado",
                columns: new[] { "Id_Empleado", "Activo", "Contrasena", "Correo", "Nombre" },
                values: new object[,]
                {
                    { 1, true, "root", "juan.perez@gmail.com", "Juan Pérez" },
                    { 2, true, "root", "maria.lopez@gmail.com", "María López" },
                    { 3, true, "root", "carlos.garcia@gmail.com", "Carlos García" },
                    { 4, true, "root", "laura.martinez@gmail.com", "Laura Martínez" },
                    { 5, true, "root", "miguel.hernandez@gmail.com", "Miguel Hernández" }
                });

            migrationBuilder.InsertData(
                table: "Mesa",
                columns: new[] { "Id_Mesa", "Activa", "Disponible", "Numero_Mesa" },
                values: new object[,]
                {
                    { 1, true, true, "1" },
                    { 2, true, true, "2" },
                    { 3, true, true, "5" },
                    { 4, true, true, "1" },
                    { 5, true, true, "8" },
                    { 6, true, true, "3" },
                    { 7, true, true, "6" },
                    { 8, true, true, "9" },
                    { 9, true, true, "4" },
                    { 10, true, false, "7" }
                });

            migrationBuilder.InsertData(
                table: "Bebida",
                columns: new[] { "Id_Bebida", "Descripcion", "Id_Categoria", "Nombre", "Precio" },
                values: new object[,]
                {
                    { 1, "Jugo natural exprimido de naranjas frescas.", 4, "Jugo de Naranja", 4000 },
                    { 2, "Té verde helado naturalmente antioxidante y revitalizante.", 4, "Té Verde Helado", 3500 },
                    { 3, "Bebida refrescante y nutritiva con mezcla de frutas frescas y yogurt.", 4, "Smoothie de Frutas", 4500 },
                    { 4, "Agua de coco natural, refrescante y bajo en calorías.", 4, "Agua de Coco", 3000 },
                    { 5, "Limonada refrescante preparada con limones frescos.", 4, "Limonada Natural", 3500 },
                    { 6, "Cóctel refrescante sin alcohol con menta, lima, azúcar, soda y hierbabuena.", 4, "Mojito sin Alcohol", 3800 },
                    { 7, "Café frío mezclado con hielo, ideal para días calurosos.", 5, "Café Frappé", 4000 },
                    { 8, "Cóctel frozen con ron, crema de coco y jugo de piña.", 4, "Piña Colada Frozen", 6500 },
                    { 9, "Cóctel frozen de tequila, triple sec, jugo de lima y azúcar.", 4, "Margarita Frozen", 7000 },
                    { 10, "Cóctel frozen con ron blanco, fresas frescas, jugo de limón y azúcar.", 4, "Daiquiri de Fresa Frozen", 6800 }
                });

            migrationBuilder.InsertData(
                table: "Orden",
                columns: new[] { "Id_Orden", "Cancelado", "Cantidad_Personas", "Fecha", "Hora", "Id_Chef", "Id_Cliente", "Id_Detalle_Orden", "Id_Empleado", "Id_Mesa", "Numero_Orden" },
                values: new object[,]
                {
                    { 1, false, 4, new DateTime(2024, 8, 21, 16, 48, 39, 950, DateTimeKind.Local).AddTicks(3105), new TimeSpan(605199503115), 1, 1, 0, 1, 1, 1 },
                    { 2, false, 2, new DateTime(2024, 8, 21, 16, 48, 39, 950, DateTimeKind.Local).AddTicks(3118), new TimeSpan(605199503119), 2, 2, 0, 2, 2, 2 },
                    { 3, false, 3, new DateTime(2024, 8, 21, 16, 48, 39, 950, DateTimeKind.Local).AddTicks(3121), new TimeSpan(605199503121), 3, 3, 0, 3, 3, 3 },
                    { 4, false, 5, new DateTime(2024, 8, 21, 16, 48, 39, 950, DateTimeKind.Local).AddTicks(3123), new TimeSpan(605199503124), 4, 4, 0, 4, 4, 4 },
                    { 5, false, 6, new DateTime(2024, 8, 21, 16, 48, 39, 950, DateTimeKind.Local).AddTicks(3125), new TimeSpan(605199503126), 5, 5, 0, 5, 5, 5 },
                    { 6, false, 2, new DateTime(2024, 8, 21, 16, 48, 39, 950, DateTimeKind.Local).AddTicks(3128), new TimeSpan(605199503128), 2, 6, 0, 1, 6, 6 },
                    { 7, false, 4, new DateTime(2024, 8, 21, 16, 48, 39, 950, DateTimeKind.Local).AddTicks(3130), new TimeSpan(605199503131), 3, 7, 0, 2, 7, 7 },
                    { 8, false, 3, new DateTime(2024, 8, 21, 16, 48, 39, 950, DateTimeKind.Local).AddTicks(3133), new TimeSpan(605199503133), 4, 8, 0, 3, 8, 8 },
                    { 9, false, 2, new DateTime(2024, 8, 21, 16, 48, 39, 950, DateTimeKind.Local).AddTicks(3135), new TimeSpan(605199503135), 1, 9, 0, 4, 9, 9 },
                    { 10, false, 4, new DateTime(2024, 8, 21, 16, 48, 39, 950, DateTimeKind.Local).AddTicks(3137), new TimeSpan(605199503138), 5, 10, 0, 5, 10, 10 }
                });

            migrationBuilder.InsertData(
                table: "Platillo",
                columns: new[] { "Id_Platillo", "Descripcion", "Id_Categoria", "Nombre", "Precio" },
                values: new object[,]
                {
                    { 1, "Filete de res a la parrilla con acompañamiento de vegetales frescos.", 2, "Filete de Res", 15000 },
                    { 2, "Filete de salmón fresco horneado con hierbas y limón.", 2, "Salmón al Horno", 18000 },
                    { 3, "Pasta fettuccine en salsa cremosa de queso parmesano.", 2, "Pasta Alfredo", 12000 },
                    { 4, "Ensalada fresca con pollo a la parrilla y aderezo César.", 6, "Ensalada César", 9000 },
                    { 5, "Pizza tradicional con salsa de tomate, mozzarella y albahaca fresca.", 2, "Pizza Margarita", 14000 },
                    { 6, "Ceviche peruano con pescado, camarones y calamares en jugo de limón.", 10, "Ceviche Mixto", 16000 },
                    { 7, "Tacos mexicanos con carnitas de cerdo, cebolla y cilantro.", 8, "Tacos de Carnitas", 11000 },
                    { 8, "Paella española con arroz, mariscos, pollo y chorizo.", 10, "Paella Valenciana", 20000 },
                    { 9, "Variedad de sushi japonés: nigiri, sashimi y rollos especiales.", 10, "Sushi Variado", 22000 },
                    { 10, "Lasagna italiana con carne de res, salsa bolognesa y queso parmesano.", 2, "Lasagna Bolognesa", 13000 }
                });

            migrationBuilder.InsertData(
                table: "Cuenta",
                columns: new[] { "Id_Cuenta", "Cancelado", "Id_Cliente", "Id_Orden", "Total" },
                values: new object[,]
                {
                    { 1, false, 1, 1, 1500m },
                    { 2, true, 2, 2, 1200m },
                    { 3, false, 3, 3, 1800m },
                    { 4, false, 4, 4, 900m },
                    { 5, true, 5, 5, 2000m },
                    { 6, false, 6, 6, 1600m },
                    { 7, false, 7, 7, 2100m },
                    { 8, true, 8, 8, 1400m },
                    { 9, false, 9, 9, 1750m },
                    { 10, false, 10, 10, 1950m }
                });

            migrationBuilder.InsertData(
                table: "DetalleOrden",
                columns: new[] { "Id_Detalle_Orden", "Cantidad_Bebida", "Cantidad_Platillo", "Id_Bebida", "Id_Orden", "Id_Platillo", "Precio" },
                values: new object[,]
                {
                    { 1, 1, 2, 1, 1, 1, 100.00m },
                    { 2, 2, 1, 2, 2, 3, 150.00m },
                    { 3, 3, 3, 3, 3, 2, 200.00m },
                    { 4, 2, 1, 4, 4, 4, 175.00m },
                    { 5, 1, 2, 5, 5, 5, 125.00m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bebida_Id_Categoria",
                table: "Bebida",
                column: "Id_Categoria");

            migrationBuilder.CreateIndex(
                name: "IX_Cuenta_Id_Orden",
                table: "Cuenta",
                column: "Id_Orden",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DetalleOrden_Id_Orden",
                table: "DetalleOrden",
                column: "Id_Orden",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DetalleOrdenBebida_Id_Detalle_Orden",
                table: "DetalleOrdenBebida",
                column: "Id_Detalle_Orden");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleOrdenPlatillo_Id_Platillo",
                table: "DetalleOrdenPlatillo",
                column: "Id_Platillo");

            migrationBuilder.CreateIndex(
                name: "IX_Orden_Id_Chef",
                table: "Orden",
                column: "Id_Chef");

            migrationBuilder.CreateIndex(
                name: "IX_Orden_Id_Cliente",
                table: "Orden",
                column: "Id_Cliente");

            migrationBuilder.CreateIndex(
                name: "IX_Orden_Id_Empleado",
                table: "Orden",
                column: "Id_Empleado");

            migrationBuilder.CreateIndex(
                name: "IX_Orden_Id_Mesa",
                table: "Orden",
                column: "Id_Mesa",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Platillo_Id_Categoria",
                table: "Platillo",
                column: "Id_Categoria");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Administrador");

            migrationBuilder.DropTable(
                name: "Cuenta");

            migrationBuilder.DropTable(
                name: "DetalleOrdenBebida");

            migrationBuilder.DropTable(
                name: "DetalleOrdenPlatillo");

            migrationBuilder.DropTable(
                name: "Bebida");

            migrationBuilder.DropTable(
                name: "DetalleOrden");

            migrationBuilder.DropTable(
                name: "Platillo");

            migrationBuilder.DropTable(
                name: "Orden");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "Chef");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Empleado");

            migrationBuilder.DropTable(
                name: "Mesa");
        }
    }
}
