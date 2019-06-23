using Microsoft.EntityFrameworkCore.Migrations;

namespace SportsRadarTest.Migrations
{
    public partial class RemoveSchedule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Weeks_Schedules_ScheduleSeason",
                table: "Weeks");

            migrationBuilder.RenameColumn(
                name: "ScheduleSeason",
                table: "Weeks",
                newName: "ScheduleId");

            migrationBuilder.RenameIndex(
                name: "IX_Weeks_ScheduleSeason",
                table: "Weeks",
                newName: "IX_Weeks_ScheduleId");

            migrationBuilder.RenameColumn(
                name: "Season",
                table: "Schedules",
                newName: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Weeks_Schedules_ScheduleId",
                table: "Weeks",
                column: "ScheduleId",
                principalTable: "Schedules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Weeks_Schedules_ScheduleId",
                table: "Weeks");

            migrationBuilder.RenameColumn(
                name: "ScheduleId",
                table: "Weeks",
                newName: "ScheduleSeason");

            migrationBuilder.RenameIndex(
                name: "IX_Weeks_ScheduleId",
                table: "Weeks",
                newName: "IX_Weeks_ScheduleSeason");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Schedules",
                newName: "Season");

            migrationBuilder.AddForeignKey(
                name: "FK_Weeks_Schedules_ScheduleSeason",
                table: "Weeks",
                column: "ScheduleSeason",
                principalTable: "Schedules",
                principalColumn: "Season",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
