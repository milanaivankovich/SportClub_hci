using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportClub.Models
{
    public class User
    {
        [Key]
        public int IdUser { get; set; }  // idKorisnik

        [Required, MaxLength(45)]
        public string FirstName { get; set; }  // Ime

        [Required, MaxLength(45)]
        public string LastName { get; set; }  // Prezime

        [Required, MaxLength(45)]
        public string Username { get; set; }  // KorisnickoIme

        [Required, MaxLength(45)]  // TODO: Hashuj lozinku u produkciji!
        public string Password { get; set; }
    }
}
