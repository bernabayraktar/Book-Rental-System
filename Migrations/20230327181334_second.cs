using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BorrowingABook.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Borrows_BookId",
                table: "Borrows",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_Borrows_Books_BookId",
                table: "Borrows",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Borrows_Books_BookId",
                table: "Borrows");

            migrationBuilder.DropIndex(
                name: "IX_Borrows_BookId",
                table: "Borrows");
        }
    }
}
