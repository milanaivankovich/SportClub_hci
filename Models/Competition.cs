using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportClub.Models
{
    public class Competition
    {
        [Key]
        public int IdCompetition { get; set; } 

        [Required, MaxLength(45)]
        public string Name { get; set; } 

        public DateTime Date { get; set; }  

        [MaxLength(45)]
        public string Location { get; set; }  
        public virtual ICollection<ClubMember> ClubMembers { get; set; } = new List<ClubMember>();
    }
}
