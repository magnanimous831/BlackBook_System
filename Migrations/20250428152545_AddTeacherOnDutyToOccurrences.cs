using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlackBook_System.Migrations
{
    /// <inheritdoc />
    public partial class AddTeacherOnDutyToOccurrences : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Occurrences",
                table: "Occurrences");

            migrationBuilder.RenameColumn(
                name: "TOD",
                table: "Occurrences",
                newName: "TeacherOnDuty");

            migrationBuilder.AlterColumn<string>(
                name: "DAY",
                table: "Occurrences",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "id",
                table: "Occurrences",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Occurrences",
                table: "Occurrences",
                column: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Occurrences",
                table: "Occurrences");

            migrationBuilder.DropColumn(
                name: "id",
                table: "Occurrences");

            migrationBuilder.RenameColumn(
                name: "TeacherOnDuty",
                table: "Occurrences",
                newName: "TOD");

            migrationBuilder.AlterColumn<string>(
                name: "DAY",
                table: "Occurrences",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Occurrences",
                table: "Occurrences",
                column: "DAY");
        }
    }
}
