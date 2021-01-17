using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEnd.Migrations
{
    public partial class V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Maticna_Ploca",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime_Maticne = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Procesor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Graficka_Kartica = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Max_Ram = table.Column<int>(type: "int", nullable: false),
                    Broj_Ram_Slota = table.Column<int>(type: "int", nullable: false),
                    Max_Sata = table.Column<int>(type: "int", nullable: false),
                    Max_NVME = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maticna_Ploca", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PC_Warehouse",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Kapacitet = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PC_Warehouse", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "NVME",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nvme = table.Column<int>(type: "int", nullable: false),
                    MotherboardID = table.Column<int>(type: "int", nullable: true)
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
                    Ram = table.Column<int>(type: "int", nullable: false),
                    MotherboardID = table.Column<int>(type: "int", nullable: true)
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
                    Sata = table.Column<int>(type: "int", nullable: false),
                    MotherboardID = table.Column<int>(type: "int", nullable: true)
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

            migrationBuilder.CreateTable(
                name: "Racunari",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MotherboardID = table.Column<int>(type: "int", nullable: false),
                    Kuciste = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Napajanje = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cena = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WarehouseID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Racunari", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Racunari_Maticna_Ploca_MotherboardID",
                        column: x => x.MotherboardID,
                        principalTable: "Maticna_Ploca",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Racunari_PC_Warehouse_WarehouseID",
                        column: x => x.WarehouseID,
                        principalTable: "PC_Warehouse",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NVME_MotherboardID",
                table: "NVME",
                column: "MotherboardID");

            migrationBuilder.CreateIndex(
                name: "IX_Racunari_MotherboardID",
                table: "Racunari",
                column: "MotherboardID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Racunari_WarehouseID",
                table: "Racunari",
                column: "WarehouseID");

            migrationBuilder.CreateIndex(
                name: "IX_RAM_MotherboardID",
                table: "RAM",
                column: "MotherboardID");

            migrationBuilder.CreateIndex(
                name: "IX_SATA_MotherboardID",
                table: "SATA",
                column: "MotherboardID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NVME");

            migrationBuilder.DropTable(
                name: "Racunari");

            migrationBuilder.DropTable(
                name: "RAM");

            migrationBuilder.DropTable(
                name: "SATA");

            migrationBuilder.DropTable(
                name: "PC_Warehouse");

            migrationBuilder.DropTable(
                name: "Maticna_Ploca");
        }
    }
}
