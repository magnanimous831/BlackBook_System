using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlackBook_System.Migrations
{
    /// <inheritdoc />
    public partial class BlackBook_System : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Occurrences",
                columns: table => new
                {
                    DAY = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TOD = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DAILYACTIVITY = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PLACE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RECORDED_BY = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    REMARKS = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Occurrences", x => x.DAY);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Occurrences");
        }
    }
}
