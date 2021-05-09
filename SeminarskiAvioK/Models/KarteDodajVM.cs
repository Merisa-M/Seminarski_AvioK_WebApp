using Microsoft.AspNetCore.Mvc.Rendering;
using SeminarskiAvio_K.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeminarskiAvioK.Models
{
    public class KarteDodajVM
    {
        public Karta Karta { get; set; }
        public string Kupac { get; set; }
        public int KupacID { get; set; }
        public List<SelectListItem> sjedista { get; set; }
        public decimal Cijena { get; set; }
        public string let { get; set; }
        public int RezervacijeID { get; set; }
        public bool ZauzetoSjediste { get; set; }
    }
}
