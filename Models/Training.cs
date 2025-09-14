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
        public int IdTraining { get; set; }  // idTrening

        [Required, MaxLength(45)]
        public string Name { get; set; }  // Naziv

        [MaxLength(45)]
        public string Type { get; set; }  // Tip

        public DateTime DateTime { get; set; }  // DatumVrijeme

        // Navigacione propertije
        public virtual ICollection<Instructor> Instructors { get; set; } = new List<Instructor>();
        public virtual ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();
    }
}
