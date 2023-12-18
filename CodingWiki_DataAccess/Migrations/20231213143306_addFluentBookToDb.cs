using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodingWiki_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addFluentBookToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fluent_Book_Publishers_Publisher_Id",
                table: "Fluent_Book");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Fluent_Book",
                table: "Fluent_Book");

            migrationBuilder.RenameTable(
                name: "Fluent_Book",
                newName: "Fluent_Books");

            migrationBuilder.RenameColumn(
                name: "Fluent_BookId",
                table: "Fluent_Books",
                newName: "BookId");

            migrationBuilder.RenameIndex(
                name: "IX_Fluent_Book_Publisher_Id",
                table: "Fluent_Books",
                newName: "IX_Fluent_Books_Publisher_Id");

            migrationBuilder.AlterColumn<string>(
                name: "ISBN",
                table: "Fluent_Books",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Fluent_Books",
                table: "Fluent_Books",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fluent_Books_Publishers_Publisher_Id",
                table: "Fluent_Books",
                column: "Publisher_Id",
                principalTable: "Publishers",
                principalColumn: "Publisher_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fluent_Books_Publishers_Publisher_Id",
                table: "Fluent_Books");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Fluent_Books",
                table: "Fluent_Books");

            migrationBuilder.RenameTable(
                name: "Fluent_Books",
                newName: "Fluent_Book");

            migrationBuilder.RenameColumn(
                name: "BookId",
                table: "Fluent_Book",
                newName: "Fluent_BookId");

            migrationBuilder.RenameIndex(
                name: "IX_Fluent_Books_Publisher_Id",
                table: "Fluent_Book",
                newName: "IX_Fluent_Book_Publisher_Id");

            migrationBuilder.AlterColumn<string>(
                name: "ISBN",
                table: "Fluent_Book",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Fluent_Book",
                table: "Fluent_Book",
                column: "Fluent_BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fluent_Book_Publishers_Publisher_Id",
                table: "Fluent_Book",
                column: "Publisher_Id",
                principalTable: "Publishers",
                principalColumn: "Publisher_Id");
        }
    }
}
