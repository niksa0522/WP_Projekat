using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEnd.Migrations
{
    public partial class V2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Racunari_Maticna_Ploca_MotherboardID",
                table: "Racunari");

            migrationBuilder.DropTable(
                name: "NVME");

            migrationBuilder.DropTable(
                name: "RAM");

            migrationBuilder.DropTable(
                name: "SATA");

            migrationBuilder.DropIndex(
                name: "IX_Racunari_MotherboardID",
                table: "Racunari");

            migrationBuilder.AlterColumn<int>(
                name: "MotherboardID",
                table: "Racunari",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "Memories",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Velicina = table.Column<int>(type: "int", nullable: false),
                    MotherboardID = table.Column<int>(type: "int", nullable: true),
                    MotherboardID1 = table.Column<int>(type: "int", nullable: true),
                    MotherboardID2 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Memories", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Memories_Maticna_Ploca_MotherboardID",
                        column: x => x.MotherboardID,
                        principalTable: "Maticna_Ploca",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Memories_Maticna_Ploca_MotherboardID1",
                        column: x => x.MotherboardID1,
                        principalTable: "Maticna_Ploca",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Memories_Maticna_Ploca_MotherboardID2",
                        column: x => x.MotherboardID2,
                        principalTable: "Maticna_Ploca",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Racunari_MotherboardID",
                table: "Racunari",
                column: "MotherboardID");

            migrationBuilder.CreateIndex(
                name: "IX_Memories_MotherboardID",
                table: "Memories",
                column: "MotherboardID");

            migrationBuilder.CreateIndex(
                name: "IX_Memories_MotherboardID1",
                table: "Memories",
                column: "MotherboardID1");

            migrationBuilder.CreateIndex(
                name: "IX_Memories_MotherboardID2",
                table: "Memories",
                column: "MotherboardID2");

            migrationBuilder.AddForeignKey(
                name: "FK_Racunari_Maticna_Ploca_MotherboardID",
                table: "Racunari",
                column: "MotherboardID",
                principalTable: "Maticna_Ploca",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Racunari_Maticna_Ploca_MotherboardID",
                table: "Racunari");

            migrationBuilder.DropTable(
                name: "Memories");

            migrationBuilder.DropIndex(
                name: "IX_Racunari_MotherboardID",
                table: "Racunari");

            migrationBuilder.AlterColumn<int>(
                name: "MotherboardID",
                table: "Racunari",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "NVME",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MotherboardID = table.Column<int>(type: "int", nullable: true),
                    Nvme = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NVME", x => x.ID);
                    table.ForeignKey(
                        name: "FK_NVME_Maticna_Ploca_MotherboardID",
                        column: x => x.MotherboardID,
                        principalTable: "Maticna_Ploca",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RAM",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MotherboardID = table.Column<int>(type: "int", nullable: true),
                    Ram = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RAM", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RAM_Maticna_Ploca_MotherboardID",
                        column: x => x.MotherboardID,
                        principalTable: "Maticna_Ploca",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SATA",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MotherboardID = table.Column<int>(type: "int", nullable: true),
                    Sata = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SATA", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SATA_Maticna_Ploca_MotherboardID",
                        column: x => x.MotherboardID,
                        principalTable: "Maticna_Ploca",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Racunari_MotherboardID",
                table: "Racunari",
                column: "MotherboardID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NVME_MotherboardID",
                table: "NVME",
                column: "MotherboardID");

            migrationBuilder.CreateIndex(
                name: "IX_RAM_MotherboardID",
                table: "RAM",
                column: "MotherboardID");

            migrationBuilder.CreateIndex(
                name: "IX_SATA_MotherboardID",
                table: "SATA",
                column: "MotherboardID");

            migrationBuilder.AddForeignKey(
                name: "FK_Racunari_Maticna_Ploca_MotherboardID",
                table: "Racunari",
                column: "MotherboardID",
                principalTable: "Maticna_Ploca",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
