using SeminarskiAvio_K.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeminarskiAvioK.Models
{
    public class PutovanjeKupacVM
    {
        public int putovanjeid { get; set; }
        public string putovanje { get; set; }
        public PutovanjeKupac PutovanjeKupac { get; set; }
    }
}
