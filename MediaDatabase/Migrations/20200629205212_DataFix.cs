using Microsoft.EntityFrameworkCore.Migrations;

namespace Step_11.Migrations
{
    public partial class DataFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MediaEntries",
                keyColumn: "Id",
                keyValue: 13,
                column: "Size",
                value: 7.0);

            migrationBuilder.UpdateData(
                table: "MediaEntries",
                keyColumn: "Id",
                keyValue: 14,
                column: "Size",
                value: 9.0);

            migrationBuilder.UpdateData(
                table: "MediaEntries",
                keyColumn: "Id",
                keyValue: 15,
                column: "Size",
                value: 10.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MediaEntries",
                keyColumn: "Id",
                keyValue: 13,
                column: "Size",
                value: 55.0);

            migrationBuilder.UpdateData(
                table: "MediaEntries",
                keyColumn: "Id",
                keyValue: 14,
                column: "Size",
                value: 55.0);

            migrationBuilder.UpdateData(
                table: "MediaEntries",
                keyColumn: "Id",
                keyValue: 15,
                column: "Size",
                value: 55.0);
        }
    }
}
