using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SportClub.Models
{
    public class ClubMember
    {
        [Key]
        public int IdClubMember { get; set; }

        [Required, MaxLength(45)]
        public string FirstName { get; set; }

        [Required, MaxLength(45)]
        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public bool Active { get; set; }

        // Dodano FullName properti za data binding
        public string FullName => $"{FirstName} {LastName}";

        public virtual ICollection<MembershipClubMember> MembershipClubMembers { get; set; } = new List<MembershipClubMember>();
        public virtual ICollection<Competition> Competitions { get; set; } = new List<Competition>();
        public virtual ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();
    }
}