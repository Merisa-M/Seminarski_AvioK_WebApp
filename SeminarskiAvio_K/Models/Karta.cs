using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SeminarskiAvio_K.Models
{
    public class Karta
    {
        [Key]
        public int KartaID { get; set; }
        [ForeignKey("Kupac")]
        public int KupacID { get; set; }
        public Kupac Kupac { get; set; }

        [ForeignKey("Sjediste")]
        public int SjedisteID { get; set; }
        public Sjediste Sjediste { get; set; }

        [ForeignKey("Rezervacija")]
        public int RezervacijaID { get; set; }
        public Rezervacija Rezervacija { get; set; }

        [ForeignKey("Letovi")]
        public int LetID { get; set; }
        public Let Let { get; set; }
    }
}
