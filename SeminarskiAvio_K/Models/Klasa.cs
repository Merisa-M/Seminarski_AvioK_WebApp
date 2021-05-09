using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SeminarskiAvio_K.Models
{
    public class Klasa
    {
        [Key]
        public int KlasaID { get; set; }
        public string Naziv { get; set; }
    }
}
