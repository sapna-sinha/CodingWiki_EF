using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodingWiki_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class changeOnPublisherModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fluent_Books_Publishers_Publisher_Id1",
                table: "Fluent_Books");

            migrationBuilder.DropIndex(
                name: "IX_Fluent_Books_Publisher_Id1",
                table: "Fluent_Books");

            migrationBuilder.DropColumn(
                name: "Publisher_Id1",
                table: "Fluent_Books");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Publisher_Id1",
                table: "Fluent_Books",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Fluent_Books_Publisher_Id1",
                table: "Fluent_Books",
                column: "Publisher_Id1");

            migrationBuilder.AddForeignKey(
                name: "FK_Fluent_Books_Publishers_Publisher_Id1",
                table: "Fluent_Books",
                column: "Publisher_Id1",
                principalTable: "Publishers",
                principalColumn: "Publisher_Id");
        }
    }
}
