using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeminarskiAvioK.Models
{
    public class AvionUrediVM
    {
        public int id { get; set; }
        public string Naziv { get; set; }
        public int Kapacitet { get; set; }
        public List<SelectListItem> klase { get; set; }
        public int klaseID { get; set; }
    }
}
