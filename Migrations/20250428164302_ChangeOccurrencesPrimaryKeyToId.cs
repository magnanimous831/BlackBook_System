using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlackBook_System.Migrations
{
    /// <inheritdoc />
    public partial class ChangeOccurrencesPrimaryKeyToId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DAY",
                table: "Occurrences");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTimeOccurred",
                table: "Occurrences",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateTimeOccurred",
                table: "Occurrences");

            migrationBuilder.AddColumn<string>(
                name: "DAY",
                table: "Occurrences",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
