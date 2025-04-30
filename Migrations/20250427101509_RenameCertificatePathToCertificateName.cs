using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlackBook_System.Migrations
{
    /// <inheritdoc />
    public partial class RenameCertificatePathToCertificateName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CertificatePath",
                table: "StudentsEnrollment",
                newName: "CertificateName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CertificateName",
                table: "StudentsEnrollment",
                newName: "CertificatePath");
        }
    }
}
