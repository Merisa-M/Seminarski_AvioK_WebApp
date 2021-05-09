using Microsoft.AspNetCore.Mvc.Rendering;
using SeminarskiAvio_K.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeminarskiAvioK.Models
{
    public class KupacDodajVM
    {
        public Kupac Kupac { get; set; }
        public int BrojTokena { get; set; }
        //public List<SelectListItem> gradovi { get; set; }
    }
}
