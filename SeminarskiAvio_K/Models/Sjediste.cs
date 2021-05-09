using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SeminarskiAvio_K.Models
{
    public class Sjediste
    {
        [Key]
        public int SjedisteID { get; set; }
        [Required(ErrorMessage = "Red je obavezno polje")]
        [RegularExpression(@"[^0]+", ErrorMessage = "Ne može biti 0!")]
        public int Red { get; set; }

        [Required(ErrorMessage = "Kolona je obavezno polje")]
        [RegularExpression(@"[^0]+", ErrorMessage = "Ne može biti 0!")]
        public int Kolona { get; set; }

        [ForeignKey("Klasa")]
        public int KlasaID { get; set; }
        public Klasa Klasa { get; set; }
    }
}
