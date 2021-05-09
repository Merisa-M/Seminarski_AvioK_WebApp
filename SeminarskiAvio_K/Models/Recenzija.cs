using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SeminarskiAvio_K.Models
{
    public class Recenzija
    {
        [Key]
        public int RecenzijaID { get; set; }
        public string Sadrzaj { get; set; }
        public DateTime VrijemeKreiranja { get; set; }
        public bool Odobren { get; set; }
        [ForeignKey("Kupac")]
        public int KupacID { get; set; }
        public Kupac Kupac { get; set; }
        [ForeignKey("Putovanja")]
        public int PutovanjaID { get; set; }
        public Putovanja Putovanja { get; set; }
    }
}
