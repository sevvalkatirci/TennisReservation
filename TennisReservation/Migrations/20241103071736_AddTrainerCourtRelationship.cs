using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TennisReservation.Migrations
{
    /// <inheritdoc />
    public partial class AddTrainerCourtRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trainers_Courts_CourtId",
                table: "Trainers");

            migrationBuilder.DropIndex(
                name: "IX_Trainers_CourtId",
                table: "Trainers");

            migrationBuilder.DropColumn(
                name: "CourtId",
                table: "Trainers");

            migrationBuilder.CreateTable(
                name: "TrainerCourts",
                columns: table => new
                {
                    CourtsId = table.Column<int>(type: "int", nullable: false),
                    TrainersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainerCourts", x => new { x.CourtsId, x.TrainersId });
                    table.ForeignKey(
                        name: "FK_TrainerCourts_Courts_CourtsId",
                        column: x => x.CourtsId,
                        principalTable: "Courts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrainerCourts_Trainers_TrainersId",
                        column: x => x.TrainersId,
                        principalTable: "Trainers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrainerCourts_TrainersId",
                table: "TrainerCourts",
                column: "TrainersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrainerCourts");

            migrationBuilder.AddColumn<int>(
                name: "CourtId",
                table: "Trainers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Trainers_CourtId",
                table: "Trainers",
                column: "CourtId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trainers_Courts_CourtId",
                table: "Trainers",
                column: "CourtId",
                principalTable: "Courts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
