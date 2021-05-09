using Microsoft.AspNetCore.Mvc.Rendering;
using SeminarskiAvio_K.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeminarskiAvioK.Models
{
    public class LetDodajVM
    {
        public Let Let { get; set; }
        public List<SelectListItem> klase { get; set; }
        public List<SelectListItem> gradovi { get; set; }
    }
}
