using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    /// <inheritdoc />
    public partial class mig_alertTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SensorAlerts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SensorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AlertTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AlertType = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    IsAcknowledged = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SensorAlerts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SensorAlerts_FactorySensors_SensorId",
                        column: x => x.SensorId,
                        principalTable: "FactorySensors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SensorAlerts_SensorId",
                table: "SensorAlerts",
                column: "SensorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SensorAlerts");
        }
    }
}
