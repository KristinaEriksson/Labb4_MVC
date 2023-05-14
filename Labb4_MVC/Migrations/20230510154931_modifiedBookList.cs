using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Labb4_MVC.Migrations
{
    /// <inheritdoc />
    public partial class modifiedBookList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BooksLists_Books_BooksBookID",
                table: "BooksLists");

            migrationBuilder.DropForeignKey(
                name: "FK_BooksLists_Customers_CustomersCustomerID",
                table: "BooksLists");

            migrationBuilder.DropIndex(
                name: "IX_BooksLists_BooksBookID",
                table: "BooksLists");

            migrationBuilder.DropIndex(
                name: "IX_BooksLists_CustomersCustomerID",
                table: "BooksLists");

            migrationBuilder.DropColumn(
                name: "BooksBookID",
                table: "BooksLists");

            migrationBuilder.DropColumn(
                name: "CustomersCustomerID",
                table: "BooksLists");

            migrationBuilder.CreateIndex(
                name: "IX_BooksLists_FK_BookID",
                table: "BooksLists",
                column: "FK_BookID");

            migrationBuilder.CreateIndex(
                name: "IX_BooksLists_FK_CustomerID",
                table: "BooksLists",
                column: "FK_CustomerID");

            migrationBuilder.AddForeignKey(
                name: "FK_BooksLists_Books_FK_BookID",
                table: "BooksLists",
                column: "FK_BookID",
                principalTable: "Books",
                principalColumn: "BookID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BooksLists_Customers_FK_CustomerID",
                table: "BooksLists",
                column: "FK_CustomerID",
                principalTable: "Customers",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BooksLists_Books_FK_BookID",
                table: "BooksLists");

            migrationBuilder.DropForeignKey(
                name: "FK_BooksLists_Customers_FK_CustomerID",
                table: "BooksLists");

            migrationBuilder.DropIndex(
                name: "IX_BooksLists_FK_BookID",
                table: "BooksLists");

            migrationBuilder.DropIndex(
                name: "IX_BooksLists_FK_CustomerID",
                table: "BooksLists");

            migrationBuilder.AddColumn<int>(
                name: "BooksBookID",
                table: "BooksLists",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CustomersCustomerID",
                table: "BooksLists",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BooksLists_BooksBookID",
                table: "BooksLists",
                column: "BooksBookID");

            migrationBuilder.CreateIndex(
                name: "IX_BooksLists_CustomersCustomerID",
                table: "BooksLists",
                column: "CustomersCustomerID");

            migrationBuilder.AddForeignKey(
                name: "FK_BooksLists_Books_BooksBookID",
                table: "BooksLists",
                column: "BooksBookID",
                principalTable: "Books",
                principalColumn: "BookID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BooksLists_Customers_CustomersCustomerID",
                table: "BooksLists",
                column: "CustomersCustomerID",
                principalTable: "Customers",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
