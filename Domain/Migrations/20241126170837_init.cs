using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ParsedDatas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HeaderText = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PostText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    PostedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SourceUrl = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Countries = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParsedDatas", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ParsedDatas_Time_HeaderText",
                table: "ParsedDatas",
                columns: new[] { "Time", "HeaderText" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParsedDatas");
        }
    }
}
