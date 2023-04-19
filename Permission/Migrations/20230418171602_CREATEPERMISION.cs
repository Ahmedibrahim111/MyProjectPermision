using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Permission.Migrations
{
    /// <inheritdoc />
    public partial class CREATEPERMISION : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "mangers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mangers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "workPermitRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    WorkConditions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkPermitApprovers = table.Column<int>(type: "int", nullable: false),
                    WorkPermitReject = table.Column<int>(type: "int", nullable: false),
                    EquipmentUsed = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FilesAttached = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeRole = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    Equipment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MangerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_workPermitRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_workPermitRequests_departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_workPermitRequests_mangers_MangerId",
                        column: x => x.MangerId,
                        principalTable: "mangers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_workPermitRequests_DepartmentId",
                table: "workPermitRequests",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_workPermitRequests_MangerId",
                table: "workPermitRequests",
                column: "MangerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "workPermitRequests");

            migrationBuilder.DropTable(
                name: "departments");

            migrationBuilder.DropTable(
                name: "mangers");
        }
    }
}
