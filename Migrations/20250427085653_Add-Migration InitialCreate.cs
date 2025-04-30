using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlackBook_System.Migrations
{
    /// <inheritdoc />
    public partial class AddMigrationInitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "County",
                table: "StudentsEnrollment",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SubCounty",
                table: "StudentsEnrollment",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "County",
                table: "StudentsEnrollment");

            migrationBuilder.DropColumn(
                name: "SubCounty",
                table: "StudentsEnrollment");
        }
    }
}
