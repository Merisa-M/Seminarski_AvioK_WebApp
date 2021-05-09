using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SeminarskiAvio_K.Models
{
    public class Novosti
    {
        [Key]
        public int NovostiID { get; set; }
        public string Naziv { get; set; }
        public string Tekst { get; set; }
        public string KratkiSadrzaj { get; set; }
        public DateTime DatumVrijemeObjave { get; set; }
        public string AdresaSlike { get; set; }
        [ForeignKey("Admin")]
        public int AdminID { get; set; }
        public Admin Admin { get; set; }
    }
}
