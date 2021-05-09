using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SeminarskiAvio_K.Models
{
    public class PutovanjeKupac
    {
        [Key]
        public int PutovanjeKupacID { get; set; }
        [Required(ErrorMessage = "Ocjena je obavezno polje")]
        [RegularExpression("[1-9]|10", ErrorMessage = "Ocjena je u rasponu izmedju 1 - 10")]
        public decimal Ocjena { get; set; }

        [ForeignKey("Putovanje")]
        public int PutovanjeID { get; set; }
        public Putovanja Putovanja { get; set; }

        [ForeignKey("Kupac")]
        public int KupacID { get; set; }
        public Kupac Kupac { get; set; }
    }
}
