using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Permission.Migrations
{
    /// <inheritdoc />
    public partial class EditModelWorkPermisionMangerId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "workPermitRequests");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "workPermitRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
