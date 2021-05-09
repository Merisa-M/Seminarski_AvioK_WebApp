using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeminarskiAvioK.Models
{
    public class NagradnaIgraKupacPrikazVM
    {

        public List<Row> lista { get; set; }
        public class Row
        {
            public int Id { get; set; }

            public int KupacId { get; set; }
            public int NagradnaIgraId { get; set; }
            public string Kupac { get; set; }
            public string Nagrada { get; set; }
        }
    }
}
