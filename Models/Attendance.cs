using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportClub.Models
{
    public class Attendance
    {
        [Key]
        public int IdAttendance { get; set; }  
        public DateTime Date { get; set; }  

        public int IdClubMember { get; set; }
        [ForeignKey("IdClubMember")]
        public virtual ClubMember ClubMember { get; set; }

        public int IdTraining { get; set; }
        [ForeignKey("IdTraining")]
        public virtual Training Training { get; set; }
    }
}
