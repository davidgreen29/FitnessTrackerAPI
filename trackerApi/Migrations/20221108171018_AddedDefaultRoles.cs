using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace trackerApi.Migrations
{
    /// <inheritdoc />
    public partial class AddedDefaultRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "038d944c-52ac-4fe2-8801-2e1d0b55977d", "3fc1e610-b4d9-4592-85dd-f4c8adf0247e", "Administrator", "ADMINISTRATOR" },
                    { "04b71f17-f720-4b37-876a-4458e915ad4b", "525d2cd0-3368-44ed-a1a7-3fa5c5f6f52a", "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "038d944c-52ac-4fe2-8801-2e1d0b55977d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "04b71f17-f720-4b37-876a-4458e915ad4b");
        }
    }
}
