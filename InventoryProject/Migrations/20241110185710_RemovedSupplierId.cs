using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryProject.Migrations
{
    /// <inheritdoc />
    public partial class RemovedSupplierId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Suppliers_SupplierId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_SupplierId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                table: "Transactions");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SupplierId",
                table: "Transactions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_SupplierId",
                table: "Transactions",
                column: "SupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Suppliers_SupplierId",
                table: "Transactions",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "SupplierId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
