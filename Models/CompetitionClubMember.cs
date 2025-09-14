using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportClub.Models
{
    public class CompetitionClubMember
    {
        public int IdCompetition { get; set; }
        public Competition Competition { get; set; }

        public int IdClubMember { get; set; }
        public ClubMember ClubMember { get; set; }
    }
}
