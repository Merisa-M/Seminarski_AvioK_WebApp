using Microsoft.EntityFrameworkCore.Migrations;

namespace SeminarskiAvio_K.Migrations
{
    public partial class dataseed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "KorisnickiNalog",
                columns: new[] { "KorisnickiNalogID", "KorisnickoIme", "Lozinka" },
                values: new object[] { 1, "admin", "admin" });

            migrationBuilder.InsertData(
                table: "KorisnickiNalog",
                columns: new[] { "KorisnickiNalogID", "KorisnickoIme", "Lozinka" },
                values: new object[] { 2, "test", "test" });

            migrationBuilder.InsertData(
                table: "Admin",
                columns: new[] { "AdminID", "Ime", "KorisnickiNalogID", "Prezime" },
                values: new object[] { 1, "Admin", 1, "Admin" });

            migrationBuilder.InsertData(
                table: "Kupac",
                columns: new[] { "KupacID", "BrojTelefona", "BrojTokena", "Email", "Ime", "KorisnickiNalogID", "Prezime" },
                values: new object[] { 1, "061-111-111", 20, "prezime.ime@gmail.com", "ImeKupca", 2, "PrezimeKupca" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Admin",
                keyColumn: "AdminID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Kupac",
                keyColumn: "KupacID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "KorisnickiNalog",
                keyColumn: "KorisnickiNalogID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "KorisnickiNalog",
                keyColumn: "KorisnickiNalogID",
                keyValue: 2);
        }
    }
}
