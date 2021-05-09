using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeminarskiAvioK.Models
{
    public class NovostiPrikaziVM
    {
        public List<row> novosti { get; set; }
        public class row
        {
            public int id { get; set; }
            public string Naziv { get; set; }
            public string Tekst { get; set; }
            public string Sadrzaj { get; set; }
            public DateTime DatumObjave { get; set; }
            public string AdresaSlike { get; set; }
        }

    }
}
