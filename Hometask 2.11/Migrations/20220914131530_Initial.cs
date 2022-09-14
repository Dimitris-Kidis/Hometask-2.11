using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hometask_2._11.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Topic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Schedules_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Age", "FullName", "Gender" },
                values: new object[] { 1, 25, "Jorja Smith", "Female" });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Age", "FullName", "Gender" },
                values: new object[] { 2, 33, "Adele Adkins", "Female" });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Age", "FullName", "Gender" },
                values: new object[] { 3, 41, "Phillip Anderson", "Male" });

            migrationBuilder.InsertData(
                table: "Schedules",
                columns: new[] { "Id", "ClientId", "Date", "Time", "Topic" },
                values: new object[,]
                {
                    { 9, 1, "09/07/2022", "09:30", "Work Meeting" },
                    { 10, 1, "09/07/2022", "12:10", "Talking" },
                    { 11, 1, "09/07/2022", "16:00", "English Practice" },
                    { 12, 1, "09/07/2022", "20:00", "Family Call" },
                    { 13, 2, "10/01/2022", "09:30", "Rehearsal" },
                    { 14, 2, "09/07/2022", "12:10", null },
                    { 15, 2, "01/01/2022", "21:00", "Relax" },
                    { 16, 3, "02/04/2022", "13:50", "Lecture Time" },
                    { 17, 3, "04/09/2022", "09:00", "Vacation" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_ClientId",
                table: "Schedules",
                column: "ClientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
