using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ServerScanPort.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Scanings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IpAdress = table.Column<string>(type: "text", nullable: true),
                    DateScan = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scanings", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Scanings",
                columns: new[] { "Id", "DateScan", "IpAdress" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 8, 28, 7, 42, 31, 260, DateTimeKind.Utc).AddTicks(3690), "123.123.123.123" },
                    { 2, new DateTime(2024, 8, 28, 7, 42, 31, 260, DateTimeKind.Utc).AddTicks(3728), "223.123.123.123" },
                    { 3, new DateTime(2024, 8, 28, 7, 42, 31, 260, DateTimeKind.Utc).AddTicks(3729), "323.123.123.123" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Scanings");
        }
    }
}
