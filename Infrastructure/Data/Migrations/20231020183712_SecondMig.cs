using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class SecondMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdEmpleado",
                table: "empleado",
                newName: "IdEmp");

            migrationBuilder.RenameIndex(
                name: "IX_empleado_IdEmpleado",
                table: "empleado",
                newName: "IX_empleado_IdEmp");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdEmp",
                table: "empleado",
                newName: "IdEmpleado");

            migrationBuilder.RenameIndex(
                name: "IX_empleado_IdEmp",
                table: "empleado",
                newName: "IX_empleado_IdEmpleado");
        }
    }
}
