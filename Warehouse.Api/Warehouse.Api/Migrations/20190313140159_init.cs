using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Warehouse.Api.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sequences",
                columns: table => new
                {
                    SequenceId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    entityname = table.Column<string>(nullable: true),
                    seq = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sequences", x => x.SequenceId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    code = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    createdDate = table.Column<DateTime>(nullable: false),
                    lastUpdatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "LocationTypes",
                columns: table => new
                {
                    LocationTypeId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    code = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    createdDate = table.Column<DateTime>(nullable: false),
                    lastUpdatedDate = table.Column<DateTime>(nullable: false),
                    createdUserId = table.Column<int>(nullable: true),
                    lastUpdatedUserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationTypes", x => x.LocationTypeId);
                    table.ForeignKey(
                        name: "FK_LocationTypes_Users_createdUserId",
                        column: x => x.createdUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LocationTypes_Users_lastUpdatedUserId",
                        column: x => x.lastUpdatedUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MovementTypes",
                columns: table => new
                {
                    MovementTypeId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    code = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    createdDate = table.Column<DateTime>(nullable: false),
                    lastUpdatedDate = table.Column<DateTime>(nullable: false),
                    createdUserId = table.Column<int>(nullable: true),
                    lastUpdatedUserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovementTypes", x => x.MovementTypeId);
                    table.ForeignKey(
                        name: "FK_MovementTypes_Users_createdUserId",
                        column: x => x.createdUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MovementTypes_Users_lastUpdatedUserId",
                        column: x => x.lastUpdatedUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    code = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    articlecode = table.Column<string>(nullable: true),
                    gtin = table.Column<string>(nullable: true),
                    createdDate = table.Column<DateTime>(nullable: false),
                    lastUpdatedDate = table.Column<DateTime>(nullable: false),
                    createdUserId = table.Column<int>(nullable: true),
                    lastUpdatedUserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Users_createdUserId",
                        column: x => x.createdUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Users_lastUpdatedUserId",
                        column: x => x.lastUpdatedUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    LocationId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    code = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    outline = table.Column<string>(nullable: true),
                    coords = table.Column<string>(nullable: true),
                    parentLocationId = table.Column<int>(nullable: true),
                    locationTypeId = table.Column<int>(nullable: false),
                    createdDate = table.Column<DateTime>(nullable: false),
                    lastUpdatedDate = table.Column<DateTime>(nullable: false),
                    createdUserId = table.Column<int>(nullable: true),
                    lastUpdatedUserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.LocationId);
                    table.ForeignKey(
                        name: "FK_Locations_Users_createdUserId",
                        column: x => x.createdUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Locations_Users_lastUpdatedUserId",
                        column: x => x.lastUpdatedUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Locations_LocationTypes_locationTypeId",
                        column: x => x.locationTypeId,
                        principalTable: "LocationTypes",
                        principalColumn: "LocationTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Locations_Locations_parentLocationId",
                        column: x => x.parentLocationId,
                        principalTable: "Locations",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Plants",
                columns: table => new
                {
                    PlantId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    code = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    locationId = table.Column<int>(nullable: false),
                    plantCoords = table.Column<string>(nullable: true),
                    createdDate = table.Column<DateTime>(nullable: false),
                    lastUpdatedDate = table.Column<DateTime>(nullable: false),
                    createdUserId = table.Column<int>(nullable: true),
                    lastUpdatedUserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plants", x => x.PlantId);
                    table.ForeignKey(
                        name: "FK_Plants_Users_createdUserId",
                        column: x => x.createdUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Plants_Users_lastUpdatedUserId",
                        column: x => x.lastUpdatedUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Plants_Locations_locationId",
                        column: x => x.locationId,
                        principalTable: "Locations",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    StockId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    productId = table.Column<int>(nullable: false),
                    plantId = table.Column<int>(nullable: false),
                    movementTypeId = table.Column<int>(nullable: false),
                    barcode = table.Column<string>(nullable: true),
                    parentStockId = table.Column<int>(nullable: true),
                    quantity = table.Column<int>(nullable: false),
                    createdDate = table.Column<DateTime>(nullable: false),
                    lastUpdatedDate = table.Column<DateTime>(nullable: false),
                    createdUserId = table.Column<int>(nullable: true),
                    lastUpdatedUserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.StockId);
                    table.ForeignKey(
                        name: "FK_Stocks_Users_createdUserId",
                        column: x => x.createdUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Stocks_Users_lastUpdatedUserId",
                        column: x => x.lastUpdatedUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Stocks_MovementTypes_movementTypeId",
                        column: x => x.movementTypeId,
                        principalTable: "MovementTypes",
                        principalColumn: "MovementTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Stocks_Stocks_parentStockId",
                        column: x => x.parentStockId,
                        principalTable: "Stocks",
                        principalColumn: "StockId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Stocks_Plants_plantId",
                        column: x => x.plantId,
                        principalTable: "Plants",
                        principalColumn: "PlantId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Stocks_Products_productId",
                        column: x => x.productId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Locations_createdUserId",
                table: "Locations",
                column: "createdUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_lastUpdatedUserId",
                table: "Locations",
                column: "lastUpdatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_locationTypeId",
                table: "Locations",
                column: "locationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_parentLocationId",
                table: "Locations",
                column: "parentLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_LocationTypes_createdUserId",
                table: "LocationTypes",
                column: "createdUserId");

            migrationBuilder.CreateIndex(
                name: "IX_LocationTypes_lastUpdatedUserId",
                table: "LocationTypes",
                column: "lastUpdatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MovementTypes_createdUserId",
                table: "MovementTypes",
                column: "createdUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MovementTypes_lastUpdatedUserId",
                table: "MovementTypes",
                column: "lastUpdatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Plants_createdUserId",
                table: "Plants",
                column: "createdUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Plants_lastUpdatedUserId",
                table: "Plants",
                column: "lastUpdatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Plants_locationId",
                table: "Plants",
                column: "locationId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_createdUserId",
                table: "Products",
                column: "createdUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_lastUpdatedUserId",
                table: "Products",
                column: "lastUpdatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_createdUserId",
                table: "Stocks",
                column: "createdUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_lastUpdatedUserId",
                table: "Stocks",
                column: "lastUpdatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_movementTypeId",
                table: "Stocks",
                column: "movementTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_parentStockId",
                table: "Stocks",
                column: "parentStockId");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_plantId",
                table: "Stocks",
                column: "plantId");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_productId",
                table: "Stocks",
                column: "productId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sequences");

            migrationBuilder.DropTable(
                name: "Stocks");

            migrationBuilder.DropTable(
                name: "MovementTypes");

            migrationBuilder.DropTable(
                name: "Plants");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "LocationTypes");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
