using Microsoft.AspNetCore.Http;
using SeminarskiAvio_K.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeminarskiAvioK.Models
{
    public class ZaposenikDodajVM
    {
        public Zaposlenik Zaposlenik { get; set; }
        public IFormFile Photo { get; set; }
    }
}
