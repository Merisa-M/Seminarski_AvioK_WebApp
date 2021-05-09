using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeminarskiAvioK.Models
{
    public class KlasaPrikaziVM
    {
        public List<row> klase { get; set; }
        public class row
        {
            public int ID { get; set; }
            public string Naziv { get; set; }
        }
    }
}
