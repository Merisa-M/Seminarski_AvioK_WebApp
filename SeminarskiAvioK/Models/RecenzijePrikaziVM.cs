using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeminarskiAvioK.Models
{
    public class RecenzijePrikaziVM
    {
        public List<row> recenzije { get; set; }
        public int putovanjeid { get; set; }
        public string putovanje { get; set; }
        public class row
        {
            public int id { get; set; }
            public string sadrzaj { get; set; }
            public bool Odobren { get; set; }
            public string kupac { get; set; }
            public string putovanja { get; set; }
            public DateTime VrijemeKreiranja { get; set; }
        }
    }
}
