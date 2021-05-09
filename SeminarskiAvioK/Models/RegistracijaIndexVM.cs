using Microsoft.AspNetCore.Mvc.Rendering;
using SeminarskiAvio_K.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeminarskiAvioK.Models
{
    public class RegistracijaIndexVM
    {
        public KorisnickiNalog KorisnickiNalog { get; set; }
        public Kupac Kupac { get; set; }
        public List<SelectListItem> gradovi { get; set; }
    }
}
