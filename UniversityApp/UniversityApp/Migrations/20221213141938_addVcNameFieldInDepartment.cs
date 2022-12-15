using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityApp.Migrations
{
    /// <inheritdoc />
    public partial class addVcNameFieldInDepartment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "VcName",
                table: "Departments",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VcName",
                table: "Departments");
        }
    }
}
