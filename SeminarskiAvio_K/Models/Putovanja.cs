using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SeminarskiAvio_K.Models
{
    public class Putovanja
    {
        [Key]
        public int PutovanjaID { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }

        public decimal ProsjecnaOcjena { get; set; }
        [ForeignKey("Grad")]
        public int GradID { get; set; }
        public Grad Grad { get; set; }
    }
}
