using Microsoft.EntityFrameworkCore;
using SeminarskiAvio_K.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeminarskiAvio_K
{
    public class MyContext : DbContext
    {
        public DbSet<Admin> Admin { get; set; }
        public DbSet<AutorizacijskiToken> AutorizacijskiToken { get; set; }
        public DbSet<Avion> Avion { get; set; }
        public DbSet<Grad> Grad { get; set; }
        public DbSet<Karta> Karta { get; set; }
        public DbSet<Klasa> Klasa { get; set; }
        public DbSet<KorisnickiNalog> KorisnickiNalog { get; set; }
        public DbSet<Kupac> Kupac { get; set; }
        public DbSet<KupacNagradnaIgra> KupacNagradnaIgra { get; set; }
        public DbSet<Let> Let { get; set; }
        public DbSet<NagradnaIgra> NagradnaIgra { get; set; }
        public DbSet<Novosti> Novosti { get; set; }

        public DbSet<PutovanjeKupac> PutovanjeKupac { get; set; }
        public DbSet<Recenzija> Recenzija { get; set; }

        public DbSet<Rezervacija> Rezervacija { get; set; }
        public DbSet<Sjediste> Sjediste { get; set; }
        public DbSet<Zaposlenik> Zaposlenik { get; set; }
        public DbSet<ZaposlenikPutovanje> ZaposlenikPutovanje { get; set; }
        public DbSet<Putovanja> Putovanja { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString: @"Server=.;Database=SeminarskiAvioK;Trusted_Connection=True;MultipleActiveResultSets=true;");
        }
    }
}
