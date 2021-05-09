using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SeminarskiAvio_K.Models
{
    public class Avion
    {
        [Key]
        public int AvionID { get; set; }
        [Required(ErrorMessage = "Naziv je obavezno polje")]
        public string Naziv { get; set; }

        [Required(ErrorMessage = "Kapacitet je obavezno polje")]
        [Range(40, 500, ErrorMessage = "Kapacitet treba biti u opsegu 40-500")]
        public int Kapacitet { get; set; }
        [ForeignKey("Klasa")]
        [Required(ErrorMessage = "Grad je obavezno polje")]
        public int KlasaID { get; set; }
        public Klasa Klasa { get; set; }
    }
}
