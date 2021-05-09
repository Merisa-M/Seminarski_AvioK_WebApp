using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeminarskiAvioK.Models
{
    public class KupacNagradnaIgraDodajVM
    {
        public SeminarskiAvio_K.Models.KupacNagradnaIgra KupacNagradnaIgra { get; set; }
 

        public List<SelectListItem> NagradnaIgra { get; set; }
        public int nagradnaIgraId { get; set; }

        public List<SelectListItem> Kupac { get; set; }
        public int kupacId { get; set; }
    }
}
