using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    /// <inheritdoc />
    public partial class migsensorvaluenamechange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BoolValue",
                table: "SensorDatas");

            migrationBuilder.DropColumn(
                name: "DecimalValue",
                table: "SensorDatas");

            migrationBuilder.DropColumn(
                name: "IntValue",
                table: "SensorDatas");

            migrationBuilder.DropColumn(
                name: "StringValue",
                table: "SensorDatas");

            migrationBuilder.AddColumn<decimal>(
                name: "Value",
                table: "SensorDatas",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Value",
                table: "SensorDatas");

            migrationBuilder.AddColumn<bool>(
                name: "BoolValue",
                table: "SensorDatas",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "DecimalValue",
                table: "SensorDatas",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IntValue",
                table: "SensorDatas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StringValue",
                table: "SensorDatas",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
