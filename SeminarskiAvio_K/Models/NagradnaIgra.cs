using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SeminarskiAvio_K.Models
{
    public class NagradnaIgra
    {
        [Key]
        public int NagradnaIgraID { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public DateTime Pocetak { get; set; }
        public DateTime Kraj { get; set; }
        [ForeignKey("Admin")]
        public int AdminID { get; set; }
        public Admin Admin { get; set; }
    }
}
