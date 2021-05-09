using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeminarskiAvioK.Models
{
    public class GradPrikaziVM
    {
        public List<row> gradovi { get; set; }
        public class row
        {
            public int id { get; set; }
            public string Naziv { get; set; }
        }
    }
}
