using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportClub.Models
{
    
    [Table("Instructors")] 
    public class Instructor : User 
    {
        public virtual ICollection<Training> Trainings { get; set; } = new List<Training>();
    }
}
