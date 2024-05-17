using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MuhmadOmarHajHamdo.Entities
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    BirthYear = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100,
                        nullable: false),
                    PhoneNumber = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20,
                        nullable: true)
                },
                constraints: table => { table.PrimaryKey("Id", x => x.Id); });

            migrationBuilder.CreateTable(
                name: "tests",
                columns: table => new
                {
                    column_name = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table => { table.PrimaryKey("tests_pk", x => x.column_name); });

            migrationBuilder.CreateTable(
                name: "salaries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mount = table.Column<double>(type: "float", nullable: false),
                    Month = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__salaries__3214EC072BCA6AD6", x => x.Id);
                    table.ForeignKey(
                        name: "employeeId__fk",
                        column: x => x.UserId,
                        principalTable: "employees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "UQ__employee__737584F665429F01",
                table: "employees",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__employee__85FB4E3895EBB785",
                table: "employees",
                column: "PhoneNumber",
                unique: true,
                filter: "[PhoneNumber] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_salaries_UserId",
                table: "salaries",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "salaries");

            migrationBuilder.DropTable(
                name: "tests");

            migrationBuilder.DropTable(
                name: "employees");
        }
    }
}