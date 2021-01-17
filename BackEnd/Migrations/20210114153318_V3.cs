using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEnd.Migrations
{
    public partial class V3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Racunari_Maticna_Ploca_MotherboardID",
                table: "Racunari");

            migrationBuilder.DropIndex(
                name: "IX_Racunari_MotherboardID",
                table: "Racunari");

            migrationBuilder.DropColumn(
                name: "MotherboardID",
                table: "Racunari");

            migrationBuilder.AddColumn<int>(
                name: "PCID",
                table: "Maticna_Ploca",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Maticna_Ploca_PCID",
                table: "Maticna_Ploca",
                column: "PCID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Maticna_Ploca_Racunari_PCID",
                table: "Maticna_Ploca",
                column: "PCID",
                principalTable: "Racunari",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Maticna_Ploca_Racunari_PCID",
                table: "Maticna_Ploca");

            migrationBuilder.DropIndex(
                name: "IX_Maticna_Ploca_PCID",
                table: "Maticna_Ploca");

            migrationBuilder.DropColumn(
                name: "PCID",
                table: "Maticna_Ploca");

            migrationBuilder.AddColumn<int>(
                name: "MotherboardID",
                table: "Racunari",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Racunari_MotherboardID",
                table: "Racunari",
                column: "MotherboardID");

            migrationBuilder.AddForeignKey(
                name: "FK_Racunari_Maticna_Ploca_MotherboardID",
                table: "Racunari",
                column: "MotherboardID",
                principalTable: "Maticna_Ploca",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
