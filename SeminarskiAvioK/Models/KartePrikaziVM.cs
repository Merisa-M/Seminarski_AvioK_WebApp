using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeminarskiAvioK.Models
{
    public class KartePrikaziVM
    {
        public List<row> karte { get; set; }
        public int KupacID { get; set; }
        public class row
        {
            public string ImePrezime { get; set; }
            public string sjedista { get; set; }
            public string let { get; set; }
            public int karteiD { get; set; }
            public decimal Cijena { get; set; }
        }
    }
}
