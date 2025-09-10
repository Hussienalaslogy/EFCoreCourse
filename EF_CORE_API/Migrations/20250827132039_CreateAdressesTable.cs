using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_CORE_API.Migrations
{
    /// <inheritdoc />
    public partial class CreateAdressesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomersAdresses",
                columns: table => new
                {
                    CustomerNo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BuildingNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomersAdresses", x => x.CustomerNo);
                    table.ForeignKey(
                        name: "FK_CustomersAdresses_CustomersListH_CustomerNo",
                        column: x => x.CustomerNo,
                        principalTable: "CustomersListH",
                        principalColumn: "CustomerNo",
                        onDelete: ReferentialAction.Restrict);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomersAdresses");
        }
    }
}
