using Microsoft.EntityFrameworkCore.Migrations;

namespace MoviesLab2.Migrations
{
    public partial class AddMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Movies_MovieId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_MovieId",
                table: "Comments");

            migrationBuilder.AlterColumn<int>(
                name: "MovieId",
                table: "Comments",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "MovieId1",
                table: "Comments",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_MovieId1",
                table: "Comments",
                column: "MovieId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Movies_MovieId1",
                table: "Comments",
                column: "MovieId1",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Movies_MovieId1",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_MovieId1",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "MovieId1",
                table: "Comments");

            migrationBuilder.AlterColumn<long>(
                name: "MovieId",
                table: "Comments",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Comments_MovieId",
                table: "Comments",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Movies_MovieId",
                table: "Comments",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
