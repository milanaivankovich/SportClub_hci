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
        public int IdCompetition { get; set; }  // idTakmicenje

        [Required, MaxLength(45)]
        public string Name { get; set; }  // Naziv

        public DateTime Date { get; set; }  // Datum (DATETIME)

        [MaxLength(45)]
        public string Location { get; set; }  // Lokacija

        // Navigaciona properti za članove (many-to-many)
        public virtual ICollection<ClubMember> ClubMembers { get; set; } = new List<ClubMember>();
    }
}
