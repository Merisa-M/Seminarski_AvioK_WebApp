using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SeminarskiAvio_K.Models
{
    public class Kupac
    {
        [Key]
        public int KupacID { get; set; }

        [Required(ErrorMessage = "Ime je obavezno polje")]
        [RegularExpression(@"^[a-zA-Z]*$", ErrorMessage = "Ime sadrzi samo slova")]

        public string Ime { get; set; }
        [Required(ErrorMessage = "Prezime je obavezno")]
        [RegularExpression(@"^[a-zA-Z]*$", ErrorMessage = "Prezime sadrzi samo slova")]
        public string Prezime { get; set; }
        [Required(ErrorMessage = "Broj telefona je obavezno")]
        public string BrojTelefona { get; set; }
       
        public int BrojTokena { get; set; }
        public string Email { get; set; }
        public KorisnickiNalog KorisnickiNalog { get; set; }
        public int KorisnickiNalogID { get; set; }
    }
}
