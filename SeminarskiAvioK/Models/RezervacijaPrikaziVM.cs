using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeminarskiAvioK.Models
{
    public class RezervacijaPrikaziVM
    {
        public List<row> rezervacije { get; set; }
        public int kupacid { get; set; }
        public int putovanjeid { get; set; }

        public class row
        {
            public string ImePrezime { get; set; }
            public string prikazivanje { get; set; }
            public DateTime DatumRezervacije { get; set; }
            public DateTime DatumIsteka { get; set; }
            public bool Odobren { get; set; }
            public int id { get; set; }
        }
    }
}
