using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DreamWedds.Services.OrderAPI.Migrations
{
    /// <inheritdoc />
    public partial class productidclientordstr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ClientOrderId",
                table: "OrderHeaders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClientOrderId",
                table: "OrderHeaders");
        }
    }
}
