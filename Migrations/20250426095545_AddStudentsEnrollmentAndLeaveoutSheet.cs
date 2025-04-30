using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlackBook_System.Migrations
{
    /// <inheritdoc />
    public partial class AddStudentsEnrollmentAndLeaveoutSheet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Leaveout_sheet",
                columns: table => new
                {
                    LEAVEOUTID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    STUDENTNAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ADMNO = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CLASS = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LEAVINGDATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    REASONFORLEAVING = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    RETURNDATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CLASSTEACHER = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SIGNATUREDATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TOD = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TODDATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PRINCIPAL = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SIGNDATE = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leaveout_sheet", x => x.LEAVEOUTID);
                });

            migrationBuilder.CreateTable(
                name: "StudentsEnrollment",
                columns: table => new
                {
                    EnrollmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ADMNO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    STUDENTNAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GENDER = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CLASSADMITTED = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ADMISSIONDATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GUARDIAN_NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CONTACTNUMBER = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ADDRESS = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CertificatePath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentsEnrollment", x => x.EnrollmentID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Leaveout_sheet");

            migrationBuilder.DropTable(
                name: "StudentsEnrollment");
        }
    }
}
