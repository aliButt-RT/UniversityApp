using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityApp.Migrations
{
    /// <inheritdoc />
    public partial class addEmployeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sal = table.Column<int>(type: "int", nullable: false),
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
