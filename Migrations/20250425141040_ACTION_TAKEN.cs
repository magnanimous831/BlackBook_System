using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlackBook_System.Migrations
{
    /// <inheritdoc />
    public partial class ACTION_TAKEN : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ACTION_TAKEN",
                table: "Discipline",
                type: "nvarchar(max)",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "CASE_STATUS",
                table: "Discipline",
                type: "nvarchar(max)",
                nullable: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ACTION_TAKEN",
                table: "Discipline");

            migrationBuilder.DropColumn(
                name: "CASE_STATUS",
                table: "Discipline");
        }
    }
}
