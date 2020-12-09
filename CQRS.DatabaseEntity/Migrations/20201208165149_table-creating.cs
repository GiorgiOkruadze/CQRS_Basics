using Microsoft.EntityFrameworkCore.Migrations;

namespace CQRS.DatabaseEntity.Migrations
{
    public partial class tablecreating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reseller",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SellerName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reseller", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Volume",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SizeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Volume", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Volume_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductReseller",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ResellerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductReseller", x => new { x.ProductId, x.ResellerId });
                    table.ForeignKey(
                        name: "FK_ProductReseller_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductReseller_Reseller_ResellerId",
                        column: x => x.ResellerId,
                        principalTable: "Reseller",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductReseller_ResellerId",
                table: "ProductReseller",
                column: "ResellerId");

            migrationBuilder.CreateIndex(
                name: "IX_Volume_ProductId",
                table: "Volume",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductReseller");

            migrationBuilder.DropTable(
                name: "Volume");

            migrationBuilder.DropTable(
                name: "Reseller");

            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
