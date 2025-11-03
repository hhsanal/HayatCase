using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    /// <inheritdoc />
    public partial class migupdateAlertTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SensorAlerts_FactorySensors_SensorId",
                table: "SensorAlerts");

            migrationBuilder.RenameColumn(
                name: "SensorId",
                table: "SensorAlerts",
                newName: "SensorDataId");

            migrationBuilder.RenameIndex(
                name: "IX_SensorAlerts_SensorId",
                table: "SensorAlerts",
                newName: "IX_SensorAlerts_SensorDataId");

            migrationBuilder.AddForeignKey(
                name: "FK_SensorAlerts_SensorDatas_SensorDataId",
                table: "SensorAlerts",
                column: "SensorDataId",
                principalTable: "SensorDatas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SensorAlerts_SensorDatas_SensorDataId",
                table: "SensorAlerts");

            migrationBuilder.RenameColumn(
                name: "SensorDataId",
                table: "SensorAlerts",
                newName: "SensorId");

            migrationBuilder.RenameIndex(
                name: "IX_SensorAlerts_SensorDataId",
                table: "SensorAlerts",
                newName: "IX_SensorAlerts_SensorId");

            migrationBuilder.AddForeignKey(
                name: "FK_SensorAlerts_FactorySensors_SensorId",
                table: "SensorAlerts",
                column: "SensorId",
                principalTable: "FactorySensors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
