using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pasteleria.Migrations
{
    /// <inheritdoc />
    public partial class AllTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReservationId",
                table: "Client",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CalendaryId",
                table: "Client",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Reservation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReservationStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReservationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationStatus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReservationStatus_Reservation_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservation",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Calendary",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReservationId = table.Column<int>(type: "int", nullable: true),
                    ReservationId1 = table.Column<int>(type: "int", nullable: true),
                    ReservationId2 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calendary", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Calendary_Reservation_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservation",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Calendary_Reservation_ReservationId1",
                        column: x => x.ReservationId1,
                        principalTable: "Reservation",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Schedule_Reservation_ReservationId2",
                        column: x => x.ReservationId2,
                        principalTable: "Reservation",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Cake",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReservationId = table.Column<int>(type: "int", nullable: true),
                    ReservationId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cake", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cake_Reservation_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservation",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Cake_Reservation_ReservationId1",
                        column: x => x.ReservationId1,
                        principalTable: "Reservation",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CakeTime",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReservationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CakeTime", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CakeTime_Reservation_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservation",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Client_ReservationId",
                table: "Client",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_Client_ReservationId",
                table: "Client",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationStatus_ReservationId",
                table: "ReservationStatus",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_Calendary_ReservationId",
                table: "Calendary",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_Calendary_ReservationId1",
                table: "Calendary",
                column: "ReservationId1");

            migrationBuilder.CreateIndex(
                name: "IX_Calendary_ReservationId2",
                table: "Calendary",
                column: "ReservationId2");

            migrationBuilder.CreateIndex(
                name: "IX_Cake_ReservationId",
                table: "Cake",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_Cake_ReservationId1",
                table: "Cake",
                column: "ReservationId1");

            migrationBuilder.CreateIndex(
                name: "IX_CAKETime_calendaryId",
                table: "CakeTime",
                column: "CalendaryId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Reservation_ReservationId",
                table: "Client",
                column: "ReservationId",
                principalTable: "Reservation",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Client_Reservation_ReservationId",
                table: "Clinet",
                column: "CalendaryId",
                principalTable: "Calendary",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Client_Reservation_ReservationId",
                table: "Client");

            migrationBuilder.DropForeignKey(
                name: "FK_Client_Calendary_ReservationId",
                table: "Client");

            migrationBuilder.DropTable(
                name: "ReservationStatus");

            migrationBuilder.DropTable(
                name: "Cake");

            migrationBuilder.DropTable(
                name: "CakeTime");

            migrationBuilder.DropTable(
                name: "Calendary");

            migrationBuilder.DropTable(
                name: "Reservation");

            migrationBuilder.DropIndex(
                name: "IX_Client_ReservationId",
                table: "Client");

            migrationBuilder.DropIndex(
                name: "IX_Client_ReservationId",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "ReservationId",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "ReservationId",
                table: "Client");
        }
    }
}
