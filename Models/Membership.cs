using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SportClub.Models
{
    public class Membership
    {
        [Key]
        public int IdMembership { get; set; }

        [Required, MaxLength(45)]
        public string Type { get; set; }

        public int Price { get; set; }

        public TimeSpan Duration { get; set; } // Changed to TimeSpan

        public virtual ICollection<MembershipClubMember> MembershipClubMembers { get; set; } = new List<MembershipClubMember>();
    }
}