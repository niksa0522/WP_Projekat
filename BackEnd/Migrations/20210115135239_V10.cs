using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEnd.Migrations
{
    public partial class V10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Memories_Maticna_Ploca_MotherboardID",
                table: "Memories");

            migrationBuilder.AddForeignKey(
                name: "FK_Memories_Maticna_Ploca_MotherboardID",
                table: "Memories",
                column: "MotherboardID",
                principalTable: "Maticna_Ploca",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Memories_Maticna_Ploca_MotherboardID",
                table: "Memories");

            migrationBuilder.AddForeignKey(
                name: "FK_Memories_Maticna_Ploca_MotherboardID",
                table: "Memories",
                column: "MotherboardID",
                principalTable: "Maticna_Ploca",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
