using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SeminarskiAvioK.Models
{
    public class ZaposlenikUrediVM
    {

        public int id { get; set; }
        public IFormFile Photo { get; set; }
        [Required(ErrorMessage = "Ime je obavezno polje")]
        [RegularExpression(@"^[a-zA-Z]*$", ErrorMessage = "Ime sadrži samo  slova")]
        public string Ime { get; set; }
        [Required(ErrorMessage = "Prezime je obavezno polje")]
        [RegularExpression(@"^[a-zA-Z]*$", ErrorMessage = "Prezime sadrži samo slova")]
        public string Prezime { get; set; }
        [Required(ErrorMessage = "Broj ugovora je obavezno polje")]
        public string BrojUgovora { get; set; }
        [Required(ErrorMessage = "Email je obavezno polje")]
        [RegularExpression(@"\w+([.']\w+)*@\w+([.]\w+)*\.\w+([.]\w+)*", ErrorMessage = "Email treba biti u formatu ime.prezime@nesto.nesto")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Datum rođenja je obavezno polje")]
        public DateTime DatumRodjenja { get; set; }
        public string adresaaSlike { get; set; }
    }
}
