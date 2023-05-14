using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Labb4_MVC.Migrations
{
    /// <inheritdoc />
    public partial class modifiedBook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Publised",
                table: "Books",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Publised",
                table: "Books");
        }
    }
}
