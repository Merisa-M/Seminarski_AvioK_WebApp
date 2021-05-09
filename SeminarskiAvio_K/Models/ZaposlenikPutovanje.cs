using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SeminarskiAvio_K.Models
{
    public class ZaposlenikPutovanje
    {
        [Key]
        public int ZaposlenikPutovanjeID { get; set; }
        [ForeignKey("Zaposlenik")]
        public int ZaposlenikID { get; set; }
        public Zaposlenik Zaposlenik { get; set; }
        [ForeignKey("Putovanje")]
        public int PutovanjeID { get; set; }
        public Putovanja Putovanje { get; set; }
    }
}
