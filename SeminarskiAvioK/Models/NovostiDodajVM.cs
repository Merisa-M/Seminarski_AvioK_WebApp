using Microsoft.AspNetCore.Http;
using SeminarskiAvio_K.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeminarskiAvioK.Models
{
    public class NovostiDodajVM
    {
        public Novosti Novosti { get; set; }
        public IFormFile Slika { get; set; }
    }
}
