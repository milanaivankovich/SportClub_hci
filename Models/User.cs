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
        public int IdUser { get; set; }  

        [Required, MaxLength(45)]
        public string FirstName { get; set; }  

        [Required, MaxLength(45)]
        public string LastName { get; set; }  

        [Required, MaxLength(45)]
        public string Username { get; set; }  

        [Required, MaxLength(45)]  
        public string Password { get; set; }
    }
}
