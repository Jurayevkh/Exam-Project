using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeneralMotors.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedCarClients : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarClient_Cars_CarId",
                table: "CarClient");

            migrationBuilder.DropForeignKey(
                name: "FK_CarClient_Clients_ClientId",
                table: "CarClient");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarClient",
                table: "CarClient");

            migrationBuilder.RenameTable(
                name: "CarClient",
                newName: "CarClients");

            migrationBuilder.RenameIndex(
                name: "IX_CarClient_ClientId",
                table: "CarClients",
                newName: "IX_CarClients_ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_CarClient_CarId",
                table: "CarClients",
                newName: "IX_CarClients_CarId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarClients",
                table: "CarClients",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CarClients_Cars_CarId",
                table: "CarClients",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarClients_Clients_ClientId",
                table: "CarClients",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarClients_Cars_CarId",
                table: "CarClients");

            migrationBuilder.DropForeignKey(
                name: "FK_CarClients_Clients_ClientId",
                table: "CarClients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarClients",
                table: "CarClients");

            migrationBuilder.RenameTable(
                name: "CarClients",
                newName: "CarClient");

            migrationBuilder.RenameIndex(
                name: "IX_CarClients_ClientId",
                table: "CarClient",
                newName: "IX_CarClient_ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_CarClients_CarId",
                table: "CarClient",
                newName: "IX_CarClient_CarId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarClient",
                table: "CarClient",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CarClient_Cars_CarId",
                table: "CarClient",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarClient_Clients_ClientId",
                table: "CarClient",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
