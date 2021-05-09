using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeminarskiAvioK.Models
{
    public class PutovanjaUrediVM
    {
        public int putovanjeid { get; set; }
        public decimal ocjena { get; set; }
        public string naziv { get; set; }
        public string opis { get; set; }


        public List<SelectListItem> gradovi { get; set; }
        public int GradID { get; set; }
    }
}
