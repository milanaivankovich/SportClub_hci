using System;

namespace SportClub.Models
{
    public class MembershipClubMember
    {
        public int IdMembership { get; set; }
        public Membership Membership { get; set; }

        public int IdClubMember { get; set; }
        public ClubMember ClubMember { get; set; }
    }
}