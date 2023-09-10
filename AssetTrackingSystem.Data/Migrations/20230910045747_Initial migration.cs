using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AssetTrackingSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initialmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AssetTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Manufacturers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Models",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ManufacturerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Models", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Models_Manufacturers_ManufacturerID",
                        column: x => x.ManufacturerID,
                        principalTable: "Manufacturers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Assets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TagNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AssetTypeId = table.Column<int>(type: "int", nullable: false),
                    ManufacturerId = table.Column<int>(type: "int", nullable: false),
                    ModelId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AssignedTo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    SerialNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assets_AssetTypes_AssetTypeId",
                        column: x => x.AssetTypeId,
                        principalTable: "AssetTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Assets_Manufacturers_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "Manufacturers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Assets_Models_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Models",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AssetTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Desktop PC" },
                    { 2, "Laptop" },
                    { 3, "Tablet" },
                    { 4, "Monitor" },
                    { 5, "Mobile Phone" },
                    { 6, "Desk Phone" }
                });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Dell" },
                    { 2, "HP" },
                    { 3, "Acer" },
                    { 4, "Apple" },
                    { 5, "Samsung" },
                    { 6, "LG" },
                    { 7, "Avaya" },
                    { 8, "Polycom" },
                    { 9, "Cisco" }
                });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "ManufacturerID", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Dell Inspiron" },
                    { 2, 1, "Dell XPS" },
                    { 3, 2, "HP Elite" },
                    { 4, 3, "Acer Aspire" },
                    { 5, 1, "Dell Latitude E4550" },
                    { 6, 1, "Dell Latitude E5550" },
                    { 7, 4, "Apple MacBook Air" },
                    { 8, 4, "Apple MacBook Pro" },
                    { 9, 4, "Apple iPad mini" },
                    { 10, 4, "Apple iPad Air" },
                    { 11, 5, "Samsung Galaxy Tab3" },
                    { 12, 3, "Acer S200" },
                    { 13, 3, "Acer STQ414" },
                    { 14, 6, "LG 22MP" },
                    { 15, 2, "HP Pavilion" },
                    { 16, 4, "Apple iPhone 5" },
                    { 17, 4, "Apple iPhone 6" },
                    { 18, 5, "Samsung Galaxy S4" },
                    { 19, 5, "Samsung Galaxy S5" },
                    { 20, 5, "Samsung Galaxy Note5" },
                    { 21, 7, "Avaya 9612G" },
                    { 22, 8, "Polycom SoundPoint331" },
                    { 23, 9, "Cisco SPA525G2" }
                });

            migrationBuilder.InsertData(
                table: "Assets",
                columns: new[] { "Id", "AssetTypeId", "AssignedTo", "Description", "ManufacturerId", "ModelId", "SerialNumber", "TagNumber" },
                values: new object[,]
                {
                    { 1, 1, "EMP001", "Dell Inspiron Desktop", 1, 1, "SN001", "TAG001" },
                    { 2, 1, "EMP002", "Dell XPS Desktop", 1, 2, "SN002", "TAG002" },
                    { 3, 1, "EMP003", "HP Elite Desktop", 2, 3, "SN003", "TAG003" },
                    { 4, 1, "EMP004", "Acer Aspire Desktop", 3, 4, "SN004", "TAG004" },
                    { 5, 2, "EMP001", "Dell Latitude E4550 Laptop", 1, 5, "SN005", "TAG005" },
                    { 6, 2, "EMP002", "Dell Latitude E5550 Laptop", 1, 6, "SN006", "TAG006" },
                    { 7, 2, "EMP003", "Apple MacBook Air Laptop", 4, 7, "SN007", "TAG007" },
                    { 8, 2, "EMP004", "Apple MacBook Pro Laptop", 4, 8, "SN008", "TAG008" },
                    { 9, 3, "EMP001", "Apple iPad mini Tablet", 4, 10, "SN009", "TAG009" },
                    { 10, 3, "EMP002", "Apple iPad Air Tablet", 4, 11, "SN010", "TAG010" },
                    { 11, 3, "EMP003", "Samsung Galaxy Tab3 Tablet", 5, 12, "SN011", "TAG011" },
                    { 12, 4, "EMP004", "Acer S200 Monitor", 3, 13, "SN012", "TAG012" },
                    { 13, 4, "EMP001", "Acer STQ414 Monitor", 3, 14, "SN013", "TAG013" },
                    { 14, 4, "EMP002", "LG 22MP Monitor", 6, 15, "SN014", "TAG014" },
                    { 15, 4, "EMP003", "HP Pavilion Monitor", 2, 16, "SN015", "TAG015" },
                    { 16, 5, "EMP004", "Apple iPhone 5", 4, 17, "SN016", "TAG016" },
                    { 17, 5, "EMP001", "Apple iPhone 6", 4, 18, "SN017", "TAG017" },
                    { 18, 5, "EMP002", "Samsung Galaxy S4", 5, 19, "SN018", "TAG018" },
                    { 19, 5, "EMP003", "Samsung Galaxy S5", 5, 20, "SN019", "TAG019" },
                    { 20, 5, "EMP004", "Samsung Galaxy Note5", 5, 21, "SN020", "TAG020" },
                    { 21, 6, "EMP001", "Avaya 9612G Desk Phone", 7, 22, "SN021", "TAG021" },
                    { 22, 6, "EMP002", "Polycom SoundPoint331 Desk Phone", 8, 23, "SN022", "TAG022" },
                    { 23, 6, "EMP003", "Cisco SPA525G2 Desk Phone", 9, 23, "SN023", "TAG023" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assets_AssetTypeId",
                table: "Assets",
                column: "AssetTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Assets_ManufacturerId",
                table: "Assets",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_Assets_ModelId",
                table: "Assets",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Models_ManufacturerID",
                table: "Models",
                column: "ManufacturerID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assets");

            migrationBuilder.DropTable(
                name: "AssetTypes");

            migrationBuilder.DropTable(
                name: "Models");

            migrationBuilder.DropTable(
                name: "Manufacturers");
        }
    }
}
