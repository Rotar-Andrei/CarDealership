using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarDealership.Migrations
{
    /// <inheritdoc />
    public partial class TDMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TDID",
                table: "Client",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TD",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TestDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TD", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Client_TDID",
                table: "Client",
                column: "TDID");

            migrationBuilder.AddForeignKey(
                name: "FK_Client_TD_TDID",
                table: "Client",
                column: "TDID",
                principalTable: "TD",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Client_TD_TDID",
                table: "Client");

            migrationBuilder.DropTable(
                name: "TD");

            migrationBuilder.DropIndex(
                name: "IX_Client_TDID",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "TDID",
                table: "Client");
        }
    }
}
