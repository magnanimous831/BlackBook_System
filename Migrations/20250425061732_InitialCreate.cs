using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlackBook_System.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Discipline",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DATE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ADMNO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    STUDENTNAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CLASS = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    INDISCIPLINECASE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AUDITED_BY = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AUDITED_DATETIME = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discipline", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Discipline");
        }
    }
}
