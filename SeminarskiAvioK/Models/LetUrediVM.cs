using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeminarskiAvioK.Models
{
    public class LetUrediVM
    {

        public int id { get; set; }
        public decimal Cijena { get; set; }
        public DateTime VrijemePolaska { get; set; }
        public List<SelectListItem> klase { get; set; }
        public int klasaid { get; set; }
        public List<SelectListItem> gradovi { get; set; }
        public int gradid { get; set; }

    }
}
