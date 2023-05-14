using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Labb4_MVC.Migrations
{
    /// <inheritdoc />
    public partial class AddedNewPropBookList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPastReturningDate",
                table: "BooksLists",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPastReturningDate",
                table: "BooksLists");
        }
    }
}
