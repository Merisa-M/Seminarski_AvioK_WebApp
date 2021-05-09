using SeminarskiAvio_K.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeminarskiAvioK.Models
{
    public class RecenzijaDodajVM
    {
        public int id { get; set; }
        public string putovanje { get; set; }
        public Recenzija Recenzija { get; set; }
    }
}
