using Microsoft.EntityFrameworkCore;
using SeminarskiAvio_K.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeminarskiAvio_K
{
    public partial class MyContext
    {
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<KorisnickiNalog>().HasData(
                new KorisnickiNalog { KorisnickiNalogID = 1, KorisnickoIme = "admin", Lozinka = "admin" },
                new KorisnickiNalog { KorisnickiNalogID = 2, KorisnickoIme = "test", Lozinka = "test" }


                );

            modelBuilder.Entity<Admin>().HasData
            (
                new Admin
                {
                    AdminID = 1,
                    Ime = "Admin",
                    Prezime = "Admin",
                    KorisnickiNalogID = 1


                }
                );

            modelBuilder.Entity<Kupac>().HasData(
                
                new Kupac
                {
                    KupacID = 1,
                    Ime = "ImeKupca",
                    Prezime = "PrezimeKupca",
                    BrojTelefona = "061-111-111",
                    BrojTokena = 20,
                    Email = "prezime.ime@gmail.com",
                    KorisnickiNalogID = 2

                }
                );
        }
    }
}
