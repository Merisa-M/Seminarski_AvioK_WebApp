using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeminarskiAvioK.Models
{
    public class AvionPrikaziVM
    {
        public List<row> avioni { get; set; }

        public class row
        {
            public int AvionID { get; set; }
            public string Naziv { get; set; }
            public int kapacitet { get; set; }
            public string Klasa { get; set; }


        }
    }
}
