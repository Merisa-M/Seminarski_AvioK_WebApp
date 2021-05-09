using Microsoft.EntityFrameworkCore.Migrations;

namespace SeminarskiAvio_K.Migrations
{
    public partial class prva : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kupac_Grad_GradID",
                table: "Kupac");

            migrationBuilder.DropIndex(
                name: "IX_Kupac_GradID",
                table: "Kupac");

            migrationBuilder.DropColumn(
                name: "GradID",
                table: "Kupac");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GradID",
                table: "Kupac",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Kupac_GradID",
                table: "Kupac",
                column: "GradID");

            migrationBuilder.AddForeignKey(
                name: "FK_Kupac_Grad_GradID",
                table: "Kupac",
                column: "GradID",
                principalTable: "Grad",
                principalColumn: "GradID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
