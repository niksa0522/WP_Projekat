using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEnd.Migrations
{
    public partial class V8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Memories_Maticna_Ploca_MotherboardID1",
                table: "Memories");

            migrationBuilder.DropForeignKey(
                name: "FK_Memories_Maticna_Ploca_MotherboardID2",
                table: "Memories");

            migrationBuilder.DropIndex(
                name: "IX_Memories_MotherboardID1",
                table: "Memories");

            migrationBuilder.DropIndex(
                name: "IX_Memories_MotherboardID2",
                table: "Memories");

            migrationBuilder.DropColumn(
                name: "MotherboardID1",
                table: "Memories");

            migrationBuilder.DropColumn(
                name: "MotherboardID2",
                table: "Memories");

            migrationBuilder.AddColumn<string>(
                name: "Tip",
                table: "Memories",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tip",
                table: "Memories");

            migrationBuilder.AddColumn<int>(
                name: "MotherboardID1",
                table: "Memories",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MotherboardID2",
                table: "Memories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Memories_MotherboardID1",
                table: "Memories",
                column: "MotherboardID1");

            migrationBuilder.CreateIndex(
                name: "IX_Memories_MotherboardID2",
                table: "Memories",
                column: "MotherboardID2");

            migrationBuilder.AddForeignKey(
                name: "FK_Memories_Maticna_Ploca_MotherboardID1",
                table: "Memories",
                column: "MotherboardID1",
                principalTable: "Maticna_Ploca",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Memories_Maticna_Ploca_MotherboardID2",
                table: "Memories",
                column: "MotherboardID2",
                principalTable: "Maticna_Ploca",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
