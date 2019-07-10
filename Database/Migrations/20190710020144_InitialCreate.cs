using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TradeData",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateTime = table.Column<DateTime>(nullable: false),
                    Qty = table.Column<int>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    Currency = table.Column<string>(nullable: true),
                    TradeType = table.Column<int>(nullable: false),
                    OrderInstruction = table.Column<string>(nullable: true),
                    OrderTransmission = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TradeData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TradeItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Status = table.Column<int>(nullable: false),
                    Side = table.Column<int>(nullable: false),
                    Ticker = table.Column<string>(nullable: true),
                    LastPrice = table.Column<decimal>(nullable: false),
                    TradeDataId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TradeItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TradeItem_TradeData_TradeDataId",
                        column: x => x.TradeDataId,
                        principalTable: "TradeData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "TradeData",
                columns: new[] { "Id", "Amount", "Currency", "DateTime", "Description", "OrderInstruction", "OrderTransmission", "Qty", "TradeType" },
                values: new object[,]
                {
                    { 1, 100m, "CAD", new DateTime(2019, 7, 10, 3, 1, 44, 396, DateTimeKind.Local), "", "day order", "broker", 100000, 1 },
                    { 2, 200m, "EUR", new DateTime(2019, 7, 10, 3, 1, 44, 404, DateTimeKind.Local), "", "day order", "ATF", 200000, 0 },
                    { 3, 300m, "GBP", new DateTime(2019, 7, 10, 3, 1, 44, 404, DateTimeKind.Local), "", "kill", "ECN", 300000, 2 },
                    { 4, 400m, "CAD", new DateTime(2019, 7, 10, 3, 1, 44, 404, DateTimeKind.Local), "", "day order", "broker", 400000, 1 },
                    { 5, 500m, "ZAR", new DateTime(2019, 7, 10, 3, 1, 44, 404, DateTimeKind.Local), "", "day order", "broker", 500000, 0 },
                    { 6, 600m, "GBP", new DateTime(2019, 7, 10, 3, 1, 44, 404, DateTimeKind.Local), "", "kill", "ECN", 600000, 2 },
                    { 7, 700m, "USD", new DateTime(2019, 7, 10, 3, 1, 44, 404, DateTimeKind.Local), "", "fill", "broker", 700000, 1 }
                });

            migrationBuilder.InsertData(
                table: "TradeItem",
                columns: new[] { "Id", "LastPrice", "Side", "Status", "Ticker", "TradeDataId" },
                values: new object[,]
                {
                    { 1, 1.11m, 0, 0, "RTR", null },
                    { 2, 1.12m, 0, 0, "LLOYDS", null },
                    { 3, 1.13m, 0, 0, "DEUET", null },
                    { 4, 1.14m, 0, 0, "BARC", null },
                    { 5, 1.15m, 0, 0, "REDB", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TradeItem_TradeDataId",
                table: "TradeItem",
                column: "TradeDataId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TradeItem");

            migrationBuilder.DropTable(
                name: "TradeData");
        }
    }
}
