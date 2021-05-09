using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SeminarskiAvioK.Models
{
    public class LoginVM
    {
        [StringLength(100, ErrorMessage = "Korisničko ime mora sadržavati mininalno 3 karaktera.", MinimumLength = 3)]
        public string Username { get; set; }
        [StringLength(100, ErrorMessage = "Lozinka mora sadržavati minimalno 4 karaktera.", MinimumLength = 4)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool ZapamtiPassword { get; set; }
    }
}
