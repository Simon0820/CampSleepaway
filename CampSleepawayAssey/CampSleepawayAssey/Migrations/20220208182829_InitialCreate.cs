using Microsoft.EntityFrameworkCore.Migrations;

namespace CampSleepawayAssey.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Campers",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 255, nullable: false),
                    Age = table.Column<int>(nullable: false),
                    Adress = table.Column<string>(maxLength: 255, nullable: true),
                    ArrivalDate = table.Column<string>(maxLength: 255, nullable: true),
                    DepartureDate = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Counselors",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    Age = table.Column<int>(nullable: false),
                    Adress = table.Column<string>(maxLength: 255, nullable: true),
                    PhoneNumber = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Counselors", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Relatives",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    Age = table.Column<int>(nullable: false),
                    Adress = table.Column<string>(maxLength: 255, nullable: true),
                    PhoneNumber = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relatives", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Cabins",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CabinName = table.Column<string>(maxLength: 255, nullable: false),
                    CounselorID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cabins", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Cabins_Counselors_CounselorID",
                        column: x => x.CounselorID,
                        principalTable: "Counselors",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CampersRelatives",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RelativeID = table.Column<int>(nullable: false),
                    CamperID = table.Column<int>(nullable: false),
                    CamperName = table.Column<string>(maxLength: 255, nullable: true),
                    RelativeName = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampersRelatives", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CampersRelatives_Campers_CamperID",
                        column: x => x.CamperID,
                        principalTable: "Campers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CampersRelatives_Relatives_RelativeID",
                        column: x => x.RelativeID,
                        principalTable: "Relatives",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CabinStatuses",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CabinID = table.Column<int>(nullable: false),
                    CamperID = table.Column<int>(nullable: false),
                    CabinArrival = table.Column<string>(maxLength: 255, nullable: true),
                    CabinDeparture = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CabinStatuses", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CabinStatuses_Cabins_CabinID",
                        column: x => x.CabinID,
                        principalTable: "Cabins",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CabinStatuses_Campers_CamperID",
                        column: x => x.CamperID,
                        principalTable: "Campers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cabins_CounselorID",
                table: "Cabins",
                column: "CounselorID");

            migrationBuilder.CreateIndex(
                name: "IX_CabinStatuses_CabinID",
                table: "CabinStatuses",
                column: "CabinID");

            migrationBuilder.CreateIndex(
                name: "IX_CabinStatuses_CamperID",
                table: "CabinStatuses",
                column: "CamperID");

            migrationBuilder.CreateIndex(
                name: "IX_CampersRelatives_CamperID",
                table: "CampersRelatives",
                column: "CamperID");

            migrationBuilder.CreateIndex(
                name: "IX_CampersRelatives_RelativeID",
                table: "CampersRelatives",
                column: "RelativeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CabinStatuses");

            migrationBuilder.DropTable(
                name: "CampersRelatives");

            migrationBuilder.DropTable(
                name: "Cabins");

            migrationBuilder.DropTable(
                name: "Campers");

            migrationBuilder.DropTable(
                name: "Relatives");

            migrationBuilder.DropTable(
                name: "Counselors");
        }
    }
}
