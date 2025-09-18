using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportClub.Models
{
    public class Training
    {
        [Key]
        public int IdTraining { get; set; }  

        [Required, MaxLength(45)]
        public string Name { get; set; } 

        [MaxLength(45)]
        public string Type { get; set; } 

        public DateTime DateTime { get; set; }  
        public virtual ICollection<Instructor> Instructors { get; set; } = new List<Instructor>();
        public virtual ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();
    }
}
