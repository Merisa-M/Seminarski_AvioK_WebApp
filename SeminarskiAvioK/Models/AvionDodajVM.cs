using Microsoft.AspNetCore.Mvc.Rendering;
using SeminarskiAvio_K.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeminarskiAvioK.Models
{
    public class AvionDodajVM
    {
        public Avion Avion { get; set; }
        public List<SelectListItem> klase { get; set; }
    }
}
