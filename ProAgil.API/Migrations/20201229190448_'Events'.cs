using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProAgil.API.Migrations
{
    public partial class Events : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    EventId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Local = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    DateEvent = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Theme = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    QtyPeoples = table.Column<int>(type: "int", nullable: false),
                    Lot = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    ImageUri = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.EventId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events");
        }
    }
}
