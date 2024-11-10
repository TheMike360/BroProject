using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Parser.Migrations
{
    /// <inheritdoc />
    public partial class newRowCountriesAndIndexes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "HeaderText",
                table: "ParsedDatas",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "Countries",
                table: "ParsedDatas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ParsedDatas_Time_HeaderText",
                table: "ParsedDatas",
                columns: new[] { "Time", "HeaderText" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ParsedDatas_Time_HeaderText",
                table: "ParsedDatas");

            migrationBuilder.DropColumn(
                name: "Countries",
                table: "ParsedDatas");

            migrationBuilder.AlterColumn<string>(
                name: "HeaderText",
                table: "ParsedDatas",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
