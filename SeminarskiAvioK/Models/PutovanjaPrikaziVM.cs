using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeminarskiAvioK.Models
{
    public class PutovanjaPrikaziVM
    {
        public List<row> putovanja { get; set; }
        public class row
        {
            public int id { get; set; }
            public string Naziv { get; set; }
            public string Opis { get; set; }
            public string NazivGrada { get; set; }

            public decimal prosjecnaOcjena { get; set; }
        }
    }
}
