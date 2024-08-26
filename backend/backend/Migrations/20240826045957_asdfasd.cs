using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class asdfasd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Precio",
                table: "DetalleOrden",
                type: "int",
                precision: 7,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(7,2)",
                oldPrecision: 7,
                oldScale: 2);

            migrationBuilder.UpdateData(
                table: "DetalleOrden",
                keyColumn: "Id_Detalle_Orden",
                keyValue: 1,
                column: "Precio",
                value: 100);

            migrationBuilder.UpdateData(
                table: "DetalleOrden",
                keyColumn: "Id_Detalle_Orden",
                keyValue: 2,
                column: "Precio",
                value: 150);

            migrationBuilder.UpdateData(
                table: "DetalleOrden",
                keyColumn: "Id_Detalle_Orden",
                keyValue: 3,
                column: "Precio",
                value: 200);

            migrationBuilder.UpdateData(
                table: "DetalleOrden",
                keyColumn: "Id_Detalle_Orden",
                keyValue: 4,
                column: "Precio",
                value: 175);

            migrationBuilder.UpdateData(
                table: "DetalleOrden",
                keyColumn: "Id_Detalle_Orden",
                keyValue: 5,
                column: "Precio",
                value: 125);

            migrationBuilder.UpdateData(
                table: "Orden",
                keyColumn: "Id_Orden",
                keyValue: 1,
                columns: new[] { "Fecha", "Hora" },
                values: new object[] { new DateTime(2024, 8, 25, 22, 59, 56, 222, DateTimeKind.Local).AddTicks(7094), new TimeSpan(827962227109) });

            migrationBuilder.UpdateData(
                table: "Orden",
                keyColumn: "Id_Orden",
                keyValue: 2,
                columns: new[] { "Fecha", "Hora" },
                values: new object[] { new DateTime(2024, 8, 25, 22, 59, 56, 222, DateTimeKind.Local).AddTicks(7119), new TimeSpan(827962227120) });

            migrationBuilder.UpdateData(
                table: "Orden",
                keyColumn: "Id_Orden",
                keyValue: 3,
                columns: new[] { "Fecha", "Hora" },
                values: new object[] { new DateTime(2024, 8, 25, 22, 59, 56, 222, DateTimeKind.Local).AddTicks(7123), new TimeSpan(827962227124) });

            migrationBuilder.UpdateData(
                table: "Orden",
                keyColumn: "Id_Orden",
                keyValue: 4,
                columns: new[] { "Fecha", "Hora" },
                values: new object[] { new DateTime(2024, 8, 25, 22, 59, 56, 222, DateTimeKind.Local).AddTicks(7127), new TimeSpan(827962227128) });

            migrationBuilder.UpdateData(
                table: "Orden",
                keyColumn: "Id_Orden",
                keyValue: 5,
                columns: new[] { "Fecha", "Hora" },
                values: new object[] { new DateTime(2024, 8, 25, 22, 59, 56, 222, DateTimeKind.Local).AddTicks(7132), new TimeSpan(827962227133) });

            migrationBuilder.UpdateData(
                table: "Orden",
                keyColumn: "Id_Orden",
                keyValue: 6,
                columns: new[] { "Fecha", "Hora" },
                values: new object[] { new DateTime(2024, 8, 25, 22, 59, 56, 222, DateTimeKind.Local).AddTicks(7135), new TimeSpan(827962227136) });

            migrationBuilder.UpdateData(
                table: "Orden",
                keyColumn: "Id_Orden",
                keyValue: 7,
                columns: new[] { "Fecha", "Hora" },
                values: new object[] { new DateTime(2024, 8, 25, 22, 59, 56, 222, DateTimeKind.Local).AddTicks(7139), new TimeSpan(827962227139) });

            migrationBuilder.UpdateData(
                table: "Orden",
                keyColumn: "Id_Orden",
                keyValue: 8,
                columns: new[] { "Fecha", "Hora" },
                values: new object[] { new DateTime(2024, 8, 25, 22, 59, 56, 222, DateTimeKind.Local).AddTicks(7142), new TimeSpan(827962227143) });

            migrationBuilder.UpdateData(
                table: "Orden",
                keyColumn: "Id_Orden",
                keyValue: 9,
                columns: new[] { "Fecha", "Hora" },
                values: new object[] { new DateTime(2024, 8, 25, 22, 59, 56, 222, DateTimeKind.Local).AddTicks(7145), new TimeSpan(827962227146) });

            migrationBuilder.UpdateData(
                table: "Orden",
                keyColumn: "Id_Orden",
                keyValue: 10,
                columns: new[] { "Fecha", "Hora" },
                values: new object[] { new DateTime(2024, 8, 25, 22, 59, 56, 222, DateTimeKind.Local).AddTicks(7149), new TimeSpan(827962227149) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Precio",
                table: "DetalleOrden",
                type: "decimal(7,2)",
                precision: 7,
                scale: 2,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldPrecision: 7,
                oldScale: 2);

            migrationBuilder.UpdateData(
                table: "DetalleOrden",
                keyColumn: "Id_Detalle_Orden",
                keyValue: 1,
                column: "Precio",
                value: 100.00m);

            migrationBuilder.UpdateData(
                table: "DetalleOrden",
                keyColumn: "Id_Detalle_Orden",
                keyValue: 2,
                column: "Precio",
                value: 150.00m);

            migrationBuilder.UpdateData(
                table: "DetalleOrden",
                keyColumn: "Id_Detalle_Orden",
                keyValue: 3,
                column: "Precio",
                value: 200.00m);

            migrationBuilder.UpdateData(
                table: "DetalleOrden",
                keyColumn: "Id_Detalle_Orden",
                keyValue: 4,
                column: "Precio",
                value: 175.00m);

            migrationBuilder.UpdateData(
                table: "DetalleOrden",
                keyColumn: "Id_Detalle_Orden",
                keyValue: 5,
                column: "Precio",
                value: 125.00m);

            migrationBuilder.UpdateData(
                table: "Orden",
                keyColumn: "Id_Orden",
                keyValue: 1,
                columns: new[] { "Fecha", "Hora" },
                values: new object[] { new DateTime(2024, 8, 24, 10, 8, 45, 356, DateTimeKind.Local).AddTicks(5944), new TimeSpan(365253565956) });

            migrationBuilder.UpdateData(
                table: "Orden",
                keyColumn: "Id_Orden",
                keyValue: 2,
                columns: new[] { "Fecha", "Hora" },
                values: new object[] { new DateTime(2024, 8, 24, 10, 8, 45, 356, DateTimeKind.Local).AddTicks(5959), new TimeSpan(365253565960) });

            migrationBuilder.UpdateData(
                table: "Orden",
                keyColumn: "Id_Orden",
                keyValue: 3,
                columns: new[] { "Fecha", "Hora" },
                values: new object[] { new DateTime(2024, 8, 24, 10, 8, 45, 356, DateTimeKind.Local).AddTicks(5962), new TimeSpan(365253565962) });

            migrationBuilder.UpdateData(
                table: "Orden",
                keyColumn: "Id_Orden",
                keyValue: 4,
                columns: new[] { "Fecha", "Hora" },
                values: new object[] { new DateTime(2024, 8, 24, 10, 8, 45, 356, DateTimeKind.Local).AddTicks(5964), new TimeSpan(365253565965) });

            migrationBuilder.UpdateData(
                table: "Orden",
                keyColumn: "Id_Orden",
                keyValue: 5,
                columns: new[] { "Fecha", "Hora" },
                values: new object[] { new DateTime(2024, 8, 24, 10, 8, 45, 356, DateTimeKind.Local).AddTicks(5966), new TimeSpan(365253565967) });

            migrationBuilder.UpdateData(
                table: "Orden",
                keyColumn: "Id_Orden",
                keyValue: 6,
                columns: new[] { "Fecha", "Hora" },
                values: new object[] { new DateTime(2024, 8, 24, 10, 8, 45, 356, DateTimeKind.Local).AddTicks(5969), new TimeSpan(365253565969) });

            migrationBuilder.UpdateData(
                table: "Orden",
                keyColumn: "Id_Orden",
                keyValue: 7,
                columns: new[] { "Fecha", "Hora" },
                values: new object[] { new DateTime(2024, 8, 24, 10, 8, 45, 356, DateTimeKind.Local).AddTicks(5971), new TimeSpan(365253565972) });

            migrationBuilder.UpdateData(
                table: "Orden",
                keyColumn: "Id_Orden",
                keyValue: 8,
                columns: new[] { "Fecha", "Hora" },
                values: new object[] { new DateTime(2024, 8, 24, 10, 8, 45, 356, DateTimeKind.Local).AddTicks(5973), new TimeSpan(365253565974) });

            migrationBuilder.UpdateData(
                table: "Orden",
                keyColumn: "Id_Orden",
                keyValue: 9,
                columns: new[] { "Fecha", "Hora" },
                values: new object[] { new DateTime(2024, 8, 24, 10, 8, 45, 356, DateTimeKind.Local).AddTicks(5976), new TimeSpan(365253565976) });

            migrationBuilder.UpdateData(
                table: "Orden",
                keyColumn: "Id_Orden",
                keyValue: 10,
                columns: new[] { "Fecha", "Hora" },
                values: new object[] { new DateTime(2024, 8, 24, 10, 8, 45, 356, DateTimeKind.Local).AddTicks(5978), new TimeSpan(365253565979) });
        }
    }
}
