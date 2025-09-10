using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_CORE_API.Migrations
{
    /// <inheritdoc />
    public partial class test3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "ItemsList");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "ItemsList",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
