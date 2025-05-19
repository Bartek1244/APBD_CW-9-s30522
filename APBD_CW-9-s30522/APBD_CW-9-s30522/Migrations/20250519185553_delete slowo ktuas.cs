using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APBD_CW_9_s30522.Migrations
{
    /// <inheritdoc />
    public partial class deleteslowoktuas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "IdPatient",
                keyValue: 1,
                column: "LastName",
                value: "Psiogon");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "IdPatient",
                keyValue: 1,
                column: "LastName",
                value: "Psikutas");
        }
    }
}
