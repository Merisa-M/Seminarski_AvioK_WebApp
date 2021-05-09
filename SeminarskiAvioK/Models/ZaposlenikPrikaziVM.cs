using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeminarskiAvioK.Models
{
    public class ZaposlenikPrikaziVM
    {
        public List<row> zaposlenici { get; set; }
        public class row
        {
            public int Id { get; set; }
            public string Ime { get; set; }
            public string Prezime { get; set; }
            public string BrojUgovora { get; set; }
            public string Email { get; set; }
            public DateTime DatumRodjenja { get; set; }
            public string adresaaSlike { get; set; }
        }
    }
}
