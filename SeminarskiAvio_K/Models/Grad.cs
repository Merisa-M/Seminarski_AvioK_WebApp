using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SeminarskiAvio_K.Models
{
    public class Grad
    {
        [Key]
        public int GradID { get; set; }
        [Required(ErrorMessage = "Grad je obavezno polje")]
        [RegularExpression(@"^[a-zA-Z]*$", ErrorMessage = "Sadrzi samo slova")]
        public String Naziv { get; set; }
    }
}
