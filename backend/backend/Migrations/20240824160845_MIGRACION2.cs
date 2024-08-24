using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class MIGRACION2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Contrasena",
                table: "Chef",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Contrasena",
                table: "Chef",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Orden",
                keyColumn: "Id_Orden",
                keyValue: 1,
                columns: new[] { "Fecha", "Hora" },
                values: new object[] { new DateTime(2024, 8, 21, 16, 48, 39, 950, DateTimeKind.Local).AddTicks(3105), new TimeSpan(605199503115) });

            migrationBuilder.UpdateData(
                table: "Orden",
                keyColumn: "Id_Orden",
                keyValue: 2,
                columns: new[] { "Fecha", "Hora" },
                values: new object[] { new DateTime(2024, 8, 21, 16, 48, 39, 950, DateTimeKind.Local).AddTicks(3118), new TimeSpan(605199503119) });

            migrationBuilder.UpdateData(
                table: "Orden",
                keyColumn: "Id_Orden",
                keyValue: 3,
                columns: new[] { "Fecha", "Hora" },
                values: new object[] { new DateTime(2024, 8, 21, 16, 48, 39, 950, DateTimeKind.Local).AddTicks(3121), new TimeSpan(605199503121) });

            migrationBuilder.UpdateData(
                table: "Orden",
                keyColumn: "Id_Orden",
                keyValue: 4,
                columns: new[] { "Fecha", "Hora" },
                values: new object[] { new DateTime(2024, 8, 21, 16, 48, 39, 950, DateTimeKind.Local).AddTicks(3123), new TimeSpan(605199503124) });

            migrationBuilder.UpdateData(
                table: "Orden",
                keyColumn: "Id_Orden",
                keyValue: 5,
                columns: new[] { "Fecha", "Hora" },
                values: new object[] { new DateTime(2024, 8, 21, 16, 48, 39, 950, DateTimeKind.Local).AddTicks(3125), new TimeSpan(605199503126) });

            migrationBuilder.UpdateData(
                table: "Orden",
                keyColumn: "Id_Orden",
                keyValue: 6,
                columns: new[] { "Fecha", "Hora" },
                values: new object[] { new DateTime(2024, 8, 21, 16, 48, 39, 950, DateTimeKind.Local).AddTicks(3128), new TimeSpan(605199503128) });

            migrationBuilder.UpdateData(
                table: "Orden",
                keyColumn: "Id_Orden",
                keyValue: 7,
                columns: new[] { "Fecha", "Hora" },
                values: new object[] { new DateTime(2024, 8, 21, 16, 48, 39, 950, DateTimeKind.Local).AddTicks(3130), new TimeSpan(605199503131) });

            migrationBuilder.UpdateData(
                table: "Orden",
                keyColumn: "Id_Orden",
                keyValue: 8,
                columns: new[] { "Fecha", "Hora" },
                values: new object[] { new DateTime(2024, 8, 21, 16, 48, 39, 950, DateTimeKind.Local).AddTicks(3133), new TimeSpan(605199503133) });

            migrationBuilder.UpdateData(
                table: "Orden",
                keyColumn: "Id_Orden",
                keyValue: 9,
                columns: new[] { "Fecha", "Hora" },
                values: new object[] { new DateTime(2024, 8, 21, 16, 48, 39, 950, DateTimeKind.Local).AddTicks(3135), new TimeSpan(605199503135) });

            migrationBuilder.UpdateData(
                table: "Orden",
                keyColumn: "Id_Orden",
                keyValue: 10,
                columns: new[] { "Fecha", "Hora" },
                values: new object[] { new DateTime(2024, 8, 21, 16, 48, 39, 950, DateTimeKind.Local).AddTicks(3137), new TimeSpan(605199503138) });
        }
    }
}
