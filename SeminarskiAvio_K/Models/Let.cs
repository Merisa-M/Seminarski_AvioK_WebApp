using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SeminarskiAvio_K.Models
{
    public class Let
    {
        [Key]
        public int LetID { get; set; }

        public int Trajanje { get; set; }
        public decimal Cijena { get; set; }

        public DateTime VrijemePolaska { get; set; }


        [ForeignKey("Grad")]
        [Required(ErrorMessage = "Grad je obavezno polje")]
        public int GradID { get; set; }
        public Grad Grad { get; set; }


        [ForeignKey("Klasa")]
        public int KlasaID { get; set; }
        public Klasa Klasa { get; set; }
    }
}
