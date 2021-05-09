using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeminarskiAvioK.Models
{
    public class NagradnaIgraUrediVM
    {

        public int id { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }

        public DateTime Pocetak { get; set; }
        public DateTime Kraj { get; set; }
    }
}
