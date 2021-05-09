using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeminarskiAvioK.Models
{
    public class LetPrikaziVM
    {
        public List<row> letovi { get; set; }
        public class row
        {
            public int letid { get; set; }
            public string grad { get; set; }
            public string klasa { get; set; }

            public decimal Cijena { get; set; }
            public DateTime VrijemePolaska { get; set; }
        }
    }
}
